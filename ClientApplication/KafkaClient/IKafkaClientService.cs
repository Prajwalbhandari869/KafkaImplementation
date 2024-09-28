using Shared.Models;

namespace ClientApplication.KafkaClient
{
    public interface IKafkaClientService
    {
        Task<string> ProduceAsync(Message message);
        Task<string> ConsumeAsync(string topic);
    }
}
