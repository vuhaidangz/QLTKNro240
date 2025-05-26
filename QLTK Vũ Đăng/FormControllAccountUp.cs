using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLTK_Vũ_Đăng
{
    public partial class FormControllAccountUp : Form
    {
        public FormControllAccountUp()
        {
            InitializeComponent();
        }
        private void WriteMod()
        {
            File.WriteAllText("Data\\Mod", (cbXBG.Checked ? "1" : "0") + "|" + (cbWall.Checked ? "1" : "0") + "|" + (cbDiaHinh.Checked ? "1" : "0") + "|" + (cbCheckLag.Checked ? "1" : "0") + "|" + (cbGDL.Checked ? "1" : "0") + "|" + (cbAutoLogin.Checked ? "1" : "0") + "|" + (cbAutoKhu.Checked ? "1" : "0") + "|" + (cbKOK.Checked ? "1" : "0") + "|" + (cbPem.Checked ? "1" : "0") + "|" + (cbCo.Checked ? "1" : "0") + "|" + (cbVutDo.Checked ? "1" : "0") + "|" + (cbHS.Checked ? "1" : "0") + "|" + (cbMuaDau.Checked ? "1" : "0") + "|" + (cbTanSat.Checked ? "1" : "0") + "|" + (cbVuotDiaHinh.Checked ? "1" : "0") + "|" + (cbAutoNhat.Checked ? "1" : "0") + "|" + (cbTeleQuai.Checked ? "1" : "0") + "|" + (cbNeSieuQuai.Checked ? "1" : "0") + "|" + (cbAutoCN.Checked ? "1" : "0") + "|" + (cbAutoBH.Checked ? "1" : "0") + "|" + (cbAutoBK.Checked ? "1" : "0") + "|" + (cbAutoGX.Checked ? "1" : "0") + "|" + (cbAutoAD.Checked ? "1" : "0") + "|" + (cbAutoMD.Checked ? "1" : "0") + "|" + (cbAutoKT.Checked ? "1" : "0") + "|" + (cbOpenCSKB.Checked ? "1" : "0") + "|" + (cbAnNho.Checked ? "1" : "0") + "|" + (cbXinDau.Checked ? "1" : "0") + "|" + (cbNhatDoDe.Checked ? "1" : "0") + "|" + txtMapUp.Text + "|" + txtKhuUp.Text + "|" + txtToaDoX.Text + "|" + txtToaDoY.Text);
            Socket_Server.sendData(new Socket_Server.vMessage()
            {
                cmd = 15,
                data = (cbXBG.Checked ? "1" : "0") + "|" + (cbWall.Checked ? "1" : "0") + "|" + (cbDiaHinh.Checked ? "1" : "0") + "|" + (cbCheckLag.Checked ? "1" : "0") + "|" + (cbGDL.Checked ? "1" : "0") + "|" + (cbAutoLogin.Checked ? "1" : "0") + "|" + (cbAutoKhu.Checked ? "1" : "0") + "|" + (cbKOK.Checked ? "1" : "0") + "|" + (cbPem.Checked ? "1" : "0") + "|" + (cbCo.Checked ? "1" : "0") + "|" + (cbVutDo.Checked ? "1" : "0") + "|" + (cbHS.Checked ? "1" : "0") + "|" + (cbMuaDau.Checked ? "1" : "0") + "|" + (cbTanSat.Checked ? "1" : "0") + "|" + (cbVuotDiaHinh.Checked ? "1" : "0") + "|" + (cbAutoNhat.Checked ? "1" : "0") + "|" + (cbTeleQuai.Checked ? "1" : "0") + "|" + (cbNeSieuQuai.Checked ? "1" : "0") + "|" + (cbAutoCN.Checked ? "1" : "0") + "|" + (cbAutoBH.Checked ? "1" : "0") + "|" + (cbAutoBK.Checked ? "1" : "0") + "|" + (cbAutoGX.Checked ? "1" : "0") + "|" + (cbAutoAD.Checked ? "1" : "0") + "|" + (cbAutoMD.Checked ? "1" : "0") + "|" + (cbAutoKT.Checked ? "1" : "0") + "|" + (cbOpenCSKB.Checked ? "1" : "0") + "|" + (cbAnNho.Checked ? "1" : "0") + "|" + (cbXinDau.Checked ? "1" : "0") + "|" + (cbNhatDoDe.Checked ? "1" : "0") + "|" + txtMapUp.Text + "|" + txtKhuUp.Text + "|" + txtToaDoX.Text + "|" + txtToaDoY.Text
            });
        }
        private void FormControllAccountUp_Load(object sender, EventArgs e)
        {
            string[] array = File.ReadAllText("Data\\Mod").Split(new char[]
            {
                    '|'
            });
            this.cbXBG.Checked = (array[0] == "1");
            this.cbWall.Checked = (array[1] == "1");
            cbDiaHinh.Checked = (array[2] == "1");
            cbCheckLag.Checked = (array[3] == "1");
            cbGDL.Checked = (array[4] == "1");
            cbAutoLogin.Checked = (array[5] == "1");
            cbAutoKhu.Checked = (array[6] == "1");
            cbKOK.Checked = (array[7] == "1");
            cbPem.Checked = (array[8] == "1");
            cbCo.Checked = (array[9] == "1");
            cbVutDo.Checked = (array[10] == "1");
            cbHS.Checked = (array[11] == "1");
            cbMuaDau.Checked = (array[12] == "1");
            cbTanSat.Checked = (array[13] == "1");
            cbVuotDiaHinh.Checked = (array[14] == "1");
            cbAutoNhat.Checked = (array[15] == "1");
            cbTeleQuai.Checked = (array[16] == "1");
            cbNeSieuQuai.Checked = (array[17] == "1");
            cbAutoCN.Checked = (array[18] == "1");
            cbAutoBH.Checked = (array[19] == "1");
            cbAutoBK.Checked = (array[20] == "1");
            cbAutoGX.Checked = (array[21] == "1");
            cbAutoAD.Checked = (array[22] == "1");
            cbAutoMD.Checked = (array[23] == "1");
            cbAutoKT.Checked = (array[24] == "1");
            cbOpenCSKB.Checked = (array[25] == "1");
            cbAnNho.Checked = (array[26] == "1");
            cbXinDau.Checked = (array[27] == "1");
            cbNhatDoDe.Checked = (array[28] == "1");
            txtMapUp.Text = array[29];
            txtKhuUp.Text = array[30];
            txtToaDoX.Text = array[31];
            txtToaDoY.Text = array[32];
            this.WriteMod();
        }

        private void cbXBG_CheckedChanged(object sender, EventArgs e)
        {
            if (this.cbXBG.Checked && this.cbWall.Checked)
            {
                this.cbWall.Checked = false;
            }
            this.WriteMod();
        }

        private void cbWall_CheckedChanged(object sender, EventArgs e)
        {
            if (this.cbWall.Checked && this.cbXBG.Checked)
            {
                this.cbXBG.Checked = false;
            }
            this.WriteMod();
        }

        private void cbDiaHinh_CheckedChanged(object sender, EventArgs e)
        {
            WriteMod();
        }

        private void cbCheckLag_CheckedChanged(object sender, EventArgs e)
        {
            WriteMod();
        }

        private void cbGDL_CheckedChanged(object sender, EventArgs e)
        {
            WriteMod();
        }

        private void cbAutoLogin_CheckedChanged(object sender, EventArgs e)
        {
            WriteMod();
        }

        private void cbAutoKhu_CheckedChanged(object sender, EventArgs e)
        {
            WriteMod();
        }

        private void cbKOK_CheckedChanged(object sender, EventArgs e)
        {
            WriteMod();
        }

        private void cbPem_CheckedChanged(object sender, EventArgs e)
        {
            WriteMod();
        }

        private void cbCo_CheckedChanged(object sender, EventArgs e)
        {
            WriteMod();
        }

        private void cbVutDo_CheckedChanged(object sender, EventArgs e)
        {
            WriteMod();
        }

        private void cbHS_CheckedChanged(object sender, EventArgs e)
        {
            WriteMod();
        }

        private void cbMuaDau_CheckedChanged(object sender, EventArgs e)
        {
            WriteMod();
        }

        private void cbAnNho_CheckedChanged(object sender, EventArgs e)
        {
            WriteMod();
        }

        private void cbXinDau_CheckedChanged(object sender, EventArgs e)
        {
            WriteMod();
        }

        private void cbNhatDoDe_CheckedChanged(object sender, EventArgs e)
        {
            WriteMod();
        }

        private void cbTanSat_CheckedChanged(object sender, EventArgs e)
        {
            WriteMod();
        }

        private void cbVuotDiaHinh_CheckedChanged(object sender, EventArgs e)
        {
            WriteMod();
        }

        private void cbAutoNhat_CheckedChanged(object sender, EventArgs e)
        {
            WriteMod();
        }

        private void cbTeleQuai_CheckedChanged(object sender, EventArgs e)
        {
            WriteMod();
        }

        private void cbNeSieuQuai_CheckedChanged(object sender, EventArgs e)
        {
            WriteMod();
        }

        private void btnUpdateKhuUp_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Update Map Up : " + this.txtMapUp.Text + " Khu Up : " + this.txtKhuUp.Text);
            this.WriteMod();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Update Tọa Độ X : " + this.txtToaDoX.Text + " Y : " + this.txtToaDoY.Text);
            this.WriteMod();
        }

        private void cbAutoCN_CheckedChanged(object sender, EventArgs e)
        {
            WriteMod();
        }

        private void cbAutoBH_CheckedChanged(object sender, EventArgs e)
        {
            WriteMod();
        }

        private void cbAutoBK_CheckedChanged(object sender, EventArgs e)
        {
            WriteMod();
        }

        private void cbAutoGX_CheckedChanged(object sender, EventArgs e)
        {
            WriteMod();
        }

        private void cbAutoAD_CheckedChanged(object sender, EventArgs e)
        {
            WriteMod();
        }

        private void cbAutoMD_CheckedChanged(object sender, EventArgs e)
        {
            WriteMod();
        }

        private void cbAutoKT_CheckedChanged(object sender, EventArgs e)
        {
            WriteMod();
        }

        private void cbOpenCSKB_CheckedChanged(object sender, EventArgs e)
        {
            if (this.cbOpenCSKB.Checked)
            {
                MessageBox.Show("Auto Mở CSKB Khi Full");
            }
            this.WriteMod();
        }
    }
}
