using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using NLog;

namespace DicomSCPService
{
    static class Program
    {
        
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main()
        {
            Logger logger = LogManager.GetCurrentClassLogger();
#if DEBUG

            DicomSCPSvc service = new DicomSCPSvc();
            service.OnDebug(null);


#else
            logger.Info("Starting dicom transformer service ... ");
            ServiceBase[] ServicesToRun;
            ServicesToRun = new ServiceBase[]
            {
                new DicomSCPSvc()
            };
            ServiceBase.Run(ServicesToRun);
#endif
        }
    }
}
