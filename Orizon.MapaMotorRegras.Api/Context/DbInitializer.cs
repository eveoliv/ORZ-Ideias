using System.Linq;
using Orizon.MapaMotorRegras.Api.Entidades;

namespace Orizon.MapaMotorRegras.Api.Context
{
    public class DbInitializer
    {
        public static void Initializer(MapaMotorContext context)
        {
            if (context.Regras.Any() || context.RegrasDetalhe.Any())
                return;

            var insertRegras = new Regra[]
            {
                new Regra { Opereadora = 48, Rules = "[1238,4556,4789,1011,10128,10135]"},
                new Regra { Opereadora = 25, Rules = "[1123,1456,1789,1111,11012,11013]"},
                new Regra { Opereadora = 60, Rules = "[1235,4565,7895,1015,10125,10135]"},
                new Regra { Opereadora = 32, Rules = "[1239,9456,8789,1011,81012,21013]"}
            };

            foreach (var item in insertRegras)            
                context.Regras.Add(item);

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
            
        }
    }
}
