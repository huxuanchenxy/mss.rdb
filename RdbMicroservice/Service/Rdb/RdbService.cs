using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Threading;
using RDB_ADL_CSharpProxy;
using rdbMicroservice;
using rdbMicroservice.Extensions;
using rdbMicroservice.Models;

namespace rdbMicroservice.Service
{
    public class RdbService : IRdbService
    {
        private readonly ILogger<RdbService> _logger;
        private readonly IConfiguration _config;
        private Rdbconfig _rdbconfig = new Rdbconfig();
        private CancellationTokenSource cts = new CancellationTokenSource();
        private List<string> rdbServers = new List<string>();
        public bool Started { get; private set; } = false;
        public bool Actived
        {
            get { return RdbProxy.IsConnectActive(); }

        }

        public RdbService(IConfiguration config, ILogger<RdbService> logger)
        {
            _logger = logger;
            _config = config;
            _config.GetSection("RdbConfig").Bind(_rdbconfig);
            rdbServers.Insert(0, _rdbconfig.Ip1);
            rdbServers.Insert(1, _rdbconfig.Ip1);

        }

        public void StartReconnect()
        {            
            Task.Factory.StartNew(async () =>
            {
                while (!cts.IsCancellationRequested)
                {
                  await  Task.Delay(10000);
                    while (!RdbProxy.IsConnectActive())
                    {
                        try
                        {
                            RdbProxy.UnInit();
                            Init();
                        }
                        catch (Exception ex)
                        {
                            _logger.LogError(ex.ToString());
                        }

                    }
                }
            }, TaskCreationOptions.LongRunning);
        }
        public void StopReconnect()
        {
            this.cts.Cancel();
        }
        public void Init()
        {
            try
            {
                _logger.LogWarning("开始准备连接RDBSrv");
                RdbProxy.Init(rdbServers);
                if (RdbProxy.Start())
                {
                    Started = true;
                    _logger.LogWarning("RDBSrv连接成功");
                }
                else
                {
                    Started = false;
                    _logger.LogError("RDBSrv连接失败");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
            }
        }

        public void UnInit()
        {
            RdbProxy.UnInit();
        }



        public List<RPointBase> ReadTable(string tableName)
        {
            List<RPointBase> rPoints = new List<RPointBase>();

            string pid = null;
            string des = null;
            string ut = null;
            int specialtyNo = -1;
            double dw = -1;
            double ddw = -1;
            double up = -1;
            double uup = -1;
            double value = -1;
            DateTime time = new DateTime();
            DateTime updateTime = new DateTime();

            RdbTable rdbTable = RdbProxy.GetTable(tableName);
            if (rdbTable == null)
                return null;

            int tableRowCount = rdbTable.RowCount();//表行数
            if (tableRowCount == 0)
                return null;

            if (RdbProxy.IsConnectActive())
            {
                if (tableName.Substring(tableName.Length - 2, 2).Equals("_a"))
                {

                    for (int i = 0; i < tableRowCount; i++)
                    {
                        rdbTable.Read(i, "PID", ref pid);
                        rdbTable.Read(i, "Des", ref des);
                        rdbTable.Read(i, "UT", ref ut);
                        rdbTable.Read(i, "SpecialtyNo", ref specialtyNo);
                        rdbTable.Read(i, "DW", ref dw);
                        rdbTable.Read(i, "DDW", ref ddw);
                        rdbTable.Read(i, "UP", ref up);
                        rdbTable.Read(i, "UUP", ref uup);
                        rdbTable.Read(i, "Value", ref value);
                        rdbTable.Read(i, "Time", ref time);
                        rdbTable.Read(i, "UpdateTime", ref updateTime);
                        var point = new RAPoint { PID = pid, Des = des, UT = ut, SpecialtyNo = specialtyNo, DW = dw, DDW = ddw, UP = up, UUP = uup, Value = value, Time = time, UpdateTime = updateTime };
                        rPoints.Add(point);
                    }

                }
                else if (tableName.Substring(tableName.Length - 2, 2).Equals("_d"))
                {
                    for (int i = 0; i < tableRowCount; i++)
                    {
                        rdbTable.Read(i, "PID", ref pid);
                        rdbTable.Read(i, "Des", ref des);
                        rdbTable.Read(i, "SpecialtyNo", ref specialtyNo);
                        rdbTable.Read(i, "Value", ref value);
                        rdbTable.Read(i, "Time", ref time);
                        rdbTable.Read(i, "UpdateTime", ref updateTime);
                        var point = new RDPoint { PID = pid, Des = des, SpecialtyNo = specialtyNo, Value = value, Time = time, UpdateTime = updateTime };
                        rPoints.Add(point);
                    }

                }

            }
            return rPoints;

        }

        public RPointBase ReadPoint(string PID)
        {
            RPointBase rPointBase = null;
            RdbPoint rdbPoint = null;
            string pid = null;
            string des = null;
            string ut = null;
            int specialtyNo = -1;
            double dw = -1;
            double ddw = -1;
            double up = -1;
            double uup = -1;
            double value = -1;
            DateTime time = new DateTime();
            DateTime updateTime = new DateTime();

            if (RdbProxy.IsConnectActive())
            {

                rdbPoint = RdbProxy.GetPoint(PID);

                if (rdbPoint == null)
                {
                    _logger.LogDebug("Pid: " + PID + "not exist!" + System.DateTime.Now.ToString());
                    return null;

                }
                if (PID.Contains("_a_"))
                {

                    rdbPoint.Read("PID", ref pid);
                    rdbPoint.Read("Des", ref des);
                    rdbPoint.Read("UT", ref ut);
                    rdbPoint.Read("SpecialtyNo", ref specialtyNo);
                    rdbPoint.Read("DW", ref dw);
                    rdbPoint.Read("DDW", ref ddw);
                    rdbPoint.Read("UP", ref up);
                    rdbPoint.Read("UUP", ref uup);
                    rdbPoint.Read("Value", ref value);
                    rdbPoint.Read("Time", ref time);
                    rdbPoint.Read("UpdateTime", ref updateTime);
                    rPointBase = new RAPoint { PID = pid, Des = des, UT = ut, SpecialtyNo = specialtyNo, DW = dw, DDW = ddw, UP = up, UUP = uup, Value = value, Time = time, UpdateTime = updateTime };

                }
                else if (PID.Contains("_d_"))
                {
                    rdbPoint.Read("PID", ref pid);
                    rdbPoint.Read("Des", ref des);
                    rdbPoint.Read("SpecialtyNo", ref specialtyNo);
                    rdbPoint.Read("Value", ref value);
                    rdbPoint.Read("Time", ref time);
                    rdbPoint.Read("UpdateTime", ref updateTime);
                    rPointBase = new RDPoint { PID = pid, Des = des, SpecialtyNo = specialtyNo, Value = value, Time = time, UpdateTime = updateTime };
                }

            }

            return rPointBase;
        }

        public RdbPoint GetPoint(string PID)
        {
            RdbPoint rdbPoint = RdbProxy.GetPoint(PID);            
            return rdbPoint;
        }
        public List<string> GetAllTablePointPids(string table)
        {
            List<string> pids = new List<string>();
              if (RdbProxy.IsConnectActive())
            {
                RdbTable rdbTable = RdbProxy.GetTable(table);
                rdbTable.GetAllPID(ref pids);
              
            }
            return pids;
        }

        public List<RdbPoint> GetTablePoints(string table)
        {
            List<RdbPoint> rdbPoints = new List<RdbPoint>();
            List<string> pidList = new List<string>();
          
                RdbTable rdbTable = RdbProxy.GetTable(table);
                if (rdbTable == null)
                    return rdbPoints;

                rdbTable.GetAllPID(ref pidList);
                foreach (string pid in pidList)
                {
                    var point = GetPoint(pid);
                    if (point != null)
                    {
                        rdbPoints.Add(point);
                    }
                }

           
            return rdbPoints;
        }
    }
}

