using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HOYA_IOT.ObjectData
{
    public class SystemConfig
    {
        public SystemConfig() 
        {
            DataFolder = "HYD";
        }
        public string DataFolder { get; set; }
        public string FileLocation { get; set; }
        public string Config2 { get; set; }
    }
    
}
