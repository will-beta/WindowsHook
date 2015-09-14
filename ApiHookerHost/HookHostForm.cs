using System;
using System.Diagnostics;
using System.Threading;
using System.Windows.Forms;
using ApiHookerDll;


namespace ApiHookerHost
{
    public partial class HookHostForm : Form
    {
        private readonly SynchronizationContext _sc;

        public int ProcessId { get; private set; }

        public string FilePath { get; private set; }

        private HookHostForm()
        {
            InitializeComponent();

            _sc = SynchronizationContext.Current;
            logBindingSource.DataSource = new BindingCollection<Log>();

            Helper.HandleLog = log => _sc.Send(d => logBindingSource.Add(log), null);
            Helper.HandlePing = () => _sc.Send(d => Text = string.Format("{0}      【{1}】{2} ", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), ProcessId, FilePath), null);
        }

        public HookHostForm(int processId)
            : this()
        {
            ProcessId = processId;
            ThreadPool.QueueUserWorkItem(aa =>
            {
                try
                {
                    var process = Process.GetProcessById(ProcessId);
                    FilePath = process.MainModule.FileName;

                    Helper.Inject(ProcessId);
                }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.ToString());
                    _sc.Send(d => Close(), null);
                }
            });
        }

        public HookHostForm(string filePath)
            : this()
        {
            FilePath = filePath;

            ThreadPool.QueueUserWorkItem(aa =>
            {
                try
                {
                    ProcessId = Helper.Inject(filePath);
                }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.ToString());
                    _sc.Send(d => Close(), null);
                }
            });
        }
    }
}
