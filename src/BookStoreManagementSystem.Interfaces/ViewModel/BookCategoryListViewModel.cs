using Newtonsoft.Json;
using System.Collections.Generic;

namespace BookStoreManagementSystem.Interfaces.ViewModel
{
   
    public class BookCategoryListViewModel
    {
        [JsonProperty("category")]
        public List<BookCategoryViewModel> Categories;
    }
}
