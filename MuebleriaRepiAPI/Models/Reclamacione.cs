using System;
using System.Collections.Generic;

namespace MuebleriaRepiAPI.Models
{
    public partial class Reclamacione
    {
        public int IdReclamaciones { get; set; }
        public string NumeroFactura { get; set; } = null!;
        public string Producto { get; set; } = null!;
        public string Sucursal { get; set; } = null!;
        public string Nombres { get; set; } = null!;
        public string Apellidos { get; set; } = null!;
        public string Telefono { get; set; } = null!;
        public string Celular { get; set; } = null!;
        public string Direccion { get; set; } = null!;
        public string Comentario { get; set; } = null!;
    }
}
