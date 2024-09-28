
using Shared.Models;
using System.Net.Http.Json;

namespace ClientApplication.KafkaClient
{
    public class KafkaClientService: IKafkaClientService
    {
        private readonly HttpClient _httpClient;

        public KafkaClientService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<string> ProduceAsync(Message message)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync<Message>("api/producer/message", message);
                return "";
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
        public async Task<string> ConsumeAsync(string topic)
        {
            try
            {
                var response = await _httpClient.GetFromJsonAsync<string>($"api/consumer/comsume/{topic}");
                return "";
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
    }
}
