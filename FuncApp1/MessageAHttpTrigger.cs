using Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.IO;
using System.Threading.Tasks;

namespace FuncApp1
{
    public class MessageAHttpTrigger
    {
        private readonly IMessageAdd _messageAdd;

        public MessageAHttpTrigger(
            IMessageAdd messageAdd)
        {
            _messageAdd = messageAdd;
        }

        [FunctionName("MessageAHttpTrigger")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("MessageAHttpTrigger processed a request.");

            var messageAOptions =
                JsonConvert.DeserializeObject<MessageAOptions>(
                    await new StreamReader(req.Body).ReadToEndAsync());

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
