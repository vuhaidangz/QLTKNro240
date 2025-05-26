using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLTK_Vũ_Đăng
{
    public partial class FormLoad : Form
    {
        public FormLoad()
        {
            InitializeComponent();
        }

        private void FormLoad_Load(object sender, EventArgs e)
        {
            Start();
        }

        private int PercentComplete { get; set; }
        private Task ProcessData(List<string> list, IProgress<FormLoad> progress)
        {
            int index = 1;
            int totalProgress = list.Count;
            var progressReport = new FormLoad();
            return Task.Run(() =>
            {
                for (int i = 0; i < totalProgress; i++)
                {
                    progressReport.PercentComplete = index++ * 100 / totalProgress;
                    progress.Report(progressReport);
                    Thread.Sleep(1);
                }
            });
        }
        public async void Start()
        {
            List<string> list = new List<string>();
            for (int i = 0; i < 250; i++)
                list.Add(i.ToString());
            guna2HtmlLabel1.Text = "Wait A Second...";
            var progress = new Progress<FormLoad>();
            progress.ProgressChanged += (o, report) =>
            {
                guna2HtmlLabel1.Text = string.Format("Loading...{0}%", report.PercentComplete);
                guna2ProgressBar1.Value = report.PercentComplete;
                guna2ProgressBar1.Update();
            };
            await ProcessData(list, progress);
            guna2HtmlLabel1.Text = "Done !";
        }
    }
}
