# AutomaticShutdown
Allow IT administrators to quickly deploy a Windows shutdown policy over a network with a shared configuration file.


```
     /\        | |                      | | (_)     
    /  \  _   _| |_ ___  _ __ ___   __ _| |_ _  ___ 
   / /\ \| | | | __/ _ \| '_ ` _ \ / _` | __| |/ __|
  / ____ \ |_| | || (_) | | | | | | (_| | |_| | (__ 
 /_/____\_\__,_|\__\___/|_| |_| |_|\__,_|\__|_|\___|
  / ____| |         | |    | |                      
 | (___ | |__  _   _| |_ __| | _____      ___ __    
  \___ \| '_ \| | | | __/ _` |/ _ \ \ /\ / / '_ \   
  ____) | | | | |_| | || (_| | (_) \ V  V /| | | |  
 |_____/|_| |_|\__,_|\__\__,_|\___/ \_/\_/ |_| |_|  
```




## Deploy Instructions

* If you want to automatically shutdown computers running Windows in your Network, make sure that all computers have .NET Framework 4.6.1 installed.

* In each computer, deploy AS.exe, KeepAliveAS.exe and AS.config
	
* In each computer edit AS.config for changing the GLOBAL_CONFIGURATOR. It should point to a file name shared in your network, which will be visible for all computers. I.e.:
```
<add key="GLOBAL_CONFIGURATOR" value="\\A-REMOTE-HOST\SHARED-FOLDER\as.global.cfg"/>
```

* Make sure all computers have read right over network for shared configuration file \\A-REMOTE-HOST\SHARED-FOLDER\
	
* Edit the global configuration file \\A-REMOTE-HOST\SHARED-FOLDER\as.global.cfg and add a shutdown policy configuration for all computers:
```
//LIMIT HOUR can be: 10PM, 10 PM OR 22 
LIMIT HOUR = 10PM

//TIME TO WAIT IN MINUTES FOR USER CONFIRMATION BEFORE SHUTDOWN. TO WAIT FOR 1 HOUR FOR USER'S CONFIRMATION ENTER 60
TIME TO CONFIRM SHUTDOWN = 60

//TIME TO WAIT IN MINUTES BEFORE ASKING AGAIN ABOUT SHUTDOWN. TO POSTPONE FOR 2 HOURS, INFORM EQUIVALENT SECONDS: 120
TIME TO POSTPONE SHUTDOWN = 120

//TO ENABLE AUTOMATIC SHUTDOWN put: Y or YES or 1 AND TO DISABLE PUT N or NO or 0
SHUTDOWN ENABLED = Y

//NAME OF HOSTNAMES WHICH SHUTDOWN WILL NOT BE EXECUTED can be: YOUR-COMPUTER ANOTHER-HOSTNAME or YOUR-COMPUTER, ANOTHER-HOSTNAME
IGNORE HOSTNAMES = LOCALHOST
```
* In each computer, add a scheduled task in Windows for running KeepAliveAS.exe at Windows start up; or add it exe into your logon script.

* When a shutdown warning appears, you set a local shutdown policy in a specific computer by pressing [SHIFT] + [C] + [P]


## Debug instructions

* Make sure you have a Postbuild command in AS project such as 
```
xcopy "$(TargetDir)*.*" "$(ProjectDir)..\KeepAliveAS\bin\Debug\" /Y /I
```
This will copy AS outputs (exe and config) to KeepAliveAS folder, as keep alive tries to find in current path AS.exe in order to keep it runnning.

* Set the solution to start multiple projects (AS and KeepAliveAS).
* Run the solution

## Comments and feedback

You can drop me a message at juniormayhe [at] gmail.com
