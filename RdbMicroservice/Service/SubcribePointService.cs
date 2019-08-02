using Microsoft.Extensions.Logging;
using RDB_ADL_CSharpProxy;
using rdbMicroservice.Service.Rdb;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace rdbMicroservice.Service
{

    public interface ISubscribePointDictionary
    {
        bool Add(RdbPoint point);
        bool ContainsKey(string key);
        RdbPoint GetValue(string key);
        void Remove(string key);
        void RemoveTable(string table);
    }
    public class SubscribePointDictionary : ISubscribePointDictionary
    {
        //private readonly ILogger _logger;
        private IBackgroundQueue _backgroundQueue;
        private ConcurrentDictionary<string, RdbPointWrapper> _rdbPointDictionary;
        public SubscribePointDictionary(/*ILogger<SubscribePointDictionary> logger,*/ IBackgroundQueue backgroundQueue)
        {
            //_logger = logger;
            _backgroundQueue = backgroundQueue;
            _rdbPointDictionary = new ConcurrentDictionary<string, RdbPointWrapper>();
        }

        public bool Add(RdbPoint rdbPoint)
        {
        
            if(_rdbPointDictionary.Keys.Contains(rdbPoint.PID))
            {
                return false;
            }
            RdbPointWrapper rdbPointWrapper = new RdbPointWrapper(rdbPoint);        
            return Add(rdbPoint.PID, rdbPointWrapper);
        }

        public void SetAll()
        {

            foreach (var item in _rdbPointDictionary)
            {
                item.Value.SetPointChanged(_backgroundQueue);
            }
          
        }

        public bool AddAndSet(RdbPoint rdbPoint)
        {

            if (_rdbPointDictionary.Keys.Contains(rdbPoint.PID))
            {
                return false;
            }
            RdbPointWrapper rdbPointWrapper = new RdbPointWrapper(rdbPoint);
            rdbPointWrapper.SetPointChanged(_backgroundQueue);
            return Add(rdbPoint.PID, rdbPointWrapper);
        }

        private bool Add(string key, RdbPointWrapper point)
        {
            if (_rdbPointDictionary.TryAdd(key, point))
            {

                return true;
            }
            else
            {
                return false;
            }
        }

        public bool ContainsKey(string key)
        {
            return _rdbPointDictionary.ContainsKey(key);
        }

        public RdbPoint GetValue(string key)
        {
            if (_rdbPointDictionary.TryGetValue(key, out var rdbPoint))
                return rdbPoint.RdbPoint;
            else
                return null;
        }

        public void Remove(string key)
        {
            if (_rdbPointDictionary.TryRemove(key, out var rdbPoint))
            {
                rdbPoint.UnsetPointChanged();
            }

        }

        public void RemoveTable(string table)
        {
            var rdbPointWrappers = _rdbPointDictionary.Values.Where(x => x.Tablename == table);

            foreach (var p in rdbPointWrappers)
            {
                _rdbPointDictionary.TryRemove(p.PID, out var rdbPoint);
                rdbPoint.UnsetPointChanged();
            }

        }

    }
}
