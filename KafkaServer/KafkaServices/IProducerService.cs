namespace KafkaServer.KafkaServices
{
    public interface IProducerService
    {
        Task ProduceAsync(string topic, string message);
    }
}
