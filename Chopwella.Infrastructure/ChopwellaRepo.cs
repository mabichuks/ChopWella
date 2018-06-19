using Chopwella.Core;
using Chopwella.DomainInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Chopwella.Infrastructure
{
    class ChopwellaRepo<T> : IRepository<T> where T : BaseEntity
    {
        private readonly ChopwellaDBContext context;

        public ChopwellaRepo()
        {
            this.context = new ChopwellaDBContext();
        }
        public void Add(T entity)
        {
            context.Set<T>().Add(entity);
            Save();
        }

        public void Delete(T entity)
        {
            context.Set<T>().Attach(entity);
            context.Set<T>().Remove(entity);
            Save();
        }

        public void Edit(T entity)
        {
            context.Entry(entity).State = System.Data.Entity.EntityState.Modified;
            Save();
        }

        public IQueryable<T> FindBy(Expression<Func<T, bool>> predicate)
        {
            IQueryable<T> query = context.Set<T>().Where(predicate);
            return query;
        }

        public IEnumerable<T> GetAll()
        {
            return context.Set<T>().ToList();
        }

        public T GetSingle(int id)
        {
            return context.Set<T>().Find(id);
        }

        public void Save()
        {
            context.SaveChanges();
        }
    }
}
