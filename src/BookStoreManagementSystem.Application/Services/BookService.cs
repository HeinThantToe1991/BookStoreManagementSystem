using System;
using System.Collections.Generic;
using System.Text;
using BookStoreManagementSystem.Application.Mapper;
using System.Xml.Linq;
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
            try
            {
                viewModel.Id = Guid.NewGuid();
                _repository.Add(BookMapper.ToDbModel(viewModel));
                return viewModel;
            }
            catch (Exception e)
            {
                return new BookViewModel();
            }
        }

        public void Delete(Guid id)
        {
            _repository.Delete(id);
        }

        public BookListViewModel GetBook()
        {
            var returnList = new BookListViewModel();
            returnList.Books = new List<BookViewModel>();
            var data = _repository.GetBook();
            foreach (var item in data)
            {
                returnList.Books.Add(BookMapper.ToViewModel(item));
            }
            return returnList;
        }

        public BookViewModel GetBookById(Guid id)
        {
            var data = _repository.GetBookById(id);
            return data == null ? null : BookMapper.ToViewModel(data);
        }

        public BookListViewModel GetBookByName(string name)
        {
            var returnList = new BookListViewModel();
            returnList.Books = new List<BookViewModel>();
            var data = _repository.GetBookByName(name);
            foreach (var item in data)
            {
                returnList.Books.Add(BookMapper.ToViewModel(item));
            }
            return returnList;
        }

        public BookViewModel Update(BookViewModel viewModel)
        {

            try
            {
                _repository.Update(BookMapper.ToDbModel(viewModel));
                return viewModel;
            }
            catch (Exception e)
            {
                return new BookViewModel();
            }
        }
    }
}
