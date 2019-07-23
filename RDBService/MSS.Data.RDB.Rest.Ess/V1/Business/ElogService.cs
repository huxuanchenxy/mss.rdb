using MSS.Data.RDB.Dao;
using MSS.Data.RDB.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MSS.Data.RDB.Rest.Ess.V1.Business
{
    public class ElogService : IElogService
    {
        private readonly IElogRepo<Elog> _repo;

        public ElogService(IElogRepo<Elog> repo)
        {
            _repo = repo;
        }
        public async Task<ApiResult> GetElogList(int ack)
        {
            ApiResult ret = new ApiResult();
            try
            {
                List<Elog> data = await _repo.GetElogList(ack);
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

    public interface IElogService
    {
        Task<ApiResult> GetElogList(int ack);
    }
}
