using MSS.Data.RDB.Dao;
using MSS.Data.RDB.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MSS.Data.RDB.Rest.His.V1.Business
{
    public class HfrqService : IHfrqService
    {
        private readonly IHfrqRepo<Hfrq> _repo;

        public HfrqService(IHfrqRepo<Hfrq> repo)
        {
            _repo = repo;
        }


        public async Task<ApiResult> ListPage(HfrqParam param)
        {
            ApiResult ret = new ApiResult();
            try
            {
                param.page = param.page != null ? param.page : 1;
                param.rows = param.rows != null ? param.rows : 20;
                param.sort = !string.IsNullOrEmpty(param.sort) ? param.sort : "UpdateTime";//有索引
                param.order = !string.IsNullOrEmpty(param.order) ? param.order : "DESC";
                param.TableName = param.TableName.Replace('r', 'h') + "_frq";
                PageData<Hfrq> data = await _repo.ListPage(param);
                
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

    public interface IHfrqService
    {
        Task<ApiResult> ListPage(HfrqParam param);
    }
}
