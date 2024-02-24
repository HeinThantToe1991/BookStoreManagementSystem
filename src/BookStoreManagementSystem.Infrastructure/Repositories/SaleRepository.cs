using BookStoreManagementSystem.Domain.Model;
using BookStoreManagementSystem.Infrastructure.Data;
using BookStoreManagementSystem.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BookStoreManagementSystem.Infrastructure.Repositories
{
    public class SaleRepository : ISaleRepository
    {
        private readonly ApplicationDbContext _context;

        public SaleRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Sale> GetSales()
        {
            return _context.Sales.ToList();
        }

        public Sale GetSaleById(Guid id)
        {
            return _context.Sales.FirstOrDefault(s => s.Id == id);
        }

        public List<Sale> GetSaleByDate(DateTime invoiceDate)
        {
            return _context.Sales.Where(s => s.InvoiceDate == invoiceDate).ToList();
        }

        public Sale GetSaleByCustomerId(Guid customerId)
        {
            return _context.Sales.FirstOrDefault(s => s.CustomerId == customerId);
        }

        public Sale GetSaleByInvoiceNo(string invoiceNo)
        {
            return _context.Sales.FirstOrDefault(s => s.InvoiceNumber == invoiceNo);
        }


        public void Add(Sale data)
        {
            _context.Sales.Add(data);
            _context.SaveChanges();
        }
        public void Update(Sale data)
        {
            var existingEntity = _context.Sales.Find(data.Id);
            if (existingEntity != null)
            {
                // Detach the existing entity from the context
                _context.Entry(existingEntity).State = EntityState.Detached;
            }

            _context.Entry(data).State = EntityState.Modified;
            _context.SaveChanges();
        }
        public void Delete(Guid id)
        {
            var data = _context.Sales.FirstOrDefault(s => s.Id == id);
            if (data != null)
            {
                _context.Sales.Remove(data);
                _context.SaveChanges();
            }
        }
    }
}
