using Permisos.DAL;
using Permisos.Domain;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Permisos.Service
{
    public class PermisoService : DataService<Permiso>, IPermisoService
    {
        private readonly IPermisoRepository Repository;
        public PermisoService(IPermisoRepository repository) : base(repository)
        {
            Repository = repository;
        }

        public Permiso GetByApellidoNombre(string appellido, string nombre)
        {
            return Repository.Get(p => p.ApellidosEmpleado == appellido && p.NombreEmpleado == nombre);
        }
    }
        
}
