using DAL.Interfaces;
using DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace DAL.Repositories
{
    class AuthorRepository : RepositoryBase<Author>, IAuthorRepository
    {
        public AuthorRepository(LibraryContext libraryContext) : base(libraryContext)
        {
        }

        //public new IEnumerable<Author> FindAll()
        //{
        //    return this.LibraryContext.Set<Author>().Include(x => x.Books);
        //}
        //
        //public new IEnumerable<Author> FindByCondition(Expression<Func<Author, bool>> expression)
        //{
        //    return this.LibraryContext.Set<Author>().Include(x => x.Books).Where(expression);
        //}
    }
}
