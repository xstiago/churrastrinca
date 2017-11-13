using System;
using System.Linq;
using System.Linq.Expressions;

namespace ChurrasTrinca.DataAccess.Contracts
{
    public interface IRepository<T> : IDisposable
    {
        IQueryable<T> Get(Expression<Func<T, bool>> predicate);
        void Delete(T entity);
        void Add(T entity);
    }
}
