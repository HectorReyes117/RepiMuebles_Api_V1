using System;
using System.Collections.Generic;

namespace MuebleriaRepiAPI.Models
{
    public partial class SolicitudEmpleado
    {
        public int IdSolicitudEmp { get; set; }
        public string Nombre { get; set; } = null!;
        public string Apellidos { get; set; } = null!;
        public string Cedula { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Telefono { get; set; } = null!;
        public string Celular { get; set; } = null!;
        public int Edad { get; set; }
        public string Genero { get; set; } = null!;
        public string EstadoCivil { get; set; } = null!;
        public string Nacionalidad { get; set; } = null!;
        public string Direccion { get; set; } = null!;
        public string NivelAcademico { get; set; } = null!;
        public string Estudios { get; set; } = null!;
        public string EstadoEstudio { get; set; } = null!;
        public string Labora { get; set; } = null!;
        public string ExperienciaLaboral { get; set; } = null!;
        public int AspiraciónSalarial { get; set; }
        public string Posicion { get; set; } = null!;
        public string Sucursal { get; set; } = null!;
        public string Licencia { get; set; } = null!;
    }
}
