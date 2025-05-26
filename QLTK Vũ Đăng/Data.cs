using System;
using System.IO;
using Guna.UI2.WinForms;

namespace QLTK_Vũ_Đăng
{
    class Data
    {
        public Guna2DataGridView DataGridView
        {
            get
            {
                return this.dataGridView;
            }
            set
            {
                this.dataGridView = value;
            }
        }
        public Guna2TextBox Acc
        {
            get
            {
                return this.acc;
            }
            set
            {
                this.acc = value;
            }
        }
        public Data(Guna2DataGridView dataGridView, Guna2TextBox textBox)
        {
            this.DataGridView = dataGridView;
            this.Acc = textBox;
        }
        public Data(Guna2TextBox textBox)
        {
            this.Acc = textBox;
        }
        public void ExportFile()
        {
            for (int i = 0; i < DataGridView.Rows.Count; i++)
            {
                this.DataGridView.Rows[i].Cells[0].Value = i + 1;
            }
            if (!File.Exists("Data\\Account"))
            {
                File.Create("Data\\Account");
            }
            TextWriter textWriter = new StreamWriter("Data\\Account");
            for (int j = 0; j < this.DataGridView.Rows.Count; j++)
            {
                for (int k = 0; k < this.DataGridView.Columns.Count - 0; k++)
                {
                    textWriter.Write(this.DataGridView.Rows[j].Cells[k].Value.ToString() + "|");
                }
                textWriter.WriteLine("");
            }
            textWriter.Close();
        }
        public void LoadFile()
        {
            try
            {
                this.DataGridView.Rows.Clear();
                string[] array = File.ReadAllLines("Data\\Account");
                for (int i = 0; i < array.Length; i++)
                {
                    string[] array2 = array[i].ToString().Split(new char[]
                    {
                        '|'
                    });
                    this.DataGridView.Rows.Add(new object[]
                    {
                        array2[0],
                        array2[1],
                        array2[2],
                        array2[3],
                        array2[4],
                        array2[5]
                    });
                }
            }
            catch (Exception)
            {
            }
        }
        public Guna2DataGridView dataGridView;
        private Guna2TextBox acc;
    }
}
