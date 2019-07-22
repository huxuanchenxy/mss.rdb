using System;
using System.Collections.Generic;
using System.Text;

namespace MSS.Data.RDB.Model
{
    public class TableInfo : BaseEntity
    {
        public string table_name { get; set; }
        public string column_name { get; set; }

    }

    public class EqpInfo : BaseEntity
    {
        public string pid { get; set; }
    }
}
