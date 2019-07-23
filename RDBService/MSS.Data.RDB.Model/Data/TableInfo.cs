using System;
using System.Collections.Generic;
using System.Text;

namespace MSS.Data.RDB.Model
{
    public class TableInfo : BaseEntity
    {
        public string TableName { get; set; }

    }

    public class EqpInfo : BaseEntity
    {
        public string pid { get; set; }
    }
}
