using System.ComponentModel.DataAnnotations;

namespace Permisos.Domain
{
    public class TipoPermiso
    {
        [Key]
        public int? Id { get; set; }
        [Required]
        public string Descripcion { get; set; }
    }
}
