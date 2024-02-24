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
    public class BookRepository : IBookRepository
    {
        private readonly ApplicationDbContext _context;

        public BookRepository(ApplicationDbContext context)
        {
            _context = context;
        }


        public List<Book> GetBooks()
        {
            return _context.Books.ToList();
        }

        public Book GetBookById(Guid id)
        {
            return _context.Books.FirstOrDefault(s => s.Id == id);
        }

        public Book GetBookByName(string name)
        {
            return _context.Books.FirstOrDefault(s => s.BookName == name);
        }

        public void Add(Book data)
        {
            _context.Books.Add(data);
            _context.SaveChanges();
        }
        public void Update(Book data)
        {
            var existingEntity = _context.Books.Find(data.Id);
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
            var data = _context.Books.FirstOrDefault(s => s.Id == id);
            if (data != null)
            {
                _context.Books.Remove(data);
                _context.SaveChanges();
            }
        }
    }
}
