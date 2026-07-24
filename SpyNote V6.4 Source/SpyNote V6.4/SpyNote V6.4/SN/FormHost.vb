Imports System.Windows.Forms

Namespace SN
    Public Module FormHost
        Public Function Create(Of T As {Form, New})() As T
            Dim form As T = New T()
            FormHost.Prepare(form)
            Return form
        End Function

        Public Sub Prepare(form As Form)
            If form Is Nothing Then
                Return
            End If

            UiTheme.WireForm(form)
            Lang.WireForm(form)
        End Sub
    End Module
End Namespace
