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
        Task<HashSet<string>> GetAllEqp();
        Task<HashSet<string>> GetAllPID(string tablename);
    }

    public class TableInfoRepo : BaseRepo, ITableInfoRepo<TableInfo>
    {
        public TableInfoRepo(DapperOptions options) : base(options) { }

        public async Task<HashSet<string>> GetAllEqp()
        {
            return await WithConnection(async c =>
            {
                HashSet<string> ret = new HashSet<string>();

                string sql1 = $@" select TableName from b_tablelist ";

                var list1 = (await c.QueryAsync<TableInfo>(sql1.ToString())).ToList();

                foreach (var li in list1)
                {
                    try
                    {
                        if (!string.IsNullOrEmpty(li.TableName))
                        {
                            ret.Add(li.TableName);
                        }
                    }
                    catch (Exception ex)
                    {
                        continue;
                    }

                }

                return ret;
            });
        }



        public async Task<HashSet<string>> GetAllPID(string tablename)
        {
            return await WithConnection(async c =>
            {
                HashSet<string> pids = new HashSet<string>();

                string sql2 = $@" SELECT PID FROM {tablename} ";
                var list2 = (await c.QueryAsync<EqpInfo>(sql2.ToString())).ToList();
                foreach (var li2 in list2)
                {
                    if (!string.IsNullOrEmpty(li2.pid))
                    {
                        pids.Add(li2.pid);
                    }
                }
                return pids;
            });
        }

    }

}
