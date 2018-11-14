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
using System.Runtime.InteropServices;
using System.IO;

namespace DicomSCPService
{
    public partial class DicomSCPSvc : ServiceBase
    {
        [DllImport("advapi32.dll", SetLastError = true)]
        private static extern bool SetServiceStatus(System.IntPtr handle, ref ServiceStatus serviceStatus);

        Config configuration;
        ConfManager ConfManager;
        Logger logger;
        IDicomServer server;
        string DicomFilesPath;
        DicomFileWatcher watcher;

        public DicomSCPSvc()
        {
            logger = LogManager.GetCurrentClassLogger();

            DicomFilesPath = ConfigurationManager.AppSettings["DicomStorePath"];
            logger.Debug($"save file path :{DicomFilesPath}");

            InitializeComponent();
            ConfManager = new ConfManager(ConfigurationManager.AppSettings["ConfigFilePath"]);
            configuration = ConfManager.GetConfiguration();
            CheckFilesAndFolders();

        }

        private void CheckFilesAndFolders()
        {
            string StorePath = ConfigurationManager.AppSettings["DicomStorePath"];
            string tempPath = Path.Combine(StorePath, "temp");
            string badPath = Path.Combine(StorePath, "bad");
            if (!Directory.Exists(StorePath))
            {
                Directory.CreateDirectory(StorePath);
            }
            if (!Directory.Exists(tempPath))
            {
                Directory.CreateDirectory(tempPath);
            }
            if (!Directory.Exists(badPath))
            {
                Directory.CreateDirectory(badPath);
            }
        }


        public void OnDebug(string[] args)
        {
            OnStart(null);
            Thread.Sleep(Timeout.Infinite);
        }

        protected override void OnStart(string[] args)
        {
            // update state to start pending
            ServiceStatus serviceStatus = new ServiceStatus();
            serviceStatus.dwCurrentState = ServiceState.SERVICE_START_PENDING;
            serviceStatus.dwWaitHint = 100000;
            SetServiceStatus(this.ServiceHandle, ref serviceStatus);

            // preload dictionary to prevent timeouts
            var dict = DicomDictionary.Default;

            int port = int.Parse(ConfigurationManager.AppSettings["OwnListenPort"]);
            if (port == 0)
            {
                port = 104;
            }

            logger.Info($"Starting Dicome Storage Service on port {port}");

            server = DicomServer.Create<DicomStorageProvider>(port);
            logger.Debug($"Created Server on port {port}");
            watcher = new DicomFileWatcher(DicomFilesPath);
            logger.Debug($"Created fileSystem Watcher on folder : {DicomFilesPath}");
            watcher.StartWatching();

            // Update the service state to Running.
            serviceStatus.dwCurrentState = ServiceState.SERVICE_RUNNING;
            SetServiceStatus(this.ServiceHandle, ref serviceStatus);
        }

        protected override void OnStop()
        {
            server.Stop();
        }
        protected override void OnShutdown()
        {// update state to stop pending
            ServiceStatus serviceStatus = new ServiceStatus();
            serviceStatus.dwCurrentState = ServiceState.SERVICE_STOP_PENDING;
            serviceStatus.dwWaitHint = 100000;
            SetServiceStatus(this.ServiceHandle, ref serviceStatus);

            server.Stop();
            watcher.StopWatching();
            base.OnShutdown();

            // Update the service state to Running.
            serviceStatus.dwCurrentState = ServiceState.SERVICE_STOPPED;
            SetServiceStatus(this.ServiceHandle, ref serviceStatus);
        }

    }
}
public enum ServiceState
{
    SERVICE_STOPPED = 0x00000001,
    SERVICE_START_PENDING = 0x00000002,
    SERVICE_STOP_PENDING = 0x00000003,
    SERVICE_RUNNING = 0x00000004,
    SERVICE_CONTINUE_PENDING = 0x00000005,
    SERVICE_PAUSE_PENDING = 0x00000006,
    SERVICE_PAUSED = 0x00000007,
}

[StructLayout(LayoutKind.Sequential)]
public struct ServiceStatus
{
    public int dwServiceType;
    public ServiceState dwCurrentState;
    public int dwControlsAccepted;
    public int dwWin32ExitCode;
    public int dwServiceSpecificExitCode;
    public int dwCheckPoint;
    public int dwWaitHint;
};