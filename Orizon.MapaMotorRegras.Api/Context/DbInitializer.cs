using System.Linq;
using Orizon.MapaMotorRegras.Api.Entities;

namespace Orizon.MapaMotorRegras.Api.Context
{
    public class DbInitializer
    {
        public static void Initializer(MapaMotorContext context)
        {
            if (context.RegrasOperadora.Any() || context.RegrasDetalhe.Any() || context.Documentacoes.Any())
                return;

            var insertRegras = new RegraOperadora[]
            {
                new RegraOperadora { Opereadora = 48, Nome = "BANANA",   Regras = "1238,4556,4789,1011,10128,10135"},
                new RegraOperadora { Opereadora = 25, Nome = "LARANJA",  Regras = "1123,1456,1789,1111,11012,11013"},
                new RegraOperadora { Opereadora = 60, Nome = "PERA",     Regras = "1235,4565,7895,1015,10125,10135"},
                new RegraOperadora { Opereadora = 32, Nome = "MELANCIA", Regras = "1239,9456,8789,1011,81012,21013"}
            };

            foreach (var item in insertRegras)            
                context.RegrasOperadora.Add(item);

            context.SaveChanges();

            var insertRegrasDetalhe = new RegraDetalhe[]
            {
                new RegraDetalhe { Codigo = 1238, Texto_analise = "Um detalhe qualquer", Operacao = "B", Aut_fat = "F", Nivel = "C", Descricao = "Teste detalhe", Alteravel = 1, Link = 2, Detalhes = "Outro detalhe." },
                new RegraDetalhe { Codigo = 1123, Texto_analise = "Um detalhe qualquer", Operacao = "B", Aut_fat = "F", Nivel = "C", Descricao = "Teste detalhe", Alteravel = 1, Link = 2, Detalhes = "Outro detalhe." },
                new RegraDetalhe { Codigo = 1235, Texto_analise = "Um detalhe qualquer", Operacao = "B", Aut_fat = "F", Nivel = "C", Descricao = "Teste detalhe", Alteravel = 1, Link = 2, Detalhes = "Outro detalhe." },
                new RegraDetalhe { Codigo = 1239, Texto_analise = "Um detalhe qualquer", Operacao = "B", Aut_fat = "F", Nivel = "C", Descricao = "Teste detalhe", Alteravel = 1, Link = 2, Detalhes = "Outro detalhe." }
            };

            foreach (var item in insertRegrasDetalhe)            
                context.RegrasDetalhe.Add(item);

            context.SaveChanges();

            var insertDocumentacoes = new Documentacao[]
            {
                new Documentacao { Codigo = 1238, DocLink = "Link da documentacao"},
                new Documentacao { Codigo = 1123, DocLink = "Link da documentacao"},
                new Documentacao { Codigo = 1235, DocLink = "Link da documentacao"},
                new Documentacao { Codigo = 1239, DocLink = "Link da documentacao"}
            };

            foreach (var item in insertDocumentacoes)
                context.Documentacoes.Add(item);

            context.SaveChanges();
        }
    }
}
