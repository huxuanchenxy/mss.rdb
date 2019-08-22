using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace rdbMicroservice.Service
{
    public class RdbMessage
    {
        public string PID;
        public double Value;
        //public DateTime Time { get; set; }
        public string UT { get; set; }

        public double DW { get; set; }
        public double DDW { get; set; }
        public double UP { get; set; }
        public double UUP { get; set; }
        public DateTime UpdateTime { get; set; }
        public long time { get; set; }
    }
}
