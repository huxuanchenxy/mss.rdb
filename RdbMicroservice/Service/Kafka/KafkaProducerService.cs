using Confluent.Kafka;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using rdbMicroservice;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace rdbMicroservice.Service
{
    public class KafkaProduicerFactoryService: IProduicerFactoryService
    {
        private readonly ILogger<KafkaProduicerFactoryService> _logger;
        private readonly IConfiguration _config;
        private Kafkaconfig _kafkaconfig;
        private IProducer<Null,string> _defaultProducer;
        private List<IProducer<Null, string>> producers;

        public KafkaProduicerFactoryService(IConfiguration config, ILogger<KafkaProduicerFactoryService> logger)
        {
            _logger = logger;
            _config = config;
            var kafkaconfig = new Kafkaconfig();
            _config.GetSection("Kafkaconfig").Bind(kafkaconfig);
            _kafkaconfig = kafkaconfig;
            var pconfig = new ProducerConfig {  BootstrapServers = _kafkaconfig.Ip};     
            _defaultProducer = new ProducerBuilder<Null, string>(pconfig).Build();
            producers = new List<IProducer<Null, string>>();
            producers.Add(_defaultProducer);
        }
       public IProducer<Null, string> GetDefaultProducer()
        {
            return _defaultProducer;
        }
        public IProducer<Null, string> GetNewProducer()
        {
            var producer = new DependentProducerBuilder<Null, string>(_defaultProducer.Handle).Build();
            producers.Add(producer);
            return producer;

        }
    }
}
