Imports MusicUI
Imports NeteaseMuisc
Imports Microsoft.Win32
Imports System
Imports System.ComponentModel
Imports System.Runtime
Imports System.Text.RegularExpressions
Imports System.Threading
Imports System.Windows.Forms

Public Class Music

#Region "自定义标题栏"
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
    '双击最大化/还原窗口
    Private Sub Panels_DoubleCLick(sender As Object, e As MouseEventArgs) Handles Panel1.MouseDoubleClick, Panel2.MouseDoubleClick
        Select Case Me.WindowState
            Case FormWindowState.Maximized
                Me.WindowState = FormWindowState.Normal
            Case FormWindowState.Normal
                Me.WindowState = FormWindowState.Maximized
        End Select
    End Sub

#End Region

    Class pStatus
        Public ReadOnly Property Null = 0
        Public ReadOnly Property Search = 1
        Public ReadOnly Property OnSearch = 2
        Public ReadOnly Property OnPlay = 3
        Public ReadOnly Property JustPlayer = 4
    End Class  '表示UI状态的类

    Public PlayStatus As New pStatus
    Property PlayState As Integer = PlayStatus.Null '当前UI状态

    Public Sub UpdateUIState() '更新UI状态
        Me.Panel2.Enabled = False
        Me.Panel2.Visible = False
        With Me.PlayStatus
            Select Case Me.PlayState
                Case .Null
                    Me.list_message.Dock = DockStyle.Fill
                    Me.list_message.Enabled = False
                    Me.list_message.Visible = True
                    Me.music_play.Dock = DockStyle.Bottom
                    Me.music_name_s.Enabled = True
                    Me.search.Enabled = True
                    Me.search.Text = "搜索"
                    Me.bt_Back.Enabled = False
                    Me.bt_Back.Visible = False
                Case .Search
                    Me.list_message.Dock = DockStyle.Fill
                    Me.list_message.Enabled = True
                    Me.list_message.Visible = True
                    Me.music_play.Dock = DockStyle.Bottom
                    Me.music_play.Height = 45
                    Me.music_name_s.Enabled = True
                    Me.search.Enabled = True
                    Me.search.Text = "搜索"
                    Me.bt_Back.Text = "↑"
                    If Me.music_play.URL = "" Or Me.music_play.URL = vbNullString Then
                        Me.bt_Back.Enabled = False
                        Me.bt_Back.Visible = False
                    Else
                        Me.bt_Back.Enabled = True
                        Me.bt_Back.Visible = True
                    End If
                    Me.bt_Back.ForeColor = Me.search.ForeColor
                    Me.bt_Back.BackColor = Me.search.BackColor
                Case .OnSearch
                    Me.list_message.Dock = DockStyle.Fill
                    Me.list_message.Enabled = False
                    Me.list_message.Visible = True
                    Me.music_play.Dock = DockStyle.Bottom
                    Me.music_name_s.Enabled = False
                    Me.search.Enabled = True
                    Me.search.Text = "取消"
                    Me.bt_Back.Enabled = False
                    Me.bt_Back.Visible = False
                Case .OnPlay
                    Me.Panel2.Enabled = True
                    Me.Panel2.Visible = True
                    Me.list_message.Enabled = False
                    Me.list_message.Visible = False
                    Me.music_play.Dock = DockStyle.Fill
                    Me.music_name_s.Enabled = False
                    Me.search.Enabled = False
                    Me.bt_Back.Text = "←"
                    Me.bt_Back.Enabled = True
                    Me.bt_Back.Visible = True
                    Dim SongName As String = Replace(Me.list_message.SelectedItem.ToString(), "!" & Me.music_play.URL & "!", " ")
                    Me.lb_OnPlay.Text = "正在播放：" + SongName
                    TitleActive()
                Case .JustPlayer
                    Me.Panel2.Enabled = True
                    Me.Panel2.Visible = True
                    Me.list_message.Enabled = False
                    Me.list_message.Visible = False
                    Me.music_play.Dock = DockStyle.Fill
                    Me.music_name_s.Enabled = False
                    Me.search.Enabled = False
                    Me.bt_Back.Text = "←"
                    Me.bt_Back.Enabled = True
                    Me.bt_Back.Visible = True
                    TitleActive()
            End Select
        End With
    End Sub

    Sub SearchMusic() '搜索音乐的Sub
        Dim api '这里用到下面的两个Class
        Dim apires '传入内容
        Dim songmessage = "" '搜到的歌的信息先弄一个对象
        Try
            api = New NeteaseMusicAPI() '这里用到下面的两个Class
            apires = api.Search(music_name_s.Text) '传入内容
            For Each song In apires.Result.Songs '循环读取歌曲信息
                songmessage += String.Format("@{0} - {1} !{2}! #", song.Name, song.Ar(0).Name, api.GetSongsUrl(New Long() {song.Id}).Data(0).Url)
            Next
            Dim web = New Regex("@(.*?)#") '读取规则@和#之间的内容
            Dim matches_web As MatchCollection = web.Matches(songmessage)
            Me.music_message.Invoke(New Action(Sub()
                                                   music_message.Items.Clear()
                                                   For Each m As Match In matches_web '循环读取内容
                                                       music_message.Items.Add(String.Format("{0}", m.Groups(1).Value)) '添加到list中
                                                   Next
                                               End Sub))
            Me.Invoke(Sub()
                          Me.list_message.Items.Clear()
                          For Each songName In music_message.Items
                              Dim address = New Regex("!(.*?)!") '这里的理解和下面一样
                              Dim matches_name As MatchCollection = address.Matches(songName.ToString())
                              For Each m As Match In matches_name
                                  Dim URL As String
                                  URL = String.Format("{0}", m.Groups(1).Value)
                                  If URL = "" Or URL = vbNullString Then
                                      Dim SgName As String = Replace(songName.ToString(), "!" & URL & "!", " ")
                                      Me.list_message.Items.Add(" " + SgName + " !")
                                  Else
                                      Dim SgName As String = Replace(songName.ToString(), "!" & URL & "!", " ")
                                      Me.list_message.Items.Add(" " + SgName)
                                  End If
                              Next
                          Next
                          Me.PlayState = PlayStatus.Search
                          UpdateUIState()
                      End Sub)
        Catch ex As Exception
            With Me.list_message.Items
                list_message.Invoke(Sub()
                                        .Clear()
                                        .Add("")
                                        .Add("  在搜索时发生了错误……")
                                        .Add("  详细信息：" + ex.Message)
                                        Me.PlayState = PlayStatus.Null()
                                        UpdateUIState()
                                    End Sub)
            End With
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
            list_message.Items.Add("")
            list_message.Items.Add("  正在搜索……")
            SearchThd.Start() '开始音乐搜索线程
        ElseIf PlayState = PlayStatus.OnSearch Then
            Me.PlayState = PlayStatus.Search '修改播放状态
            UpdateUIState() '更新UI状态
            list_message.Items.Clear()
            list_message.Items.Add("")
            list_message.Items.Add("  已取消搜索")
            SearchThd.Suspend()
            SearchThd.Abort()
        End If
    End Sub

    Private Sub list_message_DoubleClick(sender As Object, e As EventArgs) Handles list_message.DoubleClick '双击列表的事件
        If Not (Me.PlayState = PlayStatus.Null Or Me.PlayState = PlayStatus.OnSearch) Then
            Dim address = New Regex("!(.*?)!") '这里的理解和下面一样
            Dim matches_name As MatchCollection = address.Matches(Me.music_message.Items(Me.list_message.SelectedIndex))
            For Each m As Match In matches_name
                music_play.URL = String.Format("{0}", m.Groups(1).Value) '调用MediaPlayer播放获取到的链接music_play.Ctlcontrols.play()
                If Me.music_play.URL.ToString() = "" Or Me.music_play.URL.ToString = vbNullString Then
                    UpdateUIState()
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
        If Environment.OSVersion.Version.Major < 6 Then '判断是否是Vista以下的系统
            MsgBox("请在Windows Vista或更高版本的Windows上执行此程序", 16)
            End
        ElseIf Environment.OSVersion.Version.Major = 6 Then '判断Windows 7或Vista
            If Environment.OSVersion.Version.Minor = 1 Or Environment.OSVersion.Version.Minor = 0 Then
                Me.Panel1.BackColor = System.Drawing.SystemColors.Highlight
                With SystemColors.Highlight
                    Me.lb_OnPlay.ForeColor = CalcBorW(.R, .G, .B) '设置标题栏字体颜色为黑色或白色
                    Me.bt_Back.BackColor = Me.search.BackColor()
                    Me.bt_Back.ForeColor = Me.search.ForeColor()
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
                Me.lb_OnPlay.ForeColor = CalcBorW(R, G, B) '设置标题栏字体颜色为黑色或白色\
                Me.music_name_s.Top = 10
                Me.music_name_s.Left = 123
                Me.search.Left = Me.Width - 123 - Me.search.Width
                Me.music_name_s.Width = Me.Width - Me.search.Width - 123 * 2 - 15
                Me.bt_Back.BackColor = Me.lb_OnPlay.ForeColor
                Me.bt_Back.ForeColor = Me.Panel1.BackColor
                Me.lb_OnPlay.Top = Me.search.Top + (Me.search.Height - Me.lb_OnPlay.Height) / 2
                Me.Panel1.Height = Me.music_name_s.Height + 25
            End If
        End If
    End Sub

    Private Sub bt_Back_Click(sender As Object, e As EventArgs) Handles bt_Back.Click
        Select Case Me.PlayState
            Case PlayStatus.Search
                Me.PlayState = PlayStatus.JustPlayer
            Case PlayStatus.OnPlay
                Me.PlayState = PlayStatus.Search
            Case PlayStatus.JustPlayer
                Me.PlayState = PlayStatus.Search
            Case Else
                Me.bt_Back.Enabled = False
                Me.bt_Back.Visible = False
        End Select
        UpdateUIState()
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
        Me.bt_Back.Top = Me.search.Top
        Me.bt_Back.Height = Me.search.Height
        Me.bt_Back.Width = Me.bt_Back.Height
        Me.list_message.Items.Clear()
        list_message.Items.Add("")
        Me.list_message.Items.Add("  空空如也，不如搜索些什么吧！")
        UpdateUIState()
    End Sub

    Private Sub Music_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing  '关闭窗口
        End
    End Sub
End Class
