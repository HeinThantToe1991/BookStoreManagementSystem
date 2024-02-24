using System;
using System.Reflection.Metadata;
using System.Security.Cryptography.X509Certificates;
using BookStoreManagementSystem.Domain.Model;
using Microsoft.EntityFrameworkCore;


namespace UI_Layer.Data.SeedData
{
    public class ModelBuilderExtensions
    {
        public static Guid customerId = Guid.Parse("8d7fae5e-3cd5-497b-b334-86790609eedc");
        public static Guid authorId = Guid.Parse("d9cbb087-b31f-4441-8506-c21c7e0c15a4"); //Guid.Parse("");
        public static Guid BookId = Guid.Parse("3b79e7b8-9a4a-41be-883a-5853056716e9");
        public static Guid CategoryId = Guid.Parse("3b79e7b8-9a4a-41be-883a-5853056716d7");

        public static void SeedCategory(ModelBuilder builder)
        {
            BookCategories data = new BookCategories();
            data.Id = CategoryId;
            data.CategoryName = "Romance";
            data.Description = "About Romance ";
            builder.Entity<BookCategories>().HasData(data);
        }
        public static void SeedCustomer(ModelBuilder builder)
        {
            Customer data = new Customer();
            data.Id = customerId;
            data.CustomerName = "HeinThantToe";
            data.PhoneNumber = "09786779545";
            builder.Entity<Customer>().HasData(data);
        }
        public static void SeedAuthor(ModelBuilder builder)
        {
            Author data = new Author();
            data.Id = authorId;
            data.Name = "HeinThantToe-Author";
            data.Description = "Author is someone";
            builder.Entity<Author>().HasData(data);
        }

        public static void SeedBook(ModelBuilder builder)
        {
            Book data = new Book();
            data.Id = BookId;
            data.AuthorId = authorId;
            data.Description = "Rule Of Romance";
            data.BookCategoriesId = CategoryId;
            data.BookName = "Romeo & Juliet";
          
            builder.Entity<Book>().HasData(data);
        }
    }
}
