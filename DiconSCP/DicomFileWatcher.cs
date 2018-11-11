using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EvilDICOM;
using EvilDICOM.Core;
using NLog;



namespace DicomSCPService
{


    public class DicomFileWatcher
    {

        Logger logger;
        FileSystemWatcher fsw;
        AccessionNumberChanger accChanger;

        string targetIp;
        string targetAeTitle;
        string callingAeTitle;
        int targetPort;
        string fileWatcherPath;
        

        public DicomFileWatcher(string path)
        {
            fileWatcherPath = path;
            if (!Directory.Exists(Path.Combine(path, "bad")))
            {
                Directory.CreateDirectory(Path.Combine(path, "bad"));
            }
            targetIp = ConfigurationManager.AppSettings["DicomSCPTargetIpAddress"];
            targetAeTitle = ConfigurationManager.AppSettings["DicomSCPTargetAETitle"];
            callingAeTitle = ConfigurationManager.AppSettings["OwnAETitle"];
            targetPort = int.Parse(ConfigurationManager.AppSettings["DicomSCPPort"]);


            logger = LogManager.GetCurrentClassLogger();
            fsw = new FileSystemWatcher(path, "*.dcm");
            fsw.Created += NewFileCreated;
            accChanger = new AccessionNumberChanger();
            
        }

        public void StartWatching()
        {
            fsw.EnableRaisingEvents = true;
        }
        public void StopWatching()
        {
            fsw.EnableRaisingEvents = false;
        }
        private void NewFileCreated(object sender, FileSystemEventArgs e)
        {
            string newFullPath = "";
            try
            {
                DICOMObject file = DICOMObject.Read(e.FullPath);
                logger.Debug($"Read file {e.Name} , it has {file.Elements.Count} elements ");
                file = accChanger.SetAccessionNumber(file);
                logger.Debug($"Added accesstion number to  file {e.Name} ,now it has {file.Elements.Count} elements ");

                string folder = Path.GetDirectoryName(e.FullPath);
                string fileName = Path.GetFileName(e.FullPath);
                fileName = "new_" + fileName;
                newFullPath = Path.Combine(folder, fileName);
                file.Write(newFullPath);
                DicomSCU.Send(newFullPath, targetIp, callingAeTitle, targetAeTitle, targetPort);
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
                File.Move(e.FullPath, Path.Combine(fileWatcherPath, "bad"));
            }
            finally
            {
                File.Delete(newFullPath);
            }
            File.Delete(e.FullPath);


        }
    }
}
