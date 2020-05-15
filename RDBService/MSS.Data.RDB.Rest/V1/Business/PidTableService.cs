using MSS.API.Common.Utility;
using MSS.Data.RDB.Dao;
using MSS.Data.RDB.Model;
using System;
using System.Net;
using System.Threading.Tasks;


// Coded By admin 2020/2/13 10:22:38
namespace MSS.Data.RDB.Rest.V1.Business
{
    public interface IPidTableService
    {
        Task<ApiResult> GetPageList(PidTableParm parm);
        Task<ApiResult> Save(PidTable obj);
        Task<ApiResult> Update(PidTable obj);
        Task<ApiResult> Delete(string ids);
        Task<ApiResult> GetByID(string pid);
    }

    public class PidTableService : IPidTableService
    {
        private readonly IPidTableRepo<PidTable> _repo;
        private readonly IAuthHelper _authhelper;
        private readonly int _userID;

        public PidTableService(IPidTableRepo<PidTable> repo, IAuthHelper authhelper)
        {
            _repo = repo;
            _authhelper = authhelper;
            _userID = _authhelper.GetUserId();
        }

        public async Task<ApiResult> GetPageList(PidTableParm parm)
        {
            ApiResult ret = new ApiResult();
            try
            {
                //parm.UserID = _userID;
                //parm.UserID = 40;
                var data = await _repo.GetPageList(parm);
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

        public async Task<ApiResult> Save(PidTable obj)
        {
            ApiResult ret = new ApiResult();
            try
            {
               
                ret.data = await _repo.Save(obj);
                ret.code = Code.Success;
                return ret;
            }
            catch (Exception ex)
            {
                ret.code = Code.Failure;
                ret.msg = ex.Message;
                return ret;
            }
        }

        public async Task<ApiResult> Update(PidTable obj)
        {
            ApiResult ret = new ApiResult();
            try
            {
                PidTable et = await _repo.GetByID(obj.PID);
                if (et != null)
                {
                    
                    ret.data = await _repo.Update(obj);
                    ret.code = Code.Success;
                }
                else
                {
                    ret.code = Code.DataIsnotExist;
                    ret.msg = "所要修改的数据不存在";
                }
                return ret;
            }
            catch (Exception ex)
            {
                ret.code = Code.Failure;
                ret.msg = ex.Message;
                return ret;
            }
        }

        public async Task<ApiResult> Delete(string ids)
        {
            ApiResult ret = new ApiResult();
            try
            {
                ret.data = await _repo.Delete(ids.Split(','), _userID);
                ret.code = Code.Success;
                return ret;
            }
            catch (Exception ex)
            {
                ret.code = Code.Failure;
                ret.msg = ex.Message;
                return ret;
            }
        }

        public async Task<ApiResult> GetByID(string  pid)
        {
            ApiResult ret = new ApiResult();
            try
            {
                PidTable obj = await _repo.GetByID(pid);
                ret.data = obj;
                ret.code = Code.Success;
                return ret;
            }
            catch (Exception ex)
            {
                ret.code = Code.Failure;
                ret.msg = ex.Message;
                return ret;
            }
        }
    }
}



