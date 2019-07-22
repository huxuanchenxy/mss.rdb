using Dapper;
using MSS.Data.RDB.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSS.Data.RDB.Dao
{

    public interface ITableInfoRepo<T> where T : BaseEntity
    {
        Task<HashSet<string>> GetAllPID();
    }

    public class TableInfoRepo : BaseRepo, ITableInfoRepo<TableInfo>
    {
        public TableInfoRepo(DapperOptions options) : base(options) { }

        public async Task<HashSet<string>> GetAllPID()
        {
            return await WithConnection(async c =>
            {
                HashSet<string> pids = new HashSet<string>();

                string sql1 = $@" select table_name,column_name from information_schema.columns where column_name = 'PID'AND table_name LIKE 'r_%' ";

                var list1 = (await c.QueryAsync<TableInfo>(sql1.ToString())).ToList();

                foreach (var li in list1)
                {
                    try
                    {
                        string sql2 = $@" SELECT PID FROM {li.table_name} ";
                        var list2 = (await c.QueryAsync<EqpInfo>(sql2.ToString())).ToList();
                        foreach (var li2 in list2)
                        {
                            if (!string.IsNullOrEmpty(li2.pid))
                            {
                                pids.Add(li2.pid);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        continue;
                    }

                }

                return pids;
            });
        }





    }

}
