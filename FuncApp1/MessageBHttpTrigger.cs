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
    public class MessageBHttpTrigger
    {
        private readonly IMessageAdd _messageAdd;

        public MessageBHttpTrigger(
            IMessageAdd messageAdd)
        {
            _messageAdd = messageAdd;
        }

        [FunctionName("MessageBHttpTrigger")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("MessageBHttpTrigger processed a request.");

            var messageBOptions =
                JsonConvert.DeserializeObject<MessageBOptions>(
                    await new StreamReader(req.Body).ReadToEndAsync());

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
