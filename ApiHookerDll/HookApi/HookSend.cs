using System;
using System.Runtime.InteropServices;

namespace ApiHookerDll.HookApi
{
    class HookSend : HookApiAbstract
    {
        internal override bool IsAclExclusive
        {
            get { return false; }
        }

        internal override int[] AclThreadIds
        {
            get { return Common.GetUiThreadIds(); }
        }

        internal override string ModuleName
        {
            get { return "Ws2_32.dll"; }
        }

        internal override string SymbolName
        {
            get { return "send"; }
        }

        internal override Delegate ApiDelegate
        {
            get { return new TheDelegate(TheImplement); }
        }


        int TheImplement(IntPtr s, IntPtr buf, int len, int flag)
        {

            Notify("在UI线程中直接进行了web操作", true);

            // call original API...
            return send(s, buf, len, flag);
        }

        [UnmanagedFunctionPointer(CallingConvention.StdCall,
            CharSet = CharSet.Unicode,
            SetLastError = true)]
        delegate int TheDelegate(IntPtr s, IntPtr buf, int len, int flag);

        // just use a P-Invoke implementation to get native API access from C# (this step is not necessary for C++.NET)
        [DllImport("Ws2_32.dll")]
        static extern int send(IntPtr s, IntPtr buf, int len, int flags);
    }
}
