using System;
using System.IO.IsolatedStorage;
using System.IO;

namespace KeepAliveAS
{
    public static class Logger
    {
        
        static string FILE;
        static string message;
        static Logger() {
            FILE = "as.keepalive.log";   
        }

        public static void Save(string m)
        {
            if (message == m)
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
                using (StreamReader reader = new StreamReader(new IsolatedStorageFileStream(FILE, FileMode.Open, FileAccess.Read, isoStore)))
                {
                    String sb = reader.ReadLine();
                    reader.Close();
                }

            }
            catch (Exception /*ex*/)
            {
                //create a new file
                try
                {
                    using (StreamWriter writer = new StreamWriter(new IsolatedStorageFileStream(FILE, FileMode.Create, isoStore)))
                    {
                        writer.Write("");
                        writer.Close();
                    }
                }
                catch (Exception) { }
            }

            try
            {

                using (StreamWriter writer = new StreamWriter(new IsolatedStorageFileStream(FILE, FileMode.Append, FileAccess.Write, isoStore)))
                {
                    writer.WriteLine(string.Format("{0} {1}", DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"), m.Replace("\n", " ")));
                    writer.Close();
                }
            }
            catch (Exception /*ex*/)
            {
            }
            message = m;

        }

    }
}
