using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.IO;
using BookStoreManagementSystem.Domain.Model;
using UI_Layer.Data.SeedData;

namespace BookStoreManagementSystem.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<BookCategories> BookCategories { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Sale> Sales { get; set; }
        public DbSet<Customer> Customers { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
           #region SeedData
            ModelBuilderExtensions.SeedAuthor(modelBuilder);
            ModelBuilderExtensions.SeedCategory(modelBuilder);
            ModelBuilderExtensions.SeedCustomer(modelBuilder);
            ModelBuilderExtensions.SeedBook(modelBuilder);
            #endregion
        }

    }
}
