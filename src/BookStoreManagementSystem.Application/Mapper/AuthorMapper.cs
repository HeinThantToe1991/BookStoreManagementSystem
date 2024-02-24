using System;
using System.Collections.Generic;
using System.Text;
using BookStoreManagementSystem.Domain.Model;
using BookStoreManagementSystem.Interfaces.ViewModel;

namespace BookStoreManagementSystem.Application.Mapper
{
    public static class AuthorMapper
    {
        public static AuthorViewModel ToViewModel(Author model)
        {
            var data = new AuthorViewModel();
            data.Id = model.Id;
            data.Name= model.Name;
            data.Description = model.Description;
            return data;
        }

        public static Author ToDbModel(AuthorViewModel model)
        {
            var data = new Author();
            data.Id = model.Id;
            data.Name = model.Name;
            data.Description = model.Description;
            return data;
        }
    }

}
