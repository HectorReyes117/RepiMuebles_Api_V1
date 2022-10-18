using System;
using System.Collections.Generic;

namespace MuebleriaRepiAPI.Models
{
    public partial class Registrar
    {
        public int Id { get; set; }
        public string? Nombre { get; set; }
        public string? Apellido { get; set; }
        public string? NombreUsuario { get; set; }
        public string? Email { get; set; }
        public string? Contraseña { get; set; }
        public string TipoUsuario { get; set; } = null!;
    }
}
