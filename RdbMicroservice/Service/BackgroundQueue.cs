using RDB_ADL_CSharpProxy;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace rdbMicroservice.Service
{ 
    public interface IBackgroundQueue
    {
        void QueueItem(RdbPoint point);
        Task<RdbPoint> DequeueAsync(CancellationToken cancellationToken);
        RdbPoint Dequeue();
    }

    public class BackgroundQueue : IBackgroundQueue
    {
        private ConcurrentQueue<RdbPoint> _messageItems =  new ConcurrentQueue<RdbPoint>();
        private SemaphoreSlim _signal = new SemaphoreSlim(0);

        public void QueueItem(RdbPoint point)
        {
            if (point == null)
            { 
                throw new ArgumentNullException(nameof(point));
            }    

            _messageItems.Enqueue(point);
            _signal.Release();
        }

        public async Task<RdbPoint> DequeueAsync(
            CancellationToken cancellationToken)
        {
            await _signal.WaitAsync(cancellationToken);
            _messageItems.TryDequeue(out var point);          
            return point;
        }
        public RdbPoint Dequeue( )
        {
            _signal.Wait();
            _messageItems.TryDequeue(out var point);
            return point;
        }
    }
}
