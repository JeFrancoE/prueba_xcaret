using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;

namespace prueba_xcaret.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoriesController : ControllerBase
    {

        private readonly ILogger<CategoriesController> _logger;

        public CategoriesController(ILogger<CategoriesController> logger)
        {
            _logger = logger;
        }
        [HttpGet]
        public IEnumerable<string> Get()
        {
            Objects.getData myData = new Objects.getData();
            try
            {
                return myData.GetListEntries().Select(e=>e.Category).Distinct();
            }
            catch (Exception ex)
            {
                _logger.LogWarning("Error al obtener datos {EX}", ex.InnerException.ToString());
                return null;
            }

        }
    }
}
