using System;
using System.Runtime.InteropServices;


namespace ApiHookerDll.HookApi
{
    class HookWFile : HookApiAbstract
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
            get { return "kernel32.dll"; }
        }

        internal override string SymbolName
        {
            get { return "CreateFileW"; }
        }

        internal override Delegate ApiDelegate
        {
            get { return new TheDelegate(TheImplement); }
        }


        IntPtr TheImplement(
            String InFileName,
            UInt32 InDesiredAccess,
            UInt32 InShareMode,
            IntPtr InSecurityAttributes,
            UInt32 InCreationDisposition,
            UInt32 InFlagsAndAttributes,
            IntPtr InTemplateFile)
        {
            Notify("在UI线程中直接进行了IO操作", true);

            // call original API...
            return CreateFile(
                InFileName,
                InDesiredAccess,
                InShareMode,
                InSecurityAttributes,
                InCreationDisposition,
                InFlagsAndAttributes,
                InTemplateFile);
        }

        [UnmanagedFunctionPointer(CallingConvention.StdCall,
            CharSet = CharSet.Unicode,
            SetLastError = true)]
        delegate IntPtr TheDelegate(
            String InFileName,
            UInt32 InDesiredAccess,
            UInt32 InShareMode,
            IntPtr InSecurityAttributes,
            UInt32 InCreationDisposition,
            UInt32 InFlagsAndAttributes,
            IntPtr InTemplateFile);

        // just use a P-Invoke implementation to get native API access from C# (this step is not necessary for C++.NET)
        [DllImport("kernel32.dll",
            CharSet = CharSet.Unicode,
            CallingConvention = CallingConvention.StdCall)]
        static extern IntPtr CreateFile(
            String InFileName,
            UInt32 InDesiredAccess,
            UInt32 InShareMode,
            IntPtr InSecurityAttributes,
            UInt32 InCreationDisposition,
            UInt32 InFlagsAndAttributes,
            IntPtr InTemplateFile);
    }
}
