using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreManagementSystem.Domain.Model
{
    public class BookCategories
    {
        [Key]
        public System.Guid Id { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }
    }
}
