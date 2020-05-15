using Microsoft.AspNetCore.Mvc;
//using MSS.API.Common;
using MSS.Data.RDB.Model;
using MSS.Data.RDB.Rest.V1.Business;
using System.Threading.Tasks;

// Coded By admin 2020/2/13 11:00:11
namespace MSS.Data.RDB.Rest.V1.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class PidTableController : ControllerBase
    {
        private readonly IPidTableService _service;

        public PidTableController(IPidTableService service)
        {
            _service = service;
        }

        [HttpGet("GetPageList")]
        public async Task<ActionResult<ApiResult>> GetPageList([FromQuery] PidTableParm parm)
        {
            ApiResult ret = new ApiResult { code = Code.Failure };
            try
            {
                ret = await _service.GetPageList(parm);

            }
            catch (System.Exception ex)
            {
                ret.msg = string.Format(
                    "获取分页数据PidTable失败, 异常信息:{0}",
                    ex.Message);
            }
            return ret;
        }

        [HttpPut]
        public async Task<ActionResult<ApiResult>> Update(PidTable obj)
        {
            ApiResult ret = new ApiResult { code = Code.Failure };
            try
            {
                ret = await _service.Update(obj);
            }
            catch (System.Exception ex)
            {
                ret.msg = string.Format(
                    "更新数据PidTable失败, 异常信息:{0}",
                    ex.Message);
            }
            return ret;
        }

        [HttpDelete("{ids}")]
        public async Task<ActionResult<ApiResult>> Delete(string ids)
        {
            ApiResult ret = new ApiResult { code = Code.Failure };
            try
            {
                ret = await _service.Delete(ids);
            }
            catch (System.Exception ex)
            {
                ret.msg = string.Format(
                    "删除数据PidTable失败, 异常信息:{0}",
                    ex.Message);
            }
            return ret;
        }

        [HttpPost]
        public async Task<ActionResult<ApiResult>> Save(PidTable obj)
        {
            ApiResult ret = new ApiResult { code = Code.Failure };
            try
            {
                ret = await _service.Save(obj);
            }
            catch (System.Exception ex)
            {
                ret.msg = string.Format(
                    "新增数据PidTable失败, 异常信息:{0}",
                    ex.Message);
            }
            return ret;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ApiResult>> GetByID(string pid)
        {
            ApiResult ret = new ApiResult { code = Code.Failure };
            try
            {
                ret = await _service.GetByID(pid);

            }
            catch (System.Exception ex)
            {
                ret.msg = string.Format(
                    "获取单个数据PidTable失败, 异常信息:{0}",
                    ex.Message);
            }
            return ret;
        }
    }
}



