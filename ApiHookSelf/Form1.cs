using System;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace ApiHookSelf
{
    public partial class Form1 : Form
    {
        private readonly StringBuilder _sb = new StringBuilder();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Text = Process.GetCurrentProcess().Id.ToString(CultureInfo.InvariantCulture);

            new Hook
            {
                Handle = () => AppendResult(Environment.StackTrace)
            }.DoHook();

            var timer = new System.Windows.Forms.Timer { Interval = 1000 };
            timer.Tick += (aa, bb) => txtResult.BeginInvoke(new Action(() =>
            {
                txtResult.Text = _sb.ToString();
            }));
            timer.Start();
        }

        public void AppendResult(string result)
        {
            if (_sb.Length > 7000)
            {
                _sb.Clear();
            }
            _sb.AppendLine();
            _sb.AppendLine(DateTime.Now + @"-----------------------------------------");
            _sb.AppendLine(result);
        }

        private void btnFileOperate_Click(object sender, EventArgs e)
        {
            const string fileName = @"new.txt";
            File.WriteAllText(fileName, @"what");
            File.Delete(fileName);
            AppendResult(string.Format("{0}:{1}", "文件操作", fileName));
        }

        private void btnWindowOperate_Click(object sender, EventArgs e)
        {
            ThreadPool.QueueUserWorkItem(aa =>
            {
                using (var control = new CheckBox())
                {
                    AppendResult(string.Format("{0}:{1}", "跨线程创建UI控件", control.GetType()));
                }
            });
        }

        private void btnSafeWindowOperate_Click(object sender, EventArgs e)
        {
            using (var control = new ListBox())
            {
                AppendResult(string.Format("{0}:{1}", "UI线程内安全创建控件", control.GetType()));
            }
        }
    }
}
