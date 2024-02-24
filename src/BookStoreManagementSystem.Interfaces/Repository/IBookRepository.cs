using System;
using System.Collections.Generic;
using System.Text;
using BookStoreManagementSystem.Domain.Model;
using BookStoreManagementSystem.Interfaces.ViewModel;

namespace BookStoreManagementSystem.Interfaces.Repository
{
    public interface IBookRepository
    {
        List<Book> GetBook();
        Book GetBookById(Guid id);
        List<Book> GetBookByName(string name);
        void Add(Book data);

        void Delete(Guid id);

        void Update(Book data);
    }
}
