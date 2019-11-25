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
            // Settings for event grid

            var eventGridMessageAddOptions =
                new EventGridMessageAddOptions
                {
                    TopicEndpoint = Environment.GetEnvironmentVariable("EventGridMessageAddOptions:TopicEndpoint"),
                    TopicKey = Environment.GetEnvironmentVariable("EventGridMessageAddOptions:TopicKey")
                };

            builder.Services
                .AddSingleton(eventGridMessageAddOptions);

            // Settings for event hub

            var eventHubMessageAddOptions =
                new EventHubMessageAddOptions
                {
                    ConnectionString = Environment.GetEnvironmentVariable("EventHubMessageAddOptions:ConnectionString")
                };

            builder.Services
                .AddSingleton(eventHubMessageAddOptions);

            // Settings for service bus

            var serviceBusMessageSenderOptions =
                new ServiceBusMessageAddOptions
                {
                    ConnectionString = Environment.GetEnvironmentVariable("ServiceBusMessageAddOptions:ConnectionString")
                };

            builder.Services
                .AddSingleton(serviceBusMessageSenderOptions);

            // Settings for storage queue

            var storageQueueMessageAddOptions =
                new StorageQueueMessageAddOptions
                {
                    ConnectionString = Environment.GetEnvironmentVariable("StorageQueueMessageAddOptions:ConnectionString")
                };

            builder.Services
                .AddSingleton(storageQueueMessageAddOptions);

            // Choose your add message service

            builder.Services
                .AddSingleton<IMessageAdd, EventGridMessageAdd>();
            //builder.Services
            //    .AddSingleton<IMessageAdd, EventHubMessageAdd>();
            //builder.Services
            //    .AddSingleton<IMessageAdd, ServiceBusMessageAdd>();
            //builder.Services
            //    .AddSingleton<IMessageAdd, StorageQueueMessageAdd>();
            //builder.Services
            //    .AddSingleton<IMessageAdd, FakeMessageAdd>();
        }
    }
}
