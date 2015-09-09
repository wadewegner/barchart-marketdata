using System.Collections.Generic;
using Newtonsoft.Json;

namespace Barchart.MarketData.Models
{
    public class HistoryResponse
    {
        [JsonProperty(PropertyName = "status")]
        public Status Status { get; set; }

        [JsonProperty(PropertyName = "results")]
        public List<Result> Results { get; set; }
    }
}
