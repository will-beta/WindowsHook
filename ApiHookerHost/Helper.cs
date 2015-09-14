﻿using System;
using System.Runtime.Remoting;
using ApiHookerDll;
using EasyHook;

namespace ApiHookerHost
{
    class Helper
    {
        public static Action<Log> HandleLog
        {
            get { return RemoteObjectImpl.HandleLog; }
            set { RemoteObjectImpl.HandleLog = value; }
        }

        public static Action HandlePing
        {
            get { return RemoteObjectImpl.HandlePing; }
            set { RemoteObjectImpl.HandlePing = value; }
        }

        public static void Inject(int targetProcessId)
        {
            string channelName = null;
            RemoteHooking.IpcCreateServer<RemoteObjectImpl>(ref channelName, WellKnownObjectMode.SingleCall);

            var injectedDllName = typeof(RemoteObjectAbstract).Assembly.Location;

            RemoteHooking.Inject(
                targetProcessId,
                injectedDllName,
                injectedDllName,
                channelName);
        }
        public static int Inject(string targetFilePath)
        {
            string channelName = null;
            RemoteHooking.IpcCreateServer<RemoteObjectImpl>(ref channelName, WellKnownObjectMode.SingleCall);

            var injectedDllName = typeof(RemoteObjectAbstract).Assembly.Location;

            int processId;
            RemoteHooking.CreateAndInject(
                targetFilePath,
                null,
                (int)ProcessCreationFlags.CREATE_NEW_PROCESS_GROUP,
                InjectionOptions.DoNotRequireStrongName,
                injectedDllName,
                injectedDllName,
                out processId,
                channelName);
            return processId;
        }

        internal enum ProcessCreationFlags : uint
        {
            ZERO_FLAG = 0x00000000,
            CREATE_BREAKAWAY_FROM_JOB = 0x01000000,
            CREATE_DEFAULT_ERROR_MODE = 0x04000000,
            CREATE_NEW_CONSOLE = 0x00000010,
            CREATE_NEW_PROCESS_GROUP = 0x00000200,
            CREATE_NO_WINDOW = 0x08000000,
            CREATE_PROTECTED_PROCESS = 0x00040000,
            CREATE_PRESERVE_CODE_AUTHZ_LEVEL = 0x02000000,
            CREATE_SEPARATE_WOW_VDM = 0x00001000,
            CREATE_SHARED_WOW_VDM = 0x00001000,
            CREATE_SUSPENDED = 0x00000004,
            CREATE_UNICODE_ENVIRONMENT = 0x00000400,
            DEBUG_ONLY_THIS_PROCESS = 0x00000002,
            DEBUG_PROCESS = 0x00000001,
            DETACHED_PROCESS = 0x00000008,
            EXTENDED_STARTUPINFO_PRESENT = 0x00080000,
            INHERIT_PARENT_AFFINITY = 0x00010000
        }
    }
}
