using System;
using System.Collections.Generic;
using System.Text;
using BookStoreManagementSystem.Domain.Model;
using BookStoreManagementSystem.Interfaces;
using BookStoreManagementSystem.Interfaces.Repository;
using BookStoreManagementSystem.Interfaces.ViewModel;

namespace BookStoreManagementSystem.Application.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _repository;

        public BookService(IBookRepository repository)
        {
            _repository = repository;
        }

        public BookViewModel Add(BookViewModel viewModel)
        {
            throw new NotImplementedException();
        }

        public void Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public BookListViewModel GetBook()
        {
            throw new NotImplementedException();
        }

        public BookViewModel GetBookById(Guid id)
        {
            throw new NotImplementedException();
        }

        public BookViewModel GetBookByName(string name)
        {
            throw new NotImplementedException();
        }

        public BookViewModel Update(BookViewModel viewModel)
        {
            throw new NotImplementedException();
        }
    }
}
