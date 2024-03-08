using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VentasNexTI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Cors;

namespace VentasNexTI.Controllers
{
    [EnableCors("ReglasCors")]
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioProductoController : ControllerBase
    {
        public readonly DBVENTASContext _dbcontext;

        public UsuarioProductoController(DBVENTASContext _context)
        {
            _dbcontext = _context;
        }

        [HttpGet]
        [Route("Lista")]
        public IActionResult Lista()
        {
            List<UsuarioProducto> lista = new List<UsuarioProducto>();

            try
            {
                lista = _dbcontext.UsuarioProductos.Include(c => c.oUsuario).ToList();
                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok", response = lista });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { mensaje = ex.Message, response = lista });
            }
        }


        [HttpGet]
        [Route("Obtener/{idUsuarioProducto:int}")]
        public IActionResult Obtener(int idUsuarioProducto)
        {
            UsuarioProducto oUProducto = _dbcontext.UsuarioProductos.Find(idUsuarioProducto);

            if (oUProducto == null)
            {
                return BadRequest("Producto de usuario no encontrado");
            }

            try
            {
                oUProducto = _dbcontext.UsuarioProductos.Include(c => c.oUsuario).Where(p => p.IdUsuarioProducto == idUsuarioProducto).FirstOrDefault();

                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok", response = oUProducto });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { mensaje = ex.Message, response = oUProducto });
            }
        }


        [HttpPost]
        [Route("Guardar")]
        public IActionResult Guardar([FromBody] UsuarioProducto objeto)
        {
            try
            {
                _dbcontext.UsuarioProductos.Add(objeto);
                _dbcontext.SaveChanges();

                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok" });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { mensaje = ex.Message });
            }

        }


        [HttpPut]
        [Route("Editar")]
        public IActionResult Editar([FromBody] UsuarioProducto objeto)
        {
            UsuarioProducto oUProducto = _dbcontext.UsuarioProductos.Find(objeto.IdUsuarioProducto);

            if (oUProducto == null)
            {
                return BadRequest("Producto no encontrado");
            }

            try
            {
                oUProducto.CodProducto = objeto.CodProducto is null ? oUProducto.CodProducto : objeto.CodProducto;              

                _dbcontext.UsuarioProductos.Update(oUProducto);
                _dbcontext.SaveChanges();

                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok" });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { mensaje = ex.Message });
            }

        }


        [HttpDelete]
        [Route("Eliminar/{idUsuarioProducto:int}")]
        public IActionResult Eliminar(int idUsuarioProducto)
        {

            UsuarioProducto oUProducto = _dbcontext.UsuarioProductos.Find(idUsuarioProducto);

            if (oUProducto == null)
            {
                return BadRequest("Producto no encontrado");
            }

            try
            {
                _dbcontext.UsuarioProductos.Remove(oUProducto);
                _dbcontext.SaveChanges();

                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok" });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { mensaje = ex.Message });
            }

        }




    }
}
