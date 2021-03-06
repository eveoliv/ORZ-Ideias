using System.Linq;
using Orizon.MapaMotorRegras.Api.Entities;

namespace Orizon.MapaMotorRegras.Api.Context
{
    public class DbInitializer
    {
        public static void Initializer(MapaMotorContext context)
        {
            if (context.RegrasOperadora.Any() || context.RegrasDetalhe.Any() || context.RegrasDocumentacao.Any())
                return;

            var insertRegras = new RegraOperadora[]
            {
                new RegraOperadora { Operadora = 48, Nome = "BANANA",   Regras = "1238,4556,4789,1011,10128,10135"},
                new RegraOperadora { Operadora = 25, Nome = "LARANJA",  Regras = "1123,1456,1789,1111,11012,11013"},
                new RegraOperadora { Operadora = 60, Nome = "PERA",     Regras = "1235,4565,7895,1015,10125,10135"},
                new RegraOperadora { Operadora = 32, Nome = "MELANCIA", Regras = "1239,9456,8789,1011,81012,21013"}
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

            var insertDocumentacoes = new RegraDocumentacao[]
            {
                new RegraDocumentacao { Codigo = 1238, DocLink = "Link da documentacao 1238"},
                new RegraDocumentacao { Codigo = 1123, DocLink = "Link da documentacao 1123"},
                new RegraDocumentacao { Codigo = 1235, DocLink = "Link da documentacao 1235"},
                new RegraDocumentacao { Codigo = 1239, DocLink = "Link da documentacao 1239"}
            };

            foreach (var item in insertDocumentacoes)
                context.RegrasDocumentacao.Add(item);

            context.SaveChanges();
        }
    }
}
