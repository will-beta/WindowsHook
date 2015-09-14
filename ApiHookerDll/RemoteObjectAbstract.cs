using System;

namespace ApiHookerDll
{
    public abstract  class RemoteObjectAbstract:MarshalByRefObject
    {
        public abstract void OnLog(Log log);

        public abstract void OnPing();
    }
}