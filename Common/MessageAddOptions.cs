using Newtonsoft.Json;
using System;

namespace Common
{
    public class MessageAddOptions
    {
        [JsonProperty("id")]
        public Guid Id { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("time")]
        public DateTime Time { get; set; }

        [JsonProperty("data")]
        public object Data { get; set; }

        [JsonProperty("subject")]
        public string Subject { get; set; }

        [JsonProperty("data_version")]
        public string DataVersion { get; set; }

        public MessageAddOptions()
        {
            this.Id = Guid.NewGuid();
            this.Time = DateTime.UtcNow;
            this.DataVersion = "1.0";
        }
    }
}
