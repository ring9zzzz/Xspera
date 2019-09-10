

namespace Xspera.Core.Models
{
    using Newtonsoft.Json;
    public class ProductRequest
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("brandId")]
        public int BrandId { get; set; }

        [JsonProperty("userId")]
        public int UserId { get; set; }

        [JsonProperty("price")]
        public decimal Price { get; set; }

        [JsonProperty("color")]
        public string Color { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("availableStatus")]
        public int AvailableStatus { get; set; }
    }
}