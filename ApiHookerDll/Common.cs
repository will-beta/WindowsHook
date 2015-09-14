using System;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ApiHookerDll
{
    internal class Common
    {
        [DllImport("kernel32.dll")]
        internal static extern bool FreeLibrary(IntPtr hModule);

        [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
        internal static extern IntPtr GetModuleHandle(string lpModuleName);

        [DllImport("user32.dll")]
        internal static extern IntPtr GetParent(IntPtr hWnd);

        [DllImport("user32.dll")]
        internal static extern int GetWindowThreadProcessId(IntPtr hWnd, ref uint lpdwProcessId);

        [DllImport("user32.dll")]
        internal static extern bool IsWindow(IntPtr hWnd);

        [DllImport("user32.dll")]
        internal static extern bool EnumWindows(EnumWindowsDelegate lpEnumFunc, IntPtr lParam);
        internal delegate bool EnumWindowsDelegate(IntPtr hwnd, IntPtr lParam);

        internal static int[] GetUiThreadIds()
        {
            var windowHandles = new List<IntPtr>();
            var collectionHandle = GCHandle.Alloc(windowHandles);
            try
            {
                //获取屏幕上可见的所有顶级窗口，将它们的句柄保存到集合中
                EnumWindows((hwnd, hLParam) =>
                {
                    //若为顶级窗口
                    if (GetParent(hwnd) == IntPtr.Zero)
                    {
                        var list = (List<IntPtr>)GCHandle.FromIntPtr(hLParam).Target;
                        list.Add(hwnd);   // 把句柄缓存起来
                    }

                    return true;

                }, GCHandle.ToIntPtr(collectionHandle));

                //获取各句柄所在的进程与线程id
                var allWindowsInfo = windowHandles
                    .Distinct()
                    .Select(h =>
                    {
                        //获取此窗口的进程ID
                        uint pid = 0;
                        var tid = GetWindowThreadProcessId(h, ref pid);
                        return new
                        {
                            Pid = pid, // 找到进程对应的主窗口句柄
                            Tid = tid,
                            WindowHandle = h
                        };
                    });

                //根据当前进程id进行筛选
                var currentPid = (uint)Process.GetCurrentProcess().Id;
                var result = allWindowsInfo
                    .Where(info => info.Pid == currentPid)
                    .Select(info => info.Tid)
                    .ToArray();

                return result;
            }
            finally
            {
                collectionHandle.Free();
            }
        }
    }
}
