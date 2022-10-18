using System;
using System.Collections.Generic;

namespace MuebleriaRepiAPI.Models
{
    public partial class Registrarse
    {
        public int IdRegistrarse { get; set; }
        public string Nombre { get; set; } = null!;
        public string Apellido { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Username { get; set; } = null!;
        public string Contraseña { get; set; } = null!;
        public string ContraseñaConf { get; set; } = null!;
        public string TipoUsuario { get; set; } = null!;
    }
}
