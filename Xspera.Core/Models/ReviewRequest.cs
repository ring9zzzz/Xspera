
namespace Xspera.Core.Models
{
    using Newtonsoft.Json;

    public class ReviewRequest
    {
        [JsonProperty("productId")]
        public int ProductId { get; set; }
        [JsonProperty("email")]
        public string Email { get; set; }
        [JsonProperty("rating")]
        public int Rating { get; set; }
        [JsonProperty("comment")]
        public string Comment { get; set; }
    }
}