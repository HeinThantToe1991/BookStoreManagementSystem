using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;
using BookStoreManagementSystem.Application.Mapper;
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
            try
            {
                viewModel.Id = Guid.NewGuid();
                _repository.Add(AuthorMapper.ToDbModel(viewModel));
                return viewModel;
            }
            catch (Exception e)
            {
                return new AuthorViewModel();
            };
        }

        public void Delete(Guid id)
        {
            _repository.Delete(id);
        }

        public AuthorViewModel GetAuthorById(Guid id)
        {
            var data = _repository.GetAuthorById(id);
            return data == null ? null : AuthorMapper.ToViewModel(data);
        }
        public AuthorListViewModel GetAuthor()
        {
            var returnList = new AuthorListViewModel();
            returnList.Authors = new List<AuthorViewModel>();
            var data = _repository.GetAuthor();
            foreach (var item in data)
            {
                returnList.Authors.Add(AuthorMapper.ToViewModel(item));
            }
            return returnList;
        }
        public AuthorListViewModel GetAuthorByName(string name)
        {
            var returnList = new AuthorListViewModel();
            returnList.Authors = new List<AuthorViewModel>();
            var data = _repository.GetAuthorByName(name);
            foreach (var item in data)
            {
                returnList.Authors.Add(AuthorMapper.ToViewModel(item));
            }
            return returnList;
        }

        public AuthorViewModel Update(AuthorViewModel viewModel)
        {
            try
            {
                _repository.Update(AuthorMapper.ToDbModel(viewModel));
                return viewModel;
            }
            catch (Exception e)
            {
                return new AuthorViewModel();
            }
        }
    }
}
