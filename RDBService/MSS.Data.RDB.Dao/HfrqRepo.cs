using Dapper;
using MSS.Data.RDB.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSS.Data.RDB.Dao
{

    public interface IHfrqRepo<T> where T : BaseEntity
    {
        Task<PageData<Hfrq>> ListPage(HfrqParam param);
    }

    public class HfrqRepo : BaseRepo, IHfrqRepo<Hfrq>
    {
        public HfrqRepo(DapperOptions options) : base(options) { }



        public async Task<PageData<Hfrq>> ListPage(HfrqParam param)
        {
            return await WithConnection(async c =>
            {
                StringBuilder sql = new StringBuilder();
                StringBuilder sqlCount = new StringBuilder();

                sql.Append($@"SELECT PID,Value,ValueDisplay,Time,Time_MS                                ,State,UpdateTime,UpdateTime_MS,OverStatus,ELevel ");
                sqlCount.Append("SELECT COUNT(1)");

                StringBuilder whereSql = new StringBuilder();
                whereSql.Append(" FROM "+ param.TableName + " a WHERE a.PID = '" + param.PID + "' ");



                if (!string.IsNullOrEmpty(param.StartTime) && !string.IsNullOrEmpty(param.EndTime))
                {
                    whereSql.Append(" AND  a.UpdateTime >= '" + param.StartTime + "' AND a.UpdateTime <= '" + param.EndTime + "' ");
                }
                sql.Append(whereSql)
                   .Append(" order by a." + param.sort + " " + param.order)
                   .Append(" limit " + (param.page - 1) * param.rows + "," + param.rows);
                sqlCount.Append(whereSql);
                var data = await c.QueryAsync<Hfrq>(sql.ToString());
                int total = await c.QueryFirstOrDefaultAsync<int>(sqlCount.ToString());

                PageData<Hfrq> ret = new PageData<Hfrq>();
                ret.rows = data.ToList();
                ret.total = total;

                return ret;
            });
        }


    }

}
