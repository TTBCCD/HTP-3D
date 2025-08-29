
using Sunny.UI.Demo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace m_CTP
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
            //处理UI线程异常
            Application.ThreadException += new System.Threading.ThreadExceptionEventHandler(Application_ThreadException);
            //处理非UI线程异常
            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);
            Application.Run(new FLogin());
            glExitApp = true;//标志应用程序可以退出
        }
        static bool glExitApp = false;
        static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            while (true)
            {//循环处理，否则应用程序将会退出
                if (glExitApp)
                {//标志应用程序可以退出，否则程序退出后，进程仍然在运行
                    if (Link.RGBControlH)
                    {
                        Link.rgb_Set.DisposeCanera();
                    }
                    if (Link.HyperCameraControlH)
                    {
                        Hyper_Set.hyperCamera.close();
                    }
                    Application.Exit();
                    return;
                }
                System.Threading.Thread.Sleep(2 * 1000);
            };
        }

        //线程报错退出程序
        static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
           
            if (Link.RGBControlH) 
            {
                Link.rgb_Set.DisposeCanera();

            }
            if (Link.HyperCameraControlH) 
            {
                Hyper_Set.hyperCamera.close();
            }
            Link link = new Link();
            link.DisPort();
            Application.Exit();
            //throw new NotImplementedException();
        }
    }
}
