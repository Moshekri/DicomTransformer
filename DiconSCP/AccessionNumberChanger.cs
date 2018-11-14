using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EvilDICOM.Core;
using EvilDICOM.Core.Element;
using Common;
using ConfigManager;
using System.Configuration;
using System.Threading;
using NLog;

namespace DicomSCPService
{
    public class AccessionNumberChanger
    {
        ConfManager confManager;
        Config config;
        DICOMObject file;
        Logger logger;
        public AccessionNumberChanger()
        {
            logger = LogManager.GetCurrentClassLogger();
            confManager = new ConfManager(ConfigurationManager.AppSettings["ConfigFilePath"]);
            config = confManager.GetConfiguration();
        }
        public DICOMObject SetAccessionNumber(DICOMObject dcmFile)
        {
            try
            {
                file = dcmFile;
                logger.Debug($"Inside Accesstion number creator , processing file...");
                int counter = config.Counter;
                logger.Info(counter);
                int instituteNumber;
                if (dcmFile == null)
                {
                    logger.Debug("SetAccessionNumber dcmFile is null");
                }
                var accNumberElement = dcmFile.Elements.FirstOrDefault(e => e.Tag.CompleteID == "00080050");

                var instituteNameElement = dcmFile.Elements.FirstOrDefault(e => e.Tag.CompleteID == "00080080");

               var instituteNumberObject = config.SCUSites.FirstOrDefault(e => e.SiteName == instituteNameElement.DData.ToString());
                if (instituteNumberObject == null)
                {
                    logger.Error($"Could not find matching site name in configuration !! , site on file was: {instituteNameElement.DData.ToString()} ");;
                    return null;
                }
                instituteNumber = instituteNumberObject.SiteNumber;
                logger.Info($"Recieved file from site {instituteNameElement.DData} , Site number  : {instituteNumber}");
                StringBuilder sb = new StringBuilder();
                sb.Append(config.SysType);
                sb.Append(instituteNumber);
                sb.Append(config.Counter.ToString().PadLeft(12, '0'));

                if (null == accNumberElement)
                {
                    logger.Info("No Accesstion number found , Creating new accestion number");
                    logger.Info($"New accesstion number : {sb.ToString()}");
                    Tag accNum = new Tag("00080050");
                    ShortString accNumber = new ShortString(accNum, sb.ToString());
                    file.Elements.Add(accNumber);
                }
                else
                {
                    logger.Info("Accession Number exists  , no changes made");
                    return file;
                }
                config.Counter = config.Counter + 1;
                logger.Debug($"Counter = {counter}");
                confManager.Save();
                Thread.Sleep(100);
                return file;
            }
            catch (Exception ex)
            {

                throw;
            }

        }
    }
}
