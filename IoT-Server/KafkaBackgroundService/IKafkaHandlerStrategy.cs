using Confluent.Kafka;

namespace IoT_Server.KafkaBackgroundService;

public interface IKafkaHandlerStrategy
{
    public Task HandleMessage(ConsumeResult<Ignore, string> consumeResult);
}