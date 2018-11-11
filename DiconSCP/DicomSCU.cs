using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EvilDICOM.Core;
using Dicom.Network;

namespace DicomSCPService
{
    public static class DicomSCU
    {
        static object locker;
        public static void Send(string filePath, string ipAddress, string callingAe, string targetAeTitle, int port)
        {
            locker = new object();
            lock (locker)
            {
                try
                {
                    var req = new DicomCStoreRequest(filePath);
                    DicomClient client = new DicomClient();
                    client.NegotiateAsyncOps();
                    client.AddRequest(req);
                    client.Send(ipAddress, port, false, callingAe, targetAeTitle);
                }
                catch (Exception ex)
                {

                    string error = ex.Message;
                }
               
            }
            
        }

    }
}
