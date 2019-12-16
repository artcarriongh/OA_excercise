using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Permisos.Domain;
using Permisos.Service;
using Persmisos.Business.DTO;
using Persmisos.Business.Mapping;

namespace Persmisos.Business
{
    public class TipoPermisosBo : ITipoPermisosBo
    {
        private readonly ITipoPermisoService TipoPermisoService;
        public TipoPermisoDto Get(int id)
        {

            return TipoPermisoMapping.MapTipoPermisoEntity(TipoPermisoService.Get(x => x.Id == id));
        }

        public List<TipoPermisoDto> GetAll()
        {
            var result = new List<TipoPermisoDto>();
            var permisosList = TipoPermisoService.GetAll();
            foreach (var tipo in permisosList)
            {
                result.Add(TipoPermisoMapping.MapTipoPermisoEntity(tipo));
            }

            return result;
        }
    }
}
