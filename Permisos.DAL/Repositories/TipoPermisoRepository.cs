using Permisos.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Permisos.DAL
{
    public class TipoPermisoRepository : Repository<TipoPermiso>, ITipoPermisoRepository 
    {
        public TipoPermisoRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
