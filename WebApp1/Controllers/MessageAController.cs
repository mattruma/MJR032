using Common;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace WebApp1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageAController : ControllerBase
    {
        private readonly IMessageAdd _messageAdd;

        public MessageAController(
            IMessageAdd messageAdd)
        {
            _messageAdd = messageAdd;
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync(
            [FromBody] MessageAOptions messageAOptions)
        {
            var messageAddOptions =
                   new MessageAddOptions
                   {
                       Data = messageAOptions,
                       Type = "funcapp1-messagea",
                       Subject = "MessageA.Added"
                   };

            await _messageAdd.AddAsync(messageAddOptions);

            return new OkObjectResult(messageAddOptions);
        }
    }
}
