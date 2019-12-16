using Permisos.Domain;
using Persmisos.Business.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Persmisos.Business.Mapping
{
    public static class TipoPermisoMapping
    {
        public static TipoPermiso MapTipoPermisoDto(TipoPermisoDto dto)
        {
            return new TipoPermiso
            {
                Id = dto.id == 0 ? null : dto.id,
                Descripcion = dto.descripcion,
            };
        }

        public static TipoPermisoDto MapTipoPermisoEntity(TipoPermiso entity)
        {
            return new TipoPermisoDto
            {
                id = entity.Id ?? 0,
                descripcion = entity.Descripcion
            };
        }
    }
}
