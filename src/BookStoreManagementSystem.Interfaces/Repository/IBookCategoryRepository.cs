using System;
using System.Collections.Generic;
using System.Text;
using BookStoreManagementSystem.Domain.Model;
using BookStoreManagementSystem.Interfaces.ViewModel;

namespace BookStoreManagementSystem.Interfaces.Repository
{
    public interface IBookCategoryRepository
    {
        List<BookCategories> GetBookCategories();

        BookCategories GetBookCategoryById(Guid id);

        BookCategories GetBookCategoryByName(string name);

       
        void Add(BookCategories data);

        void Delete(Guid id);

        void Update(BookCategories viewModel);
    }
}
