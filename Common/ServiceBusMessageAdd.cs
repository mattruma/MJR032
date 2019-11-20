using Microsoft.Azure.ServiceBus;
using Newtonsoft.Json;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    // https://docs.microsoft.com/en-us/azure/service-bus-messaging/service-bus-dotnet-get-started-with-queues

    public class ServiceBusMessageAdd : IMessageAdd
    {
        private readonly ServiceBusMessageAddOptions _options;

        public ServiceBusMessageAdd(
            ServiceBusMessageAddOptions options)
        {
            _options = options;
        }

        public async Task<bool> AddAsync(
            MessageAddOptions messageAddOptions)
        {
            var queueClient =
                new QueueClient(_options.ConnectionString, messageAddOptions.Type);


            var message =
                new Message(
                    Encoding.UTF8.GetBytes(
                        JsonConvert.SerializeObject(messageAddOptions, Formatting.Indented)));

            await queueClient.SendAsync(message);

            return true;
        }
    }
}
