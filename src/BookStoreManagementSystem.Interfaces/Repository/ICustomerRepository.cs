using System;
using System.Collections.Generic;
using System.Text;
using BookStoreManagementSystem.Domain.Model;

namespace BookStoreManagementSystem.Interfaces.Repository
{
    public interface ICustomerRepository
    {
        void Add(Customer data);

        void Delete(Guid id);

        void Update(Customer data);
    }
}
