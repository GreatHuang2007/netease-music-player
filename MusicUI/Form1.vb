Imports System
Imports System.Text.RegularExpressions
Imports System.Windows.Forms
Imports NeteaseMuisc
Imports Microsoft.Win32
Imports System.Runtime
Imports System.Threading
Imports System.ComponentModel

Public Class Music

#Region "窗口拖动"
    Dim x1, x2, y1, y2 As Integer

    '鼠标左键按下后将x1,y1赋值
    Private Sub Panels_MouseDown(sender As Object, e As MouseEventArgs) Handles Panel1.MouseDown, Panel2.MouseDown, lb_OnPlay.MouseDown
        If e.Button = Windows.Forms.MouseButtons.Left Then
            x1 = e.X
            y1 = e.Y
        End If
    End Sub
    '拖动过程中不断对x2,y2赋值
    Private Sub Panels_MouseMove(sender As Object, e As MouseEventArgs) Handles Panel1.MouseMove, Panel2.MouseMove, lb_OnPlay.MouseMove
        If e.Button = Windows.Forms.MouseButtons.Left And Me.WindowState = FormWindowState.Normal Then
            x2 = e.X
            y2 = e.Y
            Me.Left = Me.Location.X + (x2 - x1)
            Me.Top = Me.Location.Y + (y2 - y1)
        End If
    End Sub
#End Region

    Class pStatus
        Public ReadOnly Property Null = 0
        Public ReadOnly Property Search = 1
        Public ReadOnly Property OnSearch = 2
        Public ReadOnly Property OnPlay = 3
    End Class  '表示UI状态的类

    Public PlayStatus As New pStatus
    Property PlayState As Integer = PlayStatus.Null '当前UI状态

    Public Sub UpdateUIState() '更新UI状态
        Me.Panel2.Enabled = False
        Me.Panel2.Visible = False
        Select Case Me.PlayState
            Case PlayStatus.Null
                Me.list_message.Dock = DockStyle.Fill
                Me.list_message.Enabled = True
                Me.list_message.Visible = True
                Me.music_play.Dock = DockStyle.Bottom
                Me.music_name_s.Enabled = True
                Me.search.Enabled = True
                Me.search.Text = "搜索"
            Case PlayStatus.Search
                Me.list_message.Dock = DockStyle.Fill
                Me.list_message.Enabled = True
                Me.list_message.Visible = True
                Me.music_play.Dock = DockStyle.Bottom
                Me.music_name_s.Enabled = True
                Me.search.Enabled = True
                Me.search.Text = "搜索"
            Case PlayStatus.OnSearch
                Me.list_message.Dock = DockStyle.Fill
                Me.list_message.Enabled = True
                Me.list_message.Visible = True
                Me.music_play.Dock = DockStyle.Bottom
                Me.music_name_s.Enabled = False
                Me.search.Enabled = True
                Me.search.Text = "取消"
            Case PlayStatus.OnPlay
                Me.Panel2.Enabled = True
                Me.Panel2.Visible = True
                Me.list_message.Enabled = False
                Me.list_message.Visible = False
                Me.music_play.Dock = DockStyle.Fill
                Me.music_name_s.Enabled = False
                Me.search.Enabled = False
                Dim address = New Regex("!(.*?)!")
                Dim matches_name As MatchCollection = address.Matches(Me.list_message.SelectedItem.ToString())
                Dim SongName As String = Replace(Me.list_message.SelectedItem.ToString(), matches_name.ToString(), " ")
                Me.lb_OnPlay.Text = "正在播放：" + SongName
        End Select
    End Sub

    Sub SearchMusic() '搜索音乐的Sub
        Dim api = New NeteaseMusicAPI() '这里用到下面的两个Class
        Dim apires = api.Search(music_name_s.Text) '传入内容
        Dim songmessage = "" '搜到的歌的信息先弄一个对象
        Try
            For Each song In apires.Result.Songs '循环读取歌曲信息
                songmessage += String.Format("@{0} - {1} !{2}! #", song.Name, song.Ar(0).Name, api.GetSongsUrl(New Long() {song.Id}).Data(0).Url)
            Next
            Dim web = New Regex("@(.*?)#") '读取规则@和#之间的内容
            Dim matches_web As MatchCollection = web.Matches(songmessage)
            If Me.list_message.InvokeRequired Then
                Me.list_message.Invoke(New Action(Sub()
                                                      list_message.Items.Clear()
                                                      For Each m As Match In matches_web '循环读取内容
                                                          list_message.Items.Add(String.Format("{0}", m.Groups(1).Value)) '添加到list中
                                                      Next
                                                  End Sub))
            End If
            Me.Invoke(Sub()
                          Me.PlayState = PlayStatus.Search
                          UpdateUIState()
                      End Sub)
        Catch ex As Exception
            MsgBox("在搜索歌曲时发生了错误..."， 16)
        End Try
    End Sub

    Dim SearchThd As Thread '搜索音乐的线程

    <Obsolete>
    Private Sub search_Click(sender As Object, e As EventArgs) Handles search.Click  '这里是搜索事件（核心）
        If PlayState = PlayStatus.Search Or PlayState = PlayStatus.Null Then
            Me.PlayState = PlayStatus.OnSearch '修改播放状态
            UpdateUIState() '更新UI状态
            SearchThd = New Thread(AddressOf Me.SearchMusic) '创建新的搜索线程
            list_message.Items.Clear()
            list_message.Items.Add("正在搜索……")
            SearchThd.Start() '开始音乐搜索线程
        ElseIf PlayState = PlayStatus.OnSearch Then
            Me.PlayState = PlayStatus.Search '修改播放状态
            UpdateUIState() '更新UI状态
            list_message.Items.Clear()
            list_message.Items.Add("已取消搜索")
            SearchThd.Suspend()
            SearchThd.Abort()
        End If
    End Sub

    Private Sub list_message_DoubleClick(sender As Object, e As EventArgs) Handles list_message.DoubleClick '双击列表的事件
        If Not (Me.PlayState = PlayStatus.Null Or Me.PlayState = PlayStatus.OnSearch) Then
            Dim address = New Regex("!(.*?)!") '这里的理解和下面一样
            Dim matches_name As MatchCollection = address.Matches(Me.list_message.SelectedItem.ToString())
            For Each m As Match In matches_name
                music_play.URL = String.Format("{0}", m.Groups(1).Value) '调用MediaPlayer播放获取到的链接music_play.Ctlcontrols.play()
                If Me.music_play.URL.ToString() = "" Or Me.music_play.URL.ToString = vbNullString Then
                    MsgBox("在试图播放该歌曲的时候出现了问题……", 16)
                Else
                    Me.PlayState = PlayStatus.OnPlay
                    UpdateUIState() '更新UI状态
                End If
            Next
        End If
    End Sub

    Public Function CalcBorW(ByVal red As Integer, ByVal green As Integer, ByVal blue As Integer) As Color
        If (red * 0.299 + green * 0.587 + blue * 0.114) > 186 Then
            Return Color.Black
        Else
            Return Color.White
        End If
    End Function

    Public Sub TitleActive()  '窗口得到焦点
        If Environment.OSVersion.Version.Major < 6 Then '判断是否是Vista一下的系统
            MsgBox("请在Windows Vista或更高版本的Windows上执行此程序", 16)
            End
        ElseIf Environment.OSVersion.Version.Major = 6 Then '判断Windows 7或Vista
            If Environment.OSVersion.Version.Minor = 1 Or Environment.OSVersion.Version.Minor = 0 Then
                Me.Panel1.BackColor = System.Drawing.SystemColors.Highlight
                With SystemColors.Highlight
                    Me.lb_OnPlay.ForeColor = CalcBorW(.R, .G, .B) '设置标题栏字体颜色为黑色或白色
                End With
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
                Me.lb_OnPlay.ForeColor = CalcBorW(R, G, B) '设置标题栏字体颜色为黑色或白色
            End If
        End If
    End Sub

    Public Sub TitleInactive()  '窗口失去焦点
        If Environment.OSVersion.Version.Major = 6 Then '判断Windows 7或Vista
            If Environment.OSVersion.Version.Minor = 1 Or Environment.OSVersion.Version.Minor = 0 Then
                Me.Panel1.BackColor = System.Drawing.SystemColors.Highlight
            Else 'Windows 8及以上版本的Win系统
                Me.Panel1.BackColor = Color.White
            End If
        End If
    End Sub

    Private Sub Music_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TitleActive()
        Me.search.Top = Me.music_name_s.Top
        Me.search.Height = Me.music_name_s.Height
        Me.list_message.Items.Clear()
        Me.list_message.Items.Add("空空如也，不如搜索些什么吧！")
    End Sub

    Private Sub Music_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing  '关闭窗口
        End
    End Sub
End Class
