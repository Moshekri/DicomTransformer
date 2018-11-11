using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EvilDICOM.Core;
using Dicom.Network;
using System.Threading;

namespace DicomSCPService
{
    public  class DicomSCU
    {
        int retryCount;
        static object locker;
        public DicomSCU()
        {
            retryCount = 0;
        }
        public void Send(string filePath, string ipAddress, string callingAe, string targetAeTitle, int port)
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
                    if (retryCount> 10)
                    {
                        throw new Exception($"Remote Host {ipAddress}:{port} did not respond ...  ");
                    }
                    retryCount++;
                    string error = ex.Message;
                    if (error.Contains("TemporaryCongestion"))
                    {
                        Thread.Sleep(5000);
                        Send(filePath, ipAddress, callingAe, targetAeTitle, port);
                    }
                }

            }

        }

    }
}
