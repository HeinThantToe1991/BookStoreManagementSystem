using Newtonsoft.Json;

namespace BookStoreManagementSystem.Interfaces.ViewModel
{
    [JsonObject("category")]
    public class BookCategoryViewModel
    {
        [JsonProperty("id")]
        public System.Guid Id { get; set; }
        [JsonProperty("categoryName")]
        public string CategoryName { get; set; }
        [JsonProperty("description")]
        public string Description { get; set; }
    }
}
