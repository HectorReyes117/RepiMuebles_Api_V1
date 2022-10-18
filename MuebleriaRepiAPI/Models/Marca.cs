using System;
using System.Collections.Generic;

namespace MuebleriaRepiAPI.Models
{
    public partial class Marca
    {
        public Marca()
        {
            Productos = new HashSet<Producto>();
        }

        public int IdMarca { get; set; }
        public string NombreMarca { get; set; } = null!;
        public string ImagenMarca { get; set; } = null!;

        public virtual ICollection<Producto> Productos { get; set; }
    }
}
