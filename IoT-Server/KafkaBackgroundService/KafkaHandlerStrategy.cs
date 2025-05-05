using Confluent.Kafka;

namespace IoT_Server.KafkaBackgroundService;

public class KafkaHandlerStrategy : IKafkaHandlerStrategy
{
    public Task HandleMessage(ConsumeResult<Ignore, string> consumeResult)
    {
        return Task.CompletedTask;
    }
}