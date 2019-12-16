using Permisos.Domain;
using System.Collections.Generic;

namespace Permisos.Service
{
    public interface IPermisoService : IDataService<Permiso>
    {
        Permiso GetByApellidoNombre(string appellido, string nombre);
    }
}