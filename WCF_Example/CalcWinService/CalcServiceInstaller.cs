using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration.Install;
using System.ServiceProcess;
using System.Configuration;
using System.IO;
using System.Diagnostics;

namespace WCFHostedWindowsService
{
    [RunInstaller(true)]
    public partial class CalcServiceInstaller : System.Configuration.Install.Installer
    {
        string _logfile = @"C:\Users\johary\Downloads\Calcservice.log";

        public void Log(string message)
        {
            using (var file = new StreamWriter(_logfile, true))
            {
                file.WriteLine("{0}   {1}",
                    DateTime.Now.ToString("dd/MM/yyyy  HH:mm:ss.ff"),
                    message);
            }
        }

        public CalcServiceInstaller()
        {
            InitializeComponent();
            Log("-------------------------");
            Log("Constructor CalcServiceInstaller()");
            Log(serviceInstaller1.Description);

            //processInstaller1 = new ServiceProcessInstaller();
            //processInstaller1.Account = ServiceAccount.LocalSystem;
            //Installers.Add(processInstaller1);

            //serviceInstaller1 = new ServiceInstaller();
            //serviceInstaller1.ServiceName = "@calcservice";
            //serviceInstaller1.Description = "Calculation service, WCF tutorial";
            //serviceInstaller1.StartType = ServiceStartMode.Automatic;
            //Installers.Add(serviceInstaller1);


        }
        private void serviceInstaller1_BeforeInstall(object sender, InstallEventArgs e)
        {
            Log("serviceInstaller1_BeforeInstall");

        }
        private void serviceInstaller1_AfterInstall(object sender, InstallEventArgs e)
        {
            Log("serviceInstaller1_AfterInstall()");
            using (ServiceController sc = new ServiceController(serviceInstaller1.ServiceName))
            {
                Log(string.Format("The service status is:{0}", sc.Status.ToString()));
                if (sc.Status == ServiceControllerStatus.Stopped)
                {
                    Log("Starting the service...");
                    try
                    {
                        // Start the service, and wait until its status is "Running".
                        sc.Start();
                        sc.WaitForStatus(ServiceControllerStatus.Running);

                        // Display the current service status.
                        Log(string.Format("The service status is:{0}", sc.Status.ToString()));
                    }
                    catch (InvalidOperationException)
                    {
                        Log("Could not start the service.");
                    }
                }
                else
                {
                    Log("Service is already running.");
                }
            }
        }
        private void serviceInstaller1_BeforeUninstall(object sender, InstallEventArgs e)
        {
            Log("serviceInstaller1_BeforeUninstall()");
            
        }
        private void serviceInstaller1_AfterUninstall(object sender, InstallEventArgs e)
        {
            Log("serviceInstaller1_AfterUninstall");
            //using (ServiceController sc = new ServiceController(serviceInstaller1.ServiceName))
            //{
            //    Log(string.Format("The service status is:{0}", sc.Status.ToString()));
            //    if (sc.Status != ServiceControllerStatus.Stopped)
            //    {
            //        Log("Stopping the service...");
            //        try
            //        {
            //            // Start the service, and wait until its status is "Running".
            //            sc.Stop();
            //            sc.WaitForStatus(ServiceControllerStatus.Stopped);

            //            // Display the current service status.
            //            Log(string.Format("The service status is:{0}", sc.Status.ToString()));

            //            //Delete the service
            //            Log("Deleting the service");
            //            using (Process myProcess = new Process())
            //            {
            //                myProcess.StartInfo.FileName = "sc.exe";
            //                myProcess.StartInfo.Arguments = string.Format("DELETE {0}", serviceInstaller1.ServiceName);
            //                myProcess.Start();
            //                myProcess.WaitForExit();
            //            }
            //            Log("Service deleted");
            //        }
            //        catch (InvalidOperationException)
            //        {
            //            Log("Could not stop the service.");
            //        }
            //        catch (Exception ex)
            //        {
            //            Log(ex.Message);
            //        }
            //    }
            //    else
            //    {
            //        Log("Service is already stopped.");
            //    }
            //}
        }
        
    }
}
