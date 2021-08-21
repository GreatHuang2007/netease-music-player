<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Music
    Inherits System.Windows.Forms.Form

    'Form 重写 Dispose，以清理组件列表。
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Windows 窗体设计器所必需的
    Private components As System.ComponentModel.IContainer

    '注意: 以下过程是 Windows 窗体设计器所必需的
    '可以使用 Windows 窗体设计器修改它。  
    '不要使用代码编辑器修改它。
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Music))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.music_name_s = New System.Windows.Forms.TextBox()
        Me.list_message = New System.Windows.Forms.ListBox()
        Me.music_play = New AxWMPLib.AxWindowsMediaPlayer()
        Me.search = New System.Windows.Forms.Button()
        Me.Panel1.SuspendLayout()
        CType(Me.music_play, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.SystemColors.Control
        Me.Panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Panel1.Controls.Add(Me.music_name_s)
        Me.Panel1.Controls.Add(Me.search)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(980, 77)
        Me.Panel1.TabIndex = 0
        '
        'music_name_s
        '
        Me.music_name_s.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.music_name_s.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.music_name_s.Location = New System.Drawing.Point(123, 20)
        Me.music_name_s.Margin = New System.Windows.Forms.Padding(6, 7, 6, 7)
        Me.music_name_s.Name = "music_name_s"
        Me.music_name_s.Size = New System.Drawing.Size(581, 34)
        Me.music_name_s.TabIndex = 6
        '
        'list_message
        '
        Me.list_message.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.list_message.Dock = System.Windows.Forms.DockStyle.Fill
        Me.list_message.FormattingEnabled = True
        Me.list_message.ItemHeight = 27
        Me.list_message.Location = New System.Drawing.Point(0, 77)
        Me.list_message.Margin = New System.Windows.Forms.Padding(6, 7, 6, 7)
        Me.list_message.Name = "list_message"
        Me.list_message.ScrollAlwaysVisible = True
        Me.list_message.Size = New System.Drawing.Size(980, 458)
        Me.list_message.TabIndex = 2
        '
        'music_play
        '
        Me.music_play.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.music_play.Enabled = True
        Me.music_play.Location = New System.Drawing.Point(0, 535)
        Me.music_play.Margin = New System.Windows.Forms.Padding(6, 7, 6, 7)
        Me.music_play.Name = "music_play"
        Me.music_play.OcxState = CType(resources.GetObject("music_play.OcxState"), System.Windows.Forms.AxHost.State)
        Me.music_play.Size = New System.Drawing.Size(980, 45)
        Me.music_play.TabIndex = 3
        '
        'search
        '
        Me.search.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.search.BackColor = System.Drawing.SystemColors.Control
        Me.search.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.search.Location = New System.Drawing.Point(716, 20)
        Me.search.Margin = New System.Windows.Forms.Padding(6, 7, 6, 7)
        Me.search.Name = "search"
        Me.search.Size = New System.Drawing.Size(114, 34)
        Me.search.TabIndex = 5
        Me.search.Text = "搜索"
        Me.search.UseVisualStyleBackColor = False
        '
        'Music
        '
        Me.AcceptButton = Me.search
        Me.AutoScaleDimensions = New System.Drawing.SizeF(12.0!, 27.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Window
        Me.ClientSize = New System.Drawing.Size(980, 580)
        Me.Controls.Add(Me.list_message)
        Me.Controls.Add(Me.music_play)
        Me.Controls.Add(Me.Panel1)
        Me.Font = New System.Drawing.Font("微软雅黑", 12.0!)
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Name = "Music"
        Me.Text = "Netease Music Player"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.music_play, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Private WithEvents music_name_s As TextBox
    Friend WithEvents list_message As ListBox
    Private WithEvents music_play As AxWMPLib.AxWindowsMediaPlayer
    Private WithEvents search As Button
End Class
