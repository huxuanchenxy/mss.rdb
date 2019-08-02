using rdbMicroservice.Models;
using System.Collections.Generic;


namespace rdbMicroservice.Service

{
    public interface IRdbService
    {
        void Init();
        void UnInit();
        void StartReconnect();
        List<RPointBase> ReadTable(string tableName);
        RPointBase ReadPoint(string PID);


    }
}