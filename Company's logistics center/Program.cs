using Autofac;
using System;
using System.Windows.Forms;

namespace LogisticsCenter
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var container = ContainerConfig.Configure();

            bool relogin;

            do
            {
                using (var scope = container.BeginLifetimeScope())
                {
                    relogin = scope.Resolve<IApplicationController>().Run(scope);
                }
            } while (relogin);
        }
    }
}