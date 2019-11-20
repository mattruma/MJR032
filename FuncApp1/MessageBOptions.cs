using Newtonsoft.Json;

namespace FuncApp1
{
    public class MessageBOptions
    {
        [JsonProperty("b_field_1")]
        public string Field1 { get; set; }

        [JsonProperty("b_field_2")]
        public string Field2 { get; set; }

        [JsonProperty("b_field_3")]
        public string Field3 { get; set; }
    }
}
