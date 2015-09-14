using System;
using ApiHookerDll;

namespace ApiHookerHost
{
    class RemoteObjectImpl : RemoteObjectAbstract
    {
        public static Action<Log> HandleLog { get; set; }
        public static Action HandlePing { get; set; }

        public override void OnLog(Log log)
        {
            if (HandleLog != null)
            {
                HandleLog(log);
            }
        }

        public override void OnPing()
        {
            if (HandlePing != null)
            {
                HandlePing();
            }
        }
    }
}
