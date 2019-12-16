using Permisos.DAL;
using Permisos.Domain;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Permisos.Service
{
    public class TipoPermisoService : DataService<TipoPermiso>, ITipoPermisoService
    {
        private readonly ITipoPermisoRepository Repository;
        public TipoPermisoService(ITipoPermisoRepository repository) : base(repository)
        {
            Repository = repository;
        }

        public TipoPermiso GetByDescription(string descripcion)
        {
            return Repository.Get(t => t.Descripcion == descripcion);
        }
    }
        
}
