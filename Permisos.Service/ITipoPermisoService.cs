using Permisos.Domain;
using System.Collections.Generic;

namespace Permisos.Service
{
    public interface ITipoPermisoService : IDataService<TipoPermiso>
    {
        TipoPermiso GetByDescription(string descripcion);
    }
}