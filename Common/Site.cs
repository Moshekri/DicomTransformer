using System;

namespace Common
{
    [Serializable]
    public class Site
    {
        public string SiteName { get; set; }
        public string AETitle { get; set; }
        public string Port { get; set; }
        public int SiteNumber { get; private set; }
        public string Information { get; set; }

        public Site(string name , int siteNumber,string aeTitle, int port)
        {
            SiteName = name;
            SiteNumber = siteNumber;
        }
    }
}