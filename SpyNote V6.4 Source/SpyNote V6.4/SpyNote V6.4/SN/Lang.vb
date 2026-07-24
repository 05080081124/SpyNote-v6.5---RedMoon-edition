Imports System.Collections.Generic
Imports System.Windows.Forms
Imports Microsoft.VisualBasic.CompilerServices
Imports SpyNote_V6._4.SN.SPYXml

Namespace SN
    Public Module Lang
        Public CurrentCulture As String = "en"

        Private ReadOnly Ru As Dictionary(Of String, String)
        Private ReadOnly WiredForms As HashSet(Of Integer)

        Sub New()
            Lang.Ru = New Dictionary(Of String, String)(StringComparer.OrdinalIgnoreCase) From {
                {"Tools", "Tools"},
                {"View", "View"},
                {"Help", "Help"},
                {"About SpyNote", "About SpyNote"},
                {"Payload", "Payload"},
                {"Options", "Options"},
                {"Connections Log", "Connections Log"},
                {"Black List", "Black List"},
                {"Monitor Android", "Monitor Android"},
                {"Informations", "Information"},
                {"On Login Show Alert", "Show alert on login"},
                {"Port", "Port"},
                {"Password", "Password"},
                {"Defend Against DDOS Attack", "DDoS protection"},
                {"OK", "OK"},
                {"Cancel", "Cancel"},
                {"Close", "Close"},
                {"Add", "Add"},
                {"Delete", "Delete"},
                {"Refresh", "Refresh"},
                {"Delete all items", "Delete all items"},
                {"Delete selected item", "Delete selected item"},
                {"Auto Delete items", "Auto-delete items"},
                {"Scroll to the end", "Scroll to end"},
                {"Maximized", "Maximize"},
                {"Address:", "Address:"},
                {"Server Info", "Server info"},
                {"Online", "Online"},
                {"Connections", "Connections"},
                {"Request Data", "Request data"},
                {"Received Data ", "Received data"},
                {"Sent Data", "Sent data"},
                {"DDoS Protection", "DDoS protection"},
                {"HostName", "Hostname"},
                {"LocalIP", "Local IP"},
                {"Download", "Download"},
                {"Upload", "Upload"},
                {"Interface type", "Interface type"},
                {"MAC-Addres", "MAC address"},
                {"Network Status", "Network status"},
                {"Network Multicast", "Network multicast"},
                {"Speed", "Speed"},
                {"Network Name", "Network name"},
                {"StartTime", "Start time"},
                {"Threads", "Threads"},
                {"CPU Usage", "CPU usage"},
                {"Mem(Private Bytes)", "Memory (private bytes)"},
                {"Mem(Working Set)", "Memory (working set)"},
                {"Language", "Language"},
                {"English", "English"},
                {"Russian", "Russian"},
                {"File Manager", "File Manager"},
                {"SMS Manager", "SMS Manager"},
                {"Calls Manager", "Calls Manager"},
                {"Contacts Manager", "Contacts Manager"},
                {"Location Manager", "Location Manager"},
                {"Account Manager", "Account Manager"},
                {"Camera Manager", "Camera Manager"},
                {"Screen", "Screen"},
                {"Shell Terminal", "Shell terminal"},
                {"Applications", "Applications"},
                {"Microphone", "Microphone"},
                {"Keylogger", "Keylogger"},
                {"Settings", "Settings"},
                {"Phone", "Phone"},
                {"Chat", "Chat"},
                {"Fun", "Fun"},
                {"Reconnect", "Reconnect"},
                {"To Black List", "Add to blacklist"},
                {"Clients Folder", "Clients folder"},
                {"Building Folder", "Build folder"},
                {"Receive Connection", "Receive connection"},
                {"Check Ports", "Check ports"},
                {"Fail", "Invalid port"}
            }

            Lang.Ru("Tools") = "Инструменты"
            Lang.Ru("View") = "Вид"
            Lang.Ru("Help") = "Справка"
            Lang.Ru("About SpyNote") = "О SpyNote"
            Lang.Ru("Payload") = "Сборка"
            Lang.Ru("Options") = "Настройки"
            Lang.Ru("Connections Log") = "Журнал подключений"
            Lang.Ru("Black List") = "Чёрный список"
            Lang.Ru("Monitor Android") = "Монитор Android"
            Lang.Ru("Informations") = "Информация"
            Lang.Ru("On Login Show Alert") = "Уведомление при входе"
            Lang.Ru("Port") = "Порт"
            Lang.Ru("Password") = "Пароль"
            Lang.Ru("Defend Against DDOS Attack") = "Защита от DDoS"
            Lang.Ru("OK") = "ОК"
            Lang.Ru("Cancel") = "Отмена"
            Lang.Ru("Close") = "Закрыть"
            Lang.Ru("Add") = "Добавить"
            Lang.Ru("Delete") = "Удалить"
            Lang.Ru("Refresh") = "Обновить"
            Lang.Ru("Delete all items") = "Удалить всё"
            Lang.Ru("Delete selected item") = "Удалить выбранное"
            Lang.Ru("Auto Delete items") = "Автоудаление"
            Lang.Ru("Scroll to the end") = "Прокрутить вниз"
            Lang.Ru("Maximized") = "Развернуть"
            Lang.Ru("Address:") = "Адрес:"
            Lang.Ru("Server Info") = "Информация о сервере"
            Lang.Ru("Online") = "Онлайн"
            Lang.Ru("Connections") = "Подключения"
            Lang.Ru("Request Data") = "Запрос данных"
            Lang.Ru("Received Data ") = "Получено данных"
            Lang.Ru("Sent Data") = "Отправлено данных"
            Lang.Ru("DDoS Protection") = "Защита DDoS"
            Lang.Ru("HostName") = "Имя хоста"
            Lang.Ru("LocalIP") = "Локальный IP"
            Lang.Ru("Download") = "Загрузка"
            Lang.Ru("Upload") = "Отдача"
            Lang.Ru("Interface type") = "Тип интерфейса"
            Lang.Ru("MAC-Addres") = "MAC-адрес"
            Lang.Ru("Network Status") = "Статус сети"
            Lang.Ru("Network Multicast") = "Multicast"
            Lang.Ru("Speed") = "Скорость"
            Lang.Ru("Network Name") = "Имя сети"
            Lang.Ru("StartTime") = "Время запуска"
            Lang.Ru("Threads") = "Потоки"
            Lang.Ru("CPU Usage") = "Загрузка CPU"
            Lang.Ru("Mem(Private Bytes)") = "Память (private bytes)"
            Lang.Ru("Mem(Working Set)") = "Память (working set)"
            Lang.Ru("Language") = "Язык"
            Lang.Ru("English") = "English"
            Lang.Ru("Russian") = "Русский"
            Lang.Ru("File Manager") = "Файловый менеджер"
            Lang.Ru("SMS Manager") = "SMS менеджер"
            Lang.Ru("Calls Manager") = "Менеджер звонков"
            Lang.Ru("Contacts Manager") = "Контакты"
            Lang.Ru("Location Manager") = "Геолокация"
            Lang.Ru("Account Manager") = "Аккаунты"
            Lang.Ru("Camera Manager") = "Камера"
            Lang.Ru("Screen") = "Экран"
            Lang.Ru("Shell Terminal") = "Терминал"
            Lang.Ru("Applications") = "Приложения"
            Lang.Ru("Microphone") = "Микрофон"
            Lang.Ru("Keylogger") = "Кейлоггер"
            Lang.Ru("Settings") = "Настройки"
            Lang.Ru("Phone") = "Телефон"
            Lang.Ru("Chat") = "Чат"
            Lang.Ru("Fun") = "Fun"
            Lang.Ru("Reconnect") = "Переподключить"
            Lang.Ru("To Black List") = "В чёрный список"
            Lang.Ru("Clients Folder") = "Папка клиентов"
            Lang.Ru("Building Folder") = "Папка сборки"
            Lang.Ru("Receive Connection") = "Приём подключений"
            Lang.Ru("Check Ports") = "Проверка портов"
            Lang.Ru("Fail") = "Неверный порт"

            Lang.WiredForms = New HashSet(Of Integer)()
        End Sub

        Public Sub Initialize()
            Lang.CurrentCulture = "en"
        End Sub

        Public Sub LoadFromSettings(settings As XMLSettings)
            If settings Is Nothing Then
                Lang.CurrentCulture = "en"
                Return
            End If

            Dim code As String = settings.Reading("value", 6)
            Lang.SetLanguage(code)
        End Sub

        Public Sub SetLanguage(code As String)
            If String.IsNullOrWhiteSpace(code) Then
                Lang.CurrentCulture = "en"
                Return
            End If

            code = code.Trim().ToLowerInvariant()
            Lang.CurrentCulture = If(code = "ru" OrElse code = "rus" OrElse code = "russian", "ru", "en")
        End Sub

        Public Function T(text As String) As String
            If String.IsNullOrEmpty(text) Then
                Return text
            End If

            If Lang.CurrentCulture = "ru" Then
                Dim translated As String = Nothing
                If Lang.Ru.TryGetValue(text, translated) Then
                    Return translated
                End If
                Return text
            End If

            For Each pair As KeyValuePair(Of String, String) In Lang.Ru
                If String.Equals(pair.Value, text, StringComparison.OrdinalIgnoreCase) Then
                    Return pair.Key
                End If
            Next

            Return text
        End Function

        Public Sub WireForm(form As Form)
            If form Is Nothing Then
                Return
            End If

            SyncLock Lang.WiredForms
                If Lang.WiredForms.Contains(form.GetHashCode()) Then
                    Return
                End If
                Lang.WiredForms.Add(form.GetHashCode())
            End SyncLock

            AddHandler form.Load, AddressOf Lang.OnFormLoad
        End Sub

        Private Sub OnFormLoad(sender As Object, e As EventArgs)
            Dim form As Form = TryCast(sender, Form)
            If form Is Nothing Then
                Return
            End If

            Lang.ApplyToForm(form)
        End Sub

        Public Sub ApplyToForm(form As Form)
            If form Is Nothing Then
                Return
            End If

            Lang.ApplyToControlTree(form)
            Lang.ApplyToMenus(form)
        End Sub

        Private Sub ApplyToControlTree(root As Control)
            Lang.ApplyToControl(root)

            For Each child As Control In root.Controls
                Lang.ApplyToControlTree(child)
            Next
        End Sub

        Private Sub ApplyToControl(control As Control)
            If TypeOf control Is Label OrElse TypeOf control Is LinkLabel OrElse TypeOf control Is Button OrElse TypeOf control Is CheckBox Then
                control.Text = Lang.T(control.Text)
            ElseIf TypeOf control Is TabControl Then
                Dim tabs As TabControl = DirectCast(control, TabControl)
                For Each page As TabPage In tabs.TabPages
                    page.Text = Lang.T(page.Text)
                Next
            ElseIf TypeOf control Is DataGridView Then
                Dim grid As DataGridView = DirectCast(control, DataGridView)
                For Each row As DataGridViewRow In grid.Rows
                    For Each cell As DataGridViewCell In row.Cells
                        If cell.Value IsNot Nothing AndAlso TypeOf cell.Value Is String Then
                            cell.Value = Lang.T(Conversions.ToString(cell.Value))
                        End If
                    Next
                Next
            End If
        End Sub

        Private Sub ApplyToMenus(form As Form)
            For Each field As Reflection.FieldInfo In form.GetType().GetFields(Reflection.BindingFlags.Instance Or Reflection.BindingFlags.NonPublic Or Reflection.BindingFlags.Public)
                If GetType(ToolStripMenuItem).IsAssignableFrom(field.FieldType) Then
                    Dim item As ToolStripMenuItem = TryCast(field.GetValue(form), ToolStripMenuItem)
                    Lang.ApplyToMenuItem(item)
                ElseIf GetType(ContextMenuStrip).IsAssignableFrom(field.FieldType) Then
                    Dim menu As ContextMenuStrip = TryCast(field.GetValue(form), ContextMenuStrip)
                    Lang.ApplyToToolStrip(menu)
                ElseIf GetType(MenuStrip).IsAssignableFrom(field.FieldType) Then
                    Dim menu As MenuStrip = TryCast(field.GetValue(form), MenuStrip)
                    Lang.ApplyToToolStrip(menu)
                End If
            Next
        End Sub

        Private Sub ApplyToToolStrip(strip As ToolStrip)
            If strip Is Nothing Then
                Return
            End If

            For Each item As ToolStripItem In strip.Items
                Dim menuItem As ToolStripMenuItem = TryCast(item, ToolStripMenuItem)
                Lang.ApplyToMenuItem(menuItem)
            Next
        End Sub

        Private Sub ApplyToMenuItem(item As ToolStripMenuItem)
            If item Is Nothing Then
                Return
            End If

            item.Text = Lang.T(item.Text)
            For Each child As ToolStripItem In item.DropDownItems
                Dim childMenu As ToolStripMenuItem = TryCast(child, ToolStripMenuItem)
                Lang.ApplyToMenuItem(childMenu)
            Next
        End Sub
    End Module
End Namespace
