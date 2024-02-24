using System;
using System.Collections.Generic;
using BookStoreManagementSystem.Domain;
using BookStoreManagementSystem.Domain.Model;
using BookStoreManagementSystem.Interfaces.ViewModel;

namespace BookStoreManagementSystem.Interfaces
{
    public interface IAuthorService
    {
        AuthorViewModel GetAuthorById(Guid id);
        AuthorViewModel GetAuthorByName(string name);
        AuthorViewModel Add(AuthorViewModel viewModel);

        void Delete(Guid id);
        AuthorViewModel Update(AuthorViewModel viewModel);
    }
}
