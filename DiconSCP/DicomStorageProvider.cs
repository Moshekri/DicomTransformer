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

        public DicomStorageProvider(INetworkStream stream, Encoding fallbackEncoding, Logger log)
            : base(stream, fallbackEncoding, log)
        {
            confManager = new ConfManager(ConfigurationManager.AppSettings["ConfigFilePath"]);
            configuration = confManager.GetConfiguration();
        }
        public DicomCStoreResponse OnCStoreRequest(DicomCStoreRequest request)
        {
            lock (this)
            {
                string storePath = ConfigurationManager.AppSettings["DicomStorePath"];
                var path = Path.GetFullPath(storePath);
                path = Path.Combine(path, Guid.NewGuid().ToString().Substring(0, 12));
                path = Path.Combine(path) + ".dcm";
                request.File.Save(path);
                return new DicomCStoreResponse(request, DicomStatus.Success);
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

            foreach (var pc in association.PresentationContexts)
            {
                if (pc.AbstractSyntax == DicomUID.Verification) pc.AcceptTransferSyntaxes(AcceptedTransferSyntaxes);
                else if (pc.AbstractSyntax.StorageCategory != DicomStorageCategory.None) pc.AcceptTransferSyntaxes(AcceptedImageTransferSyntaxes);
            }

            return SendAssociationAcceptAsync(association);
        }
        public Task OnReceiveAssociationReleaseRequestAsync()
        {
            return SendAssociationReleaseResponseAsync();
        }
        public void OnReceiveAbort(DicomAbortSource source, DicomAbortReason reason)
        {
            Logger.Debug(reason.ToString());
        }
        public void OnConnectionClosed(Exception exception)
        {
            Logger.Error(exception.Message);
        }
        public void OnCStoreRequestException(string tempFileName, Exception e)
        {
            Logger.Error(e.Message);
        }
        public DicomCEchoResponse OnCEchoRequest(DicomCEchoRequest request)
        {
            return new DicomCEchoResponse(request, DicomStatus.Success);
        }
    }
}
