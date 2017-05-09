using System;
using System.Configuration;
using System.Diagnostics;
using System.Threading;
using System.Timers;

/// <summary>
/// Keep alive AS - AutomaticShutdown
/// </summary>
namespace KeepAliveAS
{
    class Program
    {
        static ManualResetEvent _quitEvent = new ManualResetEvent(false);
        static System.Timers.Timer timer;
        const string AS = "AS";
        [STAThread]
        static void Main(string[] args)
        {
            bool result;
            var mutex = new System.Threading.Mutex(true, "7d4266dc-a6d2-4514-924d-6cde9f1ff321", out result);

            if (!result)
            {
                return;
            }
            

            Logger.Save("Starting KeepAliveAS...");
            Process.GetCurrentProcess().PriorityClass = ProcessPriorityClass.BelowNormal;

            Console.CancelKeyPress += (sender, eArgs) => {
                _quitEvent.Set();
                eArgs.Cancel = true;
            };

            checkAutomaticShutdown();

            Logger.Save("Staring timer every 30 seconds...");
            timer = new System.Timers.Timer(30 * 1000);
            timer.Enabled = true;
            timer.Elapsed += Timer_Elapsed;
            timer.Start();

            _quitEvent.WaitOne();

            GC.KeepAlive(mutex);
        }

        //guarantee automaticshutdown is running
        private static void checkAutomaticShutdown() {
            Process[] processes = Process.GetProcessesByName(AS);
            //process was found
            if (processes.Length > 0)
                return;

            Logger.Save(string.Format("Program was not enabled for user {0} in {1}", Environment.UserName, Environment.MachineName));
            //try to execute AutomaticShutdown in the same path
            try
            {
                Logger.Save(string.Format("Trying to start {0}", AS));
                Process.Start(AS);
                Logger.Save("AutomaticShutdown has started.");
            }
            catch (Exception ex)
            {
                Logger.Save(string.Format("It was not possible to start {0}: {1}" , AS, ex.Message));
            }

            //tenta executar o saveresources da rede
            try
            {
                Logger.Save(string.Format("Trying to start {0}{1}", ConfigurationManager.AppSettings["NETWORK_PATH"], AS));
                Process.Start(string.Format("{0}{1}", ConfigurationManager.AppSettings["NETWORK_PATH"], AS));
                Logger.Save("AutomaticShutdown has started.");
            }
            catch (Exception ex)
            {
                Logger.Save(string.Format("It was not possible to start {0}: {1}", string.Format("{0}{1}", ConfigurationManager.AppSettings["NETWORK_PATH"], AS), ex.Message));
            }
        }

        private static void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            checkAutomaticShutdown();
            
        }
    }
}
