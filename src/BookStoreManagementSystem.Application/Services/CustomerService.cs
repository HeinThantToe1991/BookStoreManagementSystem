using System;
using System.Collections.Generic;
using System.Text;
using BookStoreManagementSystem.Domain.Model;
using BookStoreManagementSystem.Interfaces;
using BookStoreManagementSystem.Interfaces.Repository;
using BookStoreManagementSystem.Interfaces.ViewModel;

namespace BookStoreManagementSystem.Application.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _repository;

        public CustomerService(ICustomerRepository repository)
        {
            _repository = repository;
        }

        public CustomerViewModel Add(CustomerViewModel viewModel)
        {
            throw new NotImplementedException();
        }

        public CustomerViewModel Update(CustomerViewModel viewModel)
        {
            throw new NotImplementedException();
        }
        public void Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public CustomerViewModel GetCustomerById(Guid id)
        {
            throw new NotImplementedException();
        }

        public CustomerViewModel GetCustomerByName(string name)
        {
            throw new NotImplementedException();
        }

        public CustomerListViewModel GetCustomers()
        {
            throw new NotImplementedException();
        }

     
    }
}
