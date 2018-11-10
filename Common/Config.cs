using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{ [Serializable]
    public class Config
    {
        public List<Site> SCUSites { get; set; }
        public List<int>  SCPPorts { get; set; }
        public Config()
        {
            SCUSites = new List<Site>();
            SCPPorts = new List<int>();
        }
    }
}
