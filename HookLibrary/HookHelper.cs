using System;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;


namespace HookLibrary
{
    public class HookHelper
    {
        #region 声明一个实现的委托
        public delegate IntPtr HookProc(int code, IntPtr wparam, IntPtr lparam);
        #endregion

        #region Hook类型
        public enum HookType //枚举，钩子的类型
        {

            MsgFilter = -1,

            JournalRecord = 0,

            JournalPlayback = 1,

            Keyboard = 2,

            GetMessage = 3,

            CallWndProc = 4,

            Cbt = 5,

            SysMsgFilter = 6,

            Mouse = 7,

            Hardware = 8,

            Debug = 9,

            Shell = 10,

            ForegroundIdle = 11,

            CallWndProcRet = 12,

            KeyboardLl = 13,

            MouseLl = 14,
        };


        #endregion

        #region 引入必须的Windows API
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern int GetClassName(IntPtr hWnd, StringBuilder lpClassName, int nMaxCount);

        /// <summary>
        /// 取得当前线程编号的AP
        /// </summary>
        /// <returns></returns>
        [DllImport("kernel32.dll")]
        public static extern int GetCurrentThreadId();

        /// <summary>
        /// 取消Hook的API
        /// </summary>
        /// <param name="handle"></param>
        [DllImport("User32.dll")]
        public extern static void UnhookWindowsHookEx(IntPtr handle);

        /// <summary>
        /// 设置Hook的API
        /// </summary>
        /// <param name="idHook">Hook类型，例如WH_KEYBOARD，WH_MOUSE</param>
        /// <param name="lpfn">Hook处理过程函数的地址</param>
        /// <param name="hinstance">包含Hook处理过程函数的dll句柄（若在本进程可以为NULL）</param>
        /// <param name="threadId">要Hook的线程ID，若为0，表示全局Hook所有</param>
        /// <returns></returns>
        [DllImport("User32.dll")]
        public extern static IntPtr SetWindowsHookEx(int idHook, [MarshalAs(UnmanagedType.FunctionPtr)] HookProc lpfn, IntPtr hinstance, int threadId);

        /// <summary>
        /// 取得下一个Hook的API
        /// </summary>
        /// <param name="handle"></param>
        /// <param name="code"></param>
        /// <param name="wparam"></param>
        /// <param name="lparam"></param>
        /// <returns></returns>
        [DllImport("User32.dll")]
        public extern static IntPtr CallNextHookEx(IntPtr handle, int code, IntPtr wparam, IntPtr lparam);

        [DllImport("kernel32.dll")]
        public static extern IntPtr GetModuleHandle(string name);
        #endregion

        #region 包装

        public static IntPtr SetGlobalHook(HookType hookType, HookProc hookProc)
        {
            var hinstance = Marshal.GetHINSTANCE(Assembly.GetExecutingAssembly().GetModules()[0]);
            return SetWindowsHookEx((int)hookType, hookProc, hinstance, 0); //加到Hook链中
        }

        public static IntPtr HookForCreationOfHookInNonUiThread(Action<IntPtr, IntPtr> action)
        {
            IntPtr[] handle = { default(IntPtr) };
            HookProc hookProc = (code, wparam, lparam) =>
            {
                try
                {
                    if (code < 0) return CallNextHookEx(handle[0], code, wparam, lparam); //返回，让后面的程序处理该消息           

                    #region 自定义处理

                    switch (code)
                    {
                        case 3: //HCBT_CREATEWND
                            action(wparam, lparam);
                            break;
                    }

                    #endregion
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex);
                }

                return IntPtr.Zero; //返回，让后面的程序处理该消息
            };
            handle[0] = SetGlobalHook(HookType.Cbt, hookProc);
            return handle[0];
        }

        public static void UnHookForCreationOfHookInNonUiThread(IntPtr hookProcPtr)
        {
            if (hookProcPtr != IntPtr.Zero)
            {
                UnhookWindowsHookEx(hookProcPtr); //从Hook链中取消
            }
        }

        #endregion
    }
}
