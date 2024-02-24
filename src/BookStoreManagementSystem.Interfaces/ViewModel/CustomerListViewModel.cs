using Newtonsoft.Json;
using System.Collections.Generic;

namespace BookStoreManagementSystem.Interfaces.ViewModel
{
   
    public class CustomerListViewModel
    {
        [JsonProperty("customer")]
        public List<CustomerViewModel> Customers;
    }
}
