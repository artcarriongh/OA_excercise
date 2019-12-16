using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using Permisos.DAL;
using Permisos.Domain;
using Permisos.Service;
using Persmisos.Business;
using Persmisos.Business.DTO;
using PersmisosApi.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Permisos.Test
{
    public class PermisosControllerTest
    {
        [Test]
        public void AddPermisoWithServiceMocking()
        {
            var permisoService = new Mock<IPermisoService>();
            var tipoService = new Mock<ITipoPermisoService>();
            var serviceBo = new Mock<IPermisosBo>();
            var validationBo = new Mock<ITipoPermisosBo>();
            var tipos = new List<TipoPermisoDto>
            {
                new TipoPermisoDto{ id = 1, descripcion = "Enfermedad"}
            };
            validationBo.Setup(mock => mock.GetAll()).Returns(tipos);
            var permiso = new PermisoDto
            {
                id = 1,
                apellidosEmpleado = "Apellido test",
                nombreEmpleado = "Nombre test",
                fechaPermiso = DateTime.Now,
                tipoPermisoId = "1",
                tipoPermiso = "Vacaciones"
            };
            var logger = new Mock<ILogger<PermisosController>>();
            var controller = new PermisosController(logger.Object, serviceBo.Object, validationBo.Object);
            var result = controller.Add(permiso) as OkObjectResult;
            Assert.AreEqual(permiso, result.Value);
        }

        [Test]
        public void ListPermisosTest()
        {
            var permisosList = new List<PermisoDto>
            {
                new PermisoDto
                {
                    id = 1,
                    apellidosEmpleado = "Apellido test 1",
                    nombreEmpleado = "Nombre test 1",
                    fechaPermiso = DateTime.Now,
                    tipoPermisoId = "1",
                    tipoPermiso ="Vacaciones"
                },
                new PermisoDto
                {
                    id = 2,
                    apellidosEmpleado = "Apellido test 2",
                    nombreEmpleado = "Nombre test 2",
                    fechaPermiso = DateTime.Now,
                    tipoPermisoId = "1",
                    tipoPermiso ="Vacaciones"
                },
            };

            var permisoService = new Mock<IPermisoService>();
            var tipoService = new Mock<ITipoPermisoService>();
            var serviceBo = new Mock<IPermisosBo>();
            serviceBo.Setup(mock => mock.GetAll()).Returns(permisosList);
            var validationBo = new Mock<ITipoPermisosBo>();
            var tipo = new TipoPermisoDto{ id = 1, descripcion = "Enfermedad"};
            validationBo.Setup(mock => mock.Get(It.IsAny<int>())).Returns(tipo);
            var logger = new Mock<ILogger<PermisosController>>();

            var controller = new PermisosController(logger.Object, serviceBo.Object, validationBo.Object);
            var result = controller.Get() as OkObjectResult;

            Assert.AreEqual(((List<PermisoDto>)result.Value).Count, 2);
        }
    }
}
