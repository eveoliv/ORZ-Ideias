﻿using System.ComponentModel.DataAnnotations;

namespace Orizon.MapaMotorRegras.Api.Entidades
{
    public class Regra
    {
        [Key]
        public int Id { get; set; }
        public int Opereadora { get; set; }
        public string Rules { get; set; }
    }
}
