using System;
using System.Collections.Generic;

namespace MuebleriaRepiAPI.Models
{
    public partial class Categorium
    {
        public Categorium()
        {
            Productos = new HashSet<Producto>();
        }

        public int IdCategoria { get; set; }
        public string Categoria { get; set; } = null!;

        public virtual ICollection<Producto> Productos { get; set; }
    }
}
