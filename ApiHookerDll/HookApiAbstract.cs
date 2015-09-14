using System;


namespace ApiHookerDll
{
    abstract class HookApiAbstract
    {
        internal Action<string, bool> Notify { get; set; }

        abstract internal bool IsAclExclusive { get; }

        abstract internal int[] AclThreadIds { get; }

        abstract internal string ModuleName { get; }

        abstract internal string SymbolName { get; }

        abstract internal Delegate ApiDelegate { get; }
    }
}
