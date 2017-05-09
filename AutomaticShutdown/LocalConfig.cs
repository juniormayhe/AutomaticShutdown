using System;
using System.IO.IsolatedStorage;
using System.IO;

namespace AutomaticShutdown
{
    /// <summary>
    /// Local configuration file for automatic shutdown
    /// </summary>
    public static class LocalConfig
    {
        public static bool UseLocalConfiguration;
        public static bool ShutdownEnabled;
        public static DateTime LimitHour;
        public static int TimeToWaitForConfirmationBeforeShutdown;
        public static int SnoozeTimeBeforeShutdown;
        public static IsolatedStorageFile isoStore;
        const string CONFIG_FILE = "as.cfg";
        static bool warningLocalConfigNotFound;
        static bool warningParametersNotFound;
        static LocalConfig() {
            try {
                isoStore = IsolatedStorageFile.GetStore(IsolatedStorageScope.User | IsolatedStorageScope.Assembly, null, null);
            }
            catch (Exception ex) {
                Logger.Save(string.Format("It was not possible to create a store for local configuration: {0}", ex.Message));
            }
            UseLocalConfiguration = false;
            ShutdownEnabled = true;
            LimitHour = new DateTime(DateTime.Now.Year,
                            DateTime.Now.Month,
                            DateTime.Now.Day,
                            22,
                            0,
                            0,
                            DateTimeKind.Local);
        }

        public static void SaveConfiguracao(string configuracao)
        {
            //sempre tentamos apagar arquivo de configuracao propria atual
            try
            {
                isoStore.Remove();
                
            }
            catch (Exception /*ex*/)
            {
            }

            try
            {
                isoStore = IsolatedStorageFile.GetStore(IsolatedStorageScope.User | IsolatedStorageScope.Assembly, null, null);
            }
            catch (Exception ex)
            {
                Logger.Save(string.Format("It was not possible to create a store for local configuration: {0}", ex.Message));
            }
            
            try
            {
                
                using (StreamWriter writer = new StreamWriter(new IsolatedStorageFileStream(CONFIG_FILE, FileMode.OpenOrCreate, isoStore)))
                {
                    writer.WriteLine(configuracao);
                    writer.Close();
                }
            }
            catch (Exception ex)
            {
                Logger.Save(string.Format("It was not possible to save local configuration {0}: {1}", CONFIG_FILE, ex.Message));
            }
        }

        
        public static string Load()
        {
            string configuracao = "";
            try
            {
                using (StreamReader reader = new StreamReader(new IsolatedStorageFileStream(CONFIG_FILE, FileMode.Open, isoStore)))
                {
                    String sb = reader.ReadLine();
                    reader.Close();
                    configuracao = sb.ToString();
                }
                if (true == warningLocalConfigNotFound)
                    Logger.Save(string.Format("Local configuration file returned {0}: {1}", CONFIG_FILE));
                warningLocalConfigNotFound = false;
            }
            catch (Exception ex)
            {
                //mostrar aviso uma vez
                if (false== warningLocalConfigNotFound)
                    Logger.Save(string.Format("It was not possible to load local configuration {0}: {1}", CONFIG_FILE, ex.Message));
                warningLocalConfigNotFound = true;
            }

            try
            {

                //tenta ler configuracao propria do usuario atual
                isoStore = IsolatedStorageFile.GetStore(IsolatedStorageScope.User | IsolatedStorageScope.Assembly, null, null);

                string[] arquivos = isoStore.GetFileNames(CONFIG_FILE);
                foreach (string arquivo in arquivos)
                {
                    if (arquivo == CONFIG_FILE)
                    {
                        string[] partes = configuracao.Split('|');

                        UseLocalConfiguration = partes[0] == "Y";
                        ShutdownEnabled = partes[1]=="Y";
                        LimitHour = new DateTime(DateTime.Now.Year, 
                            DateTime.Now.Month, 
                            DateTime.Now.Day, 
                            Int32.Parse(partes[2].Substring(0, 2)), 
                            Int32.Parse(partes[2].Substring(3, 2)),
                            0,
                            DateTimeKind.Local);
                        TimeToWaitForConfirmationBeforeShutdown = int.Parse(partes[3]);
                        SnoozeTimeBeforeShutdown = int.Parse(partes[4]);
                    }
                }
                warningParametersNotFound = false;

            }
            catch (Exception ex)
            {
                if (false == warningParametersNotFound)
                    Logger.Save(string.Format("It was not possible to read times in local configuration {0}. Assuming 60 min default to wait before shutdown and 120 min for postpone shutdown warning: {1}", CONFIG_FILE, ex.Message));
                warningParametersNotFound = true;
                UseLocalConfiguration = false;
                ShutdownEnabled = false;
                TimeToWaitForConfirmationBeforeShutdown = 60;//1 hora
                SnoozeTimeBeforeShutdown = 120;//duas horas

            }

            return configuracao;
        }
    }
}
