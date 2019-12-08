using DAL.Interfaces;
using DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace DAL.Repositories
{
    class LibraryCardRepository : RepositoryBase<LibraryCard>, ILibraryCardRepository
    {
        public LibraryCardRepository(LibraryContext libraryContext) : base(libraryContext)
        {
        }

        //public new IEnumerable<LibraryCard> FindAll()
        //{
        //    return this.LibraryContext.Set<LibraryCard>().Include(x => x.Fields).Include(x=>x.Student);
        //}
        //
        //public new IEnumerable<LibraryCard> FindByCondition(Expression<Func<LibraryCard, bool>> expression)
        //{
        //    return this.LibraryContext.Set<LibraryCard>().Include(x => x.Fields).Include(x => x.Student).Where(expression);
        //}
    }
}
