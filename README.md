## FuncApp1

Add a `local.settings.json` file.

Add the following code snippet to your `local.settings.json` file.

```
{
  "IsEncrypted": false,
  "Values": {
    "AzureWebJobsStorage": "UseDevelopmentStorage=true",
    "FUNCTIONS_WORKER_RUNTIME": "dotnet",
    "EventGridMessageAddOptions:TopicKey": "EVENT_GRID_TOPIC_KEY",
    "EventGridMessageAddOptions:TopicEndpoint": "EVENT_GRID_TOPIC_ENDPOINT",
    "EventHubMessageAddOptions:ConnectionString": "EVENT_HUB_CONNECTION_STRING",
    "ServiceBusMessageAddOptions:ConnectionString": "SERVICE_BUS_CONNECTION_STRING",
    "StorageQueueMessageAddOptions:ConnectionString": "STORAGE_QUEUE_CONNECTION_STRING"
  }
}
```

## WebApp1

Add a `appsettings.Development.json` file.

Add the following code snippet to your `appsettings.Development.json` file.

```
{
  "Logging": {
    "LogLevel": {
      "Default": "Debug",
      "System": "Information",
      "Microsoft": "Information"
    }
  },
  "EventGridMessageAddOptions": {
    "TopicKey": "EVENT_GRID_TOPIC_KEY",
    "TopicEndpoint": "EVENT_GRID_TOPIC_ENDPOINT"
  },
  "EventHubMessageAddOptions": {
    "ConnectionString": "EVENT_HUB_CONNECTION_STRING"
  },
  "ServiceBusMessageAddOptions": {
    "ConnectionString": "SERVICE_BUS_CONNECTION_STRING"
  },
  "StorageQueueMessageAddOptions": {
    "ConnectionString": "STORAGE_QUEUE_CONNECTION_STRING"
  }
}
```