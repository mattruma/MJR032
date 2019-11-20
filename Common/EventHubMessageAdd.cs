using Microsoft.Azure.EventHubs;
using Newtonsoft.Json;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    // https://docs.microsoft.com/en-us/azure/event-hubs/event-hubs-dotnet-standard-getstarted-send

    public class EventHubMessageAdd : IMessageAdd
    {
        private readonly EventHubMessageAddOptions _options;

        public EventHubMessageAdd(
            EventHubMessageAddOptions options)
        {
            _options = options;
        }

        public async Task<bool> AddAsync(
            MessageAddOptions messageAddOptions)
        {
            var connectionStringBuilder =
                new EventHubsConnectionStringBuilder(_options.ConnectionString)
                {
                    EntityPath = messageAddOptions.Type
                };


            var eventHubClient =
                EventHubClient.CreateFromConnectionString(connectionStringBuilder.ToString());

            await eventHubClient.SendAsync(
                new EventData(
                    Encoding.UTF8.GetBytes(
                        JsonConvert.SerializeObject(messageAddOptions, Formatting.Indented))));

            await eventHubClient.CloseAsync();

            return true;
        }
    }
}
