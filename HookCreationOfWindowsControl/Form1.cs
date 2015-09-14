using System;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using HookLibrary;


namespace HookCreationOfWindowsControl
{
    public partial class Form1 : Form
    {
        #region Hook
        private IntPtr _hookProcPtr; //记录Hook编号

        public void SetHook()
        {
            if (_hookProcPtr != IntPtr.Zero) //已经勾过了
                return;

            _hookProcPtr = HookHelper.HookForCreationOfHookInNonUiThread(CustomHookProc);

            if (_hookProcPtr == IntPtr.Zero)
            {
                MessageBox.Show("钩子失败");
            }
        }

        public void UnHook()
        {
            HookHelper.UnHookForCreationOfHookInNonUiThread(_hookProcPtr); //从Hook链中取消
        }

        void CustomHookProc(IntPtr wparam, IntPtr lparam)
        {
            if (_uiThreadId == Thread.CurrentThread.ManagedThreadId) return;

            var className = new StringBuilder(256);
            HookHelper.GetClassName(wparam, className, className.Capacity);

            var msg = className.ToString();
            var stackTrace = Environment.StackTrace;

            _sc.Post(d =>
            {
                if (myListItemBindingSource.Count > 20)
                {
                    myListItemBindingSource.Clear();
                }
                myListItemBindingSource.Add(new MyListItem { Text = msg, Hint = stackTrace });
            }, null);
        }
        #endregion

        #region 窗体事件处理

        private readonly SynchronizationContext _sc;
        private readonly int _uiThreadId;

        public Form1()
        {
            InitializeComponent();
            _sc = SynchronizationContext.Current;
            _uiThreadId = Thread.CurrentThread.ManagedThreadId;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            SetHook();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            UnHook();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var button = new Button();
            label1.Text = button.Handle.ToString();
            button.Dispose();
        }

        #endregion

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var item = myListItemBindingSource.Current as MyListItem;
            if (item != null)
            {
                textBox1.Text = item.Hint;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ThreadPool.QueueUserWorkItem(aa =>
            {
                var control = new TextBox();
                label1.Text = control.Handle.ToString();
                control.Dispose();
            });
        }
    }
    public class MyListItem
    {
        public string Text { get; set; }
        public string Hint { get; set; }
    }

}
