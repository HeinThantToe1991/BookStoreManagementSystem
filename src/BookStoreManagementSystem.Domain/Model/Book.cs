using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreManagementSystem.Domain.Model
{
    public class Book
    {
        [Key]
        public System.Guid Id { get; set; }
        public string BookName { get; set; }
        public string Description { get; set; }

        public decimal SellingPrice { get; set; }
        public Guid AuthorId { get; set; }
        public virtual Author Author { get; set; }

        public Guid BookCategoriesId { get; set; }
        public virtual BookCategories BookCategories { get; set; }
    }
}
