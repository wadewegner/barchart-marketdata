using Newtonsoft.Json;

namespace Barchart.MarketData.Models
{
    public class Status
    {
        [JsonProperty(PropertyName = "code")]
        public int Code { get; set; }

        [JsonProperty(PropertyName = "message")]
        public string Message { get; set; }
    }
}