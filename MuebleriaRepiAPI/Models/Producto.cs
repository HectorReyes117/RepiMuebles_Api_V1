using System;
using System.Collections.Generic;

namespace MuebleriaRepiAPI.Models
{
    public partial class Producto
    {
        public int IdProducto { get; set; }
        public string Nombre { get; set; } = null!;
        public int Precio { get; set; }
        public string Imagen { get; set; } = null!;
        public int? IdCategoria { get; set; }
        public int? IdMarca { get; set; }
        public string? Descripcion { get; set; }
        public int? Descuento { get; set; }

        public virtual Categorium? IdCategoriaNavigation { get; set; }
        public virtual Marca? IdMarcaNavigation { get; set; }
    }
}
