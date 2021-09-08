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
    public class ConsultaMapaController : ControllerBase
    {
        private readonly IRepository<RegraDetalhe> detalheRepo;
        private readonly IRepository<RegraOperadora> regraRepo;
        private readonly IRepository<RegraDocumentacao> docRepo;

        public ConsultaMapaController(IRepository<RegraOperadora> regraRepo, IRepository<RegraDetalhe> detalheRepo, IRepository<RegraDocumentacao> docRepo)
        {
            this.regraRepo = regraRepo;
            this.detalheRepo = detalheRepo;
            this.docRepo = docRepo;
        }

        [HttpGet("GetRegrasPorOperadoraLista")]
        [AutoValidateAntiforgeryToken]
        public IActionResult GetRegrasPorOperadoraLista()
        {
            var model = from r in regraRepo.All select new { r.Operadora, r.Nome, r.Regras };

            return Ok(model);
        }

        [HttpGet("GetRegrasPorIdOperadora/{id}")]
        [AutoValidateAntiforgeryToken]
        public IActionResult GetRegrasPorIdOperadora(int id)
        {
            var model = from r in regraRepo.All.Where(c => c.Operadora == id) select new { r.Operadora, r.Nome, r.Regras };

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

        //VER COMO FAZER O POST PARA INCLUIR UMA OPERADORA E SUAS REGRAS
        //[HttpPost]
        //public IActionResult AddOperadoraERegras([FromBody])
        //{

        //}

        [HttpPut("UpdateDocumentacaoRegra/{codigo}")]
        public IActionResult UpdateDocumentacaoRegra(int codigo, string docNovo)
        {
            var model = docRepo.All.Where(c => c.Codigo == codigo).FirstOrDefault();

            if (model == null)
            {
                return NotFound();
            }

            else
            {
                string nova = model.DocLink.Replace(model.DocLink, docNovo);
                model.DocLink = nova;
                docRepo.Alterar(model);
                return Ok(model);
            }
        }

        [HttpPut("UpdateRegrasPorOperadoraECodigo/{id}/{codigo}")]
        public IActionResult UpdateRegrasPorOperadoraECodigo(int id, string codigo)
        {
            var model = regraRepo.All.Where(c => c.Operadora == id).FirstOrDefault();

            if (model == null)
            {
                return NotFound();
            }

            //VER SE É POSSÍVEL ACHAR UM PEDAÇO DE TEXTO DENTRO DA STRING
            //ASSIM, SE A REGRA JÁ EXISTIR PARA A OPERADORA NÃO SERÁ FEITO O UPDATE

            else
            {
                string nova = model.Regras.Replace(model.Regras, model.Regras + "," + codigo);
                model.Regras = nova;
                regraRepo.Alterar(model);
                return Ok(model);
            }
        }

        [HttpPut("DeleteRegrasPorOperadoraECodigo/{id}/{codigo}")]
        public IActionResult DeleteRegrasPorOperadoraECodigo(int id, string codigo)
        {
            var model = regraRepo.All.Where(c => c.Operadora == id && c.Regras.Contains(codigo)).FirstOrDefault();

            if (model == null)
            {
                return NotFound();
            }

            else
            {
                if (codigo == model.Regras.Substring(model.Regras.Length - 4) || codigo == model.Regras.Substring(model.Regras.Length - 3))
                {
                    string nova = model.Regras.Replace("," + codigo, "");
                    model.Regras = nova;
                    regraRepo.Alterar(model);
                    return Ok(model);
                }

                else
                {
                    string nova = model.Regras.Replace(codigo + ",", "");
                    model.Regras = nova;
                    regraRepo.Alterar(model);
                    return Ok(model);
                }
            }
        }

        [HttpDelete("DeleteRegrasPorIdOperadora/{id}")]
        public IActionResult DeleteRegrasPorIdOperadora(int id)
        {
            var model = regraRepo.All.Where(c => c.Operadora == id).FirstOrDefault();

            if (model == null)
            {
                return NotFound();
            }

            else
            {
                regraRepo.Excluir(model);
                return Ok(model);
            }
        }
    }
}