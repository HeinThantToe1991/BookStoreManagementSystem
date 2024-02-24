using System;
using System.Collections.Generic;
using System.Text;
using BookStoreManagementSystem.Domain.Model;
using BookStoreManagementSystem.Interfaces.ViewModel;

namespace BookStoreManagementSystem.Application.Mapper
{
    public static class CustomerMapper
    {
        public static CustomerViewModel ToViewModel(Customer model)
        {
            var data = new CustomerViewModel();
            data.Id = model.Id;
            data.CustomerName= model.CustomerName;
            data.PhoneNumber = model.PhoneNumber;
            return data;
        }

        public static Customer ToDbModel(CustomerViewModel model)
        {
            var data = new Customer();
            data.Id = model.Id;
            data.CustomerName = model.CustomerName;
            data.PhoneNumber = model.PhoneNumber;
            return data;
        }
    }

}
