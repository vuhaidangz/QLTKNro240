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
    public partial class FormTutorial : Form
    {
        public FormTutorial()
        {
            InitializeComponent();
        }

        private void FormTutorial_Load(object sender, EventArgs e)
        {
            panelText.AutoScroll = true;
            GetTutorial();
        }
        private Label newLabel(string text, Point point, Color color, int fontSize = 10)
        {
            return new Label
            {
                AutoSize = true,
                Location = point,
                Font = new Font("Microsoft Sans Serif", (float)fontSize),
                ForeColor = color,
                Text = text
            };
        }
        public static List<string> manualForms = new List<string>();
        void GetTutorial()
        {
            
            {
                try
                {
                    if (!File.Exists("Data\\HDSD"))
                    {
                        string contents = new StreamReader(WebRequest.Create("https://raw.githubusercontent.com/vuhaidangz/CheckKeyMod/main/HDSDModTutorial").GetResponse().GetResponseStream()).ReadToEnd();
                        string[] array = contents.Split('|');
                        File.WriteAllText("Data\\HDSD", array[1]);
                    }
                    manualForms.AddRange(File.ReadAllLines("Data\\HDSD").ToList<string>());
                    lbLoading.Text = "";
                    int y = 10;
                    for (int i = 0; i < manualForms.Count; i++)
                    {
                        if (manualForms[i] != string.Empty)
                        {
                            Label label = this.newLabel(manualForms[i] + ".", new Point(10, y), Color.LightBlue, 12);
                            if (manualForms[i].Trim().ToLower().StartsWith("$"))
                            {
                                label = this.newLabel(manualForms[i] + ".", new Point(35, y), Color.LightBlue, 20);
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
                            if (manualForms[i].Contains("check khu boss của acc có tên (name) đã liên kết"))
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

        private void panelText_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
