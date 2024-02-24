using System;
using System.Collections.Generic;
using System.Text;
using BookStoreManagementSystem.Domain.Model;
using BookStoreManagementSystem.Interfaces.ViewModel;

namespace BookStoreManagementSystem.Application.Mapper
{
    public static class BookMapper
    {
        public static BookViewModel ToViewModel(Book model)
        {
            var book = new BookViewModel();
            book.Id = model.Id;
            book.BookCategoriesId= model.BookCategoriesId;
            book.BookName = model.BookName;
            book.Description = model.Description;
            book.AuthorId = model.AuthorId;
            book.AuthorName = model.Author.Name;
            book.CategoryName = model.BookCategories.CategoryName;
            return book;
        }

        public static Book ToDbModel(BookViewModel model)
        {
            var book = new Book();
            book.Id = model.Id;
            book.BookCategoriesId = model.BookCategoriesId;
            book.BookName = model.BookName;
            book.Description = model.Description;
            book.AuthorId = model.AuthorId;
            return book;
        }
    }

}
