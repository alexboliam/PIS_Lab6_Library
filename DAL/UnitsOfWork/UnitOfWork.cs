using DAL.Interfaces;
using DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.UnitsOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private LibraryContext libraryContext;
        private IAuthorRepository author;
        private IBookRepository books;
        private ICategoryRepository categories;
        private ILibraryCardRepository libraryCards;
        private ILibraryCardFieldRepository libraryCardFields;
        private IStudentRepository students;

        public UnitOfWork(string connection)
        {
            this.libraryContext = new LibraryContext(connection);
        }
        public void Save()
        {
            this.libraryContext.SaveChanges();
        }
        public IAuthorRepository Authors
        {
            get
            {
                if (author == null)
                {
                    author = new AuthorRepository(libraryContext);
                }
                return author;
            }
        }
        public IBookRepository Books
        {
            get
            {
                if (books == null)
                {
                    books = new BookRepository(libraryContext);
                }
                return books;
            }
        }
        public ICategoryRepository Category
        {
            get
            {
                if (categories == null)
                {
                    categories = new CategoryRepository(libraryContext);
                }
                return categories;
            }
        }
        public ILibraryCardRepository LibraryCards
        {
            get
            {
                if (libraryCards == null)
                {
                    libraryCards = new LibraryCardRepository(libraryContext);
                }
                return libraryCards;
            }
        }
        public ILibraryCardFieldRepository LibraryCardFields
        {
            get
            {
                if (libraryCardFields == null)
                {
                    libraryCardFields = new LibraryCardFieldRepository(libraryContext);
                }
                return libraryCardFields;
            }
        }
        public IStudentRepository Students
        {
            get
            {
                if (students == null)
                {
                    students = new StudentRepository(libraryContext);
                }
                return students;
            }
        }


    }
}
