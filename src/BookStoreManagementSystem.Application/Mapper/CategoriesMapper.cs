using System;
using System.Collections.Generic;
using System.Text;
using BookStoreManagementSystem.Domain.Model;
using BookStoreManagementSystem.Interfaces.ViewModel;

namespace BookStoreManagementSystem.Application.Mapper
{
    public static class CategoriesMapper 
    {
        public static BookCategoryViewModel ToViewModel(BookCategories model)
        {
            var book = new BookCategoryViewModel();
            book.Id = model.Id;
            book.CategoryName= model.CategoryName;
            book.Description = model.Description;
            return book;
        }

        public static BookCategories ToDbModel(BookCategoryViewModel model)
        {
            var book = new BookCategories();
            book.Id = model.Id;
            book.CategoryName = model.CategoryName;
            book.Description = model.Description;
            return book;
        }
    }

}
