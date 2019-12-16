using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Persmisos.Business.DTO
{
    public class PermisoDto
    {
        public int? id { get; set; }
        public string apellidosEmpleado { get; set; }
        public string nombreEmpleado { get; set; }
        public string tipoPermisoId { get; set; }
        public DateTime fechaPermiso { get; set; }
        public string tipoPermiso { get; set; }
    }
}
