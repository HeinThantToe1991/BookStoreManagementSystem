using System;

namespace BookStoreManagementSystem.Interfaces.ViewModel
{
    public class BookViewModel
    {
        public System.Guid Id { get; set; }
        public string AuthorName { get; set; }
        public string CategoryName { get; set; }
        public string BookName { get; set; }
        public string Description { get; set; }
        public Guid AuthorId { get; set; }
        public Guid BookCategoriesId { get; set; }
    }
}
