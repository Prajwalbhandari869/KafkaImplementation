
using System.Text;

namespace KafkaServer.KafkaServices
{
    public class ConsumerService : IConsumerService
    {
        private readonly IBuilderService _builderService;
        private readonly StringBuilder _response;

        public ConsumerService(IBuilderService builderService)
        {
            _builderService = builderService;
            _response = new StringBuilder();
        }
        public void Consume(string topic, string groupId)
        {
            try
            {
                using (var consumer = _builderService.GetConsumerBuilder())
                {
                    if (consumer != null)
                    {
                        consumer.Subscribe(topic);
                        try
                        {
                            CancellationTokenSource cts = new();
                            while (true)
                            {
                                _response.AppendLine();
                                var result = consumer.Consume(cts.Token);
                                _response.Append(result.Message.Value.ToString());
                                Console.WriteLine($"Received message:{result.Message.Value}");
                            }
                        }
                        catch (OperationCanceledException ex)
                        {
                            Console.WriteLine(ex.Message);
                            consumer.Close();
                        }
                    }
                }
                              
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex.Message}");
                throw;
            }


        }

        public Task<string> GetConsumedMessage()
        {
            try
            {
                return Task.FromResult(_response.ToString());
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex.Message}");
                throw;
            }
        }
    }
}
