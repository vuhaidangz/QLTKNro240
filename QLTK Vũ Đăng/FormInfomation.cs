using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLTK_Vũ_Đăng
{
    public partial class FormInfomation : Form
    {
        public FormInfomation()
        {
            InitializeComponent();
        }
        public static bool isEnable;
        private void FormInfomation_Load(object sender, EventArgs e)
        {
            version.Text = CheckVersion();
            new Thread(delegate ()
            {
                Thread.Sleep(5000);
                isEnable = true;
                guna2HtmlLabel5.Text = "";
            }).Start();
        }
        private string CheckVersion()
        {
            string contents = new StreamReader(WebRequest.Create("https://github.com/vuhaidangz/CheckKeyMod/blob/main/VersionModUIGuna").GetResponse().GetResponseStream()).ReadToEnd();
            string[] array = contents.Split('|');
            if (array[1] == "5.9")
            {
                return "Phiên Bản Hiện Tại Là Mới Nhất";
            }
            return array[2];
        }

        private void version_Click(object sender, EventArgs e)
        {

        }

        private void guna2HtmlLabel1_Click(object sender, EventArgs e)
        {

        }

        private void guna2HtmlLabel2_Click(object sender, EventArgs e)
        {

        }

        private void guna2HtmlLabel3_Click(object sender, EventArgs e)
        {

        }

        private void guna2HtmlLabel5_Click(object sender, EventArgs e)
        {

        }
    }
}
