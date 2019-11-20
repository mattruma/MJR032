using Newtonsoft.Json;

namespace FuncApp1
{
    public class MessageAOptions
    {
        [JsonProperty("a_field_1")]
        public string Field1 { get; set; }

        [JsonProperty("a_field_2")]
        public string Field2 { get; set; }

        [JsonProperty("a_field_3")]
        public string Field3 { get; set; }
    }
}
