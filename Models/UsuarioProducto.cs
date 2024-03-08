using System;
using System.Collections.Generic;

namespace VentasNexTI.Models
{
    public partial class UsuarioProducto
    {
        public int IdUsuarioProducto { get; set; }
        public int? CodUsuario { get; set; }
        public int? CodProducto { get; set; }

        public virtual Producto? oProducto { get; set; }
        public virtual Usuario? oUsuario { get; set; }
    }
}
