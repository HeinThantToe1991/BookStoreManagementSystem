using System;
using System.Collections.Generic;
using System.Text;
using BookStoreManagementSystem.Domain.Model;
using BookStoreManagementSystem.Interfaces.ViewModel;

namespace BookStoreManagementSystem.Application.Mapper
{
    public static class SaleMapper
    {
        public static SaleViewModel ToViewModel(Sale model)
        {
            var book = new SaleViewModel();
            book.Id = model.Id;
            book.CustomerId= model.CustomerId;
            book.CustomerName = model.Customer.CustomerName;
            book.BookId = model.BookId;
            book.BookName = model.Book.BookName;
            book.Quantity = model.Quantity;
            book.SellingPrice = model.SellingPrice;
            book.Amount = model.Amount;
            book.Discount = model.Discount;
            return book;
        }

        public static Sale ToDbModel(SaleViewModel model)
        {
            var book = new Sale();
            book.Id = model.Id;
            book.CustomerId = model.CustomerId;
            book.BookId = model.BookId;
            book.Quantity = model.Quantity;
            book.SellingPrice = model.SellingPrice;
            book.Amount = model.Amount;
            book.Discount = model.Discount;
            return book;
        }
    }

}
