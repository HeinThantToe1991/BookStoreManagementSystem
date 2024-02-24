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
    public class BookCategoryRepository : IBookCategoryRepository
    {
        private readonly ApplicationDbContext _context;

        public BookCategoryRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<BookCategories> GetBookCategories()
        {
            return _context.BookCategories.ToList();
        }

        public BookCategories GetBookCategoryById(Guid id)
        {
            return _context.BookCategories.FirstOrDefault(s=>s.Id == id);
        }

        public BookCategories GetBookCategoryByName(string name)
        {
            return _context.BookCategories.FirstOrDefault(s => s.CategoryName == name);
        }

        public void Add(BookCategories data)
        {
            _context.BookCategories.Add(data);
            _context.SaveChanges();
        }
        public void Update(BookCategories data)
        {
            var existingEntity = _context.BookCategories.Find(data.Id);
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
            var category = _context.BookCategories.FirstOrDefault(s => s.Id == id);
            if (category != null)
            {
                _context.BookCategories.Remove(category);
                _context.SaveChanges();
            }
        }
    }
}
