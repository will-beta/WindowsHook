using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Threading;
using EasyHook;


namespace ApiHookerDll
{
    public class Main : IEntryPoint
    {
        readonly Stack<Log> _logStack = new Stack<Log>();
        readonly RemoteObjectAbstract _remoteObject;

        public Main(RemoteHooking.IContext context, String channelName)
        {
            #region 连接HOST

            try
            {
                _remoteObject = RemoteHooking.IpcConnectClient<RemoteObjectAbstract>(channelName);
                WriteLocalLog("IPC创建成功");

                _remoteObject.OnPing();
                WriteLocalLog("IPC首次ping成功");
            }
            catch (Exception exception)
            {
                PushException(exception);
                FreeSelf();
                throw;
            }
            #endregion
        }
        public void Run(RemoteHooking.IContext context, String channelName)
        {
            try
            {
                #region 钩API
                Assembly
                    .GetExecutingAssembly()
                    .GetTypes()
                    .Where(t => !t.IsAbstract && t.IsSubclassOf(typeof(HookApiAbstract)))
                    .ToList()
                    .ForEach(t =>
                    {
                        try
                        {
                            var apiProvider = Activator.CreateInstance(t) as HookApiAbstract;
                            if (apiProvider != null)
                            {
                                apiProvider.Notify = PushLog;

                                var hook = LocalHook.Create(
                                    LocalHook.GetProcAddress(apiProvider.ModuleName, apiProvider.SymbolName),
                                    apiProvider.ApiDelegate,
                                    apiProvider);

                                if (apiProvider.IsAclExclusive)
                                {
                                    hook.ThreadACL.SetExclusiveACL(apiProvider.AclThreadIds.Union(new[] { 0 }).Distinct().ToArray());
                                }
                                else
                                {
                                    hook.ThreadACL.SetInclusiveACL(apiProvider.AclThreadIds.Except(new[] { 0 }).Distinct().ToArray());
                                }

                                PushLog(string.Format("钩{0}.{1}成功", apiProvider.ModuleName, apiProvider.SymbolName));
                            }
                        }
                        catch (Exception exception)
                        {
                            PushException(exception);
                        }
                    });
                #endregion

                //尝试唤醒目标进程（只在全新启动进程并注入的情况下才有效）
                RemoteHooking.WakeUpProcess();
                PushLog("唤醒目标进程成功");
            }
            catch (Exception exception)
            {
                PushException(exception);
            }

            #region 不断向HOST输出此注入的DLL产生的各种信息

            try
            {
                while (true)
                {
                    Thread.Sleep(500);

                    if (_logStack.Any())
                    {
                        var log = _logStack.Pop();

                        if (log != null)
                        {
                            _remoteObject.OnLog(log);
                        }
                    }
                    else
                    {
                        //定时心跳HOST，以便在其停止运行时能够能够自动停止注入的DLL的运行
                        _remoteObject.OnPing();
                    }
                }
            }
            catch (Exception ex)
            {
                PushException(ex);
                FreeSelf();
                throw;
            }
            #endregion
        }

        static void FreeSelf()
        {
            try
            {
                Common.FreeLibrary(Common.GetModuleHandle(Assembly.GetExecutingAssembly().GetName().Name));
            }
            catch (Exception inException)
            {
                Debug.WriteLine(inException);
            }
        }

        void PushException(Exception exception)
        {
            var message = exception.ToString();
            PushLog(message);
            WriteLocalLog(message);
        }

        static void WriteLocalLog(string format, params object[] args)
        {
            Debug.WriteLine(format, args);
        }

        protected void PushLog(string message, bool appendStackTrace = false)
        {
            var log = new Log
            {
                Message = appendStackTrace
                ? string.Format("{0}{1}{2}", message, Environment.NewLine, Environment.StackTrace)
                : message,
                ThreadId = RemoteHooking.GetCurrentThreadId()
            };

            PushLog(log);

            try
            {
                System.IO.File.AppendAllText("hook.txt", log.ToString());
            }
            catch (Exception exception)
            {
                WriteLocalLog(exception.ToString());
            }
        }

        void PushLog(Log log)
        {
            try
            {
                _logStack.Push(log);
            }
            catch (Exception exception)
            {
                WriteLocalLog("-------------------------------送出拦截信息时发生异常" + Environment.NewLine, exception);
            }
        }
    }
}
