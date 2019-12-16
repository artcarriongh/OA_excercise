using Permisos.Domain;
using Persmisos.Business.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Persmisos.Business.Mapping
{
    public static class PermisoMapping
    {
        public static Permiso MapPermisoDto(PermisoDto dto)
        {
            return new Permiso { 
                Id = dto.id == 0 ? null : dto.id,
                ApellidosEmpleado = dto.apellidosEmpleado,
                NombreEmpleado = dto.nombreEmpleado,
                FechaPermiso = dto.fechaPermiso,
                TipoPermisoId = int.Parse(dto.tipoPermisoId)
            };
        }

        public static PermisoDto MapPermisoEntity(Permiso entity)
        {
            return new PermisoDto
            {
                id = entity.Id ?? 0,
                apellidosEmpleado = entity.ApellidosEmpleado,
                nombreEmpleado = entity.NombreEmpleado,
                fechaPermiso = entity.FechaPermiso,
                tipoPermisoId = entity.TipoPermisoId.ToString(),
                tipoPermiso = entity.TipoPermiso.Descripcion
            };
        }
    }
}
