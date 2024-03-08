using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace VentasNexTI.Models
{
    public partial class Producto
    {
        public Producto()
        {
            UsuarioProductos = new HashSet<UsuarioProducto>();
        }

        public int IdProducto { get; set; }
        public DateTime? FechaEvento { get; set; }
        public string? LugarEvento { get; set; }
        public string? DescripcionEvento { get; set; }
        public decimal? Precio { get; set; }
        public int? CodCategoria { get; set; }

        public virtual Categoria? oCategoria { get; set; }

        [JsonIgnore]
        public virtual ICollection<UsuarioProducto> UsuarioProductos { get; set; }
    }
}
