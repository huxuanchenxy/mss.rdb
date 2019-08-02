using Confluent.Kafka;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace rdbMicroservice.Service
{
    public interface IProduicerFactoryService
    {
        IProducer<Null, string> GetDefaultProducer();
        IProducer<Null, string> GetNewProducer();
    }
}
