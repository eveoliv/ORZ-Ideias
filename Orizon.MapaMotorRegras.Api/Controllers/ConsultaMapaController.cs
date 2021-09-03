using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        private readonly IRepository<RegraOperadora> regraRepo;
        private readonly IRepository<RegraDetalhe> detalheRepo;
        private readonly IRepository<Documentacao> docRepo;

        public ConsultaMapaController(IRepository<RegraOperadora> regraRepo, IRepository<RegraDetalhe> detalheRepo, IRepository<Documentacao> docRepo)
        {
            this.regraRepo = regraRepo;
            this.detalheRepo = detalheRepo;
            this.docRepo = docRepo;
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
            var regra = detalheRepo.All.Where(d => d.Codigo == id);
            var link = docRepo.All.Where(d => d.Codigo == id);  

            if (regra == null || link == null)
                return NotFound();

            var resumo = from r in regra
                      join l in link on r.Codigo equals l.Codigo
                      select new RegraDetalheApi
                      {
                          Codigo = r.Codigo,
                          Texto_analise = r.Texto_analise,                          
                          Documentacao = l.DocLink
                      };

            return Ok(resumo);
        }       
    }
}