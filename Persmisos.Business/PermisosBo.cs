using Permisos.Domain;
using Permisos.Service;
using Persmisos.Business.DTO;
using Persmisos.Business.Mapping;
using System;
using System.Collections.Generic;

namespace Persmisos.Business
{
    public class PermisosBo : IPermisosBo
    {
        private readonly IPermisoService PermisoService;
        private readonly ITipoPermisoService TipoPermisoService;
        public PermisosBo(IPermisoService permisoService, ITipoPermisoService tipoPermisoService)
        {
            PermisoService = permisoService;
            TipoPermisoService = tipoPermisoService;
        }

        public List<PermisoDto> GetAll()
        {
            var result = new List<PermisoDto>();
            var permisosList = PermisoService.GetAll();
            foreach (var permiso in permisosList)
            {
                permiso.TipoPermiso = TipoPermisoService.Get(permiso.TipoPermisoId);
                result.Add(PermisoMapping.MapPermisoEntity(permiso));
            }

            return result;
        }

        public void Add(PermisoDto dto)
        {
            PermisoService.Add(PermisoMapping.MapPermisoDto(dto));
        }

        public void Delete(int id)
        {
            PermisoService.Delete(id);
        }
    }
}
