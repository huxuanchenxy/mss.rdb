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


    }

}
