using System;
using System.Runtime.InteropServices;

namespace ApiHookerDll.HookApi
{
    class HookCreateWindowExW : HookApiAbstract
    {
        internal override bool IsAclExclusive
        {
            get { return true; }
        }

        internal override int[] AclThreadIds
        {
            get { return Common.GetUiThreadIds(); }
        }


        internal override string ModuleName
        {
            get { return "user32.dll"; }
        }

        internal override string SymbolName
        {
            get { return "CreateWindowExW"; }
        }

        internal override Delegate ApiDelegate
        {
            get { return new TheDelegate(TheImplement); }
        }

        IntPtr TheImplement(
            UInt32 dwExStyle,

            [MarshalAs(UnmanagedType.LPWStr)] string lpClassName,

            [MarshalAs(UnmanagedType.LPWStr)] string lpWindowName,

            UInt32 dwStyle,

            Int32 x,

            Int32 y,

            Int32 nWidth,

            Int32 nHeight,

            IntPtr hWndParent,

            IntPtr hMenu,

            IntPtr hInstance,

            IntPtr lpParam
            )
        {
            Notify("在后台线程中直接进行了UI操作", true);

            // call original API...
            return CreateWindowExW(dwExStyle, lpClassName, lpWindowName, dwStyle, x, y, nWidth, nHeight, hWndParent, hMenu, hInstance, lpParam);
        }

        [UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Unicode, SetLastError = true)]
        public delegate IntPtr TheDelegate(
           UInt32 dwExStyle,

           [MarshalAs(UnmanagedType.LPWStr)]
           string lpClassName,

           [MarshalAs(UnmanagedType.LPWStr)]
           string lpWindowName,

           UInt32 dwStyle,

           Int32 x,

           Int32 y,

           Int32 nWidth,

           Int32 nHeight,

           IntPtr hWndParent,

           IntPtr hMenu,

           IntPtr hInstance,

           IntPtr lpParam
            );

        [DllImport("user32.dll")]
        public static extern IntPtr CreateWindowExW(
           UInt32 dwExStyle,

           [MarshalAs(UnmanagedType.LPWStr)]
           string lpClassName,

           [MarshalAs(UnmanagedType.LPWStr)]
           string lpWindowName,

           UInt32 dwStyle,

           Int32 x,

           Int32 y,

           Int32 nWidth,

           Int32 nHeight,

           IntPtr hWndParent,

           IntPtr hMenu,

           IntPtr hInstance,

           IntPtr lpParam
        );
    }
}
