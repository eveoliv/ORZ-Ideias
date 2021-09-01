using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Orizon.MapaMotorRegras.Api.Entidades;
using Orizon.MapaMotorRegras.Api.Repository;

namespace Orizon.MapaMotorRegras.Api.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [ApiExplorerSettings(GroupName = "v1")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class ConsultaMapaController : ControllerBase
    {
        private readonly IRepository<Regra> repository;

        public ConsultaMapaController(IRepository<Regra> repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "ConsultaMapaController value1", "ConsultaMapaController value2" };
        }

        [HttpGet("{id}")]
        public IActionResult GetRegrasPorOperadoraId(int id)
        {
            var model = repository.Find(id);
            if (model == null)
                return NotFound();

            return Ok(model);
        }
    }
}