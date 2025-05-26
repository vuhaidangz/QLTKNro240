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
using Guna.UI2.WinForms;
using Newtonsoft.Json;

namespace QLTK_Vũ_Đăng
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private Guna2Button currentButton;
        private Form activeForm;
        
        private void DisableButton()
        {
            foreach (Control previousBtn in panelMenu.Controls)
            {
                if (previousBtn.GetType() == typeof(Button))
                {
                    previousBtn.BackColor = Color.FromArgb(51, 51, 76);
                    previousBtn.ForeColor = Color.Gainsboro;
                    previousBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                }
            }
        }

        //private void ActivateButton(object btnSender)
        //{
        //    if (btnSender != null)
        //    {
        //        if (currentButton != (Guna2Button)btnSender)
        //        {
        //            DisableButton();
        //            currentButton = (Guna2Button)btnSender;
        //            currentButton.BackColor = Color.Silver;
        //            currentButton.ForeColor = Color.FromArgb(192, 0, 0);
        //            currentButton.Font = new System.Drawing.Font("Segoe UI", 9F);
        //        }
        //    }
        //}

        private void OpenChildForm(Form childForm, object btnSender)
        {
            if (activeForm != null)
                activeForm.Visible = false;
            //ActivateButton(btnSender);
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            this.panelDestkop.Controls.Add(childForm);
            this.panelDestkop.Tag = childForm;
            childForm.BringToFront();
            childForm.Visible = true;
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FormDashboard(), sender);
        }

        private void btnControlGame_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FormControlGame(), sender);
        }

        private void btnControlUp_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FormControllAccountUp(), sender);
        }

        private void btnTutorial_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FormTutorial(), sender);
        }

        private void btnInfo_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FormInfomation(), sender);
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };
            this.panelMenu.Enabled = false;
            OpenChildForm(new FormInfomation(), sender);
            btnInfo.Checked = true;
            canCloseForm = true;
            isGetCPUAndRam = true;
            Socket_Server.SetupServer();
        }
        bool canCloseForm;
        private bool checkkeys()
        {
            try
            {
                string contents = new StreamReader(WebRequest.Create("https://github.com/vuhaidangz/CheckKeyMod/blob/main/CheckModUIGuna").GetResponse().GetResponseStream()).ReadToEnd();
                string[] array = contents.Split('|');
                if (array[1].ToLower().Contains("cặc"))
                {
                    return true;
                }
            }
            catch
            {
                return false;
            }
            return false;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (canCloseForm)
            {
                DialogResult result = MessageBox.Show("Bạn Có Chắc Chắn Muốn Thoát ?", "Notification", MessageBoxButtons.OKCancel);
                if (result == DialogResult.Cancel)
                {
                    e.Cancel = true;
                    return;
                }
            }
            File.Delete("Data\\HDSD");
            File.Delete("Data\\IP");
        }
        int timeUpdate;
        bool isGetCPUAndRam;
        private void timer1_Tick(object sender, EventArgs e)
        {
            timeUpdate++;
            bool flag5 = this.timeUpdate % 10 == 0;
            if (flag5)
            {
                bool flag6 = this.isGetCPUAndRam;
                if (flag6)
                {
                    this.GetCPUAndRam();
                }
            }
            if (FormInfomation.isEnable)
                this.panelMenu.Enabled = true;
            Form1.KillFileCrash();
        }
        private void GetCPUAndRam()
        {
            float fcpu = this.pCPU.NextValue();
            float fram = this.pRAM.NextValue();
            this.lbCPU.Text = "CPU : " + Math.Round((double)fcpu, 0) + "%";
            this.lbRAM.Text = "RAM : " + Math.Round((double)fram, 0) + "%";
        }
        static void KillFileCrash()
        {
            DirectoryInfo directory = new DirectoryInfo(Directory.GetCurrentDirectory());
            for (int i = 0; i < directory.GetDirectories().Length; i++)
            {
                bool flag = directory.GetDirectories()[i].Name.Contains(DateTime.Now.Year.ToString());
                if (flag)
                {
                    try
                    {
                        FormDashboard.ClearDataGame(directory.GetDirectories()[i].ToString());
                        directory.GetDirectories()[i].Delete();
                    }
                    catch
                    {
                    }
                }
            }
        }

        private void btnCloseApp_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FormIPGame(), sender);
        }
    }
}
