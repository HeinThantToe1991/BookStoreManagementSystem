using BookStoreManagementSystem.Domain.Model;
using System;

namespace BookStoreManagementSystem.Interfaces.ViewModel
{
    public class SaleViewModel
    {
        public System.Guid Id { get; set; }
        public string InvoiceNumber { get; set; }
        public DateTime InvoiceDate { get; set; }
        public Guid BookId { get; set; }
        public string CustomerName { get; set; }
        public int Quantity { get; set; }
        public int Discount { get; set; }
        public int Amount { get; set; }
    }
}
