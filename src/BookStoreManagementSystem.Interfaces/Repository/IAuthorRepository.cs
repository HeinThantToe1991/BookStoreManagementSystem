using System;
using System.Collections.Generic;
using System.Text;
using BookStoreManagementSystem.Domain.Model;

namespace BookStoreManagementSystem.Interfaces.Repository
{
    public interface IAuthorRepository
    {
        void Add(Author data);

        void Delete(Guid id);

        void Update(Author data);

        List<Author> GetAuthor();
        Author GetAuthorById(Guid id);
        List<Author> GetAuthorByName(string name);
    }
}
