using Dapper;
using MSS.Data.RDB.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSS.Data.RDB.Dao
{

    public interface IElogRepo<T> where T : BaseEntity
    {
        Task<List<Elog>> GetElogList(int ack);
        Task<PageData<Elog>> ListPageElog(ElogPageReq param);
    }

    public class ElogRepo : BaseRepo, IElogRepo<Elog>
    {
        public ElogRepo(DapperOptions options) : base(options) { }

        public async Task<List<Elog>> GetElogList(int ack)
        {
            return await WithConnection(async c =>
            {
                List<Elog> ret = new List<Elog>();

                string sql1 = $@" select * from e_log WHERE Ack =  {ack} ;";

                ret = (await c.QueryAsync<Elog>(sql1.ToString())).ToList();
                return ret;
            });
        }

        public async Task<PageData<Elog>> ListPageElog(ElogPageReq param)
        {
            return await WithConnection(async c =>
            {
                StringBuilder sql = new StringBuilder();
                StringBuilder sqlCount = new StringBuilder();

                sql.Append("SELECT a.* ");
                sqlCount.Append("SELECT COUNT(*)");

                StringBuilder whereSql = new StringBuilder();
                whereSql.Append(" FROM e_log a WHERE 1 = 1 ");

                
                if (!string.IsNullOrEmpty(param.DeviceID))
                {
                    whereSql.Append(" AND a.PID LIKE '" + param.DeviceID + "%'");
                }
                sql.Append(whereSql)
                   .Append(" order by a." + param.sort + " " + param.order)
                   .Append(" limit " + (param.page - 1) * param.rows + "," + param.rows);
                sqlCount.Append(whereSql);
                var data = await c.QueryAsync<Elog>(sql.ToString());
                int total = await c.QueryFirstOrDefaultAsync<int>(sqlCount.ToString());

                PageData<Elog> ret = new PageData<Elog>();
                ret.rows = data.ToList();
                ret.total = total;

                return ret;
            });
        }


    }

}
