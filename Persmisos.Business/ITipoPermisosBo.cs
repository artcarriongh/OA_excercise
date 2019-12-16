using Persmisos.Business.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Persmisos.Business
{
    public interface ITipoPermisosBo
    {
        List<TipoPermisoDto> GetAll();

        TipoPermisoDto Get(int id);
    }
}
