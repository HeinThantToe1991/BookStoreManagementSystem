using System;
using System.Collections.Generic;
using BookStoreManagementSystem.Domain;
using BookStoreManagementSystem.Domain.Model;
using BookStoreManagementSystem.Interfaces.ViewModel;

namespace BookStoreManagementSystem.Interfaces
{
    public interface IBookService
    {
        BookListViewModel GetBook();
        BookViewModel GetBookById(Guid id);
        BookListViewModel GetBookByName(string name);
        BookViewModel Add(BookViewModel viewModel);

        void Delete(Guid id);
        BookViewModel Update(BookViewModel viewModel);
    }
}
