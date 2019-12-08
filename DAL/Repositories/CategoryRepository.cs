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
    class CategoryRepository : RepositoryBase<Category>, ICategoryRepository
    {
        public CategoryRepository(LibraryContext libraryContext) : base(libraryContext)
        {
        }

        //public new IEnumerable<Category> FindAll()
        //{
        //    return this.LibraryContext.Set<Category>().Include(x => x.ParentCategory);
        //}
        //
        //public new IEnumerable<Category> FindByCondition(Expression<Func<Category, bool>> expression)
        //{
        //    return this.LibraryContext.Set<Category>().Include(x => x.ParentCategory).Where(expression);
        //}
    }
}
