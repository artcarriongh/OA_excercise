using Persmisos.Business.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Persmisos.Business
{
    public interface IPermisosBo
    {
        List<PermisoDto> GetAll();

        void Add(PermisoDto dto);

        void Delete(int id);
    }
}
