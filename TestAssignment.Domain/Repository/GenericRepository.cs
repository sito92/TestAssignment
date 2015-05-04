using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using TestAssignment.Domain.Repository.Interfaces;

namespace TestAssignment.Domain.Repository
{
    public abstract class GenericRepository<T,C> : IRepository<T> where T : class where C : DbContext, new() 
    {
        protected C _entities = new C();

        public IQueryable<T> FindBy(System.Linq.Expressions.Expression<Func<T,bool>> predicate)
        {
            var query = _entities.Set<T>().Where(predicate);
            return query;
        }

        public IEnumerable<T> GetAll()
        {
           return _entities.Set<T>();
        }

        public virtual void Add(T element)
        {
            _entities.Set<T>().Add(element);
        }

        public virtual void Delete(T element)
        {
            _entities.Set<T>().Remove(element);
        }

        public abstract void Save(T element);


        public virtual void SaveChanges()
        {
            _entities.SaveChanges();
        }

    }
}