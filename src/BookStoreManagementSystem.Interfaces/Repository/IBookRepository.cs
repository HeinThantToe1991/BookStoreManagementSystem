using System;
using System.Collections.Generic;
using System.Text;
using BookStoreManagementSystem.Domain.Model;

namespace BookStoreManagementSystem.Interfaces.Repository
{
    public interface IBookRepository
    {
        void Add(Book data);

        void Delete(Guid id);

        void Update(Book data);
    }
}
