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
    public class AuthorRepository : IAuthorRepository
    {
        private readonly ApplicationDbContext _context;

        public AuthorRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Author> GetAuthors()
        {
            return _context.Authors.ToList();
        }

        public Author GetAuthorById(Guid id)
        {
            return _context.Authors.FirstOrDefault(s=>s.Id == id);
        }

        public List<Author> GetAuthorByName(string name)
        {
            return _context.Authors.Where(s => s.Name.Contains(name)).ToList();
        }

        public void Add(Author data)
        {
            _context.Authors.Add(data);
            _context.SaveChanges();
        }
        public void Update(Author data)
        {
            var existingEntity = _context.Authors.Find(data.Id);
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
            var data = _context.Authors.FirstOrDefault(s => s.Id == id);
            if (data != null)
            {
                _context.Authors.Remove(data);
                _context.SaveChanges();
            }
        }

        public List<Author> GetAuthor()
        {
            return _context.Authors.ToList();
        }
    }
}
