
namespace rdbMicroservice
{

    public class Rootconfig
    {
        public Rdbconfig RdbConfig { get; set; }
        public Kafkaconfig KafkaConfig { get; set; }
    }

    public class Rdbconfig
    {
        public string Ip1 { get; set; }
        public string Ip2 { get; set; }
    }

    public class Kafkaconfig
    {
        public string Ip { get; set; }
    }

}
