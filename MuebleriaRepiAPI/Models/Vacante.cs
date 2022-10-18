using System;
using System.Collections.Generic;

namespace MuebleriaRepiAPI.Models
{
    public partial class Vacante
    {
        public int IdVacantes { get; set; }
        public string Posicion { get; set; } = null!;
        public string DescripciónPuesto { get; set; } = null!;
        public string EstimacionSalarial { get; set; } = null!;
        public string Sucursal { get; set; } = null!;
    }
}
