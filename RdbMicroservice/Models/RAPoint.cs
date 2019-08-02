using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace rdbMicroservice.Models
{
    public class RAPoint:RPointBase
    {
        public string UT { get; set; }

        public double DW { get; set; }

        public double DDW { get; set; }

        public double UP { get; set; }

        public double UUP { get; set; }

    }
}
