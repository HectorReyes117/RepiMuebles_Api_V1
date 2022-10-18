using System;
using System.Collections.Generic;

namespace MuebleriaRepiAPI.Models
{
    public partial class FormularioCompra
    {
        public int IdFormularioCompra { get; set; }
        public string Nombre { get; set; } = null!;
        public string Apellidos { get; set; } = null!;
        public string Cedula { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Telefono { get; set; } = null!;
        public string Celular { get; set; } = null!;
        public string Sucursal { get; set; } = null!;
        public string Direccion { get; set; } = null!;
        public string Producto { get; set; } = null!;
    }
}
