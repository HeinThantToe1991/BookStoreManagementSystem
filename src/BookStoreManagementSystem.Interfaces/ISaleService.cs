using System;
using System.Collections.Generic;
using BookStoreManagementSystem.Domain;
using BookStoreManagementSystem.Domain.Model;
using BookStoreManagementSystem.Interfaces.ViewModel;

namespace BookStoreManagementSystem.Interfaces
{
    public interface ISaleService
    {
        SaleListViewModel GetSales();
        SaleViewModel GetSaleById(Guid id);
        SaleListViewModel GetSaleByDate(DateTime invoiceDate);
        SaleViewModel GetSaleByCustomerId(Guid customerId);
        SaleViewModel GetSaleByInvoiceNo(string invoiceNo);
        SaleViewModel Add(SaleViewModel viewModel);

        void Delete(Guid id);
        SaleViewModel Update(SaleViewModel viewModel);

        SaleViewModel CalculateAmount(SaleViewModel viewModel);
    }
}
