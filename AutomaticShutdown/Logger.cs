using System;
using System.IO.IsolatedStorage;
using System.IO;

namespace AutomaticShutdown
{
    public static class Logger
    {
        
        static string LOG_FILE;
        static string MESSAGE;

        static Logger() {
            LOG_FILE = "as.log";
            
        }
        
        public static void Save(string m)
        {
            if (MESSAGE == m)
                return;
            IsolatedStorageFile isoStore = null;
            try
            {
                isoStore = IsolatedStorageFile.GetStore(IsolatedStorageScope.User | IsolatedStorageScope.Assembly, null, null);
            }
            catch (Exception)
            {
            }

            try
            {
                using (StreamReader reader = new StreamReader(new IsolatedStorageFileStream(LOG_FILE, FileMode.Open, FileAccess.Read, isoStore)))
                {
                    String sb = reader.ReadLine();
                    reader.Close();
                }

            }
            catch (Exception /*ex*/)
            {
                //create a new log if there isn't one
                try
                {
                    using (StreamWriter writer = new StreamWriter(new IsolatedStorageFileStream(LOG_FILE, FileMode.Create, isoStore)))
                    {
                        writer.Write("");
                        writer.Close();
                    }
                }
                catch (Exception) { }
            }
            
            try
            {
                
                using (StreamWriter writer = new StreamWriter(new IsolatedStorageFileStream(LOG_FILE, FileMode.Append, FileAccess.Write, isoStore)))
                {
                    writer.WriteLine(string.Format("{0} {1}", DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"),m.Replace("\n", " ")));
                    writer.Close();
                }
            }
            catch (Exception /*ex*/)
            {
            }
            MESSAGE = m;
            
        }

    }
}
