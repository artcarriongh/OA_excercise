using System;
using System.ComponentModel.DataAnnotations;

namespace Permisos.Domain
{
    public class Permiso
    {
        [Key]
        public int? Id { get; set; }
        [Required]
        public string NombreEmpleado { get; set; }
        [Required]
        public string ApellidosEmpleado { get; set; }
        [Required]
        public int TipoPermisoId { get; set; }
        [Required]
        public DateTime FechaPermiso { get; set; }

        public TipoPermiso TipoPermiso { get; set; }
    }
}
