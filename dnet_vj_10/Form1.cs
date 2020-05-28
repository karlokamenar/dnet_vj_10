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

namespace dnet_vj_10
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            backgroundWorker1.DoWork += (o, a) =>
            {
                
                for(int i=0; i < 100; i++)
                {
                    Thread.Sleep(500);
                    backgroundWorker1.ReportProgress(i * 1);
                }
                if (backgroundWorker1.CancellationPending == true)
                    a.Cancel = true;
                
            };

            backgroundWorker1.RunWorkerCompleted += (o, a) =>
            {
                progressBar1.Value = Int32.Parse(a.Result.ToString());

            };

            backgroundWorker1.ProgressChanged += (o, a) =>
            {
                progressBar1.Value = a.ProgressPercentage;
            };


            backgroundWorker1.WorkerReportsProgress = true;

            if (progressBar1.Value > 99)
                progressBar1.Value = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            backgroundWorker1.RunWorkerAsync();
            button1.Enabled = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            backgroundWorker1.CancelAsync();
            backgroundWorker1.Dispose();
            button1.Enabled = true;
            progressBar1.Value = 0;
            progressBar1.Maximum = 1;
        }

        
    }
}
