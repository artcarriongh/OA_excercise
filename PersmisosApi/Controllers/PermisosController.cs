using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Permisos.DAL;
using Persmisos.Business;
using Persmisos.Business.DTO;

namespace PersmisosApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PermisosController : ControllerBase
    {
        private readonly IPermisosBo Service;

        private readonly ITipoPermisosBo ValidacionService;

        private readonly ILogger<PermisosController> Logger;

        public PermisosController(ILogger<PermisosController> logger, IPermisosBo service, ITipoPermisosBo validacionService)
        {
            Logger = logger;
            Service = service;
            ValidacionService = validacionService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var permisosList = Service.GetAll();
                return Ok(permisosList);
            }
            catch (Exception ex)
            {
                Logger.LogError($"Error: {ex.StackTrace}");
                return BadRequest("Hubo problemas para traer la lista de permisos.");
            }
        }

        [HttpPost]
        public IActionResult Add(PermisoDto dto)
        {
            try
            {
                dto.fechaPermiso = DateTime.Now;
                if (!ValidacionService.GetAll().Any(t => t.id == int.Parse(dto.tipoPermisoId)))
                {
                    return BadRequest("El Tipo de Permiso no es válido.");
                }

                Service.Add(dto);
                Logger.LogInformation("Permiso crado.");
                return Ok($"Persmiso para {dto.apellidosEmpleado}, {dto.nombreEmpleado} fue creado con éxito.");
            }
            catch (Exception ex)
            {
                Logger.LogError($"Error: {ex.StackTrace}");
                return BadRequest("Hubo problmas al tratar de crear un permiso.");
            };
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            try
            {
                Service.Delete(id);
                Logger.LogInformation($"El permiso para el Id: {id} ha sido eliminado.");
                return Ok($"El permiso para el Id: {id} fue eliminado con éxito.");
            }
            catch (Exception ex)
            {
                Logger.LogError($"ERROR: {ex.StackTrace}");
                return BadRequest("Hubo problemas para eliminar el permiso.");
            }
        }
    }
}
