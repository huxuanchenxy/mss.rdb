using System;
using System.Collections.Generic;
using System.Text;

namespace MSS.Data.RDB.Model
{


    public class Elog : BaseEntity
    {
        public System.DateTime ETime { get; set; }
        public short ETime_MS { get; set; }
        public string PID { get; set; }
        public sbyte ELevel { get; set; }
        public sbyte Ack { get; set; }
        public System.DateTime OriginTime { get; set; }
        public short OriginTime_MS { get; set; }
        public System.DateTime RestoreTime { get; set; }
        public short RestoreTime_MS { get; set; }
        public System.DateTime AckTime { get; set; }
        public short AckTime_MS { get; set; }
        public string NodeID { get; set; }
        public string User { get; set; }
        public string Src { get; set; }
        public sbyte Type { get; set; }
        public string EQDes { get; set; }
        public string PIDDes { get; set; }
        public string ValueDisplay { get; set; }
        public string Des { get; set; }
        public short StnNo { get; set; }
        public string StnName { get; set; }
        public short SpecialtyNo { get; set; }
        public string EQType { get; set; }
        public string PushGraph { get; set; }
    }
}
