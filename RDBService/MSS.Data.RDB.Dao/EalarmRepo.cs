using Dapper;
using MSS.Data.RDB.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSS.Data.RDB.Dao
{

    public interface IEalarmRepo<T> where T : BaseEntity
    {
        Task<List<Ealarm>> GetEalarmList(int ack);
    }

    public class EalarmRepo : BaseRepo, IEalarmRepo<Ealarm>
    {
        public EalarmRepo(DapperOptions options) : base(options) { }

        public async Task<List<Ealarm>> GetEalarmList(int ack)
        {
            return await WithConnection(async c =>
            {
                List<Ealarm> ret = new List<Ealarm>();

                string sql1 = $@" select * from e_alarm WHERE Ack =  {ack} ;";

                ret = (await c.QueryAsync<Ealarm>(sql1.ToString())).ToList();
                return ret;
            });
        }


    }

}
