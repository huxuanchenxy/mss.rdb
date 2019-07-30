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
        Task<PageData<Elog>> ListPageElogPID(ElogPageReq param);
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

        public async Task<PageData<Elog>> ListPageElogPID(ElogPageReq param)
        {
            return await WithConnection(async c =>
            {
                StringBuilder sql = new StringBuilder();
                StringBuilder sqlCount = new StringBuilder();

                sql.Append($@"SELECT PID,ETime ,  ETime_MS 
                                , ELevel
                                , Ack
                                , OriginTime
                                , OriginTime_MS
                                , RestoreTime
                                , RestoreTime_MS, AckTime, AckTime_MS, NodeID
                                , 'User', Src
                                , Type, EQDes, PIDDes
                                , ValueDisplay, Des, StnNo, StnName, SpecialtyNo, EQType, PushGraph ");
                sqlCount.Append("SELECT COUNT(1)");

                StringBuilder whereSql = new StringBuilder();
                whereSql.Append(" FROM e_log a WHERE a.PID = '" + param.PID + "'");



                if (!string.IsNullOrEmpty(param.OriginTimeStart) && !string.IsNullOrEmpty(param.OriginTimeEnd))
                {
                    whereSql.Append(" AND  a.OriginTime >= '" + param.OriginTimeStart + "' AND a.OriginTime <= '" + param.OriginTimeEnd + "' ");
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
