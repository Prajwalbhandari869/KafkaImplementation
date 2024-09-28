
using Confluent.Kafka;

namespace KafkaServer.KafkaServices
{
    public class ProducerService : IProducerService
    {
        private readonly IBuilderService _builderService;

        public ProducerService(IBuilderService builderService)
        {
            _builderService = builderService;
        }
        public async Task ProduceAsync(string topic, string message)
        {
            try
            {
                var msg = new Message<Null, string> { Value = message };
                var producer = _builderService.GetProducerBuilder();
                if (producer != null)
                {
                    var result = await producer.ProduceAsync(topic, msg);
                    Console.WriteLine($"Message sent to the partation {result.Partition}" +
                        $" at offset {result.Offset}");
                }
            }
            catch (ProduceException<Null,string> ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }
    }
}
