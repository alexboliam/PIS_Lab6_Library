using DAL.Interfaces;
using DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DAL.Repositories
{
    class LibraryCardFieldRepository : RepositoryBase<LibraryCardField>, ILibraryCardFieldRepository
    {
        public LibraryCardFieldRepository(LibraryContext libraryContext) : base(libraryContext)
        {
        }

        //public new IEnumerable<LibraryCardField> FindAll()
        //{
        //    return this.LibraryContext.Set<LibraryCardField>().Include(x => x.Book).Include(x => x.LibraryCard);
        //}
        //
        //public new IEnumerable<LibraryCardField> FindByCondition(Expression<Func<LibraryCardField, bool>> expression)
        //{
        //    return this.LibraryContext.Set<LibraryCardField>().Include(x => x.Book).Include(x => x.LibraryCard).Where(expression);
        //}
    }
}

