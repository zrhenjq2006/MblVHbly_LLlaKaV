using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;

using Newtonsoft.Json;

namespace vk_bot
{
    public partial class Form1 : Form
    {
        public static string access_token;
        public Form1()
        {
            InitializeComponent();
        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            if (e.Url.ToString().Contains("access_token="))
            {
                webBrowser1.Visible = false;
                access_token = e.Url.ToString();
                int pos = access_token.IndexOf("access_token=");
                pos += "access_token=".Length;
                access_token = access_token.Remove(0, pos);
                pos = access_token.IndexOf("&");
                access_token = access_token.Remove(pos);
                string request = "https://api.vk.com/method/users.get?fields=photo_100,bdate&access_token="  +access_token+ "&v=5.87";
                https://api.vk.com/method/likes.add?owner_id=-24299135&item_id=387996&type=post&access_token=cb34c33364ffca3e65783fd7a40c8f7b0b5f77a1a84ee732f36fc38704656a8352ed1e8db359f93f0ddc9&v=5.92 
                //string request2 = "https://api.vk.com/method/groups.get?user_id=56929156&fields=photo_100&extended=1&access_token=" + access_token + "&v=5.87";
                WebClient client = new WebClient();
                //string answer = client.DownloadString(request);
                string answer = Encoding.UTF8.GetString( client.DownloadData(request));
                User user = JsonConvert.DeserializeObject<User>(answer);
                    AvatarPictureBox.Load(user.response[0].photo_100);
                    FirstNameLabel.Text = user.response[0].first_name;             
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            webBrowser1.BringToFront();
        }

        private void autoAnswerButton_Click(object sender, EventArgs e)
        {
            AutoAnswerForm frm = new AutoAnswerForm();
            frm.Show();
        }

        private void AutoMessageButton_Click(object sender, EventArgs e)
        {
            AutoMessageForm amfrm = new AutoMessageForm();
            amfrm.ShowDialog();
        }

        private void AButton_Click(object sender, EventArgs e)
        {
            AButton frm = new AButton();
            frm.access_token = access_token;
            frm.ShowDialog();


        }
    }
}

