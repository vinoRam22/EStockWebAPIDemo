using Newtonsoft.Json;
using System.Collections.Generic;

namespace StockService.Models.StockDetails
{
    public class StockResponse
    {
        [JsonProperty("stocks")]
        public List<StockDetails> Stocks { get; set; }

        [JsonProperty("maxPrice")]
        public decimal? MaxPrice { get; set; }

        [JsonProperty("minPrice")]
        public decimal? MinPrice { get; set; }

        [JsonProperty("avgPrice")]
        public decimal? AvgPrice { get; set; }
    }
}
