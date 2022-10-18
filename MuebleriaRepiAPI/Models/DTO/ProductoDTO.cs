using MuebleriaRepiAPI.DTO;

namespace MuebleriaRepiAPI.Models.DTO
{
    public class ProductoDTO
    {
        public int IdProducto { get; set; }
        public string Nombre { get; set; } = null!;
        public int Precio { get; set; }
        public string Imagen { get; set; } = null!;
        public int? IdCategoria { get; set; }
        public int? IdMarca { get; set; }
        public string? Descripcion { get; set; }
        public int? Descuento { get; set; }
        public CategoriumDTO? IdCategoriaNavigation { get; set; } = null!;
        public MarcaDTO? IdMarcaNavigation { get; set; } = null!;
    }
}
