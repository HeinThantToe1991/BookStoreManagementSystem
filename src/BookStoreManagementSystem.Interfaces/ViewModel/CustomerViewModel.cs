using Newtonsoft.Json;
using System.Collections.Generic;

namespace BookStoreManagementSystem.Interfaces.ViewModel
{
   
    public class CustomerViewModel
    {
        [JsonProperty("customer")]
        public System.Guid Id { get; set; }
        public string CustomerName { get; set; }
        public string PhoneNumber { get; set; }
    }
}
