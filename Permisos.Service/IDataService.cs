using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Permisos.Service
{
    public interface IDataService<TEntityModel> where TEntityModel : class
    {
        TEntityModel Get(int id);
        TEntityModel Get(Expression<Func<TEntityModel, bool>> predicate);
        IEnumerable<TEntityModel> GetAll(Expression<Func<TEntityModel, bool>> predicate = null);
        void Add(TEntityModel entity);
        void Update(TEntityModel entity);
        void Delete(int id);
    }
}
