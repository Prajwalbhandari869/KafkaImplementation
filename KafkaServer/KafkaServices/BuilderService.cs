using Confluent.Kafka;

namespace KafkaServer.KafkaServices
{
    public class BuilderService: IBuilderService
    {
        private readonly string bootstrapServers = "192.168.1.93:9092";
        private readonly ILogger<BuilderService> _logger;

        private IProducer<Null, string>? ProducerBuilder { get; set; }
        private IConsumer<Null, string>? ConsumerBuilder { get; set; }
        public BuilderService(ILogger<BuilderService> logger)
        {
            _logger = logger;
            try
            {
                var producerConfig = new ProducerConfig { BootstrapServers = bootstrapServers };
                var consumerConfig = new ConsumerConfig
                {
                    BootstrapServers = bootstrapServers,
                    GroupId = "Browser Group",
                    AutoOffsetReset = AutoOffsetReset.Earliest
                };
                ProducerBuilder = new ProducerBuilder<Null, string>(producerConfig).Build();
                ConsumerBuilder = new ConsumerBuilder<Null, string>(consumerConfig).Build();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw;
            }           
        }

        public IProducer<Null, string>? GetProducerBuilder()
        {
            if (ProducerBuilder != null) return ProducerBuilder;
            return null;
        }
        public IConsumer<Null, string>? GetConsumerBuilder()
        {
            if(ConsumerBuilder != null) return ConsumerBuilder;
            return null;
        }
    }
}
