using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace HookWindowsMessage
{
    public partial class Form1 : Form
    {
        #region 引入必须的Windows API
        /// <summary>
        /// 取得当前线程编号的AP
        /// </summary>
        /// <returns></returns>
        [DllImport("kernel32.dll")]
        static extern int GetCurrentThreadId();

        /// <summary>
        /// 取消Hook的API
        /// </summary>
        /// <param name="handle"></param>
        [DllImport("User32.dll")]
        internal extern static void UnhookWindowsHookEx(IntPtr handle);

        /// <summary>
        /// 设置Hook的API
        /// </summary>
        /// <param name="idHook">Hook类型，例如WH_KEYBOARD，WH_MOUSE</param>
        /// <param name="lpfn">Hook处理过程函数的地址</param>
        /// <param name="hinstance">包含Hook处理过程函数的dll句柄（若在本进程可以为NULL）</param>
        /// <param name="threadId">要Hook的线程ID，若为0，表示全局Hook所有</param>
        /// <returns></returns>
        [DllImport("User32.dll")]
        internal extern static IntPtr SetWindowsHookEx(int idHook, [MarshalAs(UnmanagedType.FunctionPtr)] HookProc lpfn, IntPtr hinstance, int threadId);

        /// <summary>
        /// 取得下一个Hook的API
        /// </summary>
        /// <param name="handle"></param>
        /// <param name="code"></param>
        /// <param name="wparam"></param>
        /// <param name="lparam"></param>
        /// <returns></returns>
        [DllImport("User32.dll")]
        internal extern static IntPtr CallNextHookEx(IntPtr handle, int code, IntPtr wparam, IntPtr lparam);
        #endregion

        #region 声明一个实现的委托
        internal delegate IntPtr HookProc(int code, IntPtr wparam, IntPtr lparam);
        #endregion

        #region 添加加入Hook链和从Hook链中取消的函数
        private IntPtr _hookProcPtr; //记录Hook编号

        internal enum HookType //枚举，钩子的类型
        {

            //MsgFilter     = -1,

            //JournalRecord    = 0,

            //JournalPlayback  = 1,

            Keyboard = 2,

            //GetMessage       = 3,

            //CallWndProc      = 4,

            //CBT              = 5,

            //SysMsgFilter     = 6,

            //Mouse            = 7,

            //Hardware         = 8,

            //Debug            = 9,

            //Shell           = 10,

            //ForegroundIdle  = 11,

            //CallWndProcRet  = 12,

            //KeyboardLL        = 13,

            //MouseLL           = 14,

        };

        public void SetHook()
        {
            if (_hookProcPtr != IntPtr.Zero) //已经勾过了
                return;

            _hookProcPtr = SetWindowsHookEx((int)HookType.Keyboard, MyHookProc, IntPtr.Zero, GetCurrentThreadId()); //加到Hook链中
        }

        public void UnHook()
        {
            if (_hookProcPtr != IntPtr.Zero)
            {
                UnhookWindowsHookEx(_hookProcPtr); //从Hook链中取消

                _hookProcPtr = IntPtr.Zero;
            }
        }

        /// <summary>
        /// 定义自己的Hook处理过程
        /// </summary>
        /// <param name="code"></param>
        /// <param name="wparam"></param>
        /// <param name="lparam"></param>
        /// <returns></returns>
        IntPtr MyHookProc(int code, IntPtr wparam, IntPtr lparam)
        {
            if (code < 0) return CallNextHookEx(_hookProcPtr, code, wparam, lparam); //返回，让后面的程序处理该消息           


            if (wparam.ToInt32() == 98 || wparam.ToInt32() == 66) //如果用户输入的是 b
            {
                textBox1.Text = @"a";

                return (IntPtr)1; //直接返回了，该消息就处理结束了
            }

            return IntPtr.Zero; //返回，让后面的程序处理该消息
        }
        #endregion

        #region 窗体事件处理

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            SetHook();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            UnHook();
        }

        #endregion
    }
}
