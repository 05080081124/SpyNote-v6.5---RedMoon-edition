<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Build
    Inherits System.Windows.Forms.Form

    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    Private components As System.ComponentModel.IContainer

    Friend WithEvents ThemeTabControl1 As SpyNote_V6._4.SN.ThemeTabControl

    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents ThemeButton1 As SpyNote_V6._4.SN.ThemeButton
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TextBox4 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox3 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents TextBox6 As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents TextBox5 As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents TextBox7 As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Pi6 As SpyNote_V6._4.SN.PI
    Friend WithEvents TabPage4 As System.Windows.Forms.TabPage
    Friend WithEvents Panel5 As System.Windows.Forms.Panel
    Friend WithEvents LED5 As SpyNote_V6._4.SN.LinearLine
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents LEDDEV As SpyNote_V6._4.SN.ThemeSeparator
    Friend WithEvents Pi4 As SpyNote_V6._4.SN.PI
    Friend WithEvents LED4 As SpyNote_V6._4.SN.LinearLine
    Friend WithEvents LEDACC2 As SpyNote_V6._4.SN.ThemeSeparator
    Friend WithEvents LED1 As SpyNote_V6._4.SN.LinearLine
    Friend WithEvents Pi3 As SpyNote_V6._4.SN.PI
    Friend WithEvents LEDHID As SpyNote_V6._4.SN.ThemeSeparator
    Friend WithEvents Pi1 As SpyNote_V6._4.SN.PI
    Friend WithEvents LEDDROOT As SpyNote_V6._4.SN.ThemeSeparator
    Friend WithEvents Pi5 As SpyNote_V6._4.SN.PI
    Friend WithEvents LEDACC0 As SpyNote_V6._4.SN.ThemeSeparator
    Friend WithEvents LED3 As SpyNote_V6._4.SN.LinearLine
    Friend WithEvents LED2 As SpyNote_V6._4.SN.LinearLine
    Friend WithEvents Pi2 As SpyNote_V6._4.SN.PI
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents LEDACC1 As SpyNote_V6._4.SN.LinearLine
    Friend WithEvents TabPage5 As System.Windows.Forms.TabPage
    Friend WithEvents Panel6 As System.Windows.Forms.Panel
    Friend WithEvents ThemeButton3 As SpyNote_V6._4.SN.ThemeButton
    Friend WithEvents TextBox8 As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents PBil As System.Windows.Forms.PictureBox
    Friend WithEvents ThemeButton2 As SpyNote_V6._4.SN.ThemeButton
    Friend WithEvents Trans As System.Windows.Forms.Timer

    ' ----- НОВЫЕ ЭЛЕМЕНТЫ -----
    Friend WithEvents TabPage6 As System.Windows.Forms.TabPage
    Friend WithEvents Panel7 As System.Windows.Forms.Panel
    Friend WithEvents btnTestNotify As SpyNote_V6._4.SN.ThemeButton
    Friend WithEvents chkEnableNotify As System.Windows.Forms.CheckBox
    Friend WithEvents cbNotifyType As System.Windows.Forms.ComboBox
    Friend WithEvents lblNotifyType As System.Windows.Forms.Label
    Friend WithEvents grpTelegram As System.Windows.Forms.GroupBox
    Friend WithEvents txtTelegramToken As System.Windows.Forms.TextBox
    Friend WithEvents lblTelegramToken As System.Windows.Forms.Label
    Friend WithEvents txtTelegramChatId As System.Windows.Forms.TextBox
    Friend WithEvents lblTelegramChatId As System.Windows.Forms.Label
    Friend WithEvents grpDiscord As System.Windows.Forms.GroupBox
    Friend WithEvents txtDiscordWebhook As System.Windows.Forms.TextBox
    Friend WithEvents lblDiscordWebhook As System.Windows.Forms.Label


    ' ----- PROTECTION TAB ELEMENTS -----
    Friend WithEvents TabPage7 As System.Windows.Forms.TabPage
    Friend WithEvents Panel8 As System.Windows.Forms.Panel
    Friend WithEvents grpProtectionOptions As System.Windows.Forms.GroupBox
    Friend WithEvents chkEnableProtection As System.Windows.Forms.CheckBox
    Friend WithEvents txtPackageName As System.Windows.Forms.TextBox
    Friend WithEvents lblPackageName As System.Windows.Forms.Label
    Friend WithEvents cbMaskType As System.Windows.Forms.ComboBox
    Friend WithEvents lblMaskType As System.Windows.Forms.Label
    Friend WithEvents txtFakeActivity As System.Windows.Forms.TextBox
    Friend WithEvents lblFakeActivity As System.Windows.Forms.Label
    Friend WithEvents chkAntiEmulator As System.Windows.Forms.CheckBox
    Friend WithEvents btnGeneratePackage As SpyNote_V6._4.SN.ThemeButton
    Friend WithEvents chkHideIconAfterSetup As System.Windows.Forms.CheckBox
    Friend WithEvents chkStealthEnabled As System.Windows.Forms.CheckBox
    Friend WithEvents chkObfuscateSmali As System.Windows.Forms.CheckBox
    Friend WithEvents chkEncryptStrings As System.Windows.Forms.CheckBox
    Friend WithEvents chkMaskManifest As System.Windows.Forms.CheckBox
    Friend WithEvents chkDelayedExecution As System.Windows.Forms.CheckBox
    Friend WithEvents lblDelayOptions As System.Windows.Forms.Label
    Friend WithEvents numDelayMinutes As System.Windows.Forms.NumericUpDown

    Friend WithEvents TabPageDropper As System.Windows.Forms.TabPage
    Friend WithEvents PanelDropper As System.Windows.Forms.Panel
    Friend WithEvents grpDropper_Dropper As System.Windows.Forms.GroupBox
    Friend WithEvents chkDropperMode_Dropper As System.Windows.Forms.CheckBox
    Friend WithEvents lblDropperStyle As System.Windows.Forms.Label
    Friend WithEvents cbDropperStyle As System.Windows.Forms.ComboBox
    Friend WithEvents lblDropperTemplate As System.Windows.Forms.Label
    Friend WithEvents txtDropperTemplatePath As System.Windows.Forms.TextBox
    Friend WithEvents btnBrowseDropperTemplate As System.Windows.Forms.Button
    Friend WithEvents lblPayloadUrl As System.Windows.Forms.Label
    Friend WithEvents txtPayloadUrl As System.Windows.Forms.TextBox
    Friend WithEvents chkEmbedPayload As System.Windows.Forms.CheckBox
    Friend WithEvents lblDropperHint As System.Windows.Forms.Label

    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.Trans = New System.Windows.Forms.Timer(Me.components)
        Me.ThemeTabControl1 = New SpyNote_V6._4.SN.ThemeTabControl()
        Me.TabPage6 = New System.Windows.Forms.TabPage()
        Me.Panel7 = New System.Windows.Forms.Panel()
        Me.btnTestNotify = New SpyNote_V6._4.SN.ThemeButton()
        Me.chkEnableNotify = New System.Windows.Forms.CheckBox()
        Me.cbNotifyType = New System.Windows.Forms.ComboBox()
        Me.lblNotifyType = New System.Windows.Forms.Label()
        Me.grpTelegram = New System.Windows.Forms.GroupBox()
        Me.txtTelegramToken = New System.Windows.Forms.TextBox()
        Me.lblTelegramToken = New System.Windows.Forms.Label()
        Me.txtTelegramChatId = New System.Windows.Forms.TextBox()
        Me.lblTelegramChatId = New System.Windows.Forms.Label()
        Me.grpDiscord = New System.Windows.Forms.GroupBox()
        Me.txtDiscordWebhook = New System.Windows.Forms.TextBox()
        Me.lblDiscordWebhook = New System.Windows.Forms.Label()
        Me.TabPage7 = New System.Windows.Forms.TabPage()
        Me.Panel8 = New System.Windows.Forms.Panel()
        Me.grpProtectionOptions = New System.Windows.Forms.GroupBox()
        Me.chkEnableProtection = New System.Windows.Forms.CheckBox()
        Me.lblPackageName = New System.Windows.Forms.Label()
        Me.txtPackageName = New System.Windows.Forms.TextBox()
        Me.btnGeneratePackage = New SpyNote_V6._4.SN.ThemeButton()
        Me.lblMaskType = New System.Windows.Forms.Label()
        Me.cbMaskType = New System.Windows.Forms.ComboBox()
        Me.lblFakeActivity = New System.Windows.Forms.Label()
        Me.txtFakeActivity = New System.Windows.Forms.TextBox()
        Me.chkAntiEmulator = New System.Windows.Forms.CheckBox()
        Me.chkHideIconAfterSetup = New System.Windows.Forms.CheckBox()
        Me.chkStealthEnabled = New System.Windows.Forms.CheckBox()
        Me.chkObfuscateSmali = New System.Windows.Forms.CheckBox()
        Me.chkEncryptStrings = New System.Windows.Forms.CheckBox()
        Me.chkMaskManifest = New System.Windows.Forms.CheckBox()
        Me.chkDelayedExecution = New System.Windows.Forms.CheckBox()
        Me.lblDelayOptions = New System.Windows.Forms.Label()
        Me.numDelayMinutes = New System.Windows.Forms.NumericUpDown()
        Me.TabPageDropper = New System.Windows.Forms.TabPage()
        Me.PanelDropper = New System.Windows.Forms.Panel()
        Me.grpDropper_Dropper = New System.Windows.Forms.GroupBox()
        Me.chkDropperMode_Dropper = New System.Windows.Forms.CheckBox()
        Me.lblDropperStyle = New System.Windows.Forms.Label()
        Me.cbDropperStyle = New System.Windows.Forms.ComboBox()
        Me.lblDropperTemplate = New System.Windows.Forms.Label()
        Me.txtDropperTemplatePath = New System.Windows.Forms.TextBox()
        Me.btnBrowseDropperTemplate = New System.Windows.Forms.Button()
        Me.lblPayloadUrl = New System.Windows.Forms.Label()
        Me.txtPayloadUrl = New System.Windows.Forms.TextBox()
        Me.chkEmbedPayload = New System.Windows.Forms.CheckBox()
        Me.lblDropperHint = New System.Windows.Forms.Label()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.TextBox4 = New System.Windows.Forms.TextBox()
        Me.TextBox3 = New System.Windows.Forms.TextBox()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ThemeButton1 = New SpyNote_V6._4.SN.ThemeButton()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Pi6 = New SpyNote_V6._4.SN.PI()
        Me.TextBox7 = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.TextBox6 = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.TextBox5 = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.TabPage4 = New System.Windows.Forms.TabPage()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.LEDACC1 = New SpyNote_V6._4.SN.LinearLine()
        Me.LEDACC0 = New SpyNote_V6._4.SN.ThemeSeparator()
        Me.LED3 = New SpyNote_V6._4.SN.LinearLine()
        Me.LED2 = New SpyNote_V6._4.SN.LinearLine()
        Me.Pi2 = New SpyNote_V6._4.SN.PI()
        Me.LEDHID = New SpyNote_V6._4.SN.ThemeSeparator()
        Me.Pi1 = New SpyNote_V6._4.SN.PI()
        Me.LEDDROOT = New SpyNote_V6._4.SN.ThemeSeparator()
        Me.Pi5 = New SpyNote_V6._4.SN.PI()
        Me.LEDDEV = New SpyNote_V6._4.SN.ThemeSeparator()
        Me.Pi4 = New SpyNote_V6._4.SN.PI()
        Me.LED4 = New SpyNote_V6._4.SN.LinearLine()
        Me.LEDACC2 = New SpyNote_V6._4.SN.ThemeSeparator()
        Me.LED1 = New SpyNote_V6._4.SN.LinearLine()
        Me.Pi3 = New SpyNote_V6._4.SN.PI()
        Me.LED5 = New SpyNote_V6._4.SN.LinearLine()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.TabPage5 = New System.Windows.Forms.TabPage()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.TextBox8 = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.ThemeButton3 = New SpyNote_V6._4.SN.ThemeButton()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.PBil = New System.Windows.Forms.PictureBox()
        Me.ThemeButton2 = New SpyNote_V6._4.SN.ThemeButton()
        Me.ThemeTabControl1.SuspendLayout()
        Me.TabPage6.SuspendLayout()
        Me.Panel7.SuspendLayout()
        Me.grpTelegram.SuspendLayout()
        Me.grpDiscord.SuspendLayout()
        Me.TabPage7.SuspendLayout()
        Me.Panel8.SuspendLayout()
        Me.grpProtectionOptions.SuspendLayout()
        CType(Me.numDelayMinutes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPageDropper.SuspendLayout()
        Me.PanelDropper.SuspendLayout()
        Me.grpDropper_Dropper.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage2.SuspendLayout()
        Me.Panel3.SuspendLayout()
        CType(Me.Pi6, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage4.SuspendLayout()
        Me.Panel5.SuspendLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Pi2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Pi1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Pi5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Pi4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Pi3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage5.SuspendLayout()
        Me.Panel6.SuspendLayout()
        Me.TabPage3.SuspendLayout()
        Me.Panel4.SuspendLayout()
        CType(Me.PBil, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Trans
        '
        Me.Trans.Interval = 40
        '
        'ThemeTabControl1
        '
        Me.ThemeTabControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ThemeTabControl1.BorderColor_S = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer))
        Me.ThemeTabControl1.Controls.Add(Me.TabPage6)
        Me.ThemeTabControl1.Controls.Add(Me.TabPage7)
        Me.ThemeTabControl1.Controls.Add(Me.TabPageDropper)
        Me.ThemeTabControl1.Controls.Add(Me.TabPage1)
        Me.ThemeTabControl1.Controls.Add(Me.TabPage2)
        Me.ThemeTabControl1.Controls.Add(Me.TabPage4)
        Me.ThemeTabControl1.Controls.Add(Me.TabPage5)
        Me.ThemeTabControl1.Controls.Add(Me.TabPage3)
        Me.ThemeTabControl1.DefaultBackColor_S = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer))
        Me.ThemeTabControl1.DefaultColor0_S = System.Drawing.Color.FromArgb(CType(CType(37, Byte), Integer), CType(CType(37, Byte), Integer), CType(CType(38, Byte), Integer))
        Me.ThemeTabControl1.DefaultColor1_S = System.Drawing.Color.FromArgb(CType(CType(37, Byte), Integer), CType(CType(37, Byte), Integer), CType(CType(38, Byte), Integer))
        Me.ThemeTabControl1.DefaultForColor_S = System.Drawing.Color.FromArgb(CType(CType(190, Byte), Integer), CType(CType(190, Byte), Integer), CType(CType(190, Byte), Integer))
        Me.ThemeTabControl1.FForColorSelcted_S = System.Drawing.Color.FromArgb(CType(CType(241, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.ThemeTabControl1.ItemSize = New System.Drawing.Size(25, 25)
        Me.ThemeTabControl1.Location = New System.Drawing.Point(3, 0)
        Me.ThemeTabControl1.MouseOver0_S = System.Drawing.Color.Maroon
        Me.ThemeTabControl1.MouseOver1_S = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer))
        Me.ThemeTabControl1.Multiline = True
        Me.ThemeTabControl1.Name = "ThemeTabControl1"
        Me.ThemeTabControl1.SelectedIndex = 0
        Me.ThemeTabControl1.Size = New System.Drawing.Size(487, 456)
        Me.ThemeTabControl1.TabIndex = 0
        '
        'TabPage6
        '
        Me.TabPage6.BackColor = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer))
        Me.TabPage6.Controls.Add(Me.Panel7)
        Me.TabPage6.Location = New System.Drawing.Point(4, 54)
        Me.TabPage6.Name = "TabPage6"
        Me.TabPage6.Size = New System.Drawing.Size(479, 398)
        Me.TabPage6.TabIndex = 5
        Me.TabPage6.Text = "Notify"
        '
        'Panel7
        '
        Me.Panel7.Controls.Add(Me.btnTestNotify)
        Me.Panel7.Controls.Add(Me.chkEnableNotify)
        Me.Panel7.Controls.Add(Me.cbNotifyType)
        Me.Panel7.Controls.Add(Me.lblNotifyType)
        Me.Panel7.Controls.Add(Me.grpTelegram)
        Me.Panel7.Controls.Add(Me.grpDiscord)
        Me.Panel7.Location = New System.Drawing.Point(6, 6)
        Me.Panel7.Name = "Panel7"
        Me.Panel7.Size = New System.Drawing.Size(392, 320)
        Me.Panel7.TabIndex = 0
        '
        'btnTestNotify
        '
        Me.btnTestNotify.BackColorDown0_S = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer))
        Me.btnTestNotify.BackColorDown1_S = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer))
        Me.btnTestNotify.BackColorNone0_S = System.Drawing.Color.FromArgb(CType(CType(37, Byte), Integer), CType(CType(37, Byte), Integer), CType(CType(38, Byte), Integer))
        Me.btnTestNotify.BackColorNone1_S = System.Drawing.Color.FromArgb(CType(CType(37, Byte), Integer), CType(CType(37, Byte), Integer), CType(CType(38, Byte), Integer))
        Me.btnTestNotify.BackColorOver0_S = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(48, Byte), Integer))
        Me.btnTestNotify.BackColorOver1_S = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(48, Byte), Integer))
        Me.btnTestNotify.ButtonBackColorEnabled0_S = System.Drawing.Color.FromArgb(CType(CType(53, Byte), Integer), CType(CType(53, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.btnTestNotify.ButtonBackColorEnabled1_S = System.Drawing.Color.FromArgb(CType(CType(53, Byte), Integer), CType(CType(53, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.btnTestNotify.ButtonForColor_S = System.Drawing.Color.FromArgb(CType(CType(174, Byte), Integer), CType(CType(174, Byte), Integer), CType(CType(174, Byte), Integer))
        Me.btnTestNotify.ButtonForColorEnabled_S = System.Drawing.Color.FromArgb(CType(CType(83, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(90, Byte), Integer))
        Me.btnTestNotify.Buttonselected_Color_ForColor_S = System.Drawing.Color.FromArgb(CType(CType(214, Byte), Integer), CType(CType(214, Byte), Integer), CType(CType(214, Byte), Integer))
        Me.btnTestNotify.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!)
        Me.btnTestNotify.ImageAlignment = SpyNote_V6._4.SN.ThemeButton.__ImageAlignment.Left
        Me.btnTestNotify.ImageChoice = Nothing
        Me.btnTestNotify.Location = New System.Drawing.Point(15, 250)
        Me.btnTestNotify.Name = "btnTestNotify"
        Me.btnTestNotify.ShowImage = False
        Me.btnTestNotify.ShowText = True
        Me.btnTestNotify.Size = New System.Drawing.Size(100, 28)
        Me.btnTestNotify.TabIndex = 5
        Me.btnTestNotify.Text = "Test"
        Me.btnTestNotify.TextAlignment = System.Drawing.StringAlignment.Center
        Me.btnTestNotify.ThemeButtonclrBorder_S = System.Drawing.Color.FromArgb(CType(CType(53, Byte), Integer), CType(CType(53, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.btnTestNotify.ThemeButtonclrBorderactive_S = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(146, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnTestNotify.ThemeButtonclrBorderEnabled_S = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(68, Byte), Integer), CType(CType(75, Byte), Integer))
        '
        'chkEnableNotify
        '
        Me.chkEnableNotify.AutoSize = True
        Me.chkEnableNotify.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.chkEnableNotify.ForeColor = System.Drawing.Color.FromArgb(CType(CType(241, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.chkEnableNotify.Location = New System.Drawing.Point(280, 13)
        Me.chkEnableNotify.Name = "chkEnableNotify"
        Me.chkEnableNotify.Size = New System.Drawing.Size(130, 19)
        Me.chkEnableNotify.TabIndex = 2
        Me.chkEnableNotify.Text = "Enable notifications"
        Me.chkEnableNotify.UseVisualStyleBackColor = True
        '
        'cbNotifyType
        '
        Me.cbNotifyType.BackColor = System.Drawing.Color.FromArgb(CType(CType(37, Byte), Integer), CType(CType(37, Byte), Integer), CType(CType(38, Byte), Integer))
        Me.cbNotifyType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbNotifyType.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cbNotifyType.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.cbNotifyType.ForeColor = System.Drawing.Color.FromArgb(CType(CType(241, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.cbNotifyType.Items.AddRange(New Object() {"Telegram", "Discord"})
        Me.cbNotifyType.Location = New System.Drawing.Point(120, 10)
        Me.cbNotifyType.Name = "cbNotifyType"
        Me.cbNotifyType.Size = New System.Drawing.Size(150, 23)
        Me.cbNotifyType.TabIndex = 1
        '
        'lblNotifyType
        '
        Me.lblNotifyType.AutoSize = True
        Me.lblNotifyType.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblNotifyType.ForeColor = System.Drawing.Color.FromArgb(CType(CType(241, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.lblNotifyType.Location = New System.Drawing.Point(15, 13)
        Me.lblNotifyType.Name = "lblNotifyType"
        Me.lblNotifyType.Size = New System.Drawing.Size(99, 15)
        Me.lblNotifyType.TabIndex = 6
        Me.lblNotifyType.Text = "Notification type:"
        '
        'grpTelegram
        '
        Me.grpTelegram.Controls.Add(Me.txtTelegramToken)
        Me.grpTelegram.Controls.Add(Me.lblTelegramToken)
        Me.grpTelegram.Controls.Add(Me.txtTelegramChatId)
        Me.grpTelegram.Controls.Add(Me.lblTelegramChatId)
        Me.grpTelegram.ForeColor = System.Drawing.Color.FromArgb(CType(CType(241, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.grpTelegram.Location = New System.Drawing.Point(15, 50)
        Me.grpTelegram.Name = "grpTelegram"
        Me.grpTelegram.Size = New System.Drawing.Size(360, 100)
        Me.grpTelegram.TabIndex = 3
        Me.grpTelegram.TabStop = False
        Me.grpTelegram.Text = "Telegram Bot settings"
        '
        'txtTelegramToken
        '
        Me.txtTelegramToken.BackColor = System.Drawing.Color.FromArgb(CType(CType(37, Byte), Integer), CType(CType(37, Byte), Integer), CType(CType(38, Byte), Integer))
        Me.txtTelegramToken.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTelegramToken.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtTelegramToken.ForeColor = System.Drawing.Color.FromArgb(CType(CType(241, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.txtTelegramToken.Location = New System.Drawing.Point(80, 25)
        Me.txtTelegramToken.Name = "txtTelegramToken"
        Me.txtTelegramToken.Size = New System.Drawing.Size(260, 23)
        Me.txtTelegramToken.TabIndex = 3
        '
        'lblTelegramToken
        '
        Me.lblTelegramToken.AutoSize = True
        Me.lblTelegramToken.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblTelegramToken.ForeColor = System.Drawing.Color.FromArgb(CType(CType(241, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.lblTelegramToken.Location = New System.Drawing.Point(6, 28)
        Me.lblTelegramToken.Name = "lblTelegramToken"
        Me.lblTelegramToken.Size = New System.Drawing.Size(63, 15)
        Me.lblTelegramToken.TabIndex = 4
        Me.lblTelegramToken.Text = "Bot Token:"
        '
        'txtTelegramChatId
        '
        Me.txtTelegramChatId.BackColor = System.Drawing.Color.FromArgb(CType(CType(37, Byte), Integer), CType(CType(37, Byte), Integer), CType(CType(38, Byte), Integer))
        Me.txtTelegramChatId.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTelegramChatId.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtTelegramChatId.ForeColor = System.Drawing.Color.FromArgb(CType(CType(241, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.txtTelegramChatId.Location = New System.Drawing.Point(80, 60)
        Me.txtTelegramChatId.Name = "txtTelegramChatId"
        Me.txtTelegramChatId.Size = New System.Drawing.Size(260, 23)
        Me.txtTelegramChatId.TabIndex = 5
        '
        'lblTelegramChatId
        '
        Me.lblTelegramChatId.AutoSize = True
        Me.lblTelegramChatId.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblTelegramChatId.ForeColor = System.Drawing.Color.FromArgb(CType(CType(241, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.lblTelegramChatId.Location = New System.Drawing.Point(6, 63)
        Me.lblTelegramChatId.Name = "lblTelegramChatId"
        Me.lblTelegramChatId.Size = New System.Drawing.Size(50, 15)
        Me.lblTelegramChatId.TabIndex = 6
        Me.lblTelegramChatId.Text = "Chat ID:"
        '
        'grpDiscord
        '
        Me.grpDiscord.Controls.Add(Me.txtDiscordWebhook)
        Me.grpDiscord.Controls.Add(Me.lblDiscordWebhook)
        Me.grpDiscord.ForeColor = System.Drawing.Color.FromArgb(CType(CType(241, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.grpDiscord.Location = New System.Drawing.Point(15, 165)
        Me.grpDiscord.Name = "grpDiscord"
        Me.grpDiscord.Size = New System.Drawing.Size(360, 70)
        Me.grpDiscord.TabIndex = 4
        Me.grpDiscord.TabStop = False
        Me.grpDiscord.Text = "Discord Webhook settings"
        '
        'txtDiscordWebhook
        '
        Me.txtDiscordWebhook.BackColor = System.Drawing.Color.FromArgb(CType(CType(37, Byte), Integer), CType(CType(37, Byte), Integer), CType(CType(38, Byte), Integer))
        Me.txtDiscordWebhook.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDiscordWebhook.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtDiscordWebhook.ForeColor = System.Drawing.Color.FromArgb(CType(CType(241, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.txtDiscordWebhook.Location = New System.Drawing.Point(80, 25)
        Me.txtDiscordWebhook.Name = "txtDiscordWebhook"
        Me.txtDiscordWebhook.Size = New System.Drawing.Size(260, 23)
        Me.txtDiscordWebhook.TabIndex = 7
        '
        'lblDiscordWebhook
        '
        Me.lblDiscordWebhook.AutoSize = True
        Me.lblDiscordWebhook.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblDiscordWebhook.ForeColor = System.Drawing.Color.FromArgb(CType(CType(241, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.lblDiscordWebhook.Location = New System.Drawing.Point(6, 28)
        Me.lblDiscordWebhook.Name = "lblDiscordWebhook"
        Me.lblDiscordWebhook.Size = New System.Drawing.Size(62, 15)
        Me.lblDiscordWebhook.TabIndex = 8
        Me.lblDiscordWebhook.Text = "Webhook:"
        '
        'TabPage7
        '
        Me.TabPage7.BackColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(48, Byte), Integer))
        Me.TabPage7.Controls.Add(Me.Panel8)
        Me.TabPage7.Location = New System.Drawing.Point(4, 54)
        Me.TabPage7.Name = "TabPage7"
        Me.TabPage7.Size = New System.Drawing.Size(479, 398)
        Me.TabPage7.TabIndex = 6
        Me.TabPage7.Text = "Protection"
        '
        'Panel8
        '
        Me.Panel8.AutoScroll = True
        Me.Panel8.BackColor = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer))
        Me.Panel8.Controls.Add(Me.grpProtectionOptions)
        Me.Panel8.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel8.Location = New System.Drawing.Point(0, 0)
        Me.Panel8.Name = "Panel8"
        Me.Panel8.Padding = New System.Windows.Forms.Padding(0, 0, 0, 8)
        Me.Panel8.Size = New System.Drawing.Size(479, 398)
        Me.Panel8.TabIndex = 0
        '
        'grpProtectionOptions
        '
        Me.grpProtectionOptions.BackColor = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer))
        Me.grpProtectionOptions.Controls.Add(Me.chkEnableProtection)
        Me.grpProtectionOptions.Controls.Add(Me.lblPackageName)
        Me.grpProtectionOptions.Controls.Add(Me.txtPackageName)
        Me.grpProtectionOptions.Controls.Add(Me.btnGeneratePackage)
        Me.grpProtectionOptions.Controls.Add(Me.lblMaskType)
        Me.grpProtectionOptions.Controls.Add(Me.cbMaskType)
        Me.grpProtectionOptions.Controls.Add(Me.lblFakeActivity)
        Me.grpProtectionOptions.Controls.Add(Me.txtFakeActivity)
        Me.grpProtectionOptions.Controls.Add(Me.chkAntiEmulator)
        Me.grpProtectionOptions.Controls.Add(Me.chkHideIconAfterSetup)
        Me.grpProtectionOptions.Controls.Add(Me.chkStealthEnabled)
        Me.grpProtectionOptions.Controls.Add(Me.chkObfuscateSmali)
        Me.grpProtectionOptions.Controls.Add(Me.chkEncryptStrings)
        Me.grpProtectionOptions.Controls.Add(Me.chkMaskManifest)
        Me.grpProtectionOptions.Controls.Add(Me.chkDelayedExecution)
        Me.grpProtectionOptions.Controls.Add(Me.lblDelayOptions)
        Me.grpProtectionOptions.Controls.Add(Me.numDelayMinutes)
        Me.grpProtectionOptions.ForeColor = System.Drawing.Color.FromArgb(CType(CType(241, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.grpProtectionOptions.Location = New System.Drawing.Point(19, 0)
        Me.grpProtectionOptions.Name = "grpProtectionOptions"
        Me.grpProtectionOptions.Size = New System.Drawing.Size(420, 410)
        Me.grpProtectionOptions.TabIndex = 0
        Me.grpProtectionOptions.TabStop = False
        Me.grpProtectionOptions.Text = "Protection Options"
        '
        'chkEnableProtection
        '
        Me.chkEnableProtection.AutoSize = True
        Me.chkEnableProtection.Location = New System.Drawing.Point(20, 25)
        Me.chkEnableProtection.Name = "chkEnableProtection"
        Me.chkEnableProtection.Size = New System.Drawing.Size(122, 18)
        Me.chkEnableProtection.TabIndex = 1
        Me.chkEnableProtection.Text = "Enable protection"
        Me.chkEnableProtection.UseVisualStyleBackColor = True
        '
        'lblPackageName
        '
        Me.lblPackageName.AutoSize = True
        Me.lblPackageName.Location = New System.Drawing.Point(20, 55)
        Me.lblPackageName.Name = "lblPackageName"
        Me.lblPackageName.Size = New System.Drawing.Size(87, 14)
        Me.lblPackageName.TabIndex = 2
        Me.lblPackageName.Text = "Package name"
        '
        'txtPackageName
        '
        Me.txtPackageName.BackColor = System.Drawing.Color.FromArgb(CType(CType(37, Byte), Integer), CType(CType(37, Byte), Integer), CType(CType(38, Byte), Integer))
        Me.txtPackageName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPackageName.ForeColor = System.Drawing.Color.FromArgb(CType(CType(241, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.txtPackageName.Location = New System.Drawing.Point(20, 73)
        Me.txtPackageName.Name = "txtPackageName"
        Me.txtPackageName.Size = New System.Drawing.Size(220, 20)
        Me.txtPackageName.TabIndex = 3
        '
        'btnGeneratePackage
        '
        Me.btnGeneratePackage.BackColorDown0_S = System.Drawing.Color.FromArgb(CType(CType(210, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(45, Byte), Integer))
        Me.btnGeneratePackage.BackColorDown1_S = System.Drawing.Color.FromArgb(CType(CType(210, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(45, Byte), Integer))
        Me.btnGeneratePackage.BackColorNone0_S = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer))
        Me.btnGeneratePackage.BackColorNone1_S = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer))
        Me.btnGeneratePackage.BackColorOver0_S = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(12, Byte), Integer), CType(CType(18, Byte), Integer))
        Me.btnGeneratePackage.BackColorOver1_S = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(12, Byte), Integer), CType(CType(18, Byte), Integer))
        Me.btnGeneratePackage.ButtonBackColorEnabled0_S = System.Drawing.Color.FromArgb(CType(CType(14, Byte), Integer), CType(CType(14, Byte), Integer), CType(CType(14, Byte), Integer))
        Me.btnGeneratePackage.ButtonBackColorEnabled1_S = System.Drawing.Color.FromArgb(CType(CType(14, Byte), Integer), CType(CType(14, Byte), Integer), CType(CType(14, Byte), Integer))
        Me.btnGeneratePackage.ButtonForColor_S = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(245, Byte), Integer), CType(CType(245, Byte), Integer))
        Me.btnGeneratePackage.ButtonForColorEnabled_S = System.Drawing.Color.FromArgb(CType(CType(120, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(120, Byte), Integer))
        Me.btnGeneratePackage.Buttonselected_Color_ForColor_S = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnGeneratePackage.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!)
        Me.btnGeneratePackage.ImageAlignment = SpyNote_V6._4.SN.ThemeButton.__ImageAlignment.Left
        Me.btnGeneratePackage.ImageChoice = Nothing
        Me.btnGeneratePackage.Location = New System.Drawing.Point(250, 71)
        Me.btnGeneratePackage.Name = "btnGeneratePackage"
        Me.btnGeneratePackage.ShowImage = False
        Me.btnGeneratePackage.ShowText = True
        Me.btnGeneratePackage.Size = New System.Drawing.Size(90, 26)
        Me.btnGeneratePackage.TabIndex = 4
        Me.btnGeneratePackage.Text = "Generate"
        Me.btnGeneratePackage.TextAlignment = System.Drawing.StringAlignment.Center
        Me.btnGeneratePackage.ThemeButtonclrBorder_S = System.Drawing.Color.FromArgb(CType(CType(140, Byte), Integer), CType(CType(20, Byte), Integer), CType(CType(30, Byte), Integer))
        Me.btnGeneratePackage.ThemeButtonclrBorderactive_S = System.Drawing.Color.FromArgb(CType(CType(210, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(45, Byte), Integer))
        Me.btnGeneratePackage.ThemeButtonclrBorderEnabled_S = System.Drawing.Color.FromArgb(CType(CType(80, Byte), Integer), CType(CType(16, Byte), Integer), CType(CType(22, Byte), Integer))
        '
        'lblMaskType
        '
        Me.lblMaskType.AutoSize = True
        Me.lblMaskType.Location = New System.Drawing.Point(20, 105)
        Me.lblMaskType.Name = "lblMaskType"
        Me.lblMaskType.Size = New System.Drawing.Size(53, 14)
        Me.lblMaskType.TabIndex = 5
        Me.lblMaskType.Text = "Mask as"
        '
        'cbMaskType
        '
        Me.cbMaskType.BackColor = System.Drawing.Color.FromArgb(CType(CType(37, Byte), Integer), CType(CType(37, Byte), Integer), CType(CType(38, Byte), Integer))
        Me.cbMaskType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbMaskType.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cbMaskType.ForeColor = System.Drawing.Color.DarkRed
        Me.cbMaskType.Items.AddRange(New Object() {"Google Play", "Chrome", "Settings", "Game"})
        Me.cbMaskType.Location = New System.Drawing.Point(20, 123)
        Me.cbMaskType.Name = "cbMaskType"
        Me.cbMaskType.Size = New System.Drawing.Size(320, 22)
        Me.cbMaskType.TabIndex = 6
        '
        'lblFakeActivity
        '
        Me.lblFakeActivity.AutoSize = True
        Me.lblFakeActivity.Location = New System.Drawing.Point(20, 155)
        Me.lblFakeActivity.Name = "lblFakeActivity"
        Me.lblFakeActivity.Size = New System.Drawing.Size(74, 14)
        Me.lblFakeActivity.TabIndex = 7
        Me.lblFakeActivity.Text = "Fake activity"
        '
        'txtFakeActivity
        '
        Me.txtFakeActivity.BackColor = System.Drawing.Color.FromArgb(CType(CType(37, Byte), Integer), CType(CType(37, Byte), Integer), CType(CType(38, Byte), Integer))
        Me.txtFakeActivity.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtFakeActivity.ForeColor = System.Drawing.Color.FromArgb(CType(CType(241, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.txtFakeActivity.Location = New System.Drawing.Point(20, 173)
        Me.txtFakeActivity.Name = "txtFakeActivity"
        Me.txtFakeActivity.Size = New System.Drawing.Size(320, 20)
        Me.txtFakeActivity.TabIndex = 8
        '
        'chkAntiEmulator
        '
        Me.chkAntiEmulator.AutoSize = True
        Me.chkAntiEmulator.ForeColor = System.Drawing.Color.FromArgb(CType(CType(241, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.chkAntiEmulator.Location = New System.Drawing.Point(20, 198)
        Me.chkAntiEmulator.Name = "chkAntiEmulator"
        Me.chkAntiEmulator.Size = New System.Drawing.Size(145, 18)
        Me.chkAntiEmulator.TabIndex = 9
        Me.chkAntiEmulator.Text = "Anti-emulator checks"
        Me.chkAntiEmulator.UseVisualStyleBackColor = False
        '
        'chkHideIconAfterSetup
        '
        Me.chkHideIconAfterSetup.AutoSize = True
        Me.chkHideIconAfterSetup.ForeColor = System.Drawing.Color.FromArgb(CType(CType(241, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.chkHideIconAfterSetup.Location = New System.Drawing.Point(20, 220)
        Me.chkHideIconAfterSetup.Name = "chkHideIconAfterSetup"
        Me.chkHideIconAfterSetup.Size = New System.Drawing.Size(294, 18)
        Me.chkHideIconAfterSetup.TabIndex = 11
        Me.chkHideIconAfterSetup.Text = "Hide icon after permissions (looks like uninstall)"
        Me.chkHideIconAfterSetup.UseVisualStyleBackColor = False
        '
        'chkStealthEnabled
        '
        Me.chkStealthEnabled.AutoSize = True
        Me.chkStealthEnabled.ForeColor = System.Drawing.Color.FromArgb(CType(CType(241, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.chkStealthEnabled.Location = New System.Drawing.Point(20, 248)
        Me.chkStealthEnabled.Name = "chkStealthEnabled"
        Me.chkStealthEnabled.Size = New System.Drawing.Size(295, 18)
        Me.chkStealthEnabled.TabIndex = 12
        Me.chkStealthEnabled.Text = "Play Protect stealth (obfuscate + encrypt + mask)"
        Me.chkStealthEnabled.UseVisualStyleBackColor = False
        '
        'chkObfuscateSmali
        '
        Me.chkObfuscateSmali.AutoSize = True
        Me.chkObfuscateSmali.ForeColor = System.Drawing.Color.White
        Me.chkObfuscateSmali.Location = New System.Drawing.Point(35, 270)
        Me.chkObfuscateSmali.Name = "chkObfuscateSmali"
        Me.chkObfuscateSmali.Size = New System.Drawing.Size(236, 18)
        Me.chkObfuscateSmali.TabIndex = 13
        Me.chkObfuscateSmali.Text = "Obfuscate smali (org/spynote -> a/b/C)"
        Me.chkObfuscateSmali.UseVisualStyleBackColor = False
        '
        'chkEncryptStrings
        '
        Me.chkEncryptStrings.AutoSize = True
        Me.chkEncryptStrings.ForeColor = System.Drawing.Color.White
        Me.chkEncryptStrings.Location = New System.Drawing.Point(35, 290)
        Me.chkEncryptStrings.Name = "chkEncryptStrings"
        Me.chkEncryptStrings.Size = New System.Drawing.Size(224, 18)
        Me.chkEncryptStrings.TabIndex = 14
        Me.chkEncryptStrings.Text = "Encrypt strings (XOR + dynamic key)"
        Me.chkEncryptStrings.UseVisualStyleBackColor = False
        '
        'chkMaskManifest
        '
        Me.chkMaskManifest.AutoSize = True
        Me.chkMaskManifest.BackColor = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer))
        Me.chkMaskManifest.ForeColor = System.Drawing.Color.White
        Me.chkMaskManifest.Location = New System.Drawing.Point(35, 310)
        Me.chkMaskManifest.Name = "chkMaskManifest"
        Me.chkMaskManifest.Size = New System.Drawing.Size(263, 18)
        Me.chkMaskManifest.TabIndex = 15
        Me.chkMaskManifest.Text = "Mask AndroidManifest (support.v7 aliases)"
        Me.chkMaskManifest.UseVisualStyleBackColor = False
        '
        'chkDelayedExecution
        '
        Me.chkDelayedExecution.AutoSize = True
        Me.chkDelayedExecution.ForeColor = System.Drawing.Color.White
        Me.chkDelayedExecution.Location = New System.Drawing.Point(20, 332)
        Me.chkDelayedExecution.Name = "chkDelayedExecution"
        Me.chkDelayedExecution.Size = New System.Drawing.Size(181, 18)
        Me.chkDelayedExecution.TabIndex = 16
        Me.chkDelayedExecution.Text = "Delayed execution (optional)"
        Me.chkDelayedExecution.UseVisualStyleBackColor = False
        '
        'lblDelayOptions
        '
        Me.lblDelayOptions.AutoSize = True
        Me.lblDelayOptions.ForeColor = System.Drawing.Color.White
        Me.lblDelayOptions.Location = New System.Drawing.Point(35, 354)
        Me.lblDelayOptions.Name = "lblDelayOptions"
        Me.lblDelayOptions.Size = New System.Drawing.Size(204, 14)
        Me.lblDelayOptions.TabIndex = 17
        Me.lblDelayOptions.Text = "Delay min / screen toggles / battery:"
        '
        'numDelayMinutes
        '
        Me.numDelayMinutes.BackColor = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer))
        Me.numDelayMinutes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.numDelayMinutes.ForeColor = System.Drawing.Color.FromArgb(CType(CType(190, Byte), Integer), CType(CType(190, Byte), Integer), CType(CType(190, Byte), Integer))
        Me.numDelayMinutes.Location = New System.Drawing.Point(35, 372)
        Me.numDelayMinutes.Maximum = New Decimal(New Integer() {1440, 0, 0, 0})
        Me.numDelayMinutes.Name = "numDelayMinutes"
        Me.numDelayMinutes.Size = New System.Drawing.Size(60, 20)
        Me.numDelayMinutes.TabIndex = 18
        Me.numDelayMinutes.Value = New Decimal(New Integer() {5, 0, 0, 0})
        '
        'TabPageDropper
        '
        Me.TabPageDropper.BackColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(48, Byte), Integer))
        Me.TabPageDropper.Controls.Add(Me.PanelDropper)
        Me.TabPageDropper.Location = New System.Drawing.Point(4, 54)
        Me.TabPageDropper.Name = "TabPageDropper"
        Me.TabPageDropper.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPageDropper.Size = New System.Drawing.Size(479, 398)
        Me.TabPageDropper.TabIndex = 7
        Me.TabPageDropper.Text = "Dropper"
        '
        'PanelDropper
        '
        Me.PanelDropper.AutoScroll = True
        Me.PanelDropper.BackColor = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer))
        Me.PanelDropper.Controls.Add(Me.grpDropper_Dropper)
        Me.PanelDropper.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelDropper.Location = New System.Drawing.Point(3, 3)
        Me.PanelDropper.Name = "PanelDropper"
        Me.PanelDropper.Size = New System.Drawing.Size(473, 392)
        Me.PanelDropper.TabIndex = 0
        '
        'grpDropper_Dropper
        '
        Me.grpDropper_Dropper.BackColor = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer))
        Me.grpDropper_Dropper.Controls.Add(Me.chkDropperMode_Dropper)
        Me.grpDropper_Dropper.Controls.Add(Me.lblDropperStyle)
        Me.grpDropper_Dropper.Controls.Add(Me.cbDropperStyle)
        Me.grpDropper_Dropper.Controls.Add(Me.lblDropperTemplate)
        Me.grpDropper_Dropper.Controls.Add(Me.txtDropperTemplatePath)
        Me.grpDropper_Dropper.Controls.Add(Me.btnBrowseDropperTemplate)
        Me.grpDropper_Dropper.Controls.Add(Me.lblPayloadUrl)
        Me.grpDropper_Dropper.Controls.Add(Me.txtPayloadUrl)
        Me.grpDropper_Dropper.Controls.Add(Me.chkEmbedPayload)
        Me.grpDropper_Dropper.Controls.Add(Me.lblDropperHint)
        Me.grpDropper_Dropper.ForeColor = System.Drawing.Color.FromArgb(CType(CType(241, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.grpDropper_Dropper.Location = New System.Drawing.Point(10, 10)
        Me.grpDropper_Dropper.Name = "grpDropper_Dropper"
        Me.grpDropper_Dropper.Size = New System.Drawing.Size(440, 330)
        Me.grpDropper_Dropper.TabIndex = 0
        Me.grpDropper_Dropper.TabStop = False
        Me.grpDropper_Dropper.Text = "Play Dropper (2-stage install)"
        '
        'chkDropperMode_Dropper
        '
        Me.chkDropperMode_Dropper.AutoSize = True
        Me.chkDropperMode_Dropper.ForeColor = System.Drawing.Color.FromArgb(CType(CType(241, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.chkDropperMode_Dropper.Location = New System.Drawing.Point(12, 22)
        Me.chkDropperMode_Dropper.Name = "chkDropperMode_Dropper"
        Me.chkDropperMode_Dropper.Size = New System.Drawing.Size(213, 18)
        Me.chkDropperMode_Dropper.TabIndex = 0
        Me.chkDropperMode_Dropper.Text = "Build Play dropper after client APK"
        Me.chkDropperMode_Dropper.UseVisualStyleBackColor = False
        '
        'lblDropperStyle
        '
        Me.lblDropperStyle.AutoSize = True
        Me.lblDropperStyle.Location = New System.Drawing.Point(12, 52)
        Me.lblDropperStyle.Name = "lblDropperStyle"
        Me.lblDropperStyle.Size = New System.Drawing.Size(82, 14)
        Me.lblDropperStyle.TabIndex = 1
        Me.lblDropperStyle.Text = "Dropper skin:"
        '
        'cbDropperStyle
        '
        Me.cbDropperStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer))
        Me.cbDropperStyle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbDropperStyle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(37, Byte), Integer), CType(CType(37, Byte), Integer), CType(CType(38, Byte), Integer))
        Me.cbDropperStyle.FormattingEnabled = True
        Me.cbDropperStyle.Items.AddRange(New Object() {"Google Play", "Chrome", "System Update", "Settings"})
        Me.cbDropperStyle.Location = New System.Drawing.Point(140, 46)
        Me.cbDropperStyle.Name = "cbDropperStyle"
        Me.cbDropperStyle.Size = New System.Drawing.Size(200, 22)
        Me.cbDropperStyle.TabIndex = 2
        '
        'lblDropperTemplate
        '
        Me.lblDropperTemplate.AutoSize = True
        Me.lblDropperTemplate.ForeColor = System.Drawing.Color.FromArgb(CType(CType(190, Byte), Integer), CType(CType(190, Byte), Integer), CType(CType(190, Byte), Integer))
        Me.lblDropperTemplate.Location = New System.Drawing.Point(6, 81)
        Me.lblDropperTemplate.Name = "lblDropperTemplate"
        Me.lblDropperTemplate.Size = New System.Drawing.Size(131, 14)
        Me.lblDropperTemplate.TabIndex = 3
        Me.lblDropperTemplate.Text = "Custom template APK:"
        '
        'txtDropperTemplatePath
        '
        Me.txtDropperTemplatePath.BackColor = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer))
        Me.txtDropperTemplatePath.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDropperTemplatePath.ForeColor = System.Drawing.Color.FromArgb(CType(CType(241, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.txtDropperTemplatePath.Location = New System.Drawing.Point(140, 79)
        Me.txtDropperTemplatePath.Name = "txtDropperTemplatePath"
        Me.txtDropperTemplatePath.Size = New System.Drawing.Size(204, 20)
        Me.txtDropperTemplatePath.TabIndex = 4
        '
        'btnBrowseDropperTemplate
        '
        Me.btnBrowseDropperTemplate.BackColor = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer))
        Me.btnBrowseDropperTemplate.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnBrowseDropperTemplate.ForeColor = System.Drawing.Color.Maroon
        Me.btnBrowseDropperTemplate.Location = New System.Drawing.Point(350, 76)
        Me.btnBrowseDropperTemplate.Name = "btnBrowseDropperTemplate"
        Me.btnBrowseDropperTemplate.Size = New System.Drawing.Size(70, 25)
        Me.btnBrowseDropperTemplate.TabIndex = 5
        Me.btnBrowseDropperTemplate.Text = "Browse"
        Me.btnBrowseDropperTemplate.UseVisualStyleBackColor = False
        '
        'lblPayloadUrl
        '
        Me.lblPayloadUrl.AutoSize = True
        Me.lblPayloadUrl.Location = New System.Drawing.Point(12, 112)
        Me.lblPayloadUrl.Name = "lblPayloadUrl"
        Me.lblPayloadUrl.Size = New System.Drawing.Size(122, 14)
        Me.lblPayloadUrl.TabIndex = 6
        Me.lblPayloadUrl.Text = "Remote payload URL:"
        '
        'txtPayloadUrl
        '
        Me.txtPayloadUrl.BackColor = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer))
        Me.txtPayloadUrl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPayloadUrl.ForeColor = System.Drawing.Color.FromArgb(CType(CType(241, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.txtPayloadUrl.Location = New System.Drawing.Point(140, 110)
        Me.txtPayloadUrl.Name = "txtPayloadUrl"
        Me.txtPayloadUrl.Size = New System.Drawing.Size(273, 20)
        Me.txtPayloadUrl.TabIndex = 7
        '
        'chkEmbedPayload
        '
        Me.chkEmbedPayload.AutoSize = True
        Me.chkEmbedPayload.Checked = True
        Me.chkEmbedPayload.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkEmbedPayload.ForeColor = System.Drawing.Color.FromArgb(CType(CType(241, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.chkEmbedPayload.Location = New System.Drawing.Point(12, 140)
        Me.chkEmbedPayload.Name = "chkEmbedPayload"
        Me.chkEmbedPayload.Size = New System.Drawing.Size(292, 18)
        Me.chkEmbedPayload.TabIndex = 8
        Me.chkEmbedPayload.Text = "Embed client APK inside dropper (works offline)"
        Me.chkEmbedPayload.UseVisualStyleBackColor = False
        '
        'lblDropperHint
        '
        Me.lblDropperHint.ForeColor = System.Drawing.Color.FromArgb(CType(CType(190, Byte), Integer), CType(CType(190, Byte), Integer), CType(CType(190, Byte), Integer))
        Me.lblDropperHint.Location = New System.Drawing.Point(12, 168)
        Me.lblDropperHint.Name = "lblDropperHint"
        Me.lblDropperHint.Size = New System.Drawing.Size(410, 36)
        Me.lblDropperHint.TabIndex = 9
        Me.lblDropperHint.Text = "Built-in Google Play shell used when template is empty. Output: Resources\Dropper" &
    "" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Dropper_final.apk"
        '
        'TabPage1
        '
        Me.TabPage1.BackColor = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer))
        Me.TabPage1.Controls.Add(Me.Panel2)
        Me.TabPage1.Controls.Add(Me.Panel1)
        Me.TabPage1.Location = New System.Drawing.Point(4, 54)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(479, 398)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "App Info"
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.TextBox4)
        Me.Panel2.Controls.Add(Me.TextBox3)
        Me.Panel2.Controls.Add(Me.TextBox2)
        Me.Panel2.Controls.Add(Me.TextBox1)
        Me.Panel2.Controls.Add(Me.Label5)
        Me.Panel2.Controls.Add(Me.Label4)
        Me.Panel2.Controls.Add(Me.Label3)
        Me.Panel2.Controls.Add(Me.Label2)
        Me.Panel2.Location = New System.Drawing.Point(6, 112)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(392, 210)
        Me.Panel2.TabIndex = 1
        '
        'TextBox4
        '
        Me.TextBox4.BackColor = System.Drawing.Color.FromArgb(CType(CType(37, Byte), Integer), CType(CType(37, Byte), Integer), CType(CType(38, Byte), Integer))
        Me.TextBox4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextBox4.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(241, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.TextBox4.Location = New System.Drawing.Point(7, 166)
        Me.TextBox4.Name = "TextBox4"
        Me.TextBox4.Size = New System.Drawing.Size(370, 23)
        Me.TextBox4.TabIndex = 7
        '
        'TextBox3
        '
        Me.TextBox3.BackColor = System.Drawing.Color.FromArgb(CType(CType(37, Byte), Integer), CType(CType(37, Byte), Integer), CType(CType(38, Byte), Integer))
        Me.TextBox3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextBox3.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(241, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.TextBox3.Location = New System.Drawing.Point(7, 120)
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.Size = New System.Drawing.Size(370, 23)
        Me.TextBox3.TabIndex = 6
        '
        'TextBox2
        '
        Me.TextBox2.BackColor = System.Drawing.Color.FromArgb(CType(CType(37, Byte), Integer), CType(CType(37, Byte), Integer), CType(CType(38, Byte), Integer))
        Me.TextBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextBox2.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(241, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.TextBox2.Location = New System.Drawing.Point(7, 75)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(370, 23)
        Me.TextBox2.TabIndex = 5
        '
        'TextBox1
        '
        Me.TextBox1.BackColor = System.Drawing.Color.FromArgb(CType(CType(37, Byte), Integer), CType(CType(37, Byte), Integer), CType(CType(38, Byte), Integer))
        Me.TextBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextBox1.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(241, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.TextBox1.Location = New System.Drawing.Point(7, 29)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(370, 23)
        Me.TextBox1.TabIndex = 4
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(241, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.Label5.Location = New System.Drawing.Point(8, 148)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(46, 15)
        Me.Label5.TabIndex = 3
        Me.Label5.Text = "Version"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(241, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.Label4.Location = New System.Drawing.Point(6, 102)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(80, 15)
        Me.Label4.TabIndex = 2
        Me.Label4.Text = "Service Name"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(241, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.Label3.Location = New System.Drawing.Point(6, 56)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(64, 15)
        Me.Label3.TabIndex = 1
        Me.Label3.Text = "App Name"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(241, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(6, 10)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(77, 15)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Victim Name"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.PictureBox1)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.ThemeButton1)
        Me.Panel1.Location = New System.Drawing.Point(6, 6)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(392, 92)
        Me.Panel1.TabIndex = 0
        '
        'PictureBox1
        '
        Me.PictureBox1.Dock = System.Windows.Forms.DockStyle.Right
        Me.PictureBox1.ErrorImage = Nothing
        Me.PictureBox1.InitialImage = Nothing
        Me.PictureBox1.Location = New System.Drawing.Point(300, 0)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(92, 92)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox1.TabIndex = 2
        Me.PictureBox1.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 61)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(13, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = ".."
        '
        'ThemeButton1
        '
        Me.ThemeButton1.BackColorDown0_S = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer))
        Me.ThemeButton1.BackColorDown1_S = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer))
        Me.ThemeButton1.BackColorNone0_S = System.Drawing.Color.FromArgb(CType(CType(37, Byte), Integer), CType(CType(37, Byte), Integer), CType(CType(38, Byte), Integer))
        Me.ThemeButton1.BackColorNone1_S = System.Drawing.Color.FromArgb(CType(CType(37, Byte), Integer), CType(CType(37, Byte), Integer), CType(CType(38, Byte), Integer))
        Me.ThemeButton1.BackColorOver0_S = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(48, Byte), Integer))
        Me.ThemeButton1.BackColorOver1_S = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(48, Byte), Integer))
        Me.ThemeButton1.ButtonBackColorEnabled0_S = System.Drawing.Color.FromArgb(CType(CType(53, Byte), Integer), CType(CType(53, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.ThemeButton1.ButtonBackColorEnabled1_S = System.Drawing.Color.FromArgb(CType(CType(53, Byte), Integer), CType(CType(53, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.ThemeButton1.ButtonForColor_S = System.Drawing.Color.FromArgb(CType(CType(174, Byte), Integer), CType(CType(174, Byte), Integer), CType(CType(174, Byte), Integer))
        Me.ThemeButton1.ButtonForColorEnabled_S = System.Drawing.Color.FromArgb(CType(CType(83, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(90, Byte), Integer))
        Me.ThemeButton1.Buttonselected_Color_ForColor_S = System.Drawing.Color.FromArgb(CType(CType(214, Byte), Integer), CType(CType(214, Byte), Integer), CType(CType(214, Byte), Integer))
        Me.ThemeButton1.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!)
        Me.ThemeButton1.ImageAlignment = SpyNote_V6._4.SN.ThemeButton.__ImageAlignment.Left
        Me.ThemeButton1.ImageChoice = Nothing
        Me.ThemeButton1.Location = New System.Drawing.Point(7, 18)
        Me.ThemeButton1.Name = "ThemeButton1"
        Me.ThemeButton1.ShowImage = False
        Me.ThemeButton1.ShowText = True
        Me.ThemeButton1.Size = New System.Drawing.Size(101, 28)
        Me.ThemeButton1.TabIndex = 0
        Me.ThemeButton1.Tag = "0"
        Me.ThemeButton1.Text = "Select icon"
        Me.ThemeButton1.TextAlignment = System.Drawing.StringAlignment.Center
        Me.ThemeButton1.ThemeButtonclrBorder_S = System.Drawing.Color.FromArgb(CType(CType(53, Byte), Integer), CType(CType(53, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.ThemeButton1.ThemeButtonclrBorderactive_S = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(56, Byte), Integer), CType(CType(63, Byte), Integer))
        Me.ThemeButton1.ThemeButtonclrBorderEnabled_S = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(68, Byte), Integer), CType(CType(75, Byte), Integer))
        '
        'TabPage2
        '
        Me.TabPage2.BackColor = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer))
        Me.TabPage2.Controls.Add(Me.Panel3)
        Me.TabPage2.Location = New System.Drawing.Point(4, 54)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(479, 398)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "DNS Info"
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.Pi6)
        Me.Panel3.Controls.Add(Me.TextBox7)
        Me.Panel3.Controls.Add(Me.Label8)
        Me.Panel3.Controls.Add(Me.TextBox6)
        Me.Panel3.Controls.Add(Me.Label7)
        Me.Panel3.Controls.Add(Me.TextBox5)
        Me.Panel3.Controls.Add(Me.Label6)
        Me.Panel3.Location = New System.Drawing.Point(6, 17)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(392, 209)
        Me.Panel3.TabIndex = 0
        '
        'Pi6
        '
        Me.Pi6._CLRChecked = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(145, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Pi6._CLRCnone = System.Drawing.Color.DimGray
        Me.Pi6._CLRs7e = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.Pi6.BackColor = System.Drawing.Color.Transparent
        Me.Pi6.BACKCOLORR = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(48, Byte), Integer))
        Me.Pi6.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
        Me.Pi6.Location = New System.Drawing.Point(341, 122)
        Me.Pi6.Name = "Pi6"
        Me.Pi6.Size = New System.Drawing.Size(30, 29)
        Me.Pi6.TabIndex = 10
        Me.Pi6.TabStop = False
        '
        'TextBox7
        '
        Me.TextBox7.BackColor = System.Drawing.Color.FromArgb(CType(CType(37, Byte), Integer), CType(CType(37, Byte), Integer), CType(CType(38, Byte), Integer))
        Me.TextBox7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextBox7.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox7.ForeColor = System.Drawing.Color.FromArgb(CType(CType(241, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.TextBox7.Location = New System.Drawing.Point(15, 125)
        Me.TextBox7.Name = "TextBox7"
        Me.TextBox7.Size = New System.Drawing.Size(323, 23)
        Me.TextBox7.TabIndex = 9
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.FromArgb(CType(CType(241, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.Label8.Location = New System.Drawing.Point(12, 106)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(30, 15)
        Me.Label8.TabIndex = 8
        Me.Label8.Text = "Pass"
        '
        'TextBox6
        '
        Me.TextBox6.BackColor = System.Drawing.Color.FromArgb(CType(CType(37, Byte), Integer), CType(CType(37, Byte), Integer), CType(CType(38, Byte), Integer))
        Me.TextBox6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextBox6.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox6.ForeColor = System.Drawing.Color.FromArgb(CType(CType(241, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.TextBox6.Location = New System.Drawing.Point(15, 79)
        Me.TextBox6.Name = "TextBox6"
        Me.TextBox6.Size = New System.Drawing.Size(360, 23)
        Me.TextBox6.TabIndex = 7
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.FromArgb(CType(CType(241, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.Label7.Location = New System.Drawing.Point(12, 60)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(29, 15)
        Me.Label7.TabIndex = 6
        Me.Label7.Text = "Port"
        '
        'TextBox5
        '
        Me.TextBox5.BackColor = System.Drawing.Color.FromArgb(CType(CType(37, Byte), Integer), CType(CType(37, Byte), Integer), CType(CType(38, Byte), Integer))
        Me.TextBox5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextBox5.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(241, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.TextBox5.Location = New System.Drawing.Point(15, 32)
        Me.TextBox5.Name = "TextBox5"
        Me.TextBox5.Size = New System.Drawing.Size(360, 23)
        Me.TextBox5.TabIndex = 5
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.FromArgb(CType(CType(241, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.Label6.Location = New System.Drawing.Point(15, 13)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(18, 15)
        Me.Label6.TabIndex = 1
        Me.Label6.Text = "IP"
        '
        'TabPage4
        '
        Me.TabPage4.BackColor = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer))
        Me.TabPage4.Controls.Add(Me.Panel5)
        Me.TabPage4.Location = New System.Drawing.Point(4, 54)
        Me.TabPage4.Name = "TabPage4"
        Me.TabPage4.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage4.Size = New System.Drawing.Size(479, 398)
        Me.TabPage4.TabIndex = 2
        Me.TabPage4.Text = "Properties"
        '
        'Panel5
        '
        Me.Panel5.Controls.Add(Me.PictureBox2)
        Me.Panel5.Controls.Add(Me.LEDACC1)
        Me.Panel5.Controls.Add(Me.LEDACC0)
        Me.Panel5.Controls.Add(Me.LED3)
        Me.Panel5.Controls.Add(Me.LED2)
        Me.Panel5.Controls.Add(Me.Pi2)
        Me.Panel5.Controls.Add(Me.LEDHID)
        Me.Panel5.Controls.Add(Me.Pi1)
        Me.Panel5.Controls.Add(Me.LEDDROOT)
        Me.Panel5.Controls.Add(Me.Pi5)
        Me.Panel5.Controls.Add(Me.LEDDEV)
        Me.Panel5.Controls.Add(Me.Pi4)
        Me.Panel5.Controls.Add(Me.LED4)
        Me.Panel5.Controls.Add(Me.LEDACC2)
        Me.Panel5.Controls.Add(Me.LED1)
        Me.Panel5.Controls.Add(Me.Pi3)
        Me.Panel5.Controls.Add(Me.LED5)
        Me.Panel5.Controls.Add(Me.Label12)
        Me.Panel5.Controls.Add(Me.Label11)
        Me.Panel5.Controls.Add(Me.Label10)
        Me.Panel5.Controls.Add(Me.Label9)
        Me.Panel5.Controls.Add(Me.Label13)
        Me.Panel5.Location = New System.Drawing.Point(6, 14)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(293, 317)
        Me.Panel5.TabIndex = 0
        '
        'PictureBox2
        '
        Me.PictureBox2.Location = New System.Drawing.Point(1, 5)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(18, 18)
        Me.PictureBox2.TabIndex = 30
        Me.PictureBox2.TabStop = False
        '
        'LEDACC1
        '
        Me.LEDACC1.BackColor = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer))
        Me.LEDACC1.Colour0 = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LEDACC1.Colour1 = System.Drawing.Color.Black
        Me.LEDACC1.Location = New System.Drawing.Point(127, 98)
        Me.LEDACC1.Name = "LEDACC1"
        Me.LEDACC1.Size = New System.Drawing.Size(10, 35)
        Me.LEDACC1.TabIndex = 29
        Me.LEDACC1.Text = "LinearLine2"
        '
        'LEDACC0
        '
        Me.LEDACC0.Colour0 = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LEDACC0.Colour1 = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LEDACC0.Location = New System.Drawing.Point(11, 91)
        Me.LEDACC0.Name = "LEDACC0"
        Me.LEDACC0.Size = New System.Drawing.Size(165, 10)
        Me.LEDACC0.TabIndex = 28
        Me.LEDACC0.Text = "ThemeSeparator1"
        '
        'LED3
        '
        Me.LED3.Colour0 = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LED3.Colour1 = System.Drawing.Color.Black
        Me.LED3.Location = New System.Drawing.Point(9, 98)
        Me.LED3.Name = "LED3"
        Me.LED3.Size = New System.Drawing.Size(10, 40)
        Me.LED3.TabIndex = 27
        Me.LED3.Text = "LinearLine2"
        '
        'LED2
        '
        Me.LED2.Colour0 = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LED2.Colour1 = System.Drawing.Color.Black
        Me.LED2.Location = New System.Drawing.Point(9, 52)
        Me.LED2.Name = "LED2"
        Me.LED2.Size = New System.Drawing.Size(10, 49)
        Me.LED2.TabIndex = 26
        Me.LED2.Text = "LinearLine2"
        '
        'Pi2
        '
        Me.Pi2._CLRChecked = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(145, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Pi2._CLRCnone = System.Drawing.Color.DimGray
        Me.Pi2._CLRs7e = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.Pi2.BackColor = System.Drawing.Color.Transparent
        Me.Pi2.BACKCOLORR = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(48, Byte), Integer))
        Me.Pi2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
        Me.Pi2.Location = New System.Drawing.Point(172, 83)
        Me.Pi2.Name = "Pi2"
        Me.Pi2.Size = New System.Drawing.Size(30, 29)
        Me.Pi2.TabIndex = 25
        Me.Pi2.TabStop = False
        '
        'LEDHID
        '
        Me.LEDHID.Colour0 = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LEDHID.Colour1 = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LEDHID.Location = New System.Drawing.Point(11, 45)
        Me.LEDHID.Name = "LEDHID"
        Me.LEDHID.Size = New System.Drawing.Size(118, 10)
        Me.LEDHID.TabIndex = 24
        Me.LEDHID.Text = "ThemeSeparator1"
        '
        'Pi1
        '
        Me.Pi1._CLRChecked = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(145, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Pi1._CLRCnone = System.Drawing.Color.DimGray
        Me.Pi1._CLRs7e = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.Pi1.BackColor = System.Drawing.Color.Transparent
        Me.Pi1.BACKCOLORR = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(48, Byte), Integer))
        Me.Pi1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
        Me.Pi1.Location = New System.Drawing.Point(125, 37)
        Me.Pi1.Name = "Pi1"
        Me.Pi1.Size = New System.Drawing.Size(30, 29)
        Me.Pi1.TabIndex = 23
        Me.Pi1.TabStop = False
        '
        'LEDDROOT
        '
        Me.LEDDROOT.Colour0 = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LEDDROOT.Colour1 = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LEDDROOT.Location = New System.Drawing.Point(11, 204)
        Me.LEDDROOT.Name = "LEDDROOT"
        Me.LEDDROOT.Size = New System.Drawing.Size(161, 10)
        Me.LEDDROOT.TabIndex = 22
        Me.LEDDROOT.Text = "ThemeSeparator1"
        '
        'Pi5
        '
        Me.Pi5._CLRChecked = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(145, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Pi5._CLRCnone = System.Drawing.Color.DimGray
        Me.Pi5._CLRs7e = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.Pi5.BackColor = System.Drawing.Color.Transparent
        Me.Pi5.BACKCOLORR = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(48, Byte), Integer))
        Me.Pi5.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
        Me.Pi5.Location = New System.Drawing.Point(168, 196)
        Me.Pi5.Name = "Pi5"
        Me.Pi5.Size = New System.Drawing.Size(30, 29)
        Me.Pi5.TabIndex = 21
        Me.Pi5.TabStop = False
        '
        'LEDDEV
        '
        Me.LEDDEV.Colour0 = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LEDDEV.Colour1 = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LEDDEV.Location = New System.Drawing.Point(11, 160)
        Me.LEDDEV.Name = "LEDDEV"
        Me.LEDDEV.Size = New System.Drawing.Size(147, 10)
        Me.LEDDEV.TabIndex = 20
        Me.LEDDEV.Text = "ThemeSeparator1"
        '
        'Pi4
        '
        Me.Pi4._CLRChecked = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(145, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Pi4._CLRCnone = System.Drawing.Color.DimGray
        Me.Pi4._CLRs7e = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.Pi4.BackColor = System.Drawing.Color.Transparent
        Me.Pi4.BACKCOLORR = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(48, Byte), Integer))
        Me.Pi4.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
        Me.Pi4.Location = New System.Drawing.Point(154, 152)
        Me.Pi4.Name = "Pi4"
        Me.Pi4.Size = New System.Drawing.Size(30, 29)
        Me.Pi4.TabIndex = 19
        Me.Pi4.TabStop = False
        '
        'LED4
        '
        Me.LED4.Colour0 = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LED4.Colour1 = System.Drawing.Color.Black
        Me.LED4.Location = New System.Drawing.Point(9, 128)
        Me.LED4.Name = "LED4"
        Me.LED4.Size = New System.Drawing.Size(10, 39)
        Me.LED4.TabIndex = 18
        Me.LED4.Text = "LinearLine2"
        '
        'LEDACC2
        '
        Me.LEDACC2.BackColor = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer))
        Me.LEDACC2.Colour0 = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LEDACC2.Colour1 = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LEDACC2.Location = New System.Drawing.Point(127, 128)
        Me.LEDACC2.Name = "LEDACC2"
        Me.LEDACC2.Size = New System.Drawing.Size(121, 10)
        Me.LEDACC2.TabIndex = 17
        Me.LEDACC2.Text = "ThemeSeparator1"
        '
        'LED1
        '
        Me.LED1.Colour0 = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LED1.Colour1 = System.Drawing.Color.Black
        Me.LED1.Location = New System.Drawing.Point(9, 30)
        Me.LED1.Name = "LED1"
        Me.LED1.Size = New System.Drawing.Size(10, 25)
        Me.LED1.TabIndex = 16
        Me.LED1.Text = "LinearLine2"
        '
        'Pi3
        '
        Me.Pi3._CLRChecked = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(145, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Pi3._CLRCnone = System.Drawing.Color.DimGray
        Me.Pi3._CLRs7e = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.Pi3.BackColor = System.Drawing.Color.Transparent
        Me.Pi3.BACKCOLORR = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(48, Byte), Integer))
        Me.Pi3.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
        Me.Pi3.Location = New System.Drawing.Point(244, 120)
        Me.Pi3.Name = "Pi3"
        Me.Pi3.Size = New System.Drawing.Size(30, 29)
        Me.Pi3.TabIndex = 15
        Me.Pi3.TabStop = False
        '
        'LED5
        '
        Me.LED5.Colour0 = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LED5.Colour1 = System.Drawing.Color.Black
        Me.LED5.Location = New System.Drawing.Point(9, 167)
        Me.LED5.Name = "LED5"
        Me.LED5.Size = New System.Drawing.Size(10, 44)
        Me.LED5.TabIndex = 14
        Me.LED5.Text = "LinearLine2"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.FromArgb(CType(CType(241, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.Label12.Location = New System.Drawing.Point(15, 76)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(133, 15)
        Me.Label12.TabIndex = 12
        Me.Label12.Text = "Accessibility(Keylogger)"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.FromArgb(CType(CType(241, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.Label11.Location = New System.Drawing.Point(15, 190)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(142, 15)
        Me.Label11.TabIndex = 12
        Me.Label11.Text = "Permission Root SuperSU"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.FromArgb(CType(CType(241, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.Label10.Location = New System.Drawing.Point(23, 30)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(96, 15)
        Me.Label10.TabIndex = 11
        Me.Label10.Text = "Hide Application"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.FromArgb(CType(CType(241, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.Label9.Location = New System.Drawing.Point(144, 114)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(94, 15)
        Me.Label9.TabIndex = 10
        Me.Label9.Text = "Deactivate icons"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.FromArgb(CType(CType(241, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.Label13.Location = New System.Drawing.Point(16, 146)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(125, 15)
        Me.Label13.TabIndex = 9
        Me.Label13.Text = "Device Administration"
        '
        'TabPage5
        '
        Me.TabPage5.BackColor = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer))
        Me.TabPage5.Controls.Add(Me.Panel6)
        Me.TabPage5.Location = New System.Drawing.Point(4, 54)
        Me.TabPage5.Name = "TabPage5"
        Me.TabPage5.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage5.Size = New System.Drawing.Size(479, 398)
        Me.TabPage5.TabIndex = 3
        Me.TabPage5.Text = "Merging App"
        '
        'Panel6
        '
        Me.Panel6.Controls.Add(Me.TextBox8)
        Me.Panel6.Controls.Add(Me.Label15)
        Me.Panel6.Controls.Add(Me.Label14)
        Me.Panel6.Controls.Add(Me.ThemeButton3)
        Me.Panel6.Location = New System.Drawing.Point(6, 27)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(392, 132)
        Me.Panel6.TabIndex = 0
        '
        'TextBox8
        '
        Me.TextBox8.BackColor = System.Drawing.Color.FromArgb(CType(CType(37, Byte), Integer), CType(CType(37, Byte), Integer), CType(CType(38, Byte), Integer))
        Me.TextBox8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextBox8.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox8.ForeColor = System.Drawing.Color.FromArgb(CType(CType(241, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.TextBox8.Location = New System.Drawing.Point(13, 97)
        Me.TextBox8.Name = "TextBox8"
        Me.TextBox8.Size = New System.Drawing.Size(347, 23)
        Me.TextBox8.TabIndex = 13
        Me.TextBox8.Text = "com.packagename.example"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.ForeColor = System.Drawing.Color.FromArgb(CType(CType(241, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.Label15.Location = New System.Drawing.Point(11, 78)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(86, 15)
        Me.Label15.TabIndex = 12
        Me.Label15.Text = "Package Name"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(116, 14)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(13, 13)
        Me.Label14.TabIndex = 2
        Me.Label14.Text = ".."
        '
        'ThemeButton3
        '
        Me.ThemeButton3.BackColorDown0_S = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer))
        Me.ThemeButton3.BackColorDown1_S = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer))
        Me.ThemeButton3.BackColorNone0_S = System.Drawing.Color.FromArgb(CType(CType(37, Byte), Integer), CType(CType(37, Byte), Integer), CType(CType(38, Byte), Integer))
        Me.ThemeButton3.BackColorNone1_S = System.Drawing.Color.FromArgb(CType(CType(37, Byte), Integer), CType(CType(37, Byte), Integer), CType(CType(38, Byte), Integer))
        Me.ThemeButton3.BackColorOver0_S = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(48, Byte), Integer))
        Me.ThemeButton3.BackColorOver1_S = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(48, Byte), Integer))
        Me.ThemeButton3.ButtonBackColorEnabled0_S = System.Drawing.Color.FromArgb(CType(CType(53, Byte), Integer), CType(CType(53, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.ThemeButton3.ButtonBackColorEnabled1_S = System.Drawing.Color.FromArgb(CType(CType(53, Byte), Integer), CType(CType(53, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.ThemeButton3.ButtonForColor_S = System.Drawing.Color.FromArgb(CType(CType(174, Byte), Integer), CType(CType(174, Byte), Integer), CType(CType(174, Byte), Integer))
        Me.ThemeButton3.ButtonForColorEnabled_S = System.Drawing.Color.FromArgb(CType(CType(83, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(90, Byte), Integer))
        Me.ThemeButton3.Buttonselected_Color_ForColor_S = System.Drawing.Color.FromArgb(CType(CType(214, Byte), Integer), CType(CType(214, Byte), Integer), CType(CType(214, Byte), Integer))
        Me.ThemeButton3.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!)
        Me.ThemeButton3.ImageAlignment = SpyNote_V6._4.SN.ThemeButton.__ImageAlignment.Left
        Me.ThemeButton3.ImageChoice = Nothing
        Me.ThemeButton3.Location = New System.Drawing.Point(10, 6)
        Me.ThemeButton3.Name = "ThemeButton3"
        Me.ThemeButton3.ShowImage = False
        Me.ThemeButton3.ShowText = True
        Me.ThemeButton3.Size = New System.Drawing.Size(100, 28)
        Me.ThemeButton3.TabIndex = 1
        Me.ThemeButton3.Tag = "0"
        Me.ThemeButton3.Text = "Select File"
        Me.ThemeButton3.TextAlignment = System.Drawing.StringAlignment.Center
        Me.ThemeButton3.ThemeButtonclrBorder_S = System.Drawing.Color.FromArgb(CType(CType(53, Byte), Integer), CType(CType(53, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.ThemeButton3.ThemeButtonclrBorderactive_S = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(146, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ThemeButton3.ThemeButtonclrBorderEnabled_S = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(68, Byte), Integer), CType(CType(75, Byte), Integer))
        '
        'TabPage3
        '
        Me.TabPage3.BackColor = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer))
        Me.TabPage3.Controls.Add(Me.Panel4)
        Me.TabPage3.Location = New System.Drawing.Point(4, 54)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage3.Size = New System.Drawing.Size(479, 398)
        Me.TabPage3.TabIndex = 4
        Me.TabPage3.Text = "Build"
        '
        'Panel4
        '
        Me.Panel4.Controls.Add(Me.PBil)
        Me.Panel4.Controls.Add(Me.ThemeButton2)
        Me.Panel4.Location = New System.Drawing.Point(43, 6)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(392, 341)
        Me.Panel4.TabIndex = 0
        '
        'PBil
        '
        Me.PBil.Location = New System.Drawing.Point(20, 4)
        Me.PBil.Name = "PBil"
        Me.PBil.Size = New System.Drawing.Size(349, 291)
        Me.PBil.TabIndex = 3
        Me.PBil.TabStop = False
        '
        'ThemeButton2
        '
        Me.ThemeButton2.BackColorDown0_S = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer))
        Me.ThemeButton2.BackColorDown1_S = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer))
        Me.ThemeButton2.BackColorNone0_S = System.Drawing.Color.FromArgb(CType(CType(37, Byte), Integer), CType(CType(37, Byte), Integer), CType(CType(38, Byte), Integer))
        Me.ThemeButton2.BackColorNone1_S = System.Drawing.Color.FromArgb(CType(CType(37, Byte), Integer), CType(CType(37, Byte), Integer), CType(CType(38, Byte), Integer))
        Me.ThemeButton2.BackColorOver0_S = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(48, Byte), Integer))
        Me.ThemeButton2.BackColorOver1_S = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(48, Byte), Integer))
        Me.ThemeButton2.ButtonBackColorEnabled0_S = System.Drawing.Color.FromArgb(CType(CType(53, Byte), Integer), CType(CType(53, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.ThemeButton2.ButtonBackColorEnabled1_S = System.Drawing.Color.FromArgb(CType(CType(53, Byte), Integer), CType(CType(53, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.ThemeButton2.ButtonForColor_S = System.Drawing.Color.FromArgb(CType(CType(174, Byte), Integer), CType(CType(174, Byte), Integer), CType(CType(174, Byte), Integer))
        Me.ThemeButton2.ButtonForColorEnabled_S = System.Drawing.Color.FromArgb(CType(CType(83, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(90, Byte), Integer))
        Me.ThemeButton2.Buttonselected_Color_ForColor_S = System.Drawing.Color.FromArgb(CType(CType(214, Byte), Integer), CType(CType(214, Byte), Integer), CType(CType(214, Byte), Integer))
        Me.ThemeButton2.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!)
        Me.ThemeButton2.ImageAlignment = SpyNote_V6._4.SN.ThemeButton.__ImageAlignment.Left
        Me.ThemeButton2.ImageChoice = Nothing
        Me.ThemeButton2.Location = New System.Drawing.Point(106, 301)
        Me.ThemeButton2.Name = "ThemeButton2"
        Me.ThemeButton2.ShowImage = False
        Me.ThemeButton2.ShowText = True
        Me.ThemeButton2.Size = New System.Drawing.Size(183, 28)
        Me.ThemeButton2.TabIndex = 2
        Me.ThemeButton2.Tag = ""
        Me.ThemeButton2.Text = "Build"
        Me.ThemeButton2.TextAlignment = System.Drawing.StringAlignment.Center
        Me.ThemeButton2.ThemeButtonclrBorder_S = System.Drawing.Color.FromArgb(CType(CType(53, Byte), Integer), CType(CType(53, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.ThemeButton2.ThemeButtonclrBorderactive_S = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(146, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ThemeButton2.ThemeButtonclrBorderEnabled_S = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(68, Byte), Integer), CType(CType(75, Byte), Integer))
        '
        'Build
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(493, 480)
        Me.Controls.Add(Me.ThemeTabControl1)
        Me.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ForeColor = System.Drawing.Color.Maroon
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Build"
        Me.Opacity = 0R
        Me.ShowInTaskbar = False
        Me.Text = "Build"
        Me.ThemeTabControl1.ResumeLayout(False)
        Me.TabPage6.ResumeLayout(False)
        Me.Panel7.ResumeLayout(False)
        Me.Panel7.PerformLayout()
        Me.grpTelegram.ResumeLayout(False)
        Me.grpTelegram.PerformLayout()
        Me.grpDiscord.ResumeLayout(False)
        Me.grpDiscord.PerformLayout()
        Me.TabPage7.ResumeLayout(False)
        Me.Panel8.ResumeLayout(False)
        Me.grpProtectionOptions.ResumeLayout(False)
        Me.grpProtectionOptions.PerformLayout()
        CType(Me.numDelayMinutes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPageDropper.ResumeLayout(False)
        Me.PanelDropper.ResumeLayout(False)
        Me.grpDropper_Dropper.ResumeLayout(False)
        Me.grpDropper_Dropper.PerformLayout()
        Me.TabPage1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage2.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        CType(Me.Pi6, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage4.ResumeLayout(False)
        Me.Panel5.ResumeLayout(False)
        Me.Panel5.PerformLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Pi2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Pi1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Pi5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Pi4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Pi3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage5.ResumeLayout(False)
        Me.Panel6.ResumeLayout(False)
        Me.Panel6.PerformLayout()
        Me.TabPage3.ResumeLayout(False)
        Me.Panel4.ResumeLayout(False)
        CType(Me.PBil, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
End Class

