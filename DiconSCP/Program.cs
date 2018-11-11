using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace DicomSCPService
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main()
        {

#if DEBUG

            DicomSCPSvc service = new DicomSCPSvc();
            service.OnDebug(null);


#else
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
