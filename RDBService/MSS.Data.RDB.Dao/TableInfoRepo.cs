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
        Task<List<object>> GetAllEqp();
        Task<List<object>> GetPoints(string tablename);
    }

    public class TableInfoRepo : BaseRepo, ITableInfoRepo<TableInfo>
    {
        public TableInfoRepo(DapperOptions options) : base(options) { }

        public async Task<List<object>> GetAllEqp()
        {
            return await WithConnection(async c =>
            {
                List<object> ret = new List<object>();

                string sql1 = $@" select distinct * from b_tablelist ";

                ret = (await c.QueryAsync<object>(sql1.ToString())).ToList();

                return ret;
            });
        }



        public async Task<List<object>> GetPoints(string tablename)
        {
            return await WithConnection(async c =>
            {
                List<object> list = new List<object>();

                string sql2 = $@" SELECT distinct * FROM {tablename} ";
                list = (await c.QueryAsync<object>(sql2.ToString())).ToList();
                
                return list;
            });
        }

    }

}
