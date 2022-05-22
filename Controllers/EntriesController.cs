using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Logging;
using System;

namespace prueba_xcaret.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EntriesController : ControllerBase
    {

        private readonly ILogger<EntriesController> _logger;

        public EntriesController(ILogger<EntriesController> logger)
        {
            _logger = logger;
        }
        [HttpGet]
        public IEnumerable<prueba_xcaret.Models.Entries> Get()
        {
            Objects.getData myData = new Objects.getData();
            _logger.LogInformation("Listado completo");
            try
            {
                return myData.GetListEntries();
            }
            catch (Exception ex)
            {
                _logger.LogWarning("Error al obtener datos {EX}", ex.InnerException.ToString());
                return null;
            }
            
        }

        [Route("https/{HTTPS:bool}")]
        [HttpGet]
        public IEnumerable<prueba_xcaret.Models.Entries> Get(bool HTTPS)
        {
            Objects.getData myData = new Objects.getData();
            _logger.LogInformation("Listado filtrado por https");
            try
            {
                return myData.GetListEntries().Where(e=>e.HTTPS == HTTPS);
            }
            catch (Exception ex)
            {
                _logger.LogWarning("Error al obtener datos {EX}", ex.InnerException.ToString());
                return null;
            }
        }
    }
}
