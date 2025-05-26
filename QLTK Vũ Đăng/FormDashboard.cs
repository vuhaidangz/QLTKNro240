using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLTK_Vũ_Đăng
{
    public partial class FormDashboard : Form
    {
        public FormDashboard()
        {
            InitializeComponent();
        }


        private void FormDashboard_Load(object sender, EventArgs e)
        {
            LoadForm();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (CheckAdd(true))
            {
                dataGridView1.Rows.Add(new object[]
                {
                    "",
                    txtAcc.Text,
                    PassChange(),
                    cboSv.Text,
                    txtNote.Text,
                    cbLKType.Text
                });
                new Data(dataGridView1, txtAcc).ExportFile();
            }
        }
        string PassChange()
        {
            if (dataGridView1.RowCount <= 0)
                return Encrypt(txtPass.Text, "dangvippro");
            if (txtPass.Text == dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[2].Value.ToString())
                return txtPass.Text;
            return Encrypt(txtPass.Text, "dangvippro");
        }
        public bool CheckAdd(bool Add)
        {
            bool check;
            if (string.IsNullOrEmpty(txtAcc.Text))
            {
                MessageBox.Show("Chưa Nhập Tài Khoản", "Lỗi Thêm Tài Khoản", MessageBoxButtons.OK);
                txtAcc.Focus();
                check = false;
            }
            else if (string.IsNullOrEmpty(txtPass.Text))
            {
                MessageBox.Show("Chưa Nhập Mật Khẩu", "Lỗi Thêm Tài Khoản", MessageBoxButtons.OK);
                txtPass.Focus();
                check = false;
            }
            else if (string.IsNullOrEmpty(cboSv.Text))
            {
                MessageBox.Show("Chưa Chọn Server", "Lỗi Thêm Tài Khoản", MessageBoxButtons.OK);
                cboSv.Focus();
                check = false;
            }
            else if (string.IsNullOrEmpty(cbLKType.Text))
            {
                MessageBox.Show("Chưa Chọn Loại Liên Kết", "Lỗi Thêm Tài Khoản", MessageBoxButtons.OK);
                cboSv.Focus();
                check = false;
            }
            else
            {
                check = true;
            }
            return check;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (CheckAdd(false))
            {
                int index = dataGridView1.CurrentRow.Index;
                dataGridView1.Rows[index].Cells[1].Value = txtAcc.Text;
                dataGridView1.Rows[index].Cells[2].Value = PassChange();
                dataGridView1.Rows[index].Cells[3].Value = cboSv.Text;
                dataGridView1.Rows[index].Cells[4].Value = txtNote.Text;
                dataGridView1.Rows[index].Cells[5].Value = cbLKType.Text;
                new Data(dataGridView1, txtAcc).ExportFile();
            }
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                dataGridView1.Rows.RemoveAt(dataGridView1.CurrentRow.Index);
                new Data(dataGridView1, txtAcc).ExportFile();
            }
            else
            {
                MessageBox.Show("Chưa Có Tài Khoản", "Lỗi Xóa Tài Khoản", MessageBoxButtons.OK);
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (CanLogin())
            {
                Login(dataGridView1.CurrentRow.Index);
            }
        }
        public bool CanLogin()
        {
            if (!File.Exists("Dragon ball_240.exe"))
            {
                MessageBox.Show("Không Tìm Thấy Game", "Lỗi Đăng Nhập", MessageBoxButtons.OK);
                return false;
            }
            return true;
        }
        public void Login(int index)
        {
            TextWriter textWriter = new StreamWriter("Data\\Log");
            //for (int i = 0; i < cboSv.Items.Count; i++)
            //{
            //    if (cboSv.Items[i].ToString() == dataGridView1.Rows[index].Cells[3].Value.ToString())
            //    {
            //        Server = i;
            //        break;
            //    }
            //}
            string ID = dataGridView1.Rows[index].Cells[0].Value.ToString();
            string Acc = dataGridView1.Rows[index].Cells[1].Value.ToString();
            string Pass = dataGridView1.Rows[index].Cells[2].Value.ToString();
            int Server = cboSv.FindStringExact(dataGridView1.Rows[index].Cells[3].Value.ToString());
            string TypeAcc = dataGridView1.Rows[index].Cells[5].Value.ToString();
            for (int i = 0; i < 6; i++)
            {
                textWriter.Write(ID + "|" + Acc + "|" + Pass + "|" + Server + "|" + TypeAcc);
            }
            textWriter.Close();
            Process.Start("Dragon ball_240.exe");
            while (FindWindow(null, "Dragonboy240") == IntPtr.Zero)
            {
                this.Enabled = false;
                Thread.Sleep(500);
            }
            SetWindowText(FindWindow(null, "Dragonboy240"), NameWindow(TypeAcc) + ID + " - Mod By Vũ Đăng");
            this.Enabled = true;
        }
        [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
        static extern bool SetWindowText(IntPtr hWnd, string text);

        string NameWindow(string type)
        {
            switch (type)
            {
                case "1. Thường":
                    return "ID : ";
                case "2. Up":
                    return "Acc Up : ";
                case "3. Buff Đậu":
                    return "Acc Buff Đậu : ";
                default :
                    return "Không Hợp Lệ";
            }
        }
        [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
        static extern IntPtr FindWindow(string windowClass, string windowName);
        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool MoveWindow(IntPtr hWnd, int X, int Y, int nWidth, int nHeight, bool bRepaint);

        private void btnLoginAll_Click(object sender, EventArgs e)
        {
            new Thread(LoginAll).Start();
        }
        public void LoginAll()
        {
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                Login(i);
                while (File.Exists("Data\\Log"))
                    Thread.Sleep(100);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Đóng Hết Tất Cả Các Tab Luôn Đấy Chắc Chắn Chưa :v", "Close All", MessageBoxButtons.OKCancel);
            if (result == DialogResult.Cancel)
            {
                return;
            }
            CloseAll();
        }
        private void CloseAll()
        {
            Process[] processes = Process.GetProcesses();
            foreach (Process process in processes)
            {
                if (process.MainWindowTitle.ToLower().Contains("mod by vũ đăng"))
                {
                    try
                    {
                        process.Kill();
                    }
                    catch { }
                }
            }
        }
        public void SapXep()
        {
            int width = Screen.PrimaryScreen.Bounds.Width;
            Process[] processes = Process.GetProcesses();
            List<Process> list = new List<Process>();
            foreach (Process process in processes)
            {
                if (process.MainWindowTitle.ToLower().Contains("mod by vũ đăng") || process.MainWindowTitle.ToLower().Contains("dragonboy240"))
                {
                    list.Add(process);
                }
            }
            int num = 0;
            int num2 = 0;
            int W = int.Parse(txtW.Text);
            int H = int.Parse(txtH.Text);
            foreach (Process process2 in list)
            {
                IntPtr ptr = process2.MainWindowHandle;
                if (W * H < 480000)
                {
                    if (num + W > width)
                    {
                        num = 0;
                        num2 += H;
                    }
                    MoveWindow(ptr, num, num2, W, H + 27, true);
                    num += W;
                }
            }
        }
        private void btnSapXep_Click(object sender, EventArgs e)
        {
            SapXep();
        }

        private void btnDelData_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Chỉ Nên Xóa Dữ Liệu Khi Gặp Lỗi.\nBạn Có Chắc Chắn Muốn Xóa?", "Delete Data", MessageBoxButtons.OKCancel);
            if (result == DialogResult.Cancel)
            {
                return;
            }
            ClearDataGame("Data Game/");
            MessageBox.Show("Đã Xóa Xong Dữ Liệu", "Delete Data", MessageBoxButtons.OK);
        }
        public static void ClearDataGame(string path)
        {
            FileInfo[] files = new DirectoryInfo(path).GetFiles();
            for (int i = 0; i < files.Length; i++)
            {
                files[i].Delete();
            }
        }

        private void btnLienHe_Click(object sender, EventArgs e)
        {
            Process.Start("https://www.facebook.com/vudang.1912/");
            Process.Start("https://www.youtube.com/channel/UC68D589bn3DmcFJsOLvGsBQ");
            Process.Start("https://www.facebook.com/groups/1185921432049155/");
        }

        private void rdTeamobi_CheckedChanged(object sender, EventArgs e)
        {
            if (rdTeamobi.Checked)
            {
                File.WriteAllText("Data\\Server", "-1");
                cboSv.Items.Clear();
                this.cboSv.Items.AddRange(new object[] {
                "Vũ Trụ 1",
                "Vũ Trụ 2",
                "Vũ Trụ 3",
                "Vũ Trụ 4",
                "Vũ Trụ 5",
                "Vũ Trụ 6",
                "Vũ Trụ 7",
                "Vũ Trụ 8",
                "Vũ Trụ 9",
                "Vũ Trụ 10",
                "Vũ Trụ 11",
                "Vũ Trụ 12",
                "Vũ Trụ 13",
                "Vũ Trụ 14",
                "Vũ Trụ 15",
                "Vũ Trụ 16",
                "Vũ Trụ 17",
                "Vũ Trụ 18",
                "Vũ Trụ 19",
                "Vũ Trụ 20"});
                ResetIPGame();
            }
        }
        private void ResetIPGame()
        {
            if (File.Exists("Data Game\\NRIPlink") || File.Exists("Data Game\\NRlink2"))
            {
                File.Delete("Data Game\\NRIPlink");
                File.Delete("Data Game\\NRlink2");
            }
        }
        private void btnUpdateSize_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtW.Text))
            {
                MessageBox.Show("Chưa Nhập Chiều Ngang", "Lỗi Nhập Size", MessageBoxButtons.OK);
                txtW.Focus();
                return;
            }
            if (string.IsNullOrEmpty(txtH.Text))
            {
                MessageBox.Show("Chưa Nhập Chiều Cao", "Lỗi Nhập Size", MessageBoxButtons.OK);
                txtH.Focus();
            }
            else
            {
                MessageBox.Show("Nhập Size Thành Công", "Update Xong", MessageBoxButtons.OK);
                File.WriteAllText("Data\\Size", txtW.Text + "x" + txtH.Text);
            }
        }

        private void LoadForm()
        {
            new Data(dataGridView1, txtAcc).LoadFile();
            txtPass.PasswordChar = '*';
            if (!Directory.Exists("Data"))
            {
                Directory.CreateDirectory("Data");
            }
            if (!File.Exists("Data\\Mod"))
            {
                File.Create("Data\\Mod");
            }
            //if (File.Exists("Data\\IDTele"))
            //{
            //    txtTele.Text = File.ReadAllText("Data\\IDTele");
            //}
            //if (File.Exists(fileKhu))
            //{
            //    txtKhuVuc.Text = File.ReadAllText(fileKhu);
            //}
            //if (File.Exists("Data\\bossCanLoc"))
            //{
            //    txtBossDo.Text = File.ReadAllText("Data\\bossCanLoc");
            //}
            //if (File.Exists("Data\\VutDo"))
            //{
            //    txtDo.Text = File.ReadAllText("Data\\VutDo");
            //}
            //if (File.Exists("Data\\fileSpeed"))
            //{
            //    txtSpeed.Text = File.ReadAllText("Data\\fileSpeed");
            //}
            if (File.Exists("Data\\Server"))
            {
                string text = File.ReadAllText("Data\\Server");
                if (text == "6")
                    rdRose.Checked = true;
                else if (text == "10")
                    rdNoah.Checked = true;
                else
                    rdTeamobi.Checked = true;
            }
            //cbAn.Checked = true;
            if (!File.Exists("Data\\Size"))
            {
                File.WriteAllText("Data\\Size", "1024x600");
            }
            if (!File.Exists("Data\\AutoChat"))
            {
                File.Create("Data\\AutoChat");
            }
            string[] size = File.ReadAllText("Data\\Size").Split('x');
            txtW.Text = size[0];
            txtH.Text = size[1];
            if (File.Exists("Data\\ServerAdd"))
            {
                string[] svAdd = File.ReadAllText("Data\\ServerAdd").Split('|');
                txtIP.Text = svAdd[0];
                txtVer.Text = svAdd[1];
            }
            if (File.Exists("Data\\KeyServer"))
            {
                txtKey.Text = File.ReadAllText("Data\\KeyServer");
            }
            //txtChat.Text = File.ReadAllText("Data\\AutoChat");
            //string[] array = File.ReadAllText("Data\\Mod").Split('|');
            //cbXBG.Checked = array[0] == "1" ? true : false;
            //cbWall.Checked = array[1] == "1" ? true : false;
            //WriteMod();
        }

        //private void cbAn_CheckedChanged(object sender, EventArgs e)
        //{
        //    if (cbAn.Checked)
        //    {
        //        txtPass.PasswordChar = ' ';
        //        return;
        //    }
        //    txtPass.PasswordChar = '\0';
        //}

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Login(dataGridView1.CurrentRow.Index);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = dataGridView1.CurrentRow.Index;
            txtAcc.Text = dataGridView1.Rows[index].Cells[1].Value.ToString();
            txtPass.Text = dataGridView1.Rows[index].Cells[2].Value.ToString();
            cboSv.Text = dataGridView1.Rows[index].Cells[3].Value.ToString();
            txtNote.Text = dataGridView1.Rows[index].Cells[4].Value.ToString();
            cbLKType.Text = dataGridView1.Rows[index].Cells[5].Value.ToString();
        }
        //private void GetCPUAndRam()
        //{
        //    float fcpu = pCPU.NextValue();
        //    float fram = pRAM.NextValue();
        //    lbCPU.Text = "CPU : " + Math.Round(fcpu, 0) + "%";
        //    lbRAM.Text = "RAM : " + Math.Round(fram, 0) + "%";
        //}
        public static FormDashboard instance;
        public static FormDashboard gI()
        {
            if (instance == null)
            {
                return instance = new FormDashboard();
            }
            return instance;
        }
        public static int countDatagridview;
        private void timer1_Tick(object sender, EventArgs e)
        {
            countDatagridview = dataGridView1.Rows.Count;
        }

        private void guna2RadioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (rdRose.Checked)
            {
                File.WriteAllText("Data\\Server", "6");
                cboSv.Items.Clear();
                this.cboSv.Items.AddRange(new object[] {
                "ROSE",
                "ROSE 01",
                "ROSE 02",
                "ROSE 03",
                "ROSE 04",
                "ROSE 05",
                "ROSE 06",
                "Test Local"});
                ResetIPGame();
            }
        }

        #region Mã Hóa String
        private const int Keysize = 256;

        // This constant determines the number of iterations for the password bytes generation function.
        private const int DerivationIterations = 1000;

        public static string Encrypt(string plainText, string passPhrase)
        {
            // Salt and IV is randomly generated each time, but is preprended to encrypted cipher text
            // so that the same Salt and IV values can be used when decrypting.  
            var saltStringBytes = Generate256BitsOfRandomEntropy();
            var ivStringBytes = Generate256BitsOfRandomEntropy();
            var plainTextBytes = Encoding.UTF8.GetBytes(plainText);
            using (var password = new Rfc2898DeriveBytes(passPhrase, saltStringBytes, DerivationIterations))
            {
                var keyBytes = password.GetBytes(Keysize / 8);
                using (var symmetricKey = new RijndaelManaged())
                {
                    symmetricKey.BlockSize = 256;
                    symmetricKey.Mode = CipherMode.CBC;
                    symmetricKey.Padding = PaddingMode.PKCS7;
                    using (var encryptor = symmetricKey.CreateEncryptor(keyBytes, ivStringBytes))
                    {
                        using (var memoryStream = new MemoryStream())
                        {
                            using (var cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write))
                            {
                                cryptoStream.Write(plainTextBytes, 0, plainTextBytes.Length);
                                cryptoStream.FlushFinalBlock();
                                // Create the final bytes as a concatenation of the random salt bytes, the random iv bytes and the cipher bytes.
                                var cipherTextBytes = saltStringBytes;
                                cipherTextBytes = cipherTextBytes.Concat(ivStringBytes).ToArray();
                                cipherTextBytes = cipherTextBytes.Concat(memoryStream.ToArray()).ToArray();
                                memoryStream.Close();
                                cryptoStream.Close();
                                return Convert.ToBase64String(cipherTextBytes);
                            }
                        }
                    }
                }
            }
        }

        //public static string Decrypt(string cipherText, string passPhrase)
        //{
        //    // Get the complete stream of bytes that represent:
        //    // [32 bytes of Salt] + [32 bytes of IV] + [n bytes of CipherText]
        //    var cipherTextBytesWithSaltAndIv = Convert.FromBase64String(cipherText);
        //    // Get the saltbytes by extracting the first 32 bytes from the supplied cipherText bytes.
        //    var saltStringBytes = cipherTextBytesWithSaltAndIv.Take(Keysize / 8).ToArray();
        //    // Get the IV bytes by extracting the next 32 bytes from the supplied cipherText bytes.
        //    var ivStringBytes = cipherTextBytesWithSaltAndIv.Skip(Keysize / 8).Take(Keysize / 8).ToArray();
        //    // Get the actual cipher text bytes by removing the first 64 bytes from the cipherText string.
        //    var cipherTextBytes = cipherTextBytesWithSaltAndIv.Skip((Keysize / 8) * 2).Take(cipherTextBytesWithSaltAndIv.Length - ((Keysize / 8) * 2)).ToArray();

        //    using (var password = new Rfc2898DeriveBytes(passPhrase, saltStringBytes, DerivationIterations))
        //    {
        //        var keyBytes = password.GetBytes(Keysize / 8);
        //        using (var symmetricKey = new RijndaelManaged())
        //        {
        //            symmetricKey.BlockSize = 256;
        //            symmetricKey.Mode = CipherMode.CBC;
        //            symmetricKey.Padding = PaddingMode.PKCS7;
        //            using (var decryptor = symmetricKey.CreateDecryptor(keyBytes, ivStringBytes))
        //            {
        //                using (var memoryStream = new MemoryStream(cipherTextBytes))
        //                {
        //                    using (var cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read))
        //                    {
        //                        var plainTextBytes = new byte[cipherTextBytes.Length];
        //                        var decryptedByteCount = cryptoStream.Read(plainTextBytes, 0, plainTextBytes.Length);
        //                        memoryStream.Close();
        //                        cryptoStream.Close();
        //                        return Encoding.UTF8.GetString(plainTextBytes, 0, decryptedByteCount);
        //                    }
        //                }
        //            }
        //        }
        //    }
        //}

        private static byte[] Generate256BitsOfRandomEntropy()
        {
            var randomBytes = new byte[32]; // 32 Bytes will give us 256 bits.
            using (var rngCsp = new RNGCryptoServiceProvider())
            {
                // Fill the array with cryptographically secure random bytes.
                rngCsp.GetBytes(randomBytes);
            }
            return randomBytes;
        }
        #endregion
        
        private void guna2RadioButton1_CheckedChanged_1(object sender, EventArgs e)
        {
            if (rdNoah.Checked)
            {
                File.WriteAllText("Data\\Server", "10");
                cboSv.Items.Clear();
                this.cboSv.Items.AddRange(new object[] {
                "Vũ Đăng 01",
                "Vũ Đăng 02",
                "Vũ Đăng 03",
                "Vũ Đăng 04",
                "Vũ Đăng 05",
                "Vũ Đăng 06",
                "Vũ Đăng 07",
                "Vũ Đăng 08",
                "Vũ Đăng 09",
                "Vũ Đăng 10",
                "Vũ Đăng 11",
                "Vũ Đăng 12",
                "Vũ Đăng 13",
                "Vũ Đăng 14",
                "Vũ Đăng 15",
                "Vũ Đăng 16",
                "Vũ Đăng 17",
                "Vũ Đăng 18",
                "Vũ Đăng 19",
                "Vũ Đăng 20"});
                ResetIPGame();
            }
        }
        

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtIP.Text))
            {
                MessageBox.Show("Chưa nhập IP server muốn chơi");
                txtIP.Focus();
                return;
            }
            if (string.IsNullOrEmpty(txtVer.Text))
            {
                MessageBox.Show("Chưa nhập phiên bản server muốn chơi");
                txtVer.Focus();
                return;
            }
            ResetIPGame();
            File.WriteAllText("Data\\ServerAdd", txtIP.Text + "|" + txtVer.Text);
            MessageBox.Show("IP Server Muốn Chơi : " + txtIP.Text + "\nVersion Server : " + txtVer.Text);
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            File.WriteAllText("Data\\KeyServer", txtKey.Text);
            MessageBox.Show("Xong");
        }
    }
}
