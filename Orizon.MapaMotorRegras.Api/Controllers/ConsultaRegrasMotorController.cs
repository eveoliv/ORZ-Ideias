using System.Linq;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Orizon.MapaMotorRegras.Api.Entities;
using Orizon.MapaMotorRegras.Api.Repository;

namespace Orizon.MapaMotorRegras.Api.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [ApiExplorerSettings(GroupName = "v1")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class ConsultaRegrasMotorController : ControllerBase
    {
        private readonly IRepository<RegraOperadora> regraRepo;
        private readonly IRepository<RegraDetalhe> detalheRepo;
        private readonly IRepository<RegraDocumentacao> docRepo;

        public ConsultaRegrasMotorController(IRepository<RegraOperadora> regraRepo, IRepository<RegraDetalhe> detalheRepo, IRepository<RegraDocumentacao> docRepo)
        {
            this.regraRepo = regraRepo;
            this.detalheRepo = detalheRepo;
            this.docRepo = docRepo;
        }

        [HttpGet("GetRegrasPorOperadoraLista")]
        [AutoValidateAntiforgeryToken]
        public IActionResult GetRegrasPorOperadoraLista()
        {
            var model = from r in regraRepo.All select new { r.Opereadora, r.Nome, r.Regras };

            return Ok(model);
        }

        [HttpGet("GetRegrasPorIdOperadora/{id}")]
        [AutoValidateAntiforgeryToken]
        public IActionResult GetRegrasPorIdOperadora(int id)
        {
            var model = from r in regraRepo.All.Where(c => c.Opereadora == id) select new { r.Opereadora, r.Nome, r.Regras };

            if (model == null)
                return NotFound();

            return Ok(model);
        }

        [HttpGet("GetDetalhesPorIdRegra/{id}")]
        [AutoValidateAntiforgeryToken]
        public IActionResult GetDetalhesPorIdRegra(int id)
        {
            var model = from r in detalheRepo.All.Where(d => d.Codigo == id)
                        join l in docRepo.All.Where(d => d.Codigo == id) on r.Codigo equals l.Codigo
                        select new { r.Codigo, r.Texto_analise, l.DocLink };

            if (model == null)
                return NotFound();

            return Ok(model);
        }
    }
}