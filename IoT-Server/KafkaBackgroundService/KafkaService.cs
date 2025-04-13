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
        while (!stoppingToken.IsCancellationRequested)
        {
            await PollDataFromKafkaAsync();
        }
    }

    async Task PollDataFromKafkaAsync()
    {
        _logger.LogInformation("Polling data from Kafka.");
        await Task.Delay(5000);
    }
}