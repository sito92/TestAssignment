using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using TestAssignment.Domain.Models.DomainModels;
using TestAssignment.Domain.Repository.Interfaces;

namespace TestAssignment.Domain.Repository
{
    public abstract class GenericRepository<T,C> : IRepository<T> where T : Entity where C : DbContext, new() 
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

        public virtual void Save(T element)
        {
            var orginal = _entities.Set<T>().Find(element.Id);

            _entities.Entry(orginal).CurrentValues.SetValues(element);
        }



        public virtual void SaveChanges()
        {
            _entities.SaveChanges();
        }

    }
}