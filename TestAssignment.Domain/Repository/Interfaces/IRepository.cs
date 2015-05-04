using System;
using System.Collections.Generic;
using System.Linq;

namespace TestAssignment.Domain.Repository.Interfaces
{
    public interface IRepository<T>
    {
        IQueryable<T> FindBy(System.Linq.Expressions.Expression<Func<T, bool>> predicate);

        IEnumerable<T> GetAll();
        void Add(T element);

        void Delete(T element);

        void Save(T element);
        void SaveChanges();
    }
}
