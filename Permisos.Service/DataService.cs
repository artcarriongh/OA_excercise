using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Permisos.Domain;
using Persmisos.DAL;

namespace Permisos.Service
{
    public abstract class DataService<TEntityModel> : IDataService<TEntityModel> where TEntityModel : class
    {
        private readonly IRepository<TEntityModel> Repository;

        public DataService(IRepository<TEntityModel> repository)
        {
            Repository = repository;

        }

        public void Add(TEntityModel entity)
        {
            Repository.Add(entity);
            Repository.CommitChanges();

        }

        public void Delete(int id)
        {
            Repository.Delete(id);
            Repository.CommitChanges();
        }

        public TEntityModel Get(int id)
        {
            var model = Repository.Get(id);

            if (model == null)
                throw new Exception("ErrNotFound");

            return model;
        }

        public TEntityModel Get(Expression<Func<TEntityModel, bool>> predicate)
        {
            return Repository.Get(predicate);
        }

        public IEnumerable<TEntityModel> GetAll(Expression<Func<TEntityModel, bool>> predicate = null)
        {
            IEnumerable<TEntityModel> models;

            if (predicate != null)
                models = Repository.GetAll(predicate);
            else
                models = Repository.GetAll();

            return models;
        }

        public void Update(TEntityModel entity)
        {
            Repository.Update(entity);
            Repository.CommitChanges();
        }
    }
}
