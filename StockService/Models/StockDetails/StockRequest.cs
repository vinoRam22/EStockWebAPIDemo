using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace StockService.Models.StockDetails
{
    public class StockRequest
    {
        [JsonProperty("companyCode")]
        [Required]
        public string CompanyCode { get; set; }

        [JsonProperty("stockPrice")]
        [Required]
        public decimal StockPrice { get; set; }
    }
}
