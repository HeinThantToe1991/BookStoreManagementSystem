using Newtonsoft.Json;
using System.Collections.Generic;

namespace BookStoreManagementSystem.Interfaces.ViewModel
{
   
    public class BookListViewModel
    {
        [JsonProperty("book")]
        public List<BookViewModel> Books;
    }
}
