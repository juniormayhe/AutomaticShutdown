// *** Updated 7/8/2017 6:54 PM
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace AutomaticShutdown
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            bool result;
            var mutex = new System.Threading.Mutex(true, "38059ae7-7152-4b50-97be-6c804f89770f", out result);

            if (!result)
            {
                return;
            }
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmShutdownRequest());
            GC.KeepAlive(mutex);
        }
    }
}
