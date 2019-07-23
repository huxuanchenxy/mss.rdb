using MSS.Data.RDB.Dao;
using MSS.Data.RDB.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MSS.Data.RDB.Rest.V1.Business
{
    public class TableInfoService : ITableInfoService
    {
        //private readonly ILogger<ActionService> _logger;
        private readonly ITableInfoRepo<TableInfo> _repo;

        public TableInfoService(ITableInfoRepo<TableInfo> repo)
        {
            _repo = repo;
        }

        public async Task<ApiResult> GetAllEqp()
        {
            ApiResult ret = new ApiResult();
            try
            {
                List<object> data = await _repo.GetAllEqp();
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

        public async Task<ApiResult> GetPoints(string tablename)
        {
            ApiResult ret = new ApiResult();
            try
            {
                List<object> data = await _repo.GetPoints(tablename);
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

    public interface ITableInfoService
    {
        Task<ApiResult> GetAllEqp();
        Task<ApiResult> GetPoints(string tablename);
    }
}
