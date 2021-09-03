using System.ComponentModel.DataAnnotations;

namespace Orizon.MapaMotorRegras.Api.Entities
{
    public class RegraOperadora
    {
        [Key]
        public int Id { get; set; }
        public int Operadora { get; set; }
        public string Nome { get; set; }
        public string Regras { get; set; }
    }
}