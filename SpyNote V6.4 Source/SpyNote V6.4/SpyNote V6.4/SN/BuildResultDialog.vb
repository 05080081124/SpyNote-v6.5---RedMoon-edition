Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Windows.Forms
Imports SpyNote_V6._4.SN
Imports SpyNote_V6._4.SN.SpyNote.Stores

Public Class BuildResultSummary
    Public Success As Boolean
    Public ApkPath As String
    Public ApkSizeKb As Long
    Public Errors As New List(Of String)
    Public NotifyEnabled As Boolean
    Public NotifyType As String
    Public NotifyCredentialsOk As Boolean
    Public NotifyInApk As Boolean
    Public PanelNotifyEnabled As Boolean
    Public ProtectionEnabled As Boolean
    Public AntiEmulator As Boolean
    Public HideIcon As Boolean
    Public MaskType As String
    Public FakeActivity As String
    Public PackageName As String
    Public DropperEnabled As Boolean
    Public PatchFailed As Boolean
    Public LauncherHookApplied As Boolean
    Public ApplicationHookApplied As Boolean
    Public ProviderInManifest As Boolean
    Public ReceiverInManifest As Boolean
End Class

Public Class BuildResultDialog
    Inherits Form

    Private ReadOnly _accent As Color = Color.FromArgb(210, 35, 45)
    Private ReadOnly _border As Color = Color.FromArgb(140, 20, 30)
    Private ReadOnly _panel As Color = Color.FromArgb(27, 27, 28)
    Private ReadOnly _panelInner As Color = Color.FromArgb(20, 20, 20)
    Private ReadOnly _text As Color = Color.FromArgb(215, 215, 215)
    Private ReadOnly _muted As Color = Color.FromArgb(150, 150, 150)
    Private ReadOnly _ok As Color = Color.FromArgb(90, 190, 110)
    Private ReadOnly _warn As Color = Color.FromArgb(230, 170, 60)
    Private ReadOnly _bad As Color = Color.FromArgb(230, 80, 80)

    Private _dragging As Boolean
    Private _dragStart As Point

    Public Shared Sub ShowResult(owner As Form, summary As BuildResultSummary)
        Using dlg As New BuildResultDialog()
            dlg.BuildUi(summary)
            If owner IsNot Nothing AndAlso owner.Visible Then
                dlg.ShowDialog(owner)
            Else
                dlg.ShowDialog()
            End If
        End Using
    End Sub

    Private Sub BuildUi(summary As BuildResultSummary)
        Dim titleText As String = If(summary.Success, "Build complete", "Build finished with issues")
        Text = titleText
        FormBorderStyle = FormBorderStyle.None
        StartPosition = FormStartPosition.CenterParent
        BackColor = _border
        Font = New Font("Segoe UI", 9.0F)
        ClientSize = New Size(520, 560)
        ShowInTaskbar = False
        Try
            Icon = New Icon(String.Concat(Store.Resources(1), "\Icons\window\win\16.ico"))
        Catch
        End Try

        Dim root As New Panel() With {
            .Dock = DockStyle.Fill,
            .Padding = New Padding(1),
            .BackColor = _border
        }
        Controls.Add(root)

        Dim body As New Panel() With {
            .Dock = DockStyle.Fill,
            .BackColor = _panel
        }
        root.Controls.Add(body)

        Dim header As New Panel() With {
            .Dock = DockStyle.Top,
            .Height = 42,
            .BackColor = _panelInner
        }
        body.Controls.Add(header)

        Dim lblTitle As New Label() With {
            .AutoSize = False,
            .Dock = DockStyle.Fill,
            .Text = titleText,
            .ForeColor = _text,
            .Font = New Font("Segoe UI Semibold", 11.0F, FontStyle.Bold),
            .TextAlign = ContentAlignment.MiddleLeft,
            .Padding = New Padding(14, 0, 0, 0)
        }
        header.Controls.Add(lblTitle)

        Dim btnClose As New Button() With {
            .Text = "×",
            .FlatStyle = FlatStyle.Flat,
            .Size = New Size(42, 42),
            .Dock = DockStyle.Right,
            .ForeColor = _muted,
            .BackColor = _panelInner,
            .Cursor = Cursors.Hand
        }
        btnClose.FlatAppearance.BorderSize = 0
        btnClose.FlatAppearance.MouseOverBackColor = _accent
        AddHandler btnClose.Click, Sub() Close()
        header.Controls.Add(btnClose)

        Dim accentLine As New Panel() With {
            .Dock = DockStyle.Top,
            .Height = 2,
            .BackColor = _accent
        }
        body.Controls.Add(accentLine)

        Dim content As New Panel() With {
            .Dock = DockStyle.Fill,
            .Padding = New Padding(14, 10, 14, 8),
            .BackColor = _panel,
            .AutoScroll = True
        }
        body.Controls.Add(content)

        Dim y As Integer = 0
        AddStatusBlock(content, y, If(summary.Success, "APK signed and ready", "Build completed with warnings"), If(summary.Success, _ok, _warn))

        If Not String.IsNullOrWhiteSpace(summary.ApkPath) Then
            AddInfoLine(content, y, "Path", summary.ApkPath, _muted)
            AddInfoLine(content, y, "Size", summary.ApkSizeKb.ToString() & " KB", If(summary.ApkSizeKb > 0, _text, _bad))
        End If

        AddSectionTitle(content, y, "Notifications")
        If summary.NotifyEnabled Then
            Dim cred As String = If(summary.NotifyCredentialsOk, "configured", "credentials missing")
            Dim credColor As Color = If(summary.NotifyCredentialsOk, _ok, _bad)
            AddFeatureLine(content, y, "Enable notification (builder)", True, summary.NotifyType & " / " & cred, credColor)
            AddFeatureLine(content, y, "Panel notify (on connect)", summary.NotifyCredentialsOk, "works when device appears in SpyNote", If(summary.NotifyCredentialsOk, _ok, _bad))
            If summary.NotifyInApk Then
                Dim hookDetail As String = "provider"
                If summary.LauncherHookApplied Then hookDetail &= " + launcher"
                If summary.ApplicationHookApplied Then hookDetail &= " + app"
                If summary.ReceiverInManifest Then hookDetail &= " + boot receiver"
                AddFeatureLine(content, y, "APK notify (in APK)", True, hookDetail & ", retries until sent", _ok)
            Else
                AddFeatureLine(content, y, "APK notify (in APK)", False, If(summary.PatchFailed, "patch failed — panel notify still works", "not injected"), _warn)
            End If
            AddHintLine(content, y, "Dual notify: APK sends on open; panel sends when device connects to SpyNote.", _muted)
            AddHintLine(content, y, "Panel notify is the backup if APK notify fails.", _muted)
        Else
            AddFeatureLine(content, y, "Enable notification (builder)", False, "disabled in Notify tab", _muted)
        End If

        AddSectionTitle(content, y, "Protection")
        If summary.ProtectionEnabled Then
            AddFeatureLine(content, y, "Protection module", True, "active in APK", _ok)
            AddFeatureLine(content, y, "Mask as", Not String.IsNullOrWhiteSpace(summary.MaskType), If(summary.MaskType, "not set"), If(String.IsNullOrWhiteSpace(summary.MaskType), _muted, _ok))
            AddFeatureLine(content, y, "Fake activity", Not String.IsNullOrWhiteSpace(summary.FakeActivity), If(summary.FakeActivity, "auto by mask"), If(String.IsNullOrWhiteSpace(summary.FakeActivity), _muted, _ok))
            AddFeatureLine(content, y, "Anti-emulator", summary.AntiEmulator, If(summary.AntiEmulator, "score-based, blocks emulators / BlueStacks", "off"), If(summary.AntiEmulator, _warn, _muted))
            If summary.AntiEmulator Then
                AddHintLine(content, y, "Anti-emulator ON: APK will NOT run on BlueStacks. Turn it off for emulator tests.", _bad)
            End If
            AddFeatureLine(content, y, "Hide icon after setup", summary.HideIcon, If(summary.HideIcon, "icon will disappear", "icon stays visible"), If(summary.HideIcon, _warn, _ok))
            If summary.HideIcon Then
                AddHintLine(content, y, "Hide icon ON: after permissions the launcher icon disappears — looks like app won't open.", _warn)
            End If
            If Not String.IsNullOrWhiteSpace(summary.PackageName) Then
                AddInfoLine(content, y, "Package", summary.PackageName, _text)
            End If
        Else
            AddFeatureLine(content, y, "Protection", False, "disabled", _muted)
        End If

        If summary.DropperEnabled Then
            AddSectionTitle(content, y, "Dropper")
            AddFeatureLine(content, y, "Dropper mode", True, "built separately", _ok)
        End If

        If summary.Errors IsNot Nothing AndAlso summary.Errors.Count > 0 Then
            AddSectionTitle(content, y, "Issues")
            For Each err As String In summary.Errors
                AddHintLine(content, y, err, _bad)
            Next
        End If

        Dim footer As New Panel() With {
            .Dock = DockStyle.Bottom,
            .Height = 52,
            .BackColor = _panelInner,
            .Padding = New Padding(14, 8, 14, 8)
        }
        body.Controls.Add(footer)

        Dim btnOk As New Button() With {
            .Text = "OK",
            .Size = New Size(120, 32),
            .Anchor = AnchorStyles.Right Or AnchorStyles.Top,
            .Location = New Point(footer.Width - 134, 10),
            .FlatStyle = FlatStyle.Flat,
            .ForeColor = Color.White,
            .BackColor = _accent,
            .Cursor = Cursors.Hand
        }
        btnOk.FlatAppearance.BorderSize = 0
        btnOk.FlatAppearance.MouseOverBackColor = Color.FromArgb(230, 45, 55)
        AddHandler footer.Resize, Sub() btnOk.Location = New Point(footer.ClientSize.Width - btnOk.Width - 14, 10)
        AddHandler btnOk.Click, Sub()
                                    DialogResult = DialogResult.OK
                                    Close()
                                End Sub
        footer.Controls.Add(btnOk)

        EnableDrag(header)
        EnableDrag(lblTitle)
        EnableDrag(accentLine)
        EnableDrag(body)
        EnableDrag(root)
    End Sub

    Private Sub EnableDrag(ctrl As Control)
        AddHandler ctrl.MouseDown, AddressOf Drag_MouseDown
        AddHandler ctrl.MouseMove, AddressOf Drag_MouseMove
        AddHandler ctrl.MouseUp, AddressOf Drag_MouseUp
    End Sub

    Private Sub Drag_MouseDown(sender As Object, e As MouseEventArgs)
        If e.Button <> MouseButtons.Left Then Return
        _dragging = True
        _dragStart = Control.MousePosition
    End Sub

    Private Sub Drag_MouseMove(sender As Object, e As MouseEventArgs)
        If Not _dragging Then Return
        Dim pos As Point = Control.MousePosition
        Location = New Point(Location.X + pos.X - _dragStart.X, Location.Y + pos.Y - _dragStart.Y)
        _dragStart = pos
    End Sub

    Private Sub Drag_MouseUp(sender As Object, e As MouseEventArgs)
        _dragging = False
    End Sub

    Private Sub AddSectionTitle(parent As Panel, ByRef y As Integer, title As String)
        Dim lbl As New Label() With {
            .AutoSize = False,
            .Location = New Point(0, y),
            .Size = New Size(Math.Max(200, parent.ClientSize.Width - 28), 22),
            .Text = title.ToUpperInvariant(),
            .ForeColor = _accent,
            .Font = New Font("Segoe UI", 8.5F, FontStyle.Bold)
        }
        parent.Controls.Add(lbl)
        y += 24
    End Sub

    Private Sub AddStatusBlock(parent As Panel, ByRef y As Integer, text As String, color As Color)
        Dim box As New Panel() With {
            .Location = New Point(0, y),
            .Size = New Size(Math.Max(200, parent.ClientSize.Width - 28), 34),
            .BackColor = _panelInner
        }
        parent.Controls.Add(box)
        Dim lbl As New Label() With {
            .Dock = DockStyle.Fill,
            .Text = "   " & text,
            .ForeColor = color,
            .TextAlign = ContentAlignment.MiddleLeft,
            .Font = New Font("Segoe UI Semibold", 10.0F, FontStyle.Bold)
        }
        box.Controls.Add(lbl)
        y += 40
    End Sub

    Private Sub AddFeatureLine(parent As Panel, ByRef y As Integer, name As String, enabled As Boolean, detail As String, detailColor As Color)
        Dim status As String = If(enabled, "ON", "OFF")
        Dim statusColor As Color = If(enabled, _ok, _muted)
        AddInfoLine(parent, y, name, status, statusColor)
        AddHintLine(parent, y, detail, detailColor)
    End Sub

    Private Sub AddInfoLine(parent As Panel, ByRef y As Integer, label As String, value As String, valueColor As Color)
        Dim row As New Label() With {
            .AutoSize = False,
            .Location = New Point(0, y),
            .Size = New Size(Math.Max(200, parent.ClientSize.Width - 28), 18),
            .Text = label & ":  " & value,
            .ForeColor = valueColor
        }
        parent.Controls.Add(row)
        y += 20
    End Sub

    Private Sub AddHintLine(parent As Panel, ByRef y As Integer, text As String, color As Color)
        Dim row As New Label() With {
            .AutoSize = False,
            .Location = New Point(12, y),
            .Size = New Size(Math.Max(180, parent.ClientSize.Width - 40), 18),
            .Text = text,
            .ForeColor = color,
            .Font = New Font("Segoe UI", 8.25F)
        }
        parent.Controls.Add(row)
        y += 18
    End Sub

    Protected Overrides Sub OnPaint(e As PaintEventArgs)
        MyBase.OnPaint(e)
        Using pen As New Pen(_border)
            e.Graphics.DrawRectangle(pen, 0, 0, Width - 1, Height - 1)
        End Using
    End Sub
End Class
