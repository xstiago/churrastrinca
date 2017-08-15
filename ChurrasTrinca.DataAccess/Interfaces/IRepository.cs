using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ChurrasTrinca.DataAccess.Interfaces
{
    public interface IRepository<T> : IDisposable
    {
        IQueryable<T> Get(Expression<Func<T, bool>> predicate);
        void Delete(T entity);
        void Add(T entity);
    }
}
