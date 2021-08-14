using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;


namespace NeteaseMuisc
{
    public partial class Music : Form
    {
        public Music()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {


        }

        private void list_name_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void list_name_DoubleClick(object sender, EventArgs e)//双击列表的事件
        {
            var address = new Regex("!(.*?)!");//这里的理解和下面一样
            MatchCollection matches_name = address.Matches(this.list_message.SelectedItem.ToString());
            foreach (Match m in matches_name)
            {
                music_play.URL = string.Format("{0}", m.Groups[1].Value);//调用MediaPlayer播放获取到的链接                music_play.Ctlcontrols.play();
            }

        }

        private void textBox1_TextChanged(object sender, EventArgs e)//这个用不到
        {

        }

        private void search_Click(object sender, EventArgs e)//这里是搜索事件（核心）
        {
         list_message.Items.Clear();
            list_message.Items.Add("正在搜索……");
            var api = new NeteaseMusicAPI();//这里用到下面的两个Class
            var apires = api.Search(music_name_s.Text);//传入内容
            var songmessage = "";//搜到的歌的信息先弄一个var
            foreach (var song in apires.Result.Songs)//循环读取歌曲信息
            {
                songmessage += string.Format("@{0} - {1} !{2}! #", song.Name, song.Ar[0].Name, api.GetSongsUrl(new long[] { song.Id }).Data[0].Url);
            }//第一个数据是规则这里我引入两个符号方便读取之间的内容

            var web = new Regex("@(.*?)#");//读取规则@和#之间的内容
            MatchCollection matches_web = web.Matches(songmessage);
            list_message.Items.Clear();
            foreach (Match m in matches_web)//循环读取内容
            {
                list_message.Items.Add(string.Format("{0}", m.Groups[1].Value));//添加到list中
            }
        }
    }


}