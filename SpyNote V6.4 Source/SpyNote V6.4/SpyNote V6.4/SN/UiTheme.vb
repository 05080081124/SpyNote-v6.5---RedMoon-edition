Imports System.Drawing
Imports System.IO
Imports System.Media
Imports System.Windows.Forms
Imports SpyNote_V6._4.SN.SpyNote.Stores

Namespace SN
    Public Module UiTheme
        Public ReadOnly BgBlack As Color = Color.FromArgb(8, 8, 8)
        Public ReadOnly BgDark As Color = Color.FromArgb(14, 14, 14)
        Public ReadOnly BgPanel As Color = Color.FromArgb(20, 20, 20)
        Public ReadOnly BgDeep As Color = Color.FromArgb(10, 10, 10)
        Public ReadOnly BgGrid As Color = Color.FromArgb(16, 16, 16)
        Public ReadOnly BgMenu As Color = Color.FromArgb(12, 12, 12)
        Public ReadOnly Border As Color = Color.FromArgb(140, 20, 30)
        Public ReadOnly Accent As Color = Color.FromArgb(210, 35, 45)
        Public ReadOnly AccentActive As Color = Color.FromArgb(255, 55, 65)
        Public ReadOnly AccentMuted As Color = Color.FromArgb(60, 12, 18)
        Public ReadOnly TextPrimary As Color = Color.FromArgb(245, 245, 245)
        Public ReadOnly TextMuted As Color = Color.FromArgb(190, 190, 190)

        Private ReadOnly WiredForms As HashSet(Of Integer)

        Sub New()
            UiTheme.WiredForms = New HashSet(Of Integer)()
        End Sub

        Public Sub InitializeApp()
            UiTheme.ApplyApplicationIcon()
            BrandingAssets.PlayStartupSound()
        End Sub

        Public Sub ApplyApplicationIcon()
            Try
                Dim icon As Icon = BrandingAssets.GetApplicationIcon()
                If icon Is Nothing Then
                    Return
                End If

                For Each form As Form In Application.OpenForms
                    form.Icon = icon
                Next
            Catch ex As Exception
            End Try
        End Sub

        Public Sub WireForm(form As Form)
            If form Is Nothing Then
                Return
            End If

            SyncLock UiTheme.WiredForms
                If UiTheme.WiredForms.Contains(form.GetHashCode()) Then
                    Return
                End If
                UiTheme.WiredForms.Add(form.GetHashCode())
            End SyncLock

            AddHandler form.Load, AddressOf UiTheme.OnFormLoad
        End Sub

        Private Sub OnFormLoad(sender As Object, e As EventArgs)
            Dim form As Form = TryCast(sender, Form)
            If form Is Nothing Then
                Return
            End If

            UiTheme.ApplyToForm(form)
        End Sub

        Public Function WrapForm(Of T As Form)(form As T) As T
            UiTheme.WireForm(form)
            Return form
        End Function

        Public Sub ApplyToForm(form As Form)
            If form Is Nothing Then
                Return
            End If

            form.BackColor = UiTheme.BgDark
            form.ForeColor = UiTheme.TextPrimary
            UiTheme.ApplyControlTree(form)
            UiTheme.ApplyAllToolStrips(form)

            Dim main As MainSpyNote = TryCast(form, MainSpyNote)
            If main IsNot Nothing Then
                UiTheme.ApplyToMainForm(main)
            End If
        End Sub

        Public Sub ApplyToMainForm(form As MainSpyNote)
            form.Text = BrandingAssets.ProductTitle
            form.BackColor = UiTheme.BgBlack
            UiTheme.ApplyAllToolStrips(form)
            If form.PNLLOGESTOP IsNot Nothing Then
                form.PNLLOGESTOP.Visible = False
            End If
            If form.BOXDOWN IsNot Nothing Then
                form.BOXDOWN.BackColor = UiTheme.BgDeep
            End If
            UiTheme.ApplyToolbarButtons(form)
            UiTheme.ApplyToTabControl(form.MTabControl)
            UiTheme.ApplyMenuBackground(form.PanelTop, form.MenuStrip1)
            UiTheme.ApplyMenuRenderers(form)
            UiTheme.ApplyNestedMenuDropDowns(form)
            UiTheme.ApplyTopMenuAccent(form.MenuStrip1)
            Lang.ApplyToForm(form)
            Dim icon As Icon = BrandingAssets.GetApplicationIcon()
            If icon IsNot Nothing Then
                form.Icon = icon
            End If
        End Sub

        Public Sub ApplyTopMenuAccent(menuStrip As MenuStrip)
            If menuStrip Is Nothing Then
                Return
            End If

            For Each item As ToolStripItem In menuStrip.Items
                item.ForeColor = UiTheme.AccentActive
            Next
        End Sub

        Public Sub ApplyToolbarButtons(form As MainSpyNote)
            Dim buttons As ThemeButtonImge() = New ThemeButtonImge() {
                form.Bdown0, form.BDelete0, form.BDeleteAll0, form.BAutoDelete0,
                form.Bdown1, form.BDelete1, form.BRefres0, form.BDeleteAll1, form.BADD0,
                form.Bdown2, form.BDelete2, form.BDeleteAll2, form.BAutoDelete1
            }

            For Each button As ThemeButtonImge In buttons
                If button Is Nothing Then
                    Continue For
                End If

                button.BackColorNone0_S = UiTheme.BgPanel
                button.BackColorNone1_S = UiTheme.BgPanel
                button.BackColorOver0_S = UiTheme.AccentMuted
                button.BackColorOver1_S = UiTheme.AccentMuted
                button.BackColorDown0_S = UiTheme.Accent
                button.BackColorDown1_S = UiTheme.Accent
                button.ThemeButtonclrBorder_S = UiTheme.Border
                button.ThemeButtonclrBorderactive_S = UiTheme.Accent
                button.ButtonForColor_S = UiTheme.TextPrimary
                button.Buttonselected_Color_ForColor_S = UiTheme.TextPrimary
            Next
        End Sub

        Public Sub ApplyMenuRenderers(form As MainSpyNote)
            UiTheme.ApplyToolStripMenuItems(form.ContextControl)
            UiTheme.ApplyToolStripMenuItems(form.ContextTools)
            UiTheme.ApplyRenderer(form.MenuStrip1, True)
            For Each item As ToolStripItem In form.MenuStrip1.Items
                Dim menuItem As ToolStripMenuItem = TryCast(item, ToolStripMenuItem)
                If menuItem IsNot Nothing Then
                    UiTheme.ApplyMenuItemTree(menuItem)
                End If
            Next
            UiTheme.ApplyToolStripMenuItems(form.ContextView)
            UiTheme.ApplyToolStripMenuItems(form.SELCT_Apks)
        End Sub

        Public Sub ApplyNestedMenuDropDowns(form As MainSpyNote)
            UiTheme.ApplyMenuItemTree(form.HelpToolStripMenuItem)
            UiTheme.ApplyMenuItemTree(form.ToolsToolStripMenuItem)
            UiTheme.ApplyMenuItemTree(form.ViewToolStripMenuItem)
            UiTheme.ApplyMenuItemTree(form.FoldersToolStripMenuItem)
            UiTheme.ApplyMenuItemTree(form.ScommandToolStripMenuItem)
            UiTheme.ApplyMenuItemTree(form.WndToolStripMenuItem)
            UiTheme.ApplyMenuItemTree(form.EdweToolStripMenuItem)
            UiTheme.ApplyMenuItemTree(form.SdsafdToolStripMenuItem)
            UiTheme.ApplyMenuItemTree(form.CleintTCPToolStripMenuItem)
        End Sub

        Public Sub ApplyToolStripMenuItems(strip As ToolStrip)
            If strip Is Nothing Then
                Return
            End If

            UiTheme.ApplyRenderer(strip, False)
            For Each item As ToolStripItem In strip.Items
                Dim menuItem As ToolStripMenuItem = TryCast(item, ToolStripMenuItem)
                If menuItem IsNot Nothing Then
                    UiTheme.ApplyMenuItemTree(menuItem)
                Else
                    item.ForeColor = UiTheme.TextPrimary
                End If
            Next
        End Sub

        Public Sub ApplyMenuItemTree(item As ToolStripMenuItem)
            If item Is Nothing Then
                Return
            End If

            item.ForeColor = UiTheme.TextPrimary
            item.BackColor = UiTheme.BgBlack
            If item.HasDropDown Then
                UiTheme.ApplyRenderer(item.DropDown, False)
                Dim dropDown As ToolStripDropDownMenu = TryCast(item.DropDown, ToolStripDropDownMenu)
                If dropDown IsNot Nothing Then
                    dropDown.ShowImageMargin = False
                    dropDown.BackColor = UiTheme.BgBlack
                    dropDown.ForeColor = UiTheme.TextPrimary
                End If
                For Each child As ToolStripItem In item.DropDownItems
                    Dim childMenu As ToolStripMenuItem = TryCast(child, ToolStripMenuItem)
                    If childMenu IsNot Nothing Then
                        UiTheme.ApplyMenuItemTree(childMenu)
                    Else
                        child.ForeColor = UiTheme.TextPrimary
                    End If
                Next
            End If
        End Sub

        Public Sub ApplyAllToolStrips(root As Control)
            If root Is Nothing Then
                Return
            End If

            If TypeOf root Is ToolStrip Then
                UiTheme.ApplyToolStripMenuItems(DirectCast(root, ToolStrip))
            End If

            If root.ContextMenuStrip IsNot Nothing Then
                UiTheme.ApplyToolStripMenuItems(root.ContextMenuStrip)
            End If

            For Each child As Control In root.Controls
                UiTheme.ApplyAllToolStrips(child)
            Next
        End Sub

        Private Sub ApplyRenderer(strip As ToolStrip)
            UiTheme.ApplyRenderer(strip, False)
        End Sub

        Private Sub ApplyRenderer(strip As ToolStrip, transparentMenuBar As Boolean)
            If strip Is Nothing Then
                Return
            End If

            Dim renderer As ThemeToolStrip = TryCast(strip.Renderer, ThemeToolStrip)
            If renderer Is Nothing Then
                renderer = New ThemeToolStrip()
                strip.Renderer = renderer
            End If

            UiTheme.ApplyToThemeToolStrip(renderer)
            If transparentMenuBar AndAlso TypeOf strip Is MenuStrip Then
                strip.BackColor = Color.Transparent
            Else
                strip.BackColor = UiTheme.BgBlack
            End If
            strip.ForeColor = UiTheme.TextPrimary
        End Sub

        Public Sub ApplyMenuBackground(panelTop As Panel, menuStrip As MenuStrip)
            If panelTop Is Nothing Then
                Return
            End If

            Dim image As Image = UiTheme.LoadMenuBackgroundImage()
            If image Is Nothing Then
                panelTop.BackColor = UiTheme.BgBlack
                Return
            End If

            panelTop.BackgroundImage = image
            panelTop.BackgroundImageLayout = ImageLayout.Stretch
            If menuStrip IsNot Nothing Then
                menuStrip.BackColor = Color.Transparent
                menuStrip.ForeColor = UiTheme.TextPrimary
            End If
        End Sub

        Private Function LoadMenuBackgroundImage() As Image
            Return BrandingAssets.GetMenuBackground()
        End Function

        Public Sub PlayStartupSound()
            BrandingAssets.PlayStartupSound()
        End Sub

        Public Sub ApplyToThemeToolStrip(renderer As ThemeToolStrip)
            If renderer Is Nothing Then
                Return
            End If

            renderer.selected_Color = UiTheme.AccentMuted
            renderer.selected_Color_ForColor = UiTheme.TextPrimary
            renderer.backColor = UiTheme.BgBlack
            renderer.backColorStrip = UiTheme.BgBlack
            renderer.ForColor = UiTheme.TextPrimary
            renderer.clrSelectedBorder = UiTheme.Accent
            renderer.clrSelectedBorderCheck = UiTheme.BgDeep
            renderer.ColorLines0 = UiTheme.Border
            renderer.ColorLines1 = UiTheme.AccentMuted
            renderer.backColorChecked0 = Color.FromArgb(150, 25, 35)
            renderer.backColorChecked1 = Color.FromArgb(180, 35, 45)
            renderer.ArrowColor = UiTheme.TextPrimary
            renderer.ArrowselectedColor = UiTheme.AccentActive
            renderer.ENBArrowselectedColor = Color.FromArgb(70, 18, 24)
            renderer.ColorBorder = UiTheme.Border
        End Sub

        Public Sub ApplyToTabControl(tabControl As ThemeTabControl)
            If tabControl Is Nothing Then
                Return
            End If

            tabControl.MouseOver0_S = UiTheme.Accent
            tabControl.MouseOver1_S = UiTheme.BgBlack
            tabControl.DefaultColor0_S = UiTheme.BgBlack
            tabControl.DefaultColor1_S = UiTheme.AccentMuted
            tabControl.DefaultBackColor_S = UiTheme.BgDeep
            tabControl.DefaultForColor_S = UiTheme.TextPrimary
            tabControl.BorderColor_S = UiTheme.Border
            tabControl.FForColorSelcted_S = Color.White
        End Sub

        Private Sub ApplyControlTree(root As Control)
            UiTheme.ApplyControlColors(root)

            For Each child As Control In root.Controls
                UiTheme.ApplyControlTree(child)
            Next
        End Sub

        Private Sub ApplyControlColors(control As Control)
            If TypeOf control Is Form Then
                control.BackColor = UiTheme.BgDark
                control.ForeColor = UiTheme.TextPrimary
            ElseIf TypeOf control Is Panel Then
                control.BackColor = UiTheme.BgDark
            ElseIf TypeOf control Is SplitContainer Then
                Dim split As SplitContainer = DirectCast(control, SplitContainer)
                split.BackColor = UiTheme.Border
                split.Panel1.BackColor = UiTheme.BgDeep
                split.Panel2.BackColor = UiTheme.BgDark
            ElseIf TypeOf control Is MenuStrip OrElse TypeOf control Is StatusStrip Then
                control.BackColor = UiTheme.BgBlack
                control.ForeColor = UiTheme.TextPrimary
            ElseIf TypeOf control Is TabPage Then
                control.BackColor = UiTheme.BgDark
            ElseIf TypeOf control Is DataGridView Then
                UiTheme.ApplyGridTheme(DirectCast(control, DataGridView))
            ElseIf TypeOf control Is ContextMenuStrip Then
                UiTheme.ApplyToolStripMenuItems(DirectCast(control, ContextMenuStrip))
            ElseIf TypeOf control Is ToolStrip Then
                UiTheme.ApplyToolStripMenuItems(DirectCast(control, ToolStrip))
            ElseIf TypeOf control Is ThemeTextBox Then
                UiTheme.ApplyThemeTextBox(DirectCast(control, ThemeTextBox))
            ElseIf TypeOf control Is TextBox OrElse TypeOf control Is RichTextBox Then
                control.BackColor = UiTheme.BgPanel
                control.ForeColor = UiTheme.TextPrimary
            ElseIf TypeOf control Is ComboBox OrElse TypeOf control Is ListBox Then
                control.BackColor = UiTheme.BgPanel
                control.ForeColor = UiTheme.TextPrimary
            ElseIf TypeOf control Is Label OrElse TypeOf control Is LinkLabel Then
                control.ForeColor = UiTheme.TextPrimary
            ElseIf TypeOf control Is GroupBox Then
                control.BackColor = UiTheme.BgDark
                control.ForeColor = UiTheme.TextPrimary
            ElseIf TypeOf control Is ThemeTabControl Then
                UiTheme.ApplyToTabControl(DirectCast(control, ThemeTabControl))
            ElseIf TypeOf control Is ThemeButton OrElse TypeOf control Is ThemeButtonImge Then
                UiTheme.ApplyThemeButtonColors(control)
            ElseIf TypeOf control Is VisualStudioVerticalScrollBar Then
                UiTheme.ApplyVerticalScrollBarTheme(DirectCast(control, VisualStudioVerticalScrollBar))
            ElseIf TypeOf control Is VisualStudioHorizontalScrollBar Then
                UiTheme.ApplyHorizontalScrollBarTheme(DirectCast(control, VisualStudioHorizontalScrollBar))
            End If
        End Sub

        Private Sub ApplyThemeTextBox(box As ThemeTextBox)
            box._CVK_S = UiTheme.BgPanel
            box.__CLRXX_S = UiTheme.TextPrimary
            box.__CLRXX_SLave = UiTheme.TextMuted
            box._CBorderEnabled0_S = UiTheme.Border
            box._CBorderEnabled1_S = UiTheme.Border
            box._CBorderEnter0_S = UiTheme.Accent
            box._CBorderEnter1_S = UiTheme.Accent
            box._CBorderLave0_S = UiTheme.AccentMuted
            box._CBorderLave1_S = UiTheme.AccentMuted
            If box.HTBTB IsNot Nothing Then
                box.HTBTB.BackColor = UiTheme.BgPanel
                box.HTBTB.ForeColor = UiTheme.TextPrimary
            End If
        End Sub

        Private Sub ApplyVerticalScrollBarTheme(bar As VisualStudioVerticalScrollBar)
            bar.BaseColour = UiTheme.BgDeep
            bar.ThumbNormalColour = UiTheme.AccentMuted
            bar.ThumbHoverColour = UiTheme.Accent
            bar.ThumbPressedColour = UiTheme.AccentActive
            bar.LenColour = UiTheme.Accent
            bar.OuterBorderColour = UiTheme.Border
            bar.ThumbBorderColour = UiTheme.Border
        End Sub

        Private Sub ApplyHorizontalScrollBarTheme(bar As VisualStudioHorizontalScrollBar)
            bar.BaseColour = UiTheme.BgDeep
            bar.ThumbNormalColour = UiTheme.AccentMuted
            bar.ThumbHoverColour = UiTheme.Accent
            bar.ThumbPressedColour = UiTheme.AccentActive
            bar.OuterBorderColour = UiTheme.Border
            bar.ThumbBorderColour = UiTheme.Border
        End Sub

        Private Sub ApplyThemeButtonColors(control As Control)
            Dim backNone0 = control.GetType().GetProperty("backColorNone0")
            Dim backNone1 = control.GetType().GetProperty("backColorNone1")
            Dim backOver0 = control.GetType().GetProperty("backColorOver0")
            Dim backOver1 = control.GetType().GetProperty("backColorOver1")
            Dim backDown0 = control.GetType().GetProperty("backColorDown0")
            Dim backDown1 = control.GetType().GetProperty("backColorDown1")
            Dim border = control.GetType().GetProperty("ThemeButtonclrBorder")
            Dim borderActive = control.GetType().GetProperty("ThemeButtonclrBorderactive")
            Dim forColor = control.GetType().GetProperty("ButtonForColor")
            If backNone0 IsNot Nothing Then
                backNone0.SetValue(control, UiTheme.BgPanel, Nothing)
            End If
            If backNone1 IsNot Nothing Then
                backNone1.SetValue(control, UiTheme.BgPanel, Nothing)
            End If
            If backOver0 IsNot Nothing Then
                backOver0.SetValue(control, UiTheme.AccentMuted, Nothing)
            End If
            If backOver1 IsNot Nothing Then
                backOver1.SetValue(control, UiTheme.AccentMuted, Nothing)
            End If
            If backDown0 IsNot Nothing Then
                backDown0.SetValue(control, UiTheme.Accent, Nothing)
            End If
            If backDown1 IsNot Nothing Then
                backDown1.SetValue(control, UiTheme.Accent, Nothing)
            End If
            If border IsNot Nothing Then
                border.SetValue(control, UiTheme.Border, Nothing)
            End If
            If borderActive IsNot Nothing Then
                borderActive.SetValue(control, UiTheme.Accent, Nothing)
            End If
            If forColor IsNot Nothing Then
                forColor.SetValue(control, UiTheme.TextPrimary, Nothing)
            End If
        End Sub

        Private Sub ApplyGridTheme(grid As DataGridView)
            grid.BackgroundColor = UiTheme.BgGrid
            grid.GridColor = UiTheme.Border
            grid.DefaultCellStyle.BackColor = UiTheme.BgGrid
            grid.DefaultCellStyle.ForeColor = UiTheme.TextMuted
            grid.DefaultCellStyle.SelectionBackColor = Color.FromArgb(100, 18, 26)
            grid.DefaultCellStyle.SelectionForeColor = UiTheme.TextPrimary
            grid.ColumnHeadersDefaultCellStyle.BackColor = UiTheme.BgBlack
            grid.ColumnHeadersDefaultCellStyle.ForeColor = UiTheme.TextPrimary
            grid.ColumnHeadersDefaultCellStyle.SelectionBackColor = UiTheme.BgBlack
            grid.ColumnHeadersDefaultCellStyle.SelectionForeColor = UiTheme.TextPrimary
        End Sub
    End Module
End Namespace
