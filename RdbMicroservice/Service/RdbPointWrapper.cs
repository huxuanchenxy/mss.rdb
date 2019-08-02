using RDB_ADL_CSharpProxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace rdbMicroservice.Service.Rdb
{
    public class RdbPointWrapper
    {
        public string PID { get; private set; }
        public string Tablename { get; private set; }
        public bool PointChangedEnable { get; private set; }
        public  RdbPoint RdbPoint { get; private set; }
        private readonly RdbPoint.PointChangedFunc pointChanged;
        private IBackgroundQueue _backgroundQueue;
       

        public RdbPointWrapper(RdbPoint rdbPoint)
        {
            RdbPoint = rdbPoint;
            PID = rdbPoint.PID;
            Tablename = rdbPoint.Table.GetTableName();
            pointChanged = PointChanged;

        }
        public void PointChanged(long a, long b, long c)
        {
           // double value = -1;
            //DateTime dateTime = new DateTime();
            if (RdbPoint == null)
                return;
           // RdbPoint.Read("Value", ref value);
            //RdbPoint.Read("Time", ref dateTime);
          //  RdbMessage rdbMessage = new RdbMessage { PID = PID, Value = value, Time= dateTime };
            if (_backgroundQueue != null)
                _backgroundQueue.QueueItem(RdbPoint);
        }
        public void SetPointChanged(IBackgroundQueue backgroundQueue)
        {
            if(!PointChangedEnable)
            {
                _backgroundQueue = backgroundQueue;
                RdbPoint.SetPointChangedFuncCB(pointChanged);
                PointChangedEnable = true;
            }
        

        }
        public void UnsetPointChanged()
        {
            RdbPoint.SetPointChangedFuncCB(null);
            PointChangedEnable = false;
        }


    }
}
