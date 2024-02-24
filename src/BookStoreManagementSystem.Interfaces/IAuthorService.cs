using System;
using System.Collections.Generic;
using BookStoreManagementSystem.Domain;
using BookStoreManagementSystem.Domain.Model;
using BookStoreManagementSystem.Interfaces.ViewModel;

namespace BookStoreManagementSystem.Interfaces
{
    public interface IAuthorService
    {
        AuthorListViewModel GetAuthor();
        AuthorViewModel GetAuthorById(Guid id);
        AuthorListViewModel GetAuthorByName(string name);
        AuthorViewModel Add(AuthorViewModel viewModel);

        void Delete(Guid id);
        AuthorViewModel Update(AuthorViewModel viewModel);
    }
}
