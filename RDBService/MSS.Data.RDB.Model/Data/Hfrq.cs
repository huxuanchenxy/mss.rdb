using System;
using System.Collections.Generic;
using System.Text;

namespace MSS.Data.RDB.Model
{


    public class Hfrq : BaseEntity
    {
        public string  PID { get; set; }
        public double Value { get; set; }
        public string ValueDisplay { get; set; }
        public string Time { get; set; }
        public short Time_MS { get; set; }
        public short State { get; set; }
        public string UpdateTime { get; set; }
        public short UpdateTime_MS { get; set; }
        public string OverStatus { get; set; }
        public short ELevel { get; set; }
        
    }

    public class HfrqParam : BasePageParam
    {
        public string PID { get; set; }
        public string TableName { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
    }


}
