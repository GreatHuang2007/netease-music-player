namespace NeteaseMuisc
{
    partial class Music
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Music));
            this.list_message = new System.Windows.Forms.ListBox();
            this.music_play = new AxWMPLib.AxWindowsMediaPlayer();
            this.music_name_s = new System.Windows.Forms.TextBox();
            this.search = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.music_play)).BeginInit();
            this.SuspendLayout();
            // 
            // list_message
            // 
            this.list_message.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.list_message.FormattingEnabled = true;
            this.list_message.ItemHeight = 15;
            this.list_message.Location = new System.Drawing.Point(16, 60);
            this.list_message.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.list_message.Name = "list_message";
            this.list_message.ScrollAlwaysVisible = true;
            this.list_message.Size = new System.Drawing.Size(569, 319);
            this.list_message.TabIndex = 1;
            this.list_message.SelectedIndexChanged += new System.EventHandler(this.list_name_SelectedIndexChanged);
            this.list_message.DoubleClick += new System.EventHandler(this.list_name_DoubleClick);
            // 
            // music_play
            // 
            this.music_play.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.music_play.Enabled = true;
            this.music_play.Location = new System.Drawing.Point(0, 401);
            this.music_play.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.music_play.Name = "music_play";
            this.music_play.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("music_play.OcxState")));
            this.music_play.Size = new System.Drawing.Size(603, 45);
            this.music_play.TabIndex = 2;
            // 
            // music_name_s
            // 
            this.music_name_s.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.music_name_s.Location = new System.Drawing.Point(16, 15);
            this.music_name_s.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.music_name_s.Name = "music_name_s";
            this.music_name_s.Size = new System.Drawing.Size(485, 25);
            this.music_name_s.TabIndex = 3;
            this.music_name_s.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // search
            // 
            this.search.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.search.Location = new System.Drawing.Point(511, 15);
            this.search.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.search.Name = "search";
            this.search.Size = new System.Drawing.Size(76, 25);
            this.search.TabIndex = 4;
            this.search.Text = "搜索";
            this.search.UseVisualStyleBackColor = true;
            this.search.Click += new System.EventHandler(this.search_Click);
            // 
            // Music
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(603, 446);
            this.Controls.Add(this.search);
            this.Controls.Add(this.music_name_s);
            this.Controls.Add(this.music_play);
            this.Controls.Add(this.list_message);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Music";
            this.Text = "Netease Music Player";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.music_play)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ListBox list_message;
        private AxWMPLib.AxWindowsMediaPlayer music_play;
        private System.Windows.Forms.TextBox music_name_s;
        private System.Windows.Forms.Button search;
    }
}