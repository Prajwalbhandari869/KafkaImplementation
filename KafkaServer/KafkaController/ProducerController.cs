using KafkaServer.KafkaServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shared.Models;
using Newtonsoft.Json;

namespace ServerSide.KafkaController
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProducerController : ControllerBase
    {
        private readonly IProducerService _producerService;
        private readonly ILogger<ProducerController> _logger;

        public ProducerController(IProducerService producerService,
            ILogger<ProducerController> logger)
        {
            _producerService = producerService;
            _logger = logger;
        }
        [HttpPost("message")]
        public async Task<ActionResult> ProduceAsync(Message message)
        {
            try 
            {

                var topic = message.BrowserName.Replace(" ","").Trim();
                var messageJson = JsonConvert.SerializeObject(message).ToString();
                await _producerService.ProduceAsync(topic, messageJson);
                return Ok($"Message Published Successfully");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message.ToString());
                return BadRequest($"Error Occured. Error{ex.Message}");
            }
        }
    }
}
