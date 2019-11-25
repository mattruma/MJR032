using Common;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace WebApp1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageBController : ControllerBase
    {
        private readonly IMessageAdd _messageAdd;

        public MessageBController(
            IMessageAdd messageAdd)
        {
            _messageAdd = messageAdd;
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync(
            [FromBody] MessageBOptions messageBOptions)
        {

            var messageAddOptions =
                new MessageAddOptions
                {
                    Data = messageBOptions,
                    Type = "funcapp1-messageb",
                    Subject = "MessageB.Added"
                };

            await _messageAdd.AddAsync(messageAddOptions);

            return new OkObjectResult(messageAddOptions);
        }
    }
}
