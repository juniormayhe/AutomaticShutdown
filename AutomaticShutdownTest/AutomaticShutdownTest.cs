using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AutomaticShutdown;

namespace AutomaticShutdownTest
{
    [TestClass]
    public class Testing
    {
        [TestMethod]
        public void Limit_Hour_10PM()
        {
            GlobalConfig.DefaultConfig = @"
                    //LIMIT HOUR can be: 10PM, 10 PM OR 22 
                    LIMIT HOUR = 10 PM
                    //AUTOMATIC SHUTDOWN can be: Y or YES or Y or YES or 1
                    SHUTDOWN ENABLED = Y
                    //IGNORE HOSTNAMES = YOUR-HOSTNAME ANOTHER-HOSTNAME or your-hostname, another-hostname
                    IGNORE HOSTNAMES = LOCALHOST
                ";
            GlobalConfig.Load();
            DateTime limitHour = GlobalConfig.LimitHour;
            Assert.IsTrue(limitHour.Hour == 22 && limitHour.Minute == 0, "10 PM must be converted to 22");
        }
        
        [TestMethod]
        public void Limit_Hour_10AM()
        {
            GlobalConfig.DefaultConfig = @"
                    //LIMIT HOUR can be: 10PM, 10 PM OR 22 
                    LIMIT HOUR = 10AM
                    //AUTOMATIC SHUTDOWN can be: Y or YES or Y or YES or 1
                    SHUTDOWN ENABLED = Y
                    //IGNORE HOSTNAMES = YOUR-HOSTNAME ANOTHER-HOSTNAME or your-hostname, another-hostname
                    IGNORE HOSTNAMES = LOCALHOST
                ";
            GlobalConfig.Load();
            DateTime limitHour = GlobalConfig.LimitHour;
            Assert.IsTrue(limitHour.Hour == 10 && limitHour.Minute == 0, "10AM must be converted to 10");
        }

        [TestMethod]
        public void Limit_Hour_10_AM()
        {
            GlobalConfig.DefaultConfig = @"
                    //LIMIT HOUR can be: 10PM, 10 PM OR 22 
                    LIMIT HOUR = 10 AM
                    //AUTOMATIC SHUTDOWN can be: Y or YES or Y or YES or 1
                    SHUTDOWN ENABLED = Y
                    //IGNORE HOSTNAMES = YOUR-HOSTNAME ANOTHER-HOSTNAME or your-hostname, another-hostname
                    IGNORE HOSTNAMES = LOCALHOST
                ";
            GlobalConfig.Load();
            DateTime limitHour = GlobalConfig.LimitHour;
            Assert.IsTrue(limitHour.Hour == 10 && limitHour.Minute == 0, "10 AM must be converted to 10");
        }

        
        [TestMethod]
        public void Limit_Hour_1030PM()
        {
            GlobalConfig.DefaultConfig = @"
                    //LIMIT HOUR can be: 10PM, 10 PM OR 22 
                    LIMIT HOUR = 10:30 PM
                    //AUTOMATIC SHUTDOWN can be: Y or YES or Y or YES or 1
                    SHUTDOWN ENABLED = Y
                    //IGNORE HOSTNAMES = YOUR-HOSTNAME ANOTHER-HOSTNAME or your-hostname, another-hostname
                    IGNORE HOSTNAMES = LOCALHOST
                ";
            GlobalConfig.Load();
            DateTime limitHour = GlobalConfig.LimitHour;
            Assert.IsTrue(limitHour.Hour == 22 && limitHour.Minute == 30, "10:30 PM must be converted to 22:30");
        }
        
        [TestMethod]
        public void Limit_Hour_1030AM()
        {
            GlobalConfig.DefaultConfig = @"
                    //LIMIT HOUR can be: 10PM, 10 PM OR 22 
                    LIMIT HOUR = 10:30AM
                    //AUTOMATIC SHUTDOWN can be: Y or YES or Y or YES or 1
                    SHUTDOWN ENABLED = Y
                    //IGNORE HOSTNAMES = YOUR-HOSTNAME ANOTHER-HOSTNAME or your-hostname, another-hostname
                    IGNORE HOSTNAMES = LOCALHOST
                ";
            GlobalConfig.Load();
            DateTime limitHour = GlobalConfig.LimitHour;
            Assert.IsTrue(limitHour.Hour == 10 && limitHour.Minute == 30, "10:30AM must be converted to 10:30");
        }
        
        [TestMethod]
        public void Limit_Hour_1030()
        {
            GlobalConfig.DefaultConfig = @"
                    //LIMIT HOUR can be: 10PM, 10 PM OR 22 
                    LIMIT HOUR = 10:30
                    //AUTOMATIC SHUTDOWN can be: Y or YES or Y or YES or 1
                    SHUTDOWN ENABLED = Y
                    //IGNORE HOSTNAMES = YOUR-HOSTNAME ANOTHER-HOSTNAME or your-hostname, another-hostname
                    IGNORE HOSTNAMES = LOCALHOST
                ";
            GlobalConfig.Load();
            DateTime limitHour = GlobalConfig.LimitHour;
            Assert.IsTrue(limitHour.Hour == 10 && limitHour.Minute == 30, "10:30 must be converted to 10:30");
        }
        [TestMethod]
        public void Limit_Hour_22()
        {
            GlobalConfig.DefaultConfig = @"
                    //LIMIT HOUR can be: 10PM, 10 PM OR 22 
                    LIMIT HOUR = 22
                    //AUTOMATIC SHUTDOWN can be: Y or YES or Y or YES or 1
                    SHUTDOWN ENABLED = Y
                    //IGNORE HOSTNAMES = YOUR-HOSTNAME ANOTHER-HOSTNAME or your-hostname, another-hostname
                    IGNORE HOSTNAMES = LOCALHOST
                ";
            GlobalConfig.Load();
            DateTime limitHour = GlobalConfig.LimitHour;
            Assert.IsTrue(limitHour.Hour == 22 && limitHour.Minute == 0, "22 must be converted to 22");
        }


        [TestMethod]
        public void Limit_Hour_2230()
        {
            GlobalConfig.DefaultConfig = @"
                    //LIMIT HOUR can be: 10PM, 10 PM OR 22 
                    LIMIT HOUR = 22:30
                    //AUTOMATIC SHUTDOWN can be: Y or YES or Y or YES or 1
                    SHUTDOWN ENABLED = Y
                    //IGNORE HOSTNAMES = YOUR-HOSTNAME ANOTHER-HOSTNAME or your-hostname, another-hostname
                    IGNORE HOSTNAMES = LOCALHOST
                ";
            GlobalConfig.Load();
            DateTime limitHour = GlobalConfig.LimitHour;
            Assert.IsTrue(limitHour.Hour == 22 && limitHour.Minute == 30, "22 must be converted to 22:30");
        }


        [TestMethod]
        public void Limit_Hour_10()
        {
            GlobalConfig.DefaultConfig = @"
                    //LIMIT HOUR can be: 10PM, 10 PM OR 22 
                    LIMIT HOUR = 10
                    //AUTOMATIC SHUTDOWN can be: Y or YES or Y or YES or 1
                    SHUTDOWN ENABLED = Y
                    //IGNORE HOSTNAMES = YOUR-HOSTNAME ANOTHER-HOSTNAME or your-hostname, another-hostname
                    IGNORE HOSTNAMES = LOCALHOST
                ";
            GlobalConfig.Load();
            DateTime limitHour = GlobalConfig.LimitHour;
            Assert.IsTrue(limitHour.Hour == 10 && limitHour.Minute == 0, "10 must be converted to 10");
        }
        
        
        [TestMethod]
        public void Limit_Hour_950()
        {
            GlobalConfig.DefaultConfig = @"
                    //LIMIT HOUR can be: 10PM, 10 PM OR 22 
                    LIMIT HOUR=9:50
                    //AUTOMATIC SHUTDOWN can be: Y or YES or Y or YES or 1
                    SHUTDOWN ENABLED = Y
                    //IGNORE HOSTNAMES = YOUR-HOSTNAME ANOTHER-HOSTNAME or your-hostname, another-hostname
                    IGNORE HOSTNAMES = LOCALHOST
                ";
            GlobalConfig.Load();
            DateTime limitHour = GlobalConfig.LimitHour;
            Assert.IsTrue(limitHour.Hour == 9&& limitHour.Minute == 50, "9:50 must be converted to 9:50");
        }


        [TestMethod]
        public void Limit_Hour_950_AM()
        {
            GlobalConfig.DefaultConfig = @"
                    //LIMIT HOUR can be: 10PM, 10 PM OR 22 
                    LIMIT HOUR=9:50 AM
                    //AUTOMATIC SHUTDOWN can be: Y or YES or Y or YES or 1
                    SHUTDOWN ENABLED = Y
                    //IGNORE HOSTNAMES = YOUR-HOSTNAME ANOTHER-HOSTNAME or your-hostname, another-hostname
                    IGNORE HOSTNAMES = LOCALHOST
                ";
            GlobalConfig.Load();
            DateTime limitHour = GlobalConfig.LimitHour;
            Assert.IsTrue(limitHour.Hour == 9 && limitHour.Minute == 50, "9:50 AM must be converted to 9:50");
        }


        [TestMethod]
        public void Limit_Hour_950AM()
        {
            GlobalConfig.DefaultConfig = @"
                    //LIMIT HOUR can be: 10PM, 10 PM OR 22 
                    LIMIT HOUR=9:50AM
                    //AUTOMATIC SHUTDOWN can be: Y or YES or Y or YES or 1
                    SHUTDOWN ENABLED = Y
                    //IGNORE HOSTNAMES = YOUR-HOSTNAME ANOTHER-HOSTNAME or your-hostname, another-hostname
                    IGNORE HOSTNAMES = LOCALHOST
                ";
            GlobalConfig.Load();
            DateTime limitHour = GlobalConfig.LimitHour;
            Assert.IsTrue(limitHour.Hour == 9 && limitHour.Minute == 50, "9:50AM must be converted to 9:50");
        }

        [TestMethod]
        public void Limit_Hour_950_PM()
        {
            GlobalConfig.DefaultConfig = @"
                    //LIMIT HOUR can be: 10PM, 10 PM OR 22 
                    LIMIT HOUR=9:50 PM
                    //AUTOMATIC SHUTDOWN can be: Y or YES or Y or YES or 1
                    SHUTDOWN ENABLED = Y
                    //IGNORE HOSTNAMES = YOUR-HOSTNAME ANOTHER-HOSTNAME or your-hostname, another-hostname
                    IGNORE HOSTNAMES = LOCALHOST
                ";
            GlobalConfig.Load();
            DateTime limitHour = GlobalConfig.LimitHour;
            Assert.IsTrue(limitHour.Hour == 21 && limitHour.Minute == 50, "9:50 PM must be converted to 9:50");
        }


        [TestMethod]
        public void Limit_Hour_950PM()
        {
            GlobalConfig.DefaultConfig = @"
                    //LIMIT HOUR can be: 10PM, 10 PM OR 22 
                    LIMIT HOUR=9:50PM
                    //AUTOMATIC SHUTDOWN can be: Y or YES or Y or YES or 1
                    SHUTDOWN ENABLED = Y
                    //IGNORE HOSTNAMES = YOUR-HOSTNAME ANOTHER-HOSTNAME or your-hostname, another-hostname
                    IGNORE HOSTNAMES = LOCALHOST
                ";
            GlobalConfig.Load();
            DateTime limitHour = GlobalConfig.LimitHour;
            Assert.IsTrue(limitHour.Hour == 21 && limitHour.Minute == 50, "9:50PM must be converted to 21:50");
        }


        [TestMethod]
        public void Limit_Hour_9PM()
        {
            GlobalConfig.DefaultConfig = @"
                    //LIMIT HOUR can be: 10PM, 10 PM OR 22 
                    LIMIT HOUR=9PM
                    //AUTOMATIC SHUTDOWN can be: Y or YES or Y or YES or 1
                    SHUTDOWN ENABLED = Y
                    //IGNORE HOSTNAMES = YOUR-HOSTNAME ANOTHER-HOSTNAME or your-hostname, another-hostname
                    IGNORE HOSTNAMES = LOCALHOST
                ";
            GlobalConfig.Load();
            DateTime limitHour = GlobalConfig.LimitHour;
            Assert.IsTrue(limitHour.Hour == 21 && limitHour.Minute == 0, "9PM must be converted to 21:00");
        }

        [TestMethod]
        public void Limit_Hour_9_PM()
        {
            GlobalConfig.DefaultConfig = @"
                    //LIMIT HOUR can be: 10PM, 10 PM OR 22 
                    LIMIT HOUR=9 PM
                    //AUTOMATIC SHUTDOWN can be: Y or YES or Y or YES or 1
                    SHUTDOWN ENABLED = Y
                    //IGNORE HOSTNAMES = YOUR-HOSTNAME ANOTHER-HOSTNAME or your-hostname, another-hostname
                    IGNORE HOSTNAMES = LOCALHOST
                ";
            GlobalConfig.Load();
            DateTime limitHour = GlobalConfig.LimitHour;
            Assert.IsTrue(limitHour.Hour == 21 && limitHour.Minute == 0, "9 PM must be converted to 21:00");
        }


        [TestMethod]
        public void Limit_Hour_21_PM()
        {
            GlobalConfig.DefaultConfig = @"
                    //LIMIT HOUR can be: 10PM, 10 PM OR 22 
                    LIMIT HOUR=21
                    //AUTOMATIC SHUTDOWN can be: Y or YES or Y or YES or 1
                    SHUTDOWN ENABLED = Y
                    //IGNORE HOSTNAMES = YOUR-HOSTNAME ANOTHER-HOSTNAME or your-hostname, another-hostname
                    IGNORE HOSTNAMES = LOCALHOST
                ";
            GlobalConfig.Load();
            DateTime limitHour = GlobalConfig.LimitHour;
            Assert.IsTrue(limitHour.Hour == 21 && limitHour.Minute == 0, "21 must be converted to 21:00");
        }

        [TestMethod]
        public void Limit_Hour_9_AM()
        {
            GlobalConfig.DefaultConfig = @"
                    //LIMIT HOUR can be: 10PM, 10 PM OR 22 
                    LIMIT HOUR=9 AM
                    //AUTOMATIC SHUTDOWN can be: Y or YES or Y or YES or 1
                    SHUTDOWN ENABLED = Y
                    //IGNORE HOSTNAMES = YOUR-HOSTNAME ANOTHER-HOSTNAME or your-hostname, another-hostname
                    IGNORE HOSTNAMES = LOCALHOST
                ";
            GlobalConfig.Load();
            DateTime limitHour = GlobalConfig.LimitHour;
            Assert.IsTrue(limitHour.Hour == 9 && limitHour.Minute == 0, "9 AM must be converted to 9:00");
        }
        
        [TestMethod]
        public void Ingore_Machine()
        {
            GlobalConfig.DefaultConfig = @"
                    //LIMIT HOUR can be: 10PM, 10 PM OR 22 
                    LIMIT HOUR=9 AM
                    //AUTOMATIC SHUTDOWN can be: Y or YES or Y or YES or 1
                    SHUTDOWN ENABLED = Y
                    //IGNORE HOSTNAMES = YOUR-HOSTNAME ANOTHER-HOSTNAME or your-hostname, another-hostname
                    IGNORE HOSTNAMES = LOCALHOST
                ";
            GlobalConfig.Load();

            Assert.IsTrue(true == GlobalConfig.IgnoreThisComputer, "This hostname should be ignored");
        }

        [TestMethod]
        public void Ingore_Machines()
        {
            GlobalConfig.DefaultConfig = @"
                    //LIMIT HOUR can be: 10PM, 10 PM OR 22 
                    LIMIT HOUR=9 AM
                    //AUTOMATIC SHUTDOWN can be: Y or YES or Y or YES or 1
                    SHUTDOWN ENABLED = Y
                    //IGNORE HOSTNAMES = YOUR-HOSTNAME ANOTHER-HOSTNAME or your-hostname, another-hostname
                    IGNORE HOSTNAMES = LOCALHOST, local
                ";
            GlobalConfig.Load();

            Assert.IsTrue(true == GlobalConfig.IgnoreThisComputer, "This hostname should be ignored");
        }

        [TestMethod]
        public void Automatic_Shutdown_YES()
        {
            GlobalConfig.DefaultConfig = @"
                    //LIMIT HOUR can be: 10PM, 10 PM OR 22 
                    LIMIT HOUR=9 AM
                    //AUTOMATIC SHUTDOWN can be: Y or YES or Y or YES or 1
                    SHUTDOWN ENABLED = yes
                    //IGNORE HOSTNAMES = YOUR-HOSTNAME ANOTHER-HOSTNAME or your-hostname, another-hostname
                    IGNORE HOSTNAMES = LOCALHOST
                ";
            GlobalConfig.Load();

            Assert.IsTrue(true == GlobalConfig.ShutdownEnabled, "Shutdown should be enabled");
        }
        
        [TestMethod]
        public void Automatic_Shutdown_Y()
        {
            GlobalConfig.DefaultConfig = @"
                    //LIMIT HOUR can be: 10PM, 10 PM OR 22 
                    LIMIT HOUR=9 AM
                    //AUTOMATIC SHUTDOWN can be: Y or YES or Y or YES or 1
                    SHUTDOWN ENABLED=  y
                    //IGNORE HOSTNAMES = YOUR-HOSTNAME ANOTHER-HOSTNAME or your-hostname, another-hostname
                    IGNORE HOSTNAMES = LOCALHOST
                ";
            GlobalConfig.Load();

            Assert.IsTrue(true == GlobalConfig.ShutdownEnabled, "Shutdown should be enabled");
        }


        [TestMethod]
        public void Automatic_Shutdown_No()
        {
            GlobalConfig.DefaultConfig = @"
                    //LIMIT HOUR can be: 10PM, 10 PM OR 22 
                    LIMIT HOUR=9 AM
                    //AUTOMATIC SHUTDOWN can be: Y or YES or Y or YES or 1
                    SHUTDOWN ENABLED = no
                    //IGNORE HOSTNAMES = YOUR-HOSTNAME ANOTHER-HOSTNAME or your-hostname, another-hostname
                    IGNORE HOSTNAMES = LOCALHOST
                ";
            GlobalConfig.Load();

            Assert.IsTrue(false == GlobalConfig.ShutdownEnabled, "Shutdown should be disabled");
        }

        [TestMethod]
        public void Automatic_Shutdown_N()
        {
            GlobalConfig.DefaultConfig = @"
                    //LIMIT HOUR can be: 10PM, 10 PM OR 22 
                    LIMIT HOUR=9 AM
                    //AUTOMATIC SHUTDOWN can be: Y or YES or Y or YES or 1
                    SHUTDOWN ENABLED = n
                    //IGNORE HOSTNAMES = YOUR-HOSTNAME ANOTHER-HOSTNAME or your-hostname, another-hostname
                    IGNORE HOSTNAMES = LOCALHOST
                ";
            GlobalConfig.Load();

            Assert.IsTrue(false == GlobalConfig.ShutdownEnabled, "Shutdown should be disabled");
        }
    }
}
