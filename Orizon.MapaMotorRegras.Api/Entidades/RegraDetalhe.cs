using System.ComponentModel.DataAnnotations;

namespace Orizon.MapaMotorRegras.Api.Entidades
{
    public class RegraDetalhe
    {
        [Key]
        public int Id { get; set; }
        public int Codigo { get; set; }
        public string Texto_analise { get; set; }
        public string Operacao { get; set; }
        public string Aut_fat { get; set; }
        public string Nivel { get; set; }
        public string Descricao { get; set; }
        public byte Alteravel { get; set; }
        public int Link { get; set; }
        public string Detalhes { get; set; }
    }//criticasdeanalise
}
