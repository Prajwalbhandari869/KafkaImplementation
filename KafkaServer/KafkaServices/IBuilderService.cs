using Confluent.Kafka;

namespace KafkaServer.KafkaServices
{
    public interface IBuilderService
    {
        public IProducer<Null, string>? GetProducerBuilder();
        public IConsumer<Null, string>? GetConsumerBuilder();
    }
}
