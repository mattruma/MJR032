using Common;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Diagnostics.CodeAnalysis;

[assembly: FunctionsStartup(typeof(FuncApp1.Startup))]
namespace FuncApp1
{
    public class Startup : FunctionsStartup
    {
        [SuppressMessage("Style", "IDE0017:Simplify object initialization", Justification = "<Pending>")]
        public override void Configure(
            IFunctionsHostBuilder builder)
        {
            var eventGridMessageAddOptions =
                new EventGridMessageAddOptions();

            eventGridMessageAddOptions.TopicEndpoint =
                Environment.GetEnvironmentVariable("EventGridMessageAddOptions:TopicEndpoint");
            eventGridMessageAddOptions.TopicKey =
                Environment.GetEnvironmentVariable("EventGridMessageAddOptions:TopicKey");

            builder.Services
                .AddSingleton(eventGridMessageAddOptions);

            var eventHubMessageAddOptions =
                 new EventHubMessageAddOptions();

            eventHubMessageAddOptions.ConnectionString =
                Environment.GetEnvironmentVariable("EventHubMessageAddOptions:ConnectionString");

            builder.Services
                .AddSingleton(eventHubMessageAddOptions);

            var storageQueueMessageAddOptions =
                new StorageQueueMessageAddOptions();

            storageQueueMessageAddOptions.ConnectionString =
                Environment.GetEnvironmentVariable("StorageQueueMessageAddOptions:ConnectionString");

            builder.Services
                .AddSingleton(storageQueueMessageAddOptions);

            var serviceBusMessageSenderOptions =
                new ServiceBusMessageAddOptions();

            serviceBusMessageSenderOptions.ConnectionString =
                Environment.GetEnvironmentVariable("ServiceBusMessageAddOptions:ConnectionString");

            builder.Services
                .AddSingleton(serviceBusMessageSenderOptions);

            //builder.Services
            //    .AddSingleton<IMessageAdd, EventGridMessageAdd>();
            builder.Services
                .AddSingleton<IMessageAdd, EventHubMessageAdd>();
            //builder.Services
            //    .AddSingleton<IMessageAdd, ServiceBusMessageAdd>();
            //builder.Services
            //    .AddSingleton<IMessageAdd, StorageQueueMessageAdd>();
        }
    }
}
