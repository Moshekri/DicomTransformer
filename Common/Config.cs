using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{ [Serializable]
    public class Config
    {
        public int Counter { get; set; }
        public string  SysType { get; set; }
        public List<Site> SCUSites { get; set; }
        public List<int>  SCPPorts { get; set; }
        public Config()
        {
            SysType = "E";
            SCUSites = new List<Site>();
            SCPPorts = new List<int>();
        }
    }
}
