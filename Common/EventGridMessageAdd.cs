using Microsoft.Azure.EventGrid;
using Microsoft.Azure.EventGrid.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Common
{
    // https://docs.microsoft.com/en-us/dotnet/api/overview/azure/eventgrid?view=azure-dotnet

    public class EventGridMessageAdd : IMessageAdd
    {
        private readonly EventGridMessageAddOptions _options;

        public EventGridMessageAdd(
            EventGridMessageAddOptions options)
        {
            _options = options;
        }

        public async Task<bool> AddAsync(
            MessageAddOptions messageAddOptions)
        {
            var eventGridEventList =
                new List<EventGridEvent>();

            var topicCredentials =
                new TopicCredentials(
                    _options.TopicKey);

            var eventGridClient =
                new EventGridClient(
                    topicCredentials);

            var eventGridEvent =
                new EventGridEvent()
                {
                    Id = messageAddOptions.Id.ToString(),
                    Subject = messageAddOptions.Subject,
                    EventType = messageAddOptions.Type,
                    Data = messageAddOptions.Data,
                    EventTime = messageAddOptions.Time,
                    DataVersion = messageAddOptions.DataVersion
                };

            eventGridEventList.Add(
                eventGridEvent);

            await eventGridClient.PublishEventsAsync(
               new Uri(_options.TopicEndpoint).Host, eventGridEventList);

            return true;
        }
    }
}
