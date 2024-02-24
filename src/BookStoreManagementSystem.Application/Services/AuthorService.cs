using System;
using System.Collections.Generic;
using System.Text;
using BookStoreManagementSystem.Domain.Model;
using BookStoreManagementSystem.Interfaces;
using BookStoreManagementSystem.Interfaces.Repository;
using BookStoreManagementSystem.Interfaces.ViewModel;

namespace BookStoreManagementSystem.Application.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly IAuthorRepository _repository;

        public AuthorService(IAuthorRepository repository)
        {
            _repository = repository;
        }

        public AuthorViewModel Add(AuthorViewModel viewModel)
        {
            throw new NotImplementedException();
        }

        public void Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public AuthorViewModel GetAuthorById(Guid id)
        {
            throw new NotImplementedException();
        }

        public AuthorViewModel GetAuthorByName(string name)
        {
            throw new NotImplementedException();
        }

        public AuthorViewModel Update(AuthorViewModel viewModel)
        {
            throw new NotImplementedException();
        }
    }
}
