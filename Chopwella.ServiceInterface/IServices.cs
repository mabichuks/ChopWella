using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Chopwella.ServiceInterface
{
    public interface IServices<T>
    {
        IEnumerable<T> GetAll();
        IQueryable<T> FindBy(Expression<Func<T, bool>> predicate);
        void Add(T entity);
        void Delete(T entity);
        T GetSingle(int id);
        void Edit(T entity);
        void Save();
    }
}
