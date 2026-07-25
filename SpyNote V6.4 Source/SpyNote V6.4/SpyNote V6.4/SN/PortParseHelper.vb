Imports System.Globalization

Public Module PortParseHelper

    Public Function TryParsePort(text As String, ByRef port As Integer) As Boolean
        port = 0
        If String.IsNullOrWhiteSpace(text) Then Return False
        Dim trimmed As String = text.Trim()
        If Not Integer.TryParse(trimmed, NumberStyles.Integer, CultureInfo.InvariantCulture, port) Then
            Return False
        End If
        Return port >= 1 AndAlso port <= 65535
    End Function

    Public Function ParsePortOrDefault(text As String, defaultPort As Integer) As Integer
        Dim port As Integer
        If TryParsePort(text, port) Then Return port
        Return defaultPort
    End Function

End Module
