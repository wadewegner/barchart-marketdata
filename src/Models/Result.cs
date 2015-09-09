using Newtonsoft.Json;

namespace Barchart.MarketData.Models
{
    public class Result
    {
        [JsonProperty(PropertyName = "symbol")]
        public string Symbol { get; set; }

        [JsonProperty(PropertyName = "timestamp")]
        public string Timestamp { get; set; }

        [JsonProperty(PropertyName = "tradingDay")]
        public string TradingDay { get; set; }

        [JsonProperty(PropertyName = "open")]
        public double Open { get; set; }

        [JsonProperty(PropertyName = "high")]
        public double High { get; set; }

        [JsonProperty(PropertyName = "low")]
        public double Low { get; set; }

        [JsonProperty(PropertyName = "close")]
        public double Close { get; set; }

        [JsonProperty(PropertyName = "volume")]
        public int Volume { get; set; }

        [JsonProperty(PropertyName = "openInterest")]
        public object OpenInterest { get; set; }
    }
}