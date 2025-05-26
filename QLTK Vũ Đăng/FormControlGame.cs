using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLTK_Vũ_Đăng
{
    public partial class FormControlGame : Form
    {
        public FormControlGame()
        {
            InitializeComponent();
        }

        private void FormControlGame_Load(object sender, EventArgs e)
        {
            if (File.Exists("Data\\IDTele"))
            {
                this.txtTele.Text = File.ReadAllText("Data\\IDTele");
            }
            if (File.Exists("Data\\AutoChatTG"))
            {
                this.txtAutoCTG.Text = File.ReadAllText("Data\\AutoChatTG");
            }
            if (File.Exists("Data\\AutoChat"))
            {
                this.txtAutoChat.Text = File.ReadAllText("Data\\AutoChat");
            }
            if (File.Exists("Data\\bossCanLoc"))
            {
                this.txtBossDo.Text = File.ReadAllText("Data\\bossCanLoc");
            }
            if (File.Exists("Data\\VutDo"))
            {
                this.txtDo.Text = File.ReadAllText("Data\\VutDo");
            }
            if (File.Exists("Data\\fileSpeed"))
            {
                this.txtSpeed.Text = File.ReadAllText("Data\\fileSpeed");
            }
        }

        private void FormControlGame_Move(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            send_skill(0);
        }
        public static void send_skill(int i)
        {
            try
            {
                Socket_Server.sendData(new Socket_Server.vMessage()
                {
                    cmd = 1,
                    data = i
                });
            }catch(Exception e)
            {
            }
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            send_skill(1);
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            send_skill(2);
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            send_skill(3);
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            send_skill(4);
        }

        private void guna2Button6_Click(object sender, EventArgs e)
        {
            send_skill(5);
        }

        private void guna2Button7_Click(object sender, EventArgs e)
        {
            send_skill(6);
        }

        private void guna2Button8_Click(object sender, EventArgs e)
        {
            send_skill(7);
        }

        void send_zone(int i)
        {
            try
            {
                Socket_Server.sendData(new Socket_Server.vMessage()
                {
                    cmd = 2,
                    data = i
                });
            }
            catch (Exception e)
            {
            }
        }
        private void guna2Button16_Click(object sender, EventArgs e)
        {
            send_zone(0);
        }

        private void guna2Button15_Click(object sender, EventArgs e)
        {
            send_zone(1);
        }

        private void guna2Button14_Click(object sender, EventArgs e)
        {
            send_zone(2);
        }

        private void guna2Button13_Click(object sender, EventArgs e)
        {
            send_zone(3);
        }

        private void guna2Button9_Click(object sender, EventArgs e)
        {
            send_zone(4);
        }

        private void guna2Button10_Click(object sender, EventArgs e)
        {
            send_zone(5);
        }

        private void btnGoZone_Click(object sender, EventArgs e)
        {
            send_zone(int.Parse(txtZone.Text));
        }

        private void btnUpdateAutoChat_Click(object sender, EventArgs e)
        {
            Socket_Server.sendData(new Socket_Server.vMessage()
            {
                cmd = 11,
                data = txtAutoChat.Text
            });
            File.WriteAllText("Data\\AutoChat", txtAutoChat.Text);
            MessageBox.Show("Update Nội Dung Chat Thành Công : " + txtAutoChat.Text);
        }

        private void guna2Button22_Click(object sender, EventArgs e)
        {
            Socket_Server.sendData(new Socket_Server.vMessage()
            {
                cmd = 12,
                data = txtAutoCTG.Text
            });
            File.WriteAllText("Data\\AutoChatTG", txtAutoCTG.Text);
            MessageBox.Show("Update Nội Dung Chat Thế Giới Thành Công : " + txtAutoCTG.Text);
        }

        private void btnTele_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.txtTele.Text))
            {
                MessageBox.Show("Chưa Có ID Mục Tiêu Tele");
                return;
            }
            send_tele(int.Parse(txtTele.Text));
            File.WriteAllText("Data\\IDTele", txtTele.Text);
        }
        void send_tele(int idTele)
        {
            try
            {
                Socket_Server.sendData(new Socket_Server.vMessage()
                {
                    cmd = 3,
                    data = idTele
                });
            }
            catch (Exception e)
            {
            }
        }
        public static int idTele = -1;

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (idTele != -1)
            {
                txtTele.Text = idTele.ToString();
                File.WriteAllText("Data\\IDTele", idTele.ToString());
                idTele = -1;
            }
        }

        private void guna2Button24_Click(object sender, EventArgs e)
        {
            Socket_Server.sendData(new Socket_Server.vMessage()
            {
                cmd = 13,
                data = txtDo.Text
            });
            File.WriteAllText("Data\\VutDo", this.txtDo.Text);
            MessageBox.Show("Nhập Thành Công ID Những Đồ Sẽ Auto Vứt : " + this.txtDo.Text);
        }

        private void guna2Button26_Click(object sender, EventArgs e)
        {
            Socket_Server.sendData(new Socket_Server.vMessage()
            {
                cmd = 10,
                data = int.Parse(txtSpeed.Text)
            });
            File.WriteAllText("Data\\fileSpeed", this.txtSpeed.Text);
            MessageBox.Show("Tốc Độ Game Hiện Tại : " + this.txtSpeed.Text);
        }

        private void guna2Button25_Click(object sender, EventArgs e)
        {
            Socket_Server.sendData(new Socket_Server.vMessage()
            {
                cmd = 14,
                data = txtBossDo.Text
            });
            File.WriteAllText("Data\\bossCanLoc", this.txtBossDo.Text);
            MessageBox.Show("Update Boss Cần Lọc : " + this.txtBossDo.Text);
        }

        private void guna2Button12_Click(object sender, EventArgs e)
        {
            Socket_Server.sendData(new Socket_Server.vMessage()
            {
                cmd = 4,
                data = -1
            });
        }

        private void guna2Button17_Click(object sender, EventArgs e)
        {
            Socket_Server.sendData(new Socket_Server.vMessage()
            {
                cmd = 5,
                data = -1
            });
        }

        private void guna2Button18_Click(object sender, EventArgs e)
        {
            Socket_Server.sendData(new Socket_Server.vMessage()
            {
                cmd = 6,
                data = -1
            });
        }

        private void guna2Button19_Click(object sender, EventArgs e)
        {
            Socket_Server.sendData(new Socket_Server.vMessage()
            {
                cmd = 7,
                data = -1
            });
        }

        private void guna2Button20_Click(object sender, EventArgs e)
        {
            Socket_Server.sendData(new Socket_Server.vMessage()
            {
                cmd = 8,
                data = int.Parse(txtIDMap.Text)
            });
        }

        private void guna2Button27_Click(object sender, EventArgs e)
        {
            send_iditem(381);
        }
        void send_iditem(int idItem)
        {
            Socket_Server.sendData(new Socket_Server.vMessage()
            {
                cmd = 9,
                data = idItem
            });
        }

        private void guna2Button28_Click(object sender, EventArgs e)
        {
            send_iditem(382);
        }

        private void guna2Button29_Click(object sender, EventArgs e)
        {
            send_iditem(383);
        }

        private void guna2Button30_Click(object sender, EventArgs e)
        {
            send_iditem(384);
        }

        private void guna2Button31_Click(object sender, EventArgs e)
        {
            send_iditem(385);
        }

        private void guna2Button32_Click(object sender, EventArgs e)
        {
            send_iditem(int.Parse(txtIDItem.Text));
        }

        private void guna2Button11_Click(object sender, EventArgs e)
        {
            Socket_Server.sendData(new Socket_Server.vMessage()
            {
                cmd = 16,
                data = 19122005
            });
        }
    }
}
