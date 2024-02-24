using System;
using System.Collections.Generic;
using System.Linq;
using BookStoreManagementSystem.Domain.Model;
using BookStoreManagementSystem.Infrastructure.Data;
using BookStoreManagementSystem.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;

namespace BookStoreManagementSystem.Infrastructure.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly ApplicationDbContext _context;

        public CustomerRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Customer> GetCustomers()
        {
            return _context.Customers.ToList();
        }

        public Customer GetCustomerById(Guid id)
        {
            return _context.Customers.FirstOrDefault(s => s.Id == id);
        }

        public List<Customer> GetCustomerByName(string name)
        {
            return _context.Customers.Where(w=>w.CustomerName.Contains(name)).ToList();
        }

        public void Add(Customer data)
        {
            _context.Customers.Add(data);
            _context.SaveChanges();
        }
        public void Update(Customer data)
        {
            var existingEntity = _context.Customers.Find(data.Id);
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
            var data = _context.Customers.FirstOrDefault(s => s.Id == id);
            if (data != null)
            {
                _context.Customers.Remove(data);
                _context.SaveChanges();
            }
        }
    }
}
