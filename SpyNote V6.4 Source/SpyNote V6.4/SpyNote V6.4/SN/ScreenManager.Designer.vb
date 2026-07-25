<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ScreenManager
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

    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.ProgressBar1 = New SpyNote_V6._4.SN.ThemeProgressBar()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.STALAB = New SpyNote_V6._4.SN.ThemeButton()
        Me.QUALAB = New SpyNote_V6._4.SN.ThemeCoBox()
        Me.SIZLAB = New SpyNote_V6._4.SN.ThemeCoBox()
        Me.ThemeSeparator1 = New SpyNote_V6._4.SN.ThemeSeparator()
        Me.PNLERRORS = New System.Windows.Forms.Panel()
        Me.LBER = New System.Windows.Forms.Label()
        Me.PBox = New System.Windows.Forms.PictureBox()
        Me.SELCT_QUA = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.SELCTE_SZ = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.TProgressBar = New System.Windows.Forms.Timer(Me.components)
        Me.TFPS = New System.Windows.Forms.Timer(Me.components)
        Me.RF = New System.Windows.Forms.Timer(Me.components)
        Me.Trans = New System.Windows.Forms.Timer(Me.components)
        Me.Panel1.SuspendLayout()
        CType(Me.QUALAB, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SIZLAB, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PNLERRORS.SuspendLayout()
        CType(Me.PBox, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Animated = True
        Me.ProgressBar1.Colour0 = System.Drawing.Color.FromArgb(CType(CType(140, Byte), Integer), CType(CType(140, Byte), Integer), CType(CType(140, Byte), Integer))
        Me.ProgressBar1.Colour1 = System.Drawing.Color.FromArgb(CType(CType(140, Byte), Integer), CType(CType(140, Byte), Integer), CType(CType(140, Byte), Integer))
        Me.ProgressBar1.Customization = "AAAAAAAAAAAAAAAAAAAAAA=="
        Me.ProgressBar1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.ProgressBar1.Font = New System.Drawing.Font("Verdana", 8.0!)
        Me.ProgressBar1.Image = Nothing
        Me.ProgressBar1.Location = New System.Drawing.Point(0, 412)
        Me.ProgressBar1.Maximum = 100
        Me.ProgressBar1.Minimum = 0
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.NoRounding = False
        Me.ProgressBar1.Size = New System.Drawing.Size(634, 10)
        Me.ProgressBar1.TabIndex = 0
        Me.ProgressBar1.Text = "ThemeProgressBar1"
        Me.ProgressBar1.Transparent = False
        Me.ProgressBar1.Value = 0
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer))
        Me.Panel1.Controls.Add(Me.STALAB)
        Me.Panel1.Controls.Add(Me.QUALAB)
        Me.Panel1.Controls.Add(Me.SIZLAB)
        Me.Panel1.Controls.Add(Me.ThemeSeparator1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel1.Location = New System.Drawing.Point(460, 24)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(174, 388)
        Me.Panel1.TabIndex = 1
        '
        'STALAB
        '
        Me.STALAB.BackColorDown0_S = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer))
        Me.STALAB.BackColorDown1_S = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer))
        Me.STALAB.BackColorNone0_S = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer))
        Me.STALAB.BackColorNone1_S = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.STALAB.BackColorOver0_S = System.Drawing.Color.FromArgb(CType(CType(210, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(45, Byte), Integer))
        Me.STALAB.BackColorOver1_S = System.Drawing.Color.FromArgb(CType(CType(210, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(45, Byte), Integer))
        Me.STALAB.ButtonBackColorEnabled0_S = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.STALAB.ButtonBackColorEnabled1_S = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.STALAB.ButtonForColor_S = System.Drawing.Color.White
        Me.STALAB.ButtonForColorEnabled_S = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.STALAB.Buttonselected_Color_ForColor_S = System.Drawing.Color.White
        Me.STALAB.Enabled = False
        Me.STALAB.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!)
        Me.STALAB.ImageAlignment = SpyNote_V6._4.SN.ThemeButton.__ImageAlignment.Left
        Me.STALAB.ImageChoice = Nothing
        Me.STALAB.Location = New System.Drawing.Point(39, 120)
        Me.STALAB.Name = "STALAB"
        Me.STALAB.ShowImage = False
        Me.STALAB.ShowText = True
        Me.STALAB.Size = New System.Drawing.Size(100, 28)
        Me.STALAB.TabIndex = 17
        Me.STALAB.Tag = "-1"
        Me.STALAB.Text = "Start"
        Me.STALAB.TextAlignment = System.Drawing.StringAlignment.Center
        Me.STALAB.ThemeButtonclrBorder_S = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.STALAB.ThemeButtonclrBorderactive_S = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(70, Byte), Integer), CType(CType(80, Byte), Integer))
        Me.STALAB.ThemeButtonclrBorderEnabled_S = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(68, Byte), Integer), CType(CType(75, Byte), Integer))
        '
        'QUALAB
        '
        Me.QUALAB.BackColor = System.Drawing.Color.Transparent
        Me.QUALAB.Enabled = False
        Me.QUALAB.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!)
        Me.QUALAB.Location = New System.Drawing.Point(3, 55)
        Me.QUALAB.MlinColorovr = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(113, Byte), Integer), CType(CType(171, Byte), Integer))
        Me.QUALAB.MyArrwBackColorOvr = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.QUALAB.MyArrwColorNone = System.Drawing.Color.FromArgb(CType(CType(153, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(153, Byte), Integer))
        Me.QUALAB.MyArrwColorOvr = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(113, Byte), Integer), CType(CType(171, Byte), Integer))
        Me.QUALAB.MyBackColorNone = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(51, Byte), Integer), CType(CType(55, Byte), Integer))
        Me.QUALAB.MyBackColorOver = System.Drawing.Color.FromArgb(CType(CType(63, Byte), Integer), CType(CType(63, Byte), Integer), CType(CType(70, Byte), Integer))
        Me.QUALAB.MyBordColor = System.Drawing.Color.FromArgb(CType(CType(67, Byte), Integer), CType(CType(67, Byte), Integer), CType(CType(70, Byte), Integer))
        Me.QUALAB.MyFontColor = System.Drawing.Color.FromArgb(CType(CType(241, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.QUALAB.MylinColorNone = System.Drawing.Color.FromArgb(CType(CType(153, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(153, Byte), Integer))
        Me.QUALAB.Name = "QUALAB"
        Me.QUALAB.Size = New System.Drawing.Size(165, 20)
        Me.QUALAB.TabIndex = 16
        Me.QUALAB.TabStop = False
        Me.QUALAB.TxText = "Quality:"
        '
        'SIZLAB
        '
        Me.SIZLAB.BackColor = System.Drawing.Color.Transparent
        Me.SIZLAB.Enabled = False
        Me.SIZLAB.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!)
        Me.SIZLAB.Location = New System.Drawing.Point(3, 29)
        Me.SIZLAB.MlinColorovr = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(113, Byte), Integer), CType(CType(171, Byte), Integer))
        Me.SIZLAB.MyArrwBackColorOvr = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.SIZLAB.MyArrwColorNone = System.Drawing.Color.FromArgb(CType(CType(153, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(153, Byte), Integer))
        Me.SIZLAB.MyArrwColorOvr = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(113, Byte), Integer), CType(CType(171, Byte), Integer))
        Me.SIZLAB.MyBackColorNone = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(51, Byte), Integer), CType(CType(55, Byte), Integer))
        Me.SIZLAB.MyBackColorOver = System.Drawing.Color.FromArgb(CType(CType(63, Byte), Integer), CType(CType(63, Byte), Integer), CType(CType(70, Byte), Integer))
        Me.SIZLAB.MyBordColor = System.Drawing.Color.FromArgb(CType(CType(67, Byte), Integer), CType(CType(67, Byte), Integer), CType(CType(70, Byte), Integer))
        Me.SIZLAB.MyFontColor = System.Drawing.Color.FromArgb(CType(CType(241, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.SIZLAB.MylinColorNone = System.Drawing.Color.FromArgb(CType(CType(153, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(153, Byte), Integer))
        Me.SIZLAB.Name = "SIZLAB"
        Me.SIZLAB.Size = New System.Drawing.Size(165, 20)
        Me.SIZLAB.TabIndex = 15
        Me.SIZLAB.TabStop = False
        Me.SIZLAB.TxText = "Size:"
        '
        'ThemeSeparator1
        '
        Me.ThemeSeparator1.Colour0 = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.ThemeSeparator1.Colour1 = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.ThemeSeparator1.Location = New System.Drawing.Point(3, 88)
        Me.ThemeSeparator1.Name = "ThemeSeparator1"
        Me.ThemeSeparator1.Size = New System.Drawing.Size(165, 10)
        Me.ThemeSeparator1.TabIndex = 12
        '
        'PNLERRORS
        '
        Me.PNLERRORS.BackColor = System.Drawing.Color.FromArgb(CType(CType(37, Byte), Integer), CType(CType(37, Byte), Integer), CType(CType(38, Byte), Integer))
        Me.PNLERRORS.Controls.Add(Me.LBER)
        Me.PNLERRORS.Dock = System.Windows.Forms.DockStyle.Top
        Me.PNLERRORS.Location = New System.Drawing.Point(0, 0)
        Me.PNLERRORS.Name = "PNLERRORS"
        Me.PNLERRORS.Size = New System.Drawing.Size(634, 24)
        Me.PNLERRORS.TabIndex = 5
        Me.PNLERRORS.Visible = False
        '
        'LBER
        '
        Me.LBER.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LBER.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.LBER.Location = New System.Drawing.Point(0, 0)
        Me.LBER.Name = "LBER"
        Me.LBER.Size = New System.Drawing.Size(634, 24)
        Me.LBER.TabIndex = 0
        Me.LBER.Text = "Error"
        Me.LBER.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'PBox
        '
        Me.PBox.BackColor = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer))
        Me.PBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PBox.Location = New System.Drawing.Point(0, 24)
        Me.PBox.Name = "PBox"
        Me.PBox.Size = New System.Drawing.Size(460, 388)
        Me.PBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PBox.TabIndex = 4
        Me.PBox.TabStop = False
        '
        'SELCT_QUA
        '
        Me.SELCT_QUA.Name = "SELCT_QUA"
        Me.SELCT_QUA.Size = New System.Drawing.Size(61, 4)
        '
        'SELCTE_SZ
        '
        Me.SELCTE_SZ.Name = "SELCTE_SZ"
        Me.SELCTE_SZ.Size = New System.Drawing.Size(61, 4)
        '
        'TProgressBar
        '
        Me.TProgressBar.Interval = 1000
        '
        'TFPS
        '
        Me.TFPS.Interval = 1000
        '
        'RF
        '
        Me.RF.Interval = 400
        '
        'Trans
        '
        Me.Trans.Interval = 40
        '
        'ScreenManager
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(48, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(634, 422)
        Me.Controls.Add(Me.PBox)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.PNLERRORS)
        Me.Controls.Add(Me.ProgressBar1)
        Me.MinimumSize = New System.Drawing.Size(520, 360)
        Me.Name = "ScreenManager"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Screen"
        Me.Panel1.ResumeLayout(False)
        CType(Me.QUALAB, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SIZLAB, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PNLERRORS.ResumeLayout(False)
        CType(Me.PBox, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents ProgressBar1 As SN.ThemeProgressBar
    Friend WithEvents Panel1 As Panel
    Friend WithEvents STALAB As SN.ThemeButton
    Friend WithEvents QUALAB As SN.ThemeCoBox
    Friend WithEvents SIZLAB As SN.ThemeCoBox
    Friend WithEvents ThemeSeparator1 As SN.ThemeSeparator
    Friend WithEvents PNLERRORS As Panel
    Friend WithEvents LBER As Label
    Friend WithEvents PBox As PictureBox
    Friend WithEvents SELCT_QUA As ContextMenuStrip
    Friend WithEvents SELCTE_SZ As ContextMenuStrip
    Friend WithEvents TProgressBar As Timer
    Friend WithEvents TFPS As Timer
    Friend WithEvents RF As Timer
    Friend WithEvents Trans As Timer
End Class
