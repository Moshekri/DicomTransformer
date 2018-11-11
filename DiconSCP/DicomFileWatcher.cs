using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
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

            DICOMObject file = null;
            try
            {
                lock (this)
                {
                    Thread.Sleep(500);
                    try
                    {
                        file = DICOMObject.Read(e.FullPath);

                    }
                    catch (Exception ex)
                    {

                        logger.Error(ex.Message);
                    }

                    logger.Debug($"Read file {e.Name} , it has {file.Elements.Count} elements ");
                    file = accChanger.SetAccessionNumber(file);
                    var accNum = file.Elements.Find(el => el.Tag.CompleteID == "00080050");
                    logger.Debug($"Added accesstion number {accNum.DData.ToString()} to  file {e.Name} ,now it has {file.Elements.Count} elements ");

                    string currentFolder = Path.GetDirectoryName(e.FullPath);
                    string tempFolder = Path.Combine(currentFolder, "temp");
                    string fileName = Path.GetFileName(e.FullPath);
                    string newFileName = e.FullPath + "_New";
                    string tempFileName = Path.Combine(tempFolder, fileName);
                    file.Write(newFileName);


                    try
                    {
                        DicomSCU scu = new DicomSCU();
                        scu.Send(newFileName, targetIp, callingAeTitle, targetAeTitle, targetPort);
                        File.Delete(e.FullPath);
                        File.Delete(tempFileName);
                        File.Delete(newFileName);
                    }
                    catch (Exception ex)
                    {
                        logger.Error(ex.Message);
                        throw;
                    }


                    Thread.Sleep(500);
                }

            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
            }




        }
    }
}
