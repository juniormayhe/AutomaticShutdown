using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace AutomaticShutdown
{
    /// <summary>
    /// Main form to ask for shutdown
    /// </summary>
    public partial class frmShutdownRequest : Form
    {

        protected string ORIGINAL_WARNING;
        protected static DateTime now;
        static DateTime countdownBeforeShutdown;
        static DateTime countdownForNewWarning;
        static bool globalConfigFileNotFoundWarning;
        static bool remoteConfigurationLoaded = false;
        static bool useLocalConfig;
        static string lastMessage = "";

        //can be from global or local configuration
        static bool shutdownEnabled;

        //can be from global or local configuration
        static DateTime limitHour;

        //time to wait user confirmation for shutdown in minutes
        static int timeToWaitBeforeShutdown;

        //time to wait before new shutdown request in minutes
        static int timeToPostponeNewWarning;

        private MultiKeyGesture ctrlCP = new MultiKeyGesture(new List<Keys> { Keys.C, Keys.P }, Keys.Control);

        public frmShutdownRequest()
        {
            this.Hide();
            this.WindowState = FormWindowState.Minimized;
            Logger.Save("Starting automatic shutdown...");
            Process.GetCurrentProcess().PriorityClass = ProcessPriorityClass.BelowNormal;
            
            InitializeComponent();
            ORIGINAL_WARNING = lblWarning.Text;
            now = DateTime.Now;
        }
        
        private void btnYes_Click(object sender, EventArgs e)
        {
            Logger.Save(string.Format("User {0} confirmed shutdown in {1}", Environment.UserName, Environment.MachineName));
            shutdown();
        }

        private static void shutdown() {
            Logger.Save("Shutting down...");
            
            var psi = new ProcessStartInfo("shutdown", "/s /f /t 0");
            psi.CreateNoWindow = true;
            psi.UseShellExecute = false;
            Process.Start(psi);
        }

        private void btnNo_Click(object sender, EventArgs e)
        {
            postpone();
        }

        private void postpone() {
            Logger.Save(string.Format("User {0} postponed shutdown in {1}. Waiting for {2} minutes before new shutdown warning...", Environment.UserName, Environment.MachineName, timeToPostponeNewWarning));
            //gives 60 minutes before ask again for shutdown
            if (false == postponeTimer.Enabled)
            {
                //counter for checking if its time to ask for shutdown
                mainTimer.Enabled = false;
                mainTimer.Stop();
                //counter to shutdown because of user inactivity
                userInactivityTimer.Enabled = false;
                userInactivityTimer.Stop();

                //avoid multiples recounts
                countdownForNewWarning = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Hour, 0, 0, DateTimeKind.Local);
                countdownForNewWarning = countdownForNewWarning.AddMinutes(timeToPostponeNewWarning);
                postponeTimer.Enabled = true;
                postponeTimer.Start();
            }
            this.Hide();

        }

        [DllImport("user32.dll")]
        private static extern int ShowWindow(IntPtr hWnd, uint Msg);

        private void mainTimer_Tick(object sender, EventArgs e)
        {
            if (backgroundWorker1.IsBusy)
                return;
            
            backgroundWorker1.RunWorkerAsync();
            
        }

        
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            string message = "";
            //local configuration always overrides global configuration
            LocalConfig.Load();
            useLocalConfig = LocalConfig.UseLocalConfiguration;
            //is there a local config?
            if (useLocalConfig)
            {
                //is shutdown enabled
                shutdownEnabled = LocalConfig.ShutdownEnabled;

                //when to ask for shutdown
                limitHour = LocalConfig.LimitHour;

                //15 minutes default tolerance when there is no confirmation from user before proceeding with shutdown
                timeToWaitBeforeShutdown = LocalConfig.TimeToWaitForConfirmationBeforeShutdown;

                //when shutdown is postponed, ask user again in 60 minutes
                timeToPostponeNewWarning = LocalConfig.SnoozeTimeBeforeShutdown;

                message = string.Format("Assuming local configuration shutdownEnabled={0}, limitHour={1}, {2}min wait before shutdown and {3}min postpone time before new warning", shutdownEnabled ? "Yes" : "No", 
                    limitHour.ToString("HH:mm"), 
                    timeToWaitBeforeShutdown, 
                    timeToPostponeNewWarning);
            }
            else {
                //maybe there is a global configuration set in a file in a network share
                try
                {
                    FileInfo fi= new FileInfo(ConfigurationManager.AppSettings["GLOBAL_CONFIGURATOR"]);
                    using (StreamReader sr = fi.OpenText())
                    {
                        GlobalConfig.DefaultConfig = sr.ReadToEnd();
                    }
                    remoteConfigurationLoaded = true;
                    
                    this.Invoke((MethodInvoker)delegate
                    {
                        panel1.BackColor = Color.ForestGreen;
                    });

                    //log warning just one time
                    if (globalConfigFileNotFoundWarning == true)
                        Logger.Save(string.Format("Global remote configuration returned: {0}", ConfigurationManager.AppSettings["GLOBAL_CONFIGURATOR"]));
                    globalConfigFileNotFoundWarning = false;
                }
                catch (Exception ex) {
                    //log warning just one time
                    if (globalConfigFileNotFoundWarning==false)
                        Logger.Save(string.Format("It was not possible to load global configuration file: {0}", ex.Message));
                    globalConfigFileNotFoundWarning= true;
                    remoteConfigurationLoaded = false;
                    
                    this.Invoke((MethodInvoker)delegate
                    {
                        panel1.BackColor = Color.Crimson;
                    });
                }

            }
            
            if (lastMessage != message)
            { 
                lastMessage = message;
                Logger.Save(lastMessage);
            }

        }
        

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            now = DateTime.Now.ToLocalTime();

            if (useLocalConfig)
            {
                toolTip1.SetToolTip(panel1, "Local configuration loaded");
            }
            else { 
                try
                {
                    //after async task has ended, load global config settings
                    GlobalConfig.Load();
                    
                    shutdownEnabled = GlobalConfig.ShutdownEnabled;
                    
                    //local shutdown policy disabled
                    if (false == shutdownEnabled)
                        Logger.Save("Automatic shutdown was disabled in global configuration");

                    //limit hour
                    limitHour = GlobalConfig.LimitHour;

                    //15 minutes wait tolerance when there is no user confirmation before proceeding with shutdown
                    timeToWaitBeforeShutdown = GlobalConfig.TimeToWaitBeforeShutdown;

                    //when shutdown is postponed, ask user again in 60 minutos
                    timeToPostponeNewWarning = GlobalConfig.TimeToPostponeShutdown;

                    lblWarning.Text = ORIGINAL_WARNING.Replace("[HOUR]", GlobalConfig.LimitHour.ToString("HH:mm"));
                    toolTip1.SetToolTip(panel1, remoteConfigurationLoaded ? "Global remote configuration loaded" : "Default configuration loaded");
                }
                catch (Exception ex)
                {
                    Logger.Save(string.Format("It was not possible to load remote global configuration. Assuming default limit hour {0}: {1}", GlobalConfig.LimitHour.ToShortTimeString(), ex.Message));
                    toolTip1.SetToolTip(panel1, "Configuration could not be loaded");
                
                }
            }
            panel1.Update();

            //default behavior is to show shutdown request if there is a local configuration
            bool showWarning;
            
            LocalConfig.Load();

            if (LocalConfig.UseLocalConfiguration)
            {
                showWarning = LocalConfig.ShutdownEnabled && Int32.Parse(now.ToString("HHmm")) >= Int32.Parse(LocalConfig.LimitHour.ToString("HHmm"));
            }
            else
            {
                showWarning = GlobalConfig.ShutdownEnabled && GlobalConfig.LimitHour.Year != 1 && Int32.Parse(now.ToString("HHmm")) >= Int32.Parse(GlobalConfig.LimitHour.ToString("HHmm"));
            }
            
            if (showWarning)
            {
                if (LocalConfig.UseLocalConfiguration)
                    Logger.Save(string.Format("User {0} in {1} surpassed own limit hour {2}. Showing warning and waiting for confirmation in {3} minutes...", Environment.UserName, Environment.MachineName, LocalConfig.LimitHour.ToShortTimeString(), timeToWaitBeforeShutdown));
                else
                    Logger.Save(string.Format("User {0} in {1} surpassed limit hour {2}. Showing warning and waiting for confirmation in {3} minutes...", Environment.UserName, Environment.MachineName, GlobalConfig.LimitHour.ToShortTimeString(), timeToWaitBeforeShutdown));
                ShowWindow(this.Handle, 0x09);
                this.Show();
                this.Activate();
                this.TopLevel = true;

                //gives 15 minutes for user to decide
                if (false == userInactivityTimer.Enabled)
                {
                    
                    mainTimer.Enabled = false;
                    mainTimer.Stop();
                    
                    countdownBeforeShutdown = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Hour, 0, 0, DateTimeKind.Local);
                    countdownBeforeShutdown = countdownBeforeShutdown.AddMinutes(timeToWaitBeforeShutdown);
                    userInactivityTimer.Enabled = true;
                    userInactivityTimer.Start();
                }
            }
            else
            {
                //hide warning if limit hour was not hit
                userInactivityTimer.Stop();
                userInactivityTimer.Enabled = false;

                if (false == mainTimer.Enabled)
                {
                    mainTimer.Enabled = true;
                    mainTimer.Start();
                }
                this.Hide();
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            postpone();
            
            e.Cancel = true;
        }

        private void userInactivityTimer_Tick(object sender, EventArgs e)
        {
            //if user walked away from computer, it gives some time before shutting down
            this.Invoke((MethodInvoker)delegate
            {
                btnYes.Text = string.Format("Yes, turn off in {0:D2}min {1:D2}s", +countdownBeforeShutdown.Minute, countdownBeforeShutdown.Second);
            });
            countdownBeforeShutdown= countdownBeforeShutdown.AddSeconds(-1);
            if (countdownBeforeShutdown.Minute == 0 && countdownBeforeShutdown.Second == 0)
                shutdown();

        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            //user pressed shift + C + P to create local configuration
            if (ctrlCP.Matches(e))
            {
                Logger.Save(string.Format("User {0} used shortcut SHIFT + C + P for local configuration", Environment.UserName));
                frmLocalConfiguration c = new frmLocalConfiguration();
                c.ShowDialog();

                LocalConfig.Load();

                if (LocalConfig.UseLocalConfiguration) { 
                    shutdownEnabled = LocalConfig.ShutdownEnabled;
                    timeToWaitBeforeShutdown = LocalConfig.TimeToWaitForConfirmationBeforeShutdown;
                    timeToPostponeNewWarning = LocalConfig.SnoozeTimeBeforeShutdown;


                    countdownBeforeShutdown = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Hour, 0, 0, DateTimeKind.Local);
                    countdownBeforeShutdown = countdownBeforeShutdown.AddMinutes(timeToWaitBeforeShutdown);
                
                    btnYes.Text = string.Format("Yes, turn off in {0:D2}min {1:D2}s", +countdownBeforeShutdown.Minute, countdownBeforeShutdown.Second);
                    countdownForNewWarning = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Hour, 0, 0, DateTimeKind.Local);
                    countdownForNewWarning = countdownForNewWarning.AddMinutes(timeToPostponeNewWarning);

                    //disable shutdown button and reactivate main timer
                    btnYes.Enabled = true;
                    if (LocalConfig.UseLocalConfiguration && false == shutdownEnabled)
                    {
                        btnYes.Text = "Yes";
                        btnYes.Enabled = false;
                        userInactivityTimer.Enabled = false;
                        userInactivityTimer.Stop();

                        //show warning again because extra time is over
                        mainTimer.Enabled = true;
                        mainTimer.Start();
                    }
                }
            }
        }


        private class MultiKeyGesture
        {
            private List<Keys> _keys;
            public MultiKeyGesture(IEnumerable<Keys> keys, Keys modifiers)
            {
                _keys = new List<Keys>(keys);

                if (_keys.Count == 0)
                {
                    throw new ArgumentException("At least one key must be specified.", "keys");
                }
            }

            private int currentindex;
            public bool Matches(KeyEventArgs e)
            {
                if (_keys[currentindex] == e.KeyCode)
                    //at least a partial match
                    currentindex++;
                else
                    //No Match
                    currentindex = 0;
                if (currentindex + 1 > _keys.Count)
                {
                    //Matched last key
                    currentindex = 0;
                    return true;
                }
                return false;
            }
        }

        private void postponeTimer_Tick(object sender, EventArgs e)
        {
            //count down before show shutdown request again
            countdownForNewWarning = countdownForNewWarning.AddSeconds(-1);
            if (countdownForNewWarning.Minute == 0 && countdownForNewWarning.Second == 0)
            {
                postponeTimer.Enabled = false;
                postponeTimer.Stop();
                userInactivityTimer.Enabled = false;
                userInactivityTimer.Stop();
                
                //mostra mensagem de novo porque o tempo extra acabou
                mainTimer.Enabled = true;
                mainTimer.Start();
            }

            
            
        }
    }


}
