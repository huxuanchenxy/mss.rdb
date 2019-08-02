using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace rdbMicroservice.Models
{
    public class RPointBase
    {
        public string PID { get; set; }
        public string Des { get; set; }
        public int SpecialtyNo { get; set; }
        public DateTime Time { get; set; }
        public DateTime UpdateTime { get; set; }
        public double Value { get; set; }
    }
}
