using Microsoft.Azure.Storage;
using Microsoft.Azure.Storage.Queue;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace Common
{
    // https://docs.microsoft.com/en-us/azure/storage/queues/storage-dotnet-how-to-use-queues

    public class StorageQueueMessageAdd : IMessageAdd
    {
        private readonly StorageQueueMessageAddOptions _options;

        public StorageQueueMessageAdd(
            StorageQueueMessageAddOptions options)
        {
            _options = options;
        }

        public async Task<bool> AddAsync(
            MessageAddOptions messageAddOptions)
        {
            var cloudStorageAccount =
                CloudStorageAccount.Parse(_options.ConnectionString);

            var cloudQueueClient =
                cloudStorageAccount.CreateCloudQueueClient();

            var cloudQueue =
                cloudQueueClient.GetQueueReference(messageAddOptions.Type);

            await cloudQueue.CreateIfNotExistsAsync();

            var cloudQueueMessage =
                new CloudQueueMessage(
                    JsonConvert.SerializeObject(messageAddOptions, Formatting.Indented));

            await cloudQueue.AddMessageAsync(cloudQueueMessage);

            return true;
        }
    }
}
