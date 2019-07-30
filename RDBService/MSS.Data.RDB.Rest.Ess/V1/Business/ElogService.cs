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

        public async Task<ApiResult> ListPageElog(ElogReq param)
        {
            ApiResult ret = new ApiResult();
            try
            {
                List<PageData<Elog>> data = new List<PageData<Elog>>();
                foreach (var p1 in param.PIDList)
                {
                    if (string.IsNullOrEmpty(p1.PID))
                    {
                        continue;
                    }
                    var d = await ListPageElogPID(p1);
                    data.Add(d);
                }
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

        public async Task<PageData<Elog>> ListPageElogPID(ElogPageReq param)
        {
            param.page = param.page != null ? param.page : 1;
            param.rows = param.rows != null ? param.rows : 20;
            param.sort = !string.IsNullOrEmpty(param.sort) ? param.sort : "ETime";
            param.order = !string.IsNullOrEmpty(param.order) ? param.order : "ASC";
            var data = await _repo.ListPageElogPID(param);
            return data;
        }

    }

    public interface IElogService
    {
        Task<ApiResult> GetElogList(int ack);
        Task<ApiResult> ListPageElog(ElogReq param);

        Task<PageData<Elog>> ListPageElogPID(ElogPageReq param);
    }
}
