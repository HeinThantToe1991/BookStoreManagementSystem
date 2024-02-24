using System;
using System.Collections.Generic;
using BookStoreManagementSystem.Domain;
using BookStoreManagementSystem.Domain.Model;
using BookStoreManagementSystem.Interfaces.ViewModel;

namespace BookStoreManagementSystem.Interfaces
{
    public interface ICustomerService
    {
        CustomerListViewModel GetCustomers();
        CustomerViewModel GetCustomerById(Guid id);
        CustomerListViewModel GetCustomerByName(string name);
        CustomerViewModel Add(CustomerViewModel viewModel);

        void Delete(Guid id);
        CustomerViewModel Update(CustomerViewModel viewModel);
    }
}
