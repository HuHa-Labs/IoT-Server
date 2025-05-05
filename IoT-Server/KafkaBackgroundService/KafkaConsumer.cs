using Confluent.Kafka;

namespace IoT_Server.KafkaBackgroundService;

public static class KafkaConsumer
{
    public static async Task StartAsync(CancellationToken stoppingToken, CancellationToken consumeToken, 
        IKafkaHandlerStrategy consumeHandler)
    {
        var config = KafkaConfigFactory.Create();
        using (var consumer = new ConsumerBuilder<Ignore, string>(config).Build())
        {
            consumer.Subscribe("iot.kafka");
            while (!stoppingToken.IsCancellationRequested)
            {
                try
                {
                    var consumeResult = consumer.Consume(consumeToken);
                    await consumeHandler.HandleMessage(consumeResult);
                }
                catch(ConsumeException e)
                {
                    Console.WriteLine(e);
                }
            }
            consumer.Close();
        }
    }
}