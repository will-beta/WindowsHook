using System;
using System.Runtime.InteropServices;
using EasyHook;


namespace ApiHookSelf
{
    public class Hook : IEntryPoint
    {
        public Action Handle { get; set; }

        public void DoHook()
        {
            var createFileHook = LocalHook.Create(
               LocalHook.GetProcAddress("user32.dll", "CreateWindowExW"),
               new DCreateWindowExW(CreateWindowExWImpl),
               this);

            //除了当前线程外，都进行Hook
            createFileHook.ThreadACL.SetExclusiveACL(new [] { 0 });
        }

        [DllImport("user32.dll")]
        static extern IntPtr CreateWindowExW(
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
        [UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Unicode, SetLastError = true)]
        delegate IntPtr DCreateWindowExW(
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

        IntPtr CreateWindowExWImpl(
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
            if (Handle != null)
            {
                Handle();
            }
            return CreateWindowExW(dwExStyle, lpClassName, lpWindowName, dwStyle, x, y, nWidth, nHeight, hWndParent, hMenu, hInstance, lpParam);
        }

    }
}
