Imports System
Imports System.Text.RegularExpressions
Imports System.Windows.Forms
Imports NeteaseMuisc
Imports Microsoft.Win32
Imports System.Runtime

Public Class Music

#Region "窗口拖动"
    Dim x1, x2, y1, y2 As Integer

    '鼠标左键按下后将x1,y1赋值
    Private Sub Panel1_MouseDown(sender As Object, e As MouseEventArgs) Handles Panel1.MouseDown
        If e.Button = Windows.Forms.MouseButtons.Left Then
            x1 = e.X
            y1 = e.Y
        End If
    End Sub
    '拖动过程中不断对x2,y2赋值
    Private Sub Panel1_MouseMove(sender As Object, e As MouseEventArgs) Handles Panel1.MouseMove
        If e.Button = Windows.Forms.MouseButtons.Left Then
            x2 = e.X
            y2 = e.Y
            Me.Left = Me.Location.X + (x2 - x1)
            Me.Top = Me.Location.Y + (y2 - y1)
        End If
    End Sub
#End Region

    Class pStatus
        Public Property Null = 0
        Public Property Serach = 1
        Public Property OnPlay = 2
    End Class  'UI状态类

    Public Property PlayStatus As New pStatus '当前UI状态

    Private Sub search_Click(sender As Object, e As EventArgs) Handles search.Click  '这里是搜索事件（核心）
        list_message.Items.Clear()
        list_message.Items.Add("正在搜索……")
        Dim api = New NeteaseMusicAPI() '这里用到下面的两个Class
        Dim apires = api.Search(music_name_s.Text) '传入内容
        Dim songmessage = "" '搜到的歌的信息先弄一个对象
        Try
            For Each song In apires.Result.Songs '循环读取歌曲信息
                songmessage += String.Format("@{0} - {1} !{2}! #", song.Name, song.Ar(0).Name, api.GetSongsUrl(New Long() {song.Id}).Data(0).Url)
            Next
            Dim web = New Regex("@(.*?)#") '读取规则@和#之间的内容
            Dim matches_web As MatchCollection = web.Matches(songmessage)
            list_message.Items.Clear()
            For Each m As Match In matches_web '循环读取内容
                list_message.Items.Add(String.Format("{0}", m.Groups(1).Value)) '添加到list中
            Next
        Catch ex As Exception
        End Try
    End Sub

    Private Sub list_message_DoubleClick(sender As Object, e As EventArgs) Handles list_message.DoubleClick '双击列表的事件
        Dim address = New Regex("!(.*?)!") '这里的理解和下面一样
        Dim matches_name As MatchCollection = address.Matches(Me.list_message.SelectedItem.ToString())
        For Each m As Match In matches_name
            music_play.URL = String.Format("{0}", m.Groups(1).Value) '调用MediaPlayer播放获取到的链接music_play.Ctlcontrols.play()
            If Me.music_play.URL.ToString() = "" Or Me.music_play.URL.ToString = vbNullString Then
                MsgBox("在播放该歌曲的时候出现了问题……", 16)
            End If
        Next
    End Sub

    Private Sub Music_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Environment.OSVersion.Version.Major < 6 Then '判断是否是Vista一下的系统
            MsgBox("请在Windows Vista或更高版本的Windows上执行此程序", 16)
            End
        ElseIf Environment.OSVersion.Version.Major = 6 Then '判断Windows 7或Vista
            If Environment.OSVersion.Version.Minor = 1 Or Environment.OSVersion.Version.Minor = 0 Then
                'ChangeThemeForAero()
            Else 'Windows 8及以上版本的Win系统
                Dim FormTitleColor As Boolean = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Software\Microsoft\Windows\DWM", "ColorPrevalence", True)
                Dim R As Integer = 255
                Dim G As Integer = 255
                Dim B As Integer = 255
                If FormTitleColor Then
                    Dim FormColorSource As String = Hex(My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Software\Microsoft\Windows\DWM", "ColorizationColor", Int32.Parse("FF000000", Globalization.NumberStyles.HexNumber)))
                    R = Int32.Parse(FormColorSource.Substring(2, 2), Globalization.NumberStyles.HexNumber)
                    G = Int32.Parse(FormColorSource.Substring(4, 2), Globalization.NumberStyles.HexNumber)
                    B = Int32.Parse(FormColorSource.Substring(6, 2), Globalization.NumberStyles.HexNumber)
                End If
                Me.Panel1.BackColor = Color.FromArgb(255, R, G, B)
                Me.search.Top = Me.music_name_s.Top
                Me.search.Height = Me.music_name_s.Height
            End If
        End If
    End Sub

End Class
