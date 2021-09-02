using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Orizon.MapaMotorRegras.Api.Entities;
using Orizon.MapaMotorRegras.Api.Repository;

namespace Orizon.MapaMotorRegras.Api.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [ApiExplorerSettings(GroupName = "v1")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class ConsultaMapaController : ControllerBase
    {
        private readonly IRepository<Regra> regraRepo;
        private readonly IRepository<RegraDetalhe> detalheRepo;

        public ConsultaMapaController(IRepository<Regra> regraRepo, IRepository<RegraDetalhe> detalheRepo)
        {
            this.regraRepo = regraRepo;
            this.detalheRepo = detalheRepo;
        }

        [HttpGet("GetRegrasPorOperadoraLista")]
        [AutoValidateAntiforgeryToken]
        public IActionResult GetRegrasPorOperadoraLista()
        {
            var model = regraRepo.All;

            return Ok(model);
        }       

        [HttpGet("GetRegrasPorIdOperadora/{id}")]
        [AutoValidateAntiforgeryToken]
        public IActionResult GetRegrasPorIdOperadora(int id)
        {
            var model = regraRepo.All.Where(c => c.Opereadora == id);            

            if (model == null)
                return NotFound();           

            return Ok(model);
        }

        [HttpGet("GetDetalhesPorIdRegra/{id}")]
        [AutoValidateAntiforgeryToken]
        public IActionResult GetDetalhesPorIdRegra(int id)
        {
            var model = detalheRepo.All.Where(d => d.Codigo == id);

            if (model == null)
                return NotFound();

            return Ok(model);
        }       
    }
}