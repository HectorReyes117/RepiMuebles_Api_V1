using System;
using System.Collections.Generic;

namespace MuebleriaRepiAPI.Models
{
    public partial class Solicitar
    {
        public int IdSolicitar { get; set; }
        public string Nombre { get; set; } = null!;
        public string Apellidos { get; set; } = null!;
        public string Cedula { get; set; } = null!;
        public int Edad { get; set; }
        public string ViviendaPropia { get; set; } = null!;
        public string SectorVive { get; set; } = null!;
        public string ArticuloFinanciar { get; set; } = null!;
        public string DondeSolicitarCredito { get; set; } = null!;
        public string CompraAnterior { get; set; } = null!;
        public string Telefono { get; set; } = null!;
        public string Celular { get; set; } = null!;
        public string DondeTrabaja { get; set; } = null!;
        public string Puestos { get; set; } = null!;
        public string TiempoEmpresa { get; set; } = null!;
        public string TelefonoLabora { get; set; } = null!;
        public string JefeInmediato { get; set; } = null!;
        public int Salario { get; set; }
        public int OtrosIngresos { get; set; }
    }
}
