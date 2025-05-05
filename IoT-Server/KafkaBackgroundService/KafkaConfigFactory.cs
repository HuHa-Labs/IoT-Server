using Confluent.Kafka;

namespace IoT_Server.KafkaBackgroundService;

public static class KafkaConfigFactory
{
    public static ConsumerConfig Create()
    {
        return new ConsumerConfig()
        {
            BootstrapServers = "localhost:9092",
            GroupId = "iot.kafka",
            AutoOffsetReset = AutoOffsetReset.Earliest,
        };
    }
}