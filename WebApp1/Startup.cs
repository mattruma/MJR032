using Common;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace WebApp1
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Settings for event grid

            var eventGridMessageAddOptions =
                new EventGridMessageAddOptions
                {
                    TopicEndpoint = Configuration["EventGridMessageAddOptions:TopicEndpoint"],
                    TopicKey = Configuration["EventGridMessageAddOptions:TopicKey"]
                };

            services
                .AddSingleton(eventGridMessageAddOptions);

            // Settings for event hub

            var eventHubMessageAddOptions =
                new EventHubMessageAddOptions
                {
                    ConnectionString = Configuration["EventHubMessageAddOptions:ConnectionString"]
                };

            services
                .AddSingleton(eventHubMessageAddOptions);

            // Settings for service bus

            var serviceBusMessageSenderOptions =
                new ServiceBusMessageAddOptions
                {
                    ConnectionString = Configuration["ServiceBusMessageAddOptions:ConnectionString"]
                };

            services
                .AddSingleton(serviceBusMessageSenderOptions);

            // Settings for storage queue

            var storageQueueMessageAddOptions =
                new StorageQueueMessageAddOptions
                {
                    ConnectionString = Configuration["StorageQueueMessageAddOptions:ConnectionString"]
                };

            services
                .AddSingleton(storageQueueMessageAddOptions);

            // Choose your add message service

            services
                .AddSingleton<IMessageAdd, EventGridMessageAdd>();
            //services
            //    .AddSingleton<IMessageAdd, EventHubMessageAdd>();
            //services
            //    .AddSingleton<IMessageAdd, ServiceBusMessageAdd>();
            //services
            //    .AddSingleton<IMessageAdd, StorageQueueMessageAdd>();
            //services
            //    .AddSingleton<IMessageAdd, FakeMessageAdd>();

            services.AddMvc()
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
