using System;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Net;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace ApiHookerDestination
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Text = Process.GetCurrentProcess().Id.ToString(CultureInfo.InvariantCulture);
        }

        private void btnWindowOperateInUi_Click(object sender, EventArgs e)
        {
            ThreadPool.QueueUserWorkItem(aa => Invoke(new Action(() =>
            {
                using (var control = new ListBox())
                {
                    Debug.WriteLine(control);
                }
            })));
        }

        private void btnWindowOperateInBackground_Click(object sender, EventArgs e)
        {
            ThreadPool.QueueUserWorkItem(aa =>
            {
                using (var control = new CheckBox())
                {
                    Thread.Sleep(10000);
                    Debug.WriteLine(control);
                }
            });
        }

        private void btnFileOperateInUI_Click(object sender, EventArgs e)
        {
            const string fileName = @"new.txt";
            File.WriteAllText(fileName, @"what");
            File.Delete(fileName);
        }

        private void btnFileOperateInBackground_Click(object sender, EventArgs e)
        {
            ThreadPool.QueueUserWorkItem(aa => btnFileOperateInUI_Click(sender, e));
        }

        private void btnWebOperateInUi_Click(object sender, EventArgs e)
        {
            using (var client = new WebClient())
            {
                var pageData = client.DownloadData("http://www.baidu.com");
                Debug.WriteLine(Encoding.UTF8.GetString(pageData));
            }
        }

        private void btnWebOperateInBackground_Click(object sender, EventArgs e)
        {
            ThreadPool.QueueUserWorkItem(aa => btnWebOperateInUi_Click(sender, e));
        }

        private void btnNewUi_Click(object sender, EventArgs e)
        {
            ThreadPool.QueueUserWorkItem(aa => Application.Run(new Form1()));
        }

        private void btnShowModelWindow_Click(object sender, EventArgs e)
        {
            MessageBox.Show(DateTime.Now.ToString(CultureInfo.InvariantCulture));
        }
    }
}
