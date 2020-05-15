using Dapper;
using MSS.Data.RDB.Model;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


// Coded By admin 2020/2/13 9:27:53
namespace MSS.Data.RDB.Dao
{
    public interface IPidTableRepo<T> where T : BaseEntity
    {
        Task<PidTablePageView> GetPageList(PidTableParm param);
        Task<PidTable> Save(PidTable obj);
        Task<PidTable> GetByID(string pid);
        Task<int> Update(PidTable obj);
        Task<int> Delete(string[] ids, int userID);
    }

    public class PidTableRepo : BaseRepo, IPidTableRepo<PidTable>
    {
        public PidTableRepo(DapperOptions options) : base(options) { }

        public async Task<PidTablePageView> GetPageList(PidTableParm parm)
        {
            return await WithConnection(async c =>
            {

                StringBuilder sql = new StringBuilder();
                sql.Append($@"  SELECT 
                PID,
                eqp_id,
                prop,
                Des,
                pid_type,
                UT,
                UP,
                DW,
                UUP,DDW FROM pid_table
                 ");
                StringBuilder whereSql = new StringBuilder();
                //whereSql.Append(" WHERE ai.ProcessInstanceID = '" + parm.ProcessInstanceID + "'");

                //if (parm.AppName != null)
                //{
                //    whereSql.Append(" and ai.AppName like '%" + parm.AppName.Trim() + "%'");
                //}

                sql.Append(whereSql);
                //验证是否有参与到流程中
                //string sqlcheck = sql.ToString();
                //sqlcheck += ("AND ai.CreatedByUserID = '" + parm.UserID + "'");
                //var checkdata = await c.QueryFirstOrDefaultAsync<TaskViewModel>(sqlcheck);
                //if (checkdata == null)
                //{
                //    return null;
                //}

                var data = await c.QueryAsync<PidTable>(sql.ToString());
                var total = data.ToList().Count;
                sql.Append(" order by " + parm.sort + " " + parm.order)
                .Append(" limit " + (parm.page - 1) * parm.rows + "," + parm.rows);
                var ets = await c.QueryAsync<PidTable>(sql.ToString());

                PidTablePageView ret = new PidTablePageView();
                ret.rows = ets.ToList();
                ret.total = total;
                return ret;
            });
        }

        public async Task<PidTable> Save(PidTable obj)
        {
            return await WithConnection(async c =>
            {
                string sql = $@" INSERT INTO `pid_table`(
                    PID,
                    eqp_id,
                    prop,
                    Des,
                    pid_type,
                    UT,
                    UP,
                    DW,
                    UUP,
                    DDW
                ) VALUES 
                (@PID,
                    @EqpId,
                    @Prop,
                    @Des,
                    @PidType,
                    @UT,
                    @UP,
                    @DW,
                    @UUP,
                    @DDW
                    );
                    ";
                //sql += "SELECT LAST_INSERT_ID() ";
                int newid = await c.QueryFirstOrDefaultAsync<int>(sql, obj);
                //obj.Id = newid;
                return obj;
            });
        }

        public async Task<PidTable> GetByID(string pid)
        {
            return await WithConnection(async c =>
            {
                var result = await c.QueryFirstOrDefaultAsync<PidTable>(
                    "SELECT * FROM pid_table WHERE PID = @pid", new { pid = pid });
                return result;
            });
        }

        public async Task<int> Update(PidTable obj)
        {
            return await WithConnection(async c =>
            {
                var result = await c.ExecuteAsync($@" UPDATE pid_table set 
                    PID=@PID,
                    eqp_id=@EqpId,
                    prop=@Prop,
                    Des=@Des,
                    pid_type=@PidType,
                    UT=@UT,
                    UP=@UP,
                    DW=@DW,
                    UUP=@UUP,
                    DDW=@DDW
                 where PID=@Pid", obj);
                return result;
            });
        }

        public async Task<int> Delete(string[] ids, int userID)
        {
            return await WithConnection(async c =>
            {
                var result = await c.ExecuteAsync(" Update pid_table set is_del=1" +
                ",updated_time=@updated_time,updated_by=@updated_by" +
                " WHERE pid in @ids ", new { ids = ids, updated_time = DateTime.Now, updated_by = userID });
                return result;
            });
        }
    }
}



