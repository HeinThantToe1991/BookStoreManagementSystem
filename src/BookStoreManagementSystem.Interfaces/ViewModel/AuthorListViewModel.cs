using Newtonsoft.Json;
using System.Collections.Generic;

namespace BookStoreManagementSystem.Interfaces.ViewModel
{
   
    public class AuthorListViewModel
    {
        [JsonProperty("author")]
        public List<AuthorViewModel> Authors;
    }
}
