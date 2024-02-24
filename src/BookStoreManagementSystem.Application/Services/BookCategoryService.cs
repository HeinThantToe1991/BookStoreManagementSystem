using System;
using System.Collections;
using System.Collections.Generic;
using BookStoreManagementSystem.Application.Mapper;
using BookStoreManagementSystem.Domain.Model;
using BookStoreManagementSystem.Interfaces;
using BookStoreManagementSystem.Interfaces.Repository;
using BookStoreManagementSystem.Interfaces.ViewModel;

namespace BookStoreManagementSystem.Application.Services
{
    public class BookCategoryService : IBookCategoryService
    {
        private readonly IBookCategoryRepository _bookCategoryRepository;

        public BookCategoryService(IBookCategoryRepository bookCategoryRepository)
        {
            _bookCategoryRepository = bookCategoryRepository;
        }

        public BookCategoryListViewModel GetBookCategories()
        {
            var returnList =new BookCategoryListViewModel();
            returnList.Categories = new List<BookCategoryViewModel>();
            var data = _bookCategoryRepository.GetBookCategories();
            foreach (var item in data)
            {
                returnList.Categories.Add(CategoriesMapper.ToViewModel(item));
            }
            return returnList;
        }

        public BookCategoryViewModel GetBookCategoryById(Guid id)
        {
            var data = _bookCategoryRepository.GetBookCategoryById(id);
            return data == null ? null : CategoriesMapper.ToViewModel(data);
        }

        public BookCategoryViewModel GetBookCategoryByName(string name)
        {
            var data = _bookCategoryRepository.GetBookCategoryByName(name);
            return data == null ? null : CategoriesMapper.ToViewModel(data);
        }

        public BookCategoryViewModel Add(BookCategoryViewModel viewModel)
        {
            try
            {
                viewModel.Id = Guid.NewGuid();
                _bookCategoryRepository.Add(CategoriesMapper.ToDbModel(viewModel));
                return viewModel;
            }
            catch (Exception e)
            {
                return new BookCategoryViewModel();
            }
        
        }

        public void Delete(Guid Id)
        {
            _bookCategoryRepository.Delete(Id);
        }

        public BookCategoryViewModel Update(BookCategoryViewModel viewModel)
        {
            try
            {
                _bookCategoryRepository.Update(CategoriesMapper.ToDbModel(viewModel));
                return viewModel;
            }
            catch (Exception e)
            {
                return new BookCategoryViewModel();
            }

        }


    }
}
