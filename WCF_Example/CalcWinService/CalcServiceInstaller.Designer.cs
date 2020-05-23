namespace WCFHostedWindowsService
{
    partial class CalcServiceInstaller
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.serviceInstaller1 = new System.ServiceProcess.ServiceInstaller();
            this.processInstaller1 = new System.ServiceProcess.ServiceProcessInstaller();
            // 
            // serviceInstaller1
            // 
            this.serviceInstaller1.Description = "Calculation service v 3.05";
            this.serviceInstaller1.ServiceName = "@calcservice";
            this.serviceInstaller1.StartType = System.ServiceProcess.ServiceStartMode.Automatic;
            this.serviceInstaller1.AfterInstall += new System.Configuration.Install.InstallEventHandler(this.serviceInstaller1_AfterInstall);
            this.serviceInstaller1.AfterUninstall += new System.Configuration.Install.InstallEventHandler(this.serviceInstaller1_AfterUninstall);
            this.serviceInstaller1.BeforeInstall += new System.Configuration.Install.InstallEventHandler(this.serviceInstaller1_BeforeInstall);
            this.serviceInstaller1.BeforeUninstall += new System.Configuration.Install.InstallEventHandler(this.serviceInstaller1_BeforeUninstall);
            // 
            // processInstaller1
            // 
            this.processInstaller1.Account = System.ServiceProcess.ServiceAccount.LocalSystem;
            this.processInstaller1.Password = null;
            this.processInstaller1.Username = null;
            // 
            // CalcServiceInstaller
            // 
            this.Installers.AddRange(new System.Configuration.Install.Installer[] {
            this.serviceInstaller1,
            this.processInstaller1});

        }

        #endregion

        private System.ServiceProcess.ServiceInstaller serviceInstaller1;
        private System.ServiceProcess.ServiceProcessInstaller processInstaller1;
    }
}