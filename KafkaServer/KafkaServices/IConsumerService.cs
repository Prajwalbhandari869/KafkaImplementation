namespace KafkaServer.KafkaServices
{
    public interface IConsumerService
    {
        void Consume(string topic, string groupId);
        Task<string> GetConsumedMessage();
    }
}
