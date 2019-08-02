using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace rdbMicroservice.Models
{
    public class Alarm
    { 
        [Timestamp]
        public DateTime ETime { get; set; }    
        public int ETime_MS { get; set; } 
        public string PID { get; set; }
        [Required]
        public int ELevel { get; set; }
        [Required]
        public int Ack { get; set; }
        public DateTime? OriginTime { get; set; }
        public int? OriginTime_MS { get; set; }
        public DateTime? RestoreTime { get; set; }
        public int? RestoreTime_MS { get; set; }
        public DateTime? AckTime { get; set; }
        public int? AckTime_MS { get; set; }
        public string NodeID { get; set; }
        public string User { get; set; }
        public string Src { get; set; }
        public int? Type { get; set; }
        public string EQDes { get; set; }
        public string PIDDes { get; set; }
        public string ValueDisplay { get; set; }
        public string Des { get; set; }
        public int? StnNo { get; set; }
        public string StnName { get; set; }
        public int? SpecialtyNo { get; set; }
        public string EQType { get; set; }
        public string PushGraph  { get; set; }
    }
}
