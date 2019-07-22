using MSS.Data.RDB.Dao;
using MSS.Data.RDB.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MSS.API.Operlog.V1.Business
{
    public class TableInfoService : ITableInfoService
    {
        //private readonly ILogger<ActionService> _logger;
        private readonly ITableInfoRepo<TableInfo> _repo;

        public TableInfoService(ITableInfoRepo<TableInfo> repo)
        {
            _repo = repo;
        }
        public async Task<HashSet<string>> GetAllPID()
        {
            return await _repo.GetAllPID();
        }

    }

    public interface ITableInfoService
    {
        Task<HashSet<string>> GetAllPID();
    }
}
