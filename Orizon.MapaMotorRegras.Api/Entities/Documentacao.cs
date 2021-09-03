﻿using System.ComponentModel.DataAnnotations;

namespace Orizon.MapaMotorRegras.Api.Entities
{
    public class Documentacao
    {
        [Key]
        public int Id { get; set; }
        public int Codigo { get; set; }
        public string DocLink { get; set; }
    }
}
