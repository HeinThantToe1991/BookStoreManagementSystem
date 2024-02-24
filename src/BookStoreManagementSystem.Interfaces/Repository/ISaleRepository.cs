using System;
using System.Collections.Generic;
using System.Text;
using BookStoreManagementSystem.Domain.Model;
using BookStoreManagementSystem.Interfaces.ViewModel;

namespace BookStoreManagementSystem.Interfaces.Repository
{
    public interface ISaleRepository
    {
        void Add(Sale data);

        void Delete(Guid id);

        void Update(Sale data);
        List<Sale> GetSales();
        Sale GetSaleById(Guid id);
        List<Sale> GetSaleByDate(DateTime invoiceDate);
        Sale GetSaleByCustomerId(Guid customerId);
        Sale GetSaleByInvoiceNo(string invoiceNo);
    }
}
