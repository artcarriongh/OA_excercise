using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Persmisos.DAL
{
    public interface IRepository<TEntity> where TEntity : class
    {
        TEntity Get(int id);
        TEntity Get(Expression<Func<TEntity, bool>> predicate);
        IEnumerable<TEntity> GetAll(Expression<Func<TEntity, bool>> predicate = null);
        void Add(TEntity entity);
        void Update(TEntity entity);
        void Delete(int id);

        int CommitChanges();
        Task<int> CommitChangesAsync();
    }
}
