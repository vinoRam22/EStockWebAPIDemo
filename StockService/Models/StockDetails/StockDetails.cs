using Newtonsoft.Json;

namespace StockService.Models.StockDetails
{
    public class StockDetails
    {
        [JsonProperty("companyCode")]
        public string CompanyCode { get; set; }

        [JsonProperty("stockPrice")]
        public decimal StockPrice { get; set; }

        [JsonProperty("stockDate")]
        public string StockDate { get; set; }

        [JsonProperty("stockTime")]
        public string StockTime { get; set; }

    }
}
