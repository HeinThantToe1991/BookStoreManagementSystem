using Newtonsoft.Json;
using System.Collections.Generic;

namespace BookStoreManagementSystem.Interfaces.ViewModel
{
   
    public class SaleListViewModel
    {
        [JsonProperty("sale")]
        public List<SaleViewModel> Books;
    }
}
