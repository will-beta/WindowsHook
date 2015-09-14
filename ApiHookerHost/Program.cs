using System;
using System.Threading;
using System.Windows.Forms;


namespace ApiHookerHost
{
    class Program : MarshalByRefObject
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            if (args != null && args.Length > 0)
            {
                int pId;
                Application.Run(int.TryParse(args[0], out pId)
                    ? new HookHostForm(pId)
                    : new HookHostForm(args[0]));
            }
            else
            {
                Application.Run(new SelectAppForm());
            }
        }

        public void Start(string[] args)
        {
            var autoEvent = new AutoResetEvent(false);
            var thread = new Thread(() =>
            {
                Main(args);
                autoEvent.Set();
            });
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
            autoEvent.WaitOne();
        }
    }
}
