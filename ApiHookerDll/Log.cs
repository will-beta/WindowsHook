using System;

namespace ApiHookerDll
{
    [Serializable]
    public class Log
    {
        public DateTime CreateDateTime { get; set; }
        public int ThreadId { get; set; }
        public string Message { get; set; }

        public Log()
        {
            CreateDateTime = DateTime.Now;
        }

        public override string ToString()
        {
            return string.Format("{0}时间：{1}{0}线程：{2}{0}内容：{3}{0}", Environment.NewLine, CreateDateTime, ThreadId, Message);
        }
    }
}
