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
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _repository;

        public CustomerService(ICustomerRepository repository)
        {
            _repository = repository;
        }

        public CustomerViewModel Add(CustomerViewModel viewModel)
        {
            try
            {
                viewModel.Id = Guid.NewGuid();
                _repository.Add(CustomerMapper.ToDbModel(viewModel));
                return viewModel;
            }
            catch (Exception e)
            {
                return new CustomerViewModel();
            };
        }

        public CustomerViewModel Update(CustomerViewModel viewModel)
        {
            try
            {
                _repository.Update(CustomerMapper.ToDbModel(viewModel));
                return viewModel;
            }
            catch (Exception e)
            {
                return new CustomerViewModel();
            }
        }
        public void Delete(Guid id)
        {
            _repository.Delete(id);
        }

        public CustomerViewModel GetCustomerById(Guid id)
        {
            var data = _repository.GetCustomerById(id);
            return data == null ? null : CustomerMapper.ToViewModel(data);
        }

        public CustomerListViewModel GetCustomerByName(string name)
        {
            var returnList = new CustomerListViewModel();
            returnList.Customers = new List<CustomerViewModel>();
            var data = _repository.GetCustomerByName(name);
            foreach (var item in data)
            {
                returnList.Customers.Add(CustomerMapper.ToViewModel(item));
            }
            return returnList;
        }

        public CustomerListViewModel GetCustomers()
        {
            var returnList = new CustomerListViewModel();
            returnList.Customers = new List<CustomerViewModel>();
            var data = _repository.GetCustomers();
            foreach (var item in data)
            {
                returnList.Customers.Add(CustomerMapper.ToViewModel(item));
            }
            return returnList;
        }

     
    }
}
