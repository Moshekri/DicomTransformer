using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dicom;
using Dicom.Log;
using Dicom.Network;
using Common;
using ConfigManager;
using NLog;

namespace DicomSCPService
{
    class DicomStorageProvider : DicomService, IDicomServiceProvider, IDicomCStoreProvider, IDicomCEchoProvider
    {
        private static readonly DicomTransferSyntax[] AcceptedTransferSyntaxes = new DicomTransferSyntax[]
    {
               DicomTransferSyntax.ExplicitVRLittleEndian,
               DicomTransferSyntax.ExplicitVRBigEndian,
               DicomTransferSyntax.ImplicitVRLittleEndian
    };
        private static readonly DicomTransferSyntax[] AcceptedImageTransferSyntaxes = new DicomTransferSyntax[]
        {
               // Lossless
               DicomTransferSyntax.JPEGLSLossless,
               DicomTransferSyntax.JPEG2000Lossless,
               DicomTransferSyntax.JPEGProcess14SV1,
               DicomTransferSyntax.JPEGProcess14,
               DicomTransferSyntax.RLELossless,
               // Lossy
               DicomTransferSyntax.JPEGLSNearLossless,
               DicomTransferSyntax.JPEG2000Lossy,
               DicomTransferSyntax.JPEGProcess1,
               DicomTransferSyntax.JPEGProcess2_4,
               // Uncompressed
               DicomTransferSyntax.ExplicitVRLittleEndian,
               DicomTransferSyntax.ExplicitVRBigEndian,
               DicomTransferSyntax.ImplicitVRLittleEndian
        };

        Config configuration;
        ConfManager confManager;
        NLog.Logger logger;
        public DicomStorageProvider(INetworkStream stream, Encoding fallbackEncoding, Dicom.Log.Logger log)
            : base(stream, fallbackEncoding, log)
        {
            confManager = new ConfManager(ConfigurationManager.AppSettings["ConfigFilePath"]);
            configuration = confManager.GetConfiguration();
            logger = NLog.LogManager.GetCurrentClassLogger();

        }
        public DicomCStoreResponse OnCStoreRequest(DicomCStoreRequest request)
        {
            logger.Debug($"Recived StoreRequest ");
            lock (this)
            {
                try
                {
                    string guid = Guid.NewGuid().ToString();

                    string storePath = ConfigurationManager.AppSettings["DicomStorePath"];
                    var actualPath = Path.GetFullPath(storePath);

                    logger.Debug($"Store path = {actualPath}");

                    string tempPath = Path.GetDirectoryName(actualPath).ToString() + "\\dicomfiles\\temp\\" + guid + ".dcm";
                    logger.Debug($"Temp files store  path = {tempPath}");

                    if (!Directory.Exists(Path.GetDirectoryName(tempPath)))
                    {
                        logger.Debug("Temp folder does not exist - creating temp folder");
                        Directory.CreateDirectory(Path.GetDirectoryName(tempPath));
                    }
                    actualPath = Path.Combine(actualPath, guid);
                    actualPath = Path.Combine(actualPath) + ".dcm";

                    request.File.Save(actualPath);
                    logger.Debug($"Saving file {actualPath}");
                    request.File.Save(tempPath);
                    logger.Debug($"Saving file {tempPath}");

                    return new DicomCStoreResponse(request, DicomStatus.Success);
                }
                catch (Exception ex)
                {
                    do
                    {
                        logger.Error(ex.Message);
                        ex = ex.InnerException;
                    } while (ex.InnerException != null);

                    return new DicomCStoreResponse(request, DicomStatus.Cancel);
                }
            }

        }


        public Task OnReceiveAssociationRequestAsync(DicomAssociation association)
        {

            //if (association.CalledAE != "STORESCP")
            //{
            //    return SendAssociationRejectAsync(
            //        DicomRejectResult.Permanent,
            //        DicomRejectSource.ServiceUser,
            //        DicomRejectReason.CalledAENotRecognized);
            //}
            logger.Debug($"Received assocciation request from :");
            logger.Debug($"                                     AETitle :{association.CallingAE}");
            logger.Debug($"                                     Remote Host :{association.RemoteHost}");
            logger.Debug($"                                     Port :{association.RemotePort}");
            



            foreach (var pc in association.PresentationContexts)
            {
                if (pc.AbstractSyntax == DicomUID.Verification) pc.AcceptTransferSyntaxes(AcceptedTransferSyntaxes);
                else if (pc.AbstractSyntax.StorageCategory != DicomStorageCategory.None) pc.AcceptTransferSyntaxes(AcceptedImageTransferSyntaxes);
            }

            return SendAssociationAcceptAsync(association);
        }
        public Task OnReceiveAssociationReleaseRequestAsync()
        {
            logger.Debug($"OnReceiveAssociationReleaseRequestAsync");
            return SendAssociationReleaseResponseAsync();
        }
        public void OnReceiveAbort(DicomAbortSource source, DicomAbortReason reason)
        {
            logger.Debug($"Recieved Abort {reason.ToString()}");
        }
        public void OnConnectionClosed(Exception exception)
        {
            logger.Error($"Connection closed {exception.Message}");
        }
        public void OnCStoreRequestException(string tempFileName, Exception e)
        {
            logger.Error($"CSTORE Request error {e.Message}");
        }
        public DicomCEchoResponse OnCEchoRequest(DicomCEchoRequest request)
        {
            logger.Debug($"Recieved echo request {request.MessageID}");
            return new DicomCEchoResponse(request, DicomStatus.Success);
        }
    }
}
