using System;
using System.Collections.Generic;

using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text.RegularExpressions;


namespace ESS_BLG
{
    public interface IGenericRepository<T> where T : class
    {
        IQueryable<T> GetAll();
      //  IEnumerable<T> GetAll1();
        IQueryable<T> FindBy(Expression<Func<T, bool>> predicate);
        void Add(T entity);
        void Delete(T entity);
        void Edit(T entity);
        void Save();
    }

   
}


