using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Permisos.Domain;
using Permisos.Service;

namespace PermisosApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PermisosController : ControllerBase
    {
        private IDataService<Permiso> Service;
        
        private readonly ILogger<PermisosController> _logger;

        public PermisosController(ILogger<PermisosController> logger, IDataService<Permiso> service)
        {
            _logger = logger;
            Service = service;
        }

        [HttpGet]
        public ActionResult Get()
        {
            try
            {
                var permisosList = Service.GetAll();

                return Ok(permisosList);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
