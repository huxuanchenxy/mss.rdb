using MSS.Data.RDB.Dao;
using MSS.Data.RDB.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MSS.Data.RDB.Rest.Ess.V1.Business
{
    public class EalarmService : IEalarmService
    {
        //private readonly ILogger<ActionService> _logger;
        private readonly IEalarmRepo<Ealarm> _repo;

        public EalarmService(IEalarmRepo<Ealarm> repo)
        {
            _repo = repo;
        }
        public async Task<ApiResult> GetEalarmList(int ack)
        {
            ApiResult ret = new ApiResult();
            try
            {
                List<Ealarm> data = await _repo.GetEalarmList(ack);
                ret.code = Code.Success;
                ret.data = data;
            }
            catch (Exception ex)
            {
                ret.code = Code.Failure;
                ret.msg = ex.Message;
            }

            return ret;
        }
    }

    public interface IEalarmService
    {
        Task<ApiResult> GetEalarmList(int ack);
    }
}
