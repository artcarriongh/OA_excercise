using Permisos.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Permisos.DAL
{
    public class PermisoRepository : Repository<Permiso>, IPermisoRepository 
    {
        public PermisoRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
