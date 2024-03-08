using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace VentasNexTI.Models
{
    public partial class Usuario
    {
        public Usuario()
        {
            UsuarioProductos = new HashSet<UsuarioProducto>();
        }

        public int IdUsuario { get; set; }
        public string? Nombre { get; set; }
        public int? Cedula { get; set; }

        [JsonIgnore]        
        public virtual ICollection<UsuarioProducto> UsuarioProductos { get; set; }
    }
}
