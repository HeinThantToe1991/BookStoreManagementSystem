using System;
using System.Collections.Generic;
using System.Text;
using BookStoreManagementSystem.Domain.Model;
using BookStoreManagementSystem.Interfaces;
using BookStoreManagementSystem.Interfaces.Repository;
using BookStoreManagementSystem.Interfaces.ViewModel;

namespace BookStoreManagementSystem.Application.Services
{
    public class SaleService : ISaleService
    {
        private readonly ISaleRepository _repository;

        public SaleService(ISaleRepository repository)
        {
            _repository = repository;
        }

        public SaleViewModel Add(SaleViewModel viewModel)
        {
            throw new NotImplementedException();
        }

        public void Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public SaleViewModel GetSaleByCustomerId(Guid customerId)
        {
            throw new NotImplementedException();
        }

        public SaleViewModel GetSaleByDate(DateTime invoiceDate)
        {
            throw new NotImplementedException();
        }

        public SaleViewModel GetSaleById(Guid id)
        {
            throw new NotImplementedException();
        }

        public SaleViewModel GetSaleByInvoiceNo(string invoiceNo)
        {
            throw new NotImplementedException();
        }

        public SaleListViewModel GetSales()
        {
            throw new NotImplementedException();
        }

        public SaleViewModel Update(SaleViewModel viewModel)
        {
            throw new NotImplementedException();
        }
    }
}
