using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreManagementSystem.Domain.Model
{
    public class Customer
    {
        [Key]
        public System.Guid Id { get; set; }
        public string CustomerName { get; set; }
        public string PhoneNumber { get; set; }
    }
}
