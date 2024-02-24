using System;
using System.Collections.Generic;
using System.Text;
using BookStoreManagementSystem.Domain.Model;

namespace BookStoreManagementSystem.Interfaces.Repository
{
    public interface ICustomerRepository
    {
        List<Customer> GetCustomers();
        Customer GetCustomerById(Guid id);
        List<Customer> GetCustomerByName(string name);
        void Add(Customer data);

        void Delete(Guid id);

        void Update(Customer data);
    }
}
