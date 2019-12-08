using DAL.Interfaces;
using DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace DAL.Repositories
{
    class BookRepository : RepositoryBase<Book>, IBookRepository
    {
        public BookRepository(LibraryContext libraryContext) : base(libraryContext)
        {
        }

        //public new IEnumerable<Book> FindAll()
        //{
        //    return this.LibraryContext.Set<Book>().Include(x => x.Category).Include(x => x.Author);
        //}
        //
        //public new IEnumerable<Book> FindByCondition(Expression<Func<Book, bool>> expression)
        //{
        //    return this.LibraryContext.Set<Book>().Include(x => x.Category).Include(x => x.Author).Where(expression);
        //}
    }
}
