using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;
using Common;

namespace ConfigManager
{
    public class ConfManager
    {
        private Config _conf;
        private string ConfigFilePath;
       
        public ConfManager(string path)
        {
            ConfigFilePath = path;
            LoadConfiguration();
            
            
        }

        private void LoadConfiguration()
        {
            string fullPath = Path.GetFullPath(ConfigFilePath);
            if (!File.Exists(ConfigFilePath))
            {
                Config conf = new Config();
                conf.SCPPorts.Add(104);
                
                BinaryFormatter bf = new BinaryFormatter();
                using (var fs = File.Open(ConfigFilePath, FileMode.OpenOrCreate))
                {
                    bf.Serialize(fs, conf);
                }
               
            }
            using (FileStream fs = File.Open(ConfigFilePath, FileMode.OpenOrCreate))
            {
                BinaryFormatter bf = new BinaryFormatter();
                var configuration = (Config)bf.Deserialize(fs);
                _conf = configuration;
            }
        }
        public List<Site> GetSCUList()
        {
            return _conf.SCUSites;
        }
        public List<int> GetSCPList()
        {
            return _conf.SCPPorts;
        }
        public bool AddSite(string name , string aeTitle,int port , int siteNumber,string comments)
        {
            Site site = new Site(name, siteNumber, aeTitle, port,comments);
            var s = _conf.SCUSites.FirstOrDefault(obj => obj.AETitle == aeTitle && obj.SiteNumber == siteNumber && obj.SiteName == name);
            if (s== null)
            {
                _conf.SCUSites.Add(site);
                Save();
                return true;
            }
            throw new SiteExistsExecption($"Site {site.SiteName} already exists ! \r\n No duplicate sites allowed ! ");
        }
        public bool AddSCP(int port)
        {
            var scp = _conf.SCPPorts.FirstOrDefault(o => o == port);
            if (scp ==0)
            {
                _conf.SCPPorts.Add(port);
                Save();
                return true;
            }
            throw new SCPExsitsException($"An SCP Service Already on port {port} Exists");
        }
        public Config GetConfiguration()
        {
            return _conf;
        }
      public void Save()
        {
            BinaryFormatter bf = new BinaryFormatter();
            using (var fs = File.Open(ConfigFilePath, FileMode.OpenOrCreate))
            {
                bf.Serialize(fs, _conf);
            }
        }
        
    }
}
