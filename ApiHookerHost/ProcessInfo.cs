namespace ApiHookerHost
{
    public class ProcessInfo
    {
        public int? 标识 { get; set; }

        public string 进程名 { get; set; }

        public string 标题 { get; set; }

        public string 路径 { get; set; }

        public override int GetHashCode()
        {
            return (标识 + 进程名 + 标题 + 路径).GetHashCode();
        }
    }
}
