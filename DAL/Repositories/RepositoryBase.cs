using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DAL.Repositories
{
    abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected internal LibraryContext LibraryContext { get; }

        public RepositoryBase(LibraryContext context)
        {
            this.LibraryContext = context;
        }

        public void Create(T entity)
        {
            this.LibraryContext.Set<T>().Add(entity);
        }
        public void Delete(T entity)
        {
            this.LibraryContext.Set<T>().Remove(entity);
        }
        public IEnumerable<T> FindAll()
        {
            return this.LibraryContext.Set<T>();
        }
        public IEnumerable<T> FindByCondition(Expression<Func<T, bool>> expression)
        {
            return this.LibraryContext.Set<T>().Where(expression);
        }
        public void Update(T entity)
        {
            this.LibraryContext.Set<T>().Update(entity);
        }
    }
}
