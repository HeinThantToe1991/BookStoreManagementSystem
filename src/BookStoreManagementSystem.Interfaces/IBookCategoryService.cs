using System;
using System.Collections.Generic;
using BookStoreManagementSystem.Domain;
using BookStoreManagementSystem.Domain.Model;
using BookStoreManagementSystem.Interfaces.ViewModel;

namespace BookStoreManagementSystem.Interfaces
{
    public interface IBookCategoryService
    {
        BookCategoryListViewModel GetBookCategories();
        BookCategoryViewModel GetBookCategoryById(Guid id);
        BookCategoryViewModel GetBookCategoryByName(string name);
        BookCategoryViewModel Add(BookCategoryViewModel viewModel);

        void Delete(Guid id);
        BookCategoryViewModel Update(BookCategoryViewModel viewModel);
    }
}
