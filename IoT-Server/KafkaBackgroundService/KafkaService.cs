namespace IoT_Server.KafkaBackgroundService;

public class KafkaService : BackgroundService 
{
    readonly ILogger<KafkaService> _logger;
    
    public KafkaService(ILogger<KafkaService> logger)
    {
        _logger = logger;
    }
    
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        _logger.LogInformation("Kafka Service is starting.");
        var consumeTokenSource = new CancellationTokenSource();
        IKafkaHandlerStrategy kafkaHandlerStrategy = new KafkaHandlerStrategy();
        await PollDataFromKafkaAsync(stoppingToken, consumeTokenSource.Token, kafkaHandlerStrategy);
    }

    async Task PollDataFromKafkaAsync(CancellationToken stoppingToken, CancellationToken consumeCancellationToken, IKafkaHandlerStrategy kafkaHandlerStrategy)
    {
        _logger.LogInformation("Polling data from Kafka.");
        await KafkaConsumer.StartAsync(stoppingToken, consumeCancellationToken, kafkaHandlerStrategy);
    }
}