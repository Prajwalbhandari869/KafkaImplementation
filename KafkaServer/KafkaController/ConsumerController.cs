using KafkaServer.KafkaServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KafkaServer.KafkaController
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConsumerController : ControllerBase
    {
        private readonly IConsumerService _consumerService;
        private readonly ILogger<ConsumerController> _logger;

        public ConsumerController(IConsumerService consumerService,
            ILogger<ConsumerController> logger)
        {
            _consumerService = consumerService;
            _logger = logger;
        }
        [HttpGet("comsume/{topic}")]
        public async Task<ActionResult<string>> ConsumeAsync(string topic)
        {
            try
            {
                topic = topic.Replace(" ", "").Trim();
                _consumerService.Consume(topic, "Browser Group");
                string result = await _consumerService.GetConsumedMessage(); 
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message.ToString());
                return BadRequest($"Error Occured. Error{ex.Message}");
            }
        }
    }
}
