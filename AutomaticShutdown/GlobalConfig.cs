using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;

namespace AutomaticShutdown
{
    /// <summary>
    /// Global configuration file (in a network share) visible for all deployed agents in a network
    /// </summary>
    public sealed class GlobalConfig
    {
        
        //horário que a máquina será desligada
        const int LIMIT_HOUR = 22;
        
        static string DEFAULT_CONFIG = @"
                    //LIMIT HOUR can be: 10PM, 10 PM OR 22 
                    LIMIT HOUR = 01:15PM

                    //TIME TO WAIT FOR USER CONFIRMATION BEFORE SHUTDOWN. TO WAIT FOR 1 HOUR FOR USER'S CONFIRMATION ENTER 60
                    TIME TO CONFIRM SHUTDOWN = 60

                    //TIME TO WAIT BEFORE ASKING AGAIN ABOUT SHUTDOWN. TO POSTPONE FOR 2 HOURS, INFORM EQUIVALENT SECONDS: 120
                    TIME TO POSTPONE SHUTDOWN = 120

                    //AUTOMATIC SHUTDOWN can be: Y or YES or Y or YES or 1
                    SHUTDOWN ENABLED = Y

                    //NAME OF HOSTNAMES WHICH SHUTDOWN WILL NOT BE EXECUTED can be YOUR-COMPUTER ANOTHER-HOSTNAME or YOUR-COMPUTER, ANOTHER-HOSTNAME
                    IGNORE HOSTNAMES = LOCALHOST
                ";

        //horario desligamento
        public static DateTime LimitHour{
            get; set;
        }
        
        //Ignorar estacao
        public static bool IgnoreThisComputer
        {
            get; set;
        }

        //tempo de espera em minutos antes de desligar
        public static int TimeToWaitBeforeShutdown
        {
            get; set;
        }

        //tempo de espera em minutos antes de perguntar sobre desligamento
        public static int TimeToPostponeShutdown
        {
            get; set;
        }

        //desligamento ativado?
        public static bool ShutdownEnabled
        {
            get; set;
        }
        public static string DefaultConfig
        {
            get
            {
                return DEFAULT_CONFIG;
            }
            set {
                DEFAULT_CONFIG = value;
            }
        }

        //Tenta ler a configuracao global de um arquivo localizado na rede
        //ou usa configuracao padrao de 10 da noite para desligamento automatico
        public static void Load()
        {
            LimitHour = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, LIMIT_HOUR, 0, 0, DateTimeKind.Local);
            ShutdownEnabled =true;
            IgnoreThisComputer = true;
            try
            {

                string[] lines = DEFAULT_CONFIG.Split('\n');
                foreach (string line in lines)
                {
                    string[] item = line.ToUpperInvariant().Split('=');
                    string key;
                    string value;
                    string error = "";
                    
                    try
                    {
                        if (item.Length < 2)
                            continue;
                        key = item[0].Trim();
                        value = item[1].Trim();
                    }
                    catch (IndexOutOfRangeException iex)
                    {
                        error = iex.Message;
                        continue;
                    }
                    catch (Exception) {
                        continue;
                    }

                    #region hora limite
                    if (key == "LIMIT HOUR")
                    {
                        int hour = LIMIT_HOUR;
                        int minute = 0;

                        //caso o horario tenha sido definido como hh:mm
                        if (value.IndexOf(":") > 0)
                        {
                            string[] time = value.Split(':');
                            hour = int.Parse(time[0]);
                            minute = int.Parse(time[1].Replace("PM", "").Replace("AM",""));
                        }
                        else
                        {
                            //hora limite foi definida como hhPM or hh PM
                            hour = int.Parse(Regex.Match(value, @"\d+").Value);
                        }
                        //se hora contem AM or PM
                        if (value.EndsWith("PM"))
                        {
                            hour += 12;
                            if (hour == 12)
                                hour = 0;
                        }

                        LimitHour = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, hour, minute, 0, DateTimeKind.Local);
                        continue;
                    }
                    #endregion

                    if (key == "TIME TO CONFIRM SHUTDOWN")
                    {
                        TimeToWaitBeforeShutdown = int.Parse(Regex.Match(value, @"\d+").Value);
                        continue;
                    }

                    if (key == "TIME TO POSTPONE SHUTDOWN")
                    {
                        TimeToPostponeShutdown = int.Parse(Regex.Match(value, @"\d+").Value);
                        continue;
                    }

                    if (key == "SHUTDOWN ENABLED")
                    {
                        ShutdownEnabled = value == "Y" || value == "YES" || value == "1";
                        continue;
                    }

                    if (key == "IGNORE HOSTNAMES")
                    {
                        List<string> estacoes = new List<string>(Regex.Replace(value.Replace(",", " "), @"\s+", " ").Split(' '));
                        estacoes = estacoes.Select(x => x.ToUpperInvariant() == "LOCALHOST" ? Environment.MachineName.ToUpperInvariant() : x).ToList();
                        
                        IgnoreThisComputer = estacoes.Contains(Environment.MachineName.ToUpperInvariant());
                        continue;
                    }
                }//para cada linha da configuracao
            }
            catch (Exception)
            {
            }
            
        }
    }
}
