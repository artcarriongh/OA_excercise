using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using NUnit.Framework;
using Permisos.DAL;
using Permisos.Domain;
using Permisos.Service;
using System;
using System.Linq;

namespace Permisos.Test
{
    public class PermisosTests
    {

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        [Obsolete]
        public void AddPermisoTest()
        {
            var connString = "Data Source=LAP0378\\SQLEXPRESS;Initial Catalog=Permisos;Integrated Security=True";
            IOptions<ConnectionStringOption> connStrOptions = Options.Create(new ConnectionStringOption { ConStr = connString });
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            optionsBuilder.UseSqlServer(connString);
            var repo = new PermisoRepository(new ApplicationDbContext(connStrOptions, optionsBuilder.Options));
            var service = new PermisoService(repo);
            service.Add(new Permiso { 
                Id = null,
                ApellidosEmpleado = "Carrion",
                NombreEmpleado = "Arturo",
                TipoPermisoId = 1,
                FechaPermiso= DateTime.Now
            });
            
            Assert.AreEqual(repo.GetAll().ToList().Count, 5);
        }
        [Test]
        [Obsolete]
        public void DeletePermisoTest()
        {
            var connString = "Data Source=LAP0378\\SQLEXPRESS;Initial Catalog=Permisos;Integrated Security=True";
            IOptions<ConnectionStringOption> connStrOptions = Options.Create(new ConnectionStringOption { ConStr = connString });
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            optionsBuilder.UseSqlServer(connString);
            var repo = new PermisoRepository(new ApplicationDbContext(connStrOptions, optionsBuilder.Options));
            var service = new PermisoService(repo);
            var permiso = service.GetByApellidoNombre("Carrion", "Arturo");
            if (permiso != null)
            {
                service.Delete(permiso.Id.Value);
            }

            Assert.AreEqual(repo.GetAll().ToList().Count, 4);
        }

        

    }
}