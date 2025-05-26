using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLTK_Vũ_Đăng
{
    public partial class FormIPGame : Form
    {
        public FormIPGame()
        {
            InitializeComponent();
        }

        private void panelText_Paint(object sender, PaintEventArgs e)
        {

        }

        private void FormIPGame_Load(object sender, EventArgs e)
        {
            panelText.AutoScroll = true;
            GetIP();
        }

        private Label newLabel(string text, Point point, Color color, int fontSize = 15)
        {
            Label label = new Label();
            label.AutoSize = true;
            label.Location = point;
            label.Font = new Font("Microsoft Sans Serif", (float)fontSize);
            label.ForeColor = color;
            label.Enabled = true;
            label.Text = text;
            label.Click += new EventHandler(LB_Click);
            return label;
        }
        public static List<string> manualForms = new List<string>();
        void GetIP()
        {
            {
                try
                {
                    if (!File.Exists("Data\\IP"))
                    {
                        string contents = new StreamReader(WebRequest.Create("https://raw.githubusercontent.com/vuhaidangz/CheckKeyMod/main/IPGame.txt").GetResponse().GetResponseStream()).ReadToEnd();
                        string[] array = contents.Split('|');
                        File.WriteAllText("Data\\IP", array[1]);
                    }
                    manualForms.AddRange(File.ReadAllLines("Data\\IP").ToList<string>());
                    lbLoading.Text = "";
                    int y = 10;
                    for (int i = 0; i < manualForms.Count; i++)
                    {
                        if (manualForms[i] != string.Empty)
                        {
                            Label label = this.newLabel(manualForms[i], new Point(10, y), Color.LightBlue, 12);
                            if (manualForms[i].Trim().ToLower().StartsWith("$"))
                            {
                                label = this.newLabel(manualForms[i], new Point(35, y), Color.LightBlue, 20);
                                label.Text = label.Text.Replace("$", "");
                            }
                            else if (manualForms[i].StartsWith("**"))
                            {
                                label = this.newLabel(manualForms[i], new Point(15, y), Color.Yellow, 15);
                                label.Text = label.Text.Replace("**", "");
                            }
                            else if (manualForms[i].StartsWith("- "))
                            {
                                label = this.newLabel(manualForms[i], new Point(10, y), Color.LightBlue, 12);
                            }
                            this.panelText.Controls.Add(label);
                            y += label.Size.Height + 3;
                            if (manualForms[i].Trim().ToLower().Contains("hết"))
                                break;
                        }
                    }
                    Label label2 = this.newLabel("", new Point(10, y + 10), Color.HotPink, 20);
                    this.panelText.Controls.Add(label2);
                }
                catch
                {
                    MessageBox.Show("Đang Có Lỗi Gì Đó Vui Lòng Thử Lại");
                }
            }
        }
        protected void LB_Click(object sender, EventArgs e)
        {
            //attempt to cast the sender as a label
            Label lbl = sender as Label;

            //if the cast was successful (i.e. not null), navigate to the site
            if (lbl != null)
            {
                Invoke((Action)(() => { Clipboard.SetText(lbl.Text); }));
                MessageBox.Show("Copy IP Thành Công : " + lbl.Text);
            }
        }
    }
}
