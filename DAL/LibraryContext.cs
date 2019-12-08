using DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace DAL
{
    public class LibraryContext : DbContext
    {
        private string connection;
        internal DbSet<Author> Authors { get; set; }
        internal DbSet<Book> Books { get; set; }
        internal DbSet<Category> Categories { get; set; }
        internal DbSet<LibraryCard> LibraryCards { get; set; }
        internal DbSet<LibraryCardField> LibraryCardFields { get; set; }
        internal DbSet<Student> Students  { get; set; }

        public LibraryContext(string connection)
        {
            this.connection = connection;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies()
                          .UseSqlServer(connection);
        }
    }
}
/*"Server=.\\SQLEXPRESS;Database=StudentsLibrary;Trusted_Connection=True;"*/
