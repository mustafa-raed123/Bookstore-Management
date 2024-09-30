using Bookstore_Management.Models.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Bookstore_Management.Models.Data
{
    public class BookDbContext : DbContext
    {
        public DbSet<Book> book {  get; set; }
        public BookDbContext(DbContextOptions<BookDbContext> options ) : base( options ) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            

        }
    }
}
