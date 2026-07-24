Imports System.Drawing
Imports System.IO
Imports System.Media

Namespace SN
    Public Module BrandingAssets
        Public Const ProductTitle As String = "SpyNote v6.5 - RedMoon edition"
        Public Const ProductShort As String = "SpyNote v6.5"
        Public Const AboutCaption As String = "About SpyNote"
        Public Function GetMenuBackground() As Image
            Try
                Dim bitmap As Bitmap = My.Resources.MenuBackground
                If bitmap IsNot Nothing Then
                    Return DirectCast(bitmap.Clone(), Image)
                End If
            Catch ex As Exception
            End Try

            Return Nothing
        End Function

        Public Sub PlayStartupSound()
            Try
                Dim bytes As Byte() = My.Resources.StartupSound
                If bytes IsNot Nothing AndAlso bytes.Length > 0 Then
                    Using stream As New MemoryStream(bytes)
                        Using player As New SoundPlayer(stream)
                            player.Play()
                        End Using
                    End Using
                End If
            Catch ex As Exception
            End Try
        End Sub

        Public Function GetApplicationIcon() As Icon
            Try
                Return My.Resources.AppIcon
            Catch ex As Exception
                Return Nothing
            End Try
        End Function
    End Module
End Namespace
