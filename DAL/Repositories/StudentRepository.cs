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
    class StudentRepository : RepositoryBase<Student>, IStudentRepository
    {
        public StudentRepository(LibraryContext libraryContext) : base(libraryContext)
        {
        }

        //public new IEnumerable<Student> FindAll()
        //{
        //    return this.LibraryContext.Set<Student>().Include(x => x.LibraryCard)
        //        .ThenInclude(x=>x.Fields)
        //        .ThenInclude(y=>y.Book);
        //}
        //
        //public new IEnumerable<Student> FindByCondition(Expression<Func<Student, bool>> expression)
        //{
        //    return this.LibraryContext.Set<Student>().Include(x => x.LibraryCard)
        //        .ThenInclude(x => x.Fields)
        //        .ThenInclude(y => y.Book)
        //        .Where(expression);
        //}
    }
}
