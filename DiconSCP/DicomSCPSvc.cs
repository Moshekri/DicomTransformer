using Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ConfigManager;
using System.Configuration;
using Dicom;
using NLog;
using Dicom.Network;

namespace DicomSCPService
{
    public partial class DicomSCPSvc : ServiceBase
    {
        Config configuration;
        ConfManager ConfManager;
        Logger logger;
        IDicomServer server;
        string DicomFilesPath;
        DicomFileWatcher watcher;
        public DicomSCPSvc()
        {
            DicomFilesPath = ConfigurationManager.AppSettings["DicomStorePath"];
            logger = LogManager.GetCurrentClassLogger();
            InitializeComponent();
            ConfManager = new ConfManager(ConfigurationManager.AppSettings["ConfigFilePath"]);
            configuration = ConfManager.GetConfiguration();
        }
        public void OnDebug(string[] args)
        {
            OnStart(null);
            Thread.Sleep(Timeout.Infinite);
        }

        protected override void OnStart(string[] args)
        {
           
            // preload dictionary to prevent timeouts
            var dict = DicomDictionary.Default;

           int port =  configuration.SCPPorts[0];
            if (port == 0)
            {
                port = 104;
            }

            logger.Info($"Starting Dicome Storage Service on port {port}");
            server = DicomServer.Create<DicomStorageProvider>(port);
            watcher = new DicomFileWatcher(DicomFilesPath);
            watcher.StartWatching();
        }

        protected override void OnStop()
        {
            server.Stop();
        }
        protected override void OnShutdown()
        {
            server.Stop();
            watcher.StopWatching();
            base.OnShutdown();
        }
        
    }
}
