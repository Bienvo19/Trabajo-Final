using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Tarea___Trabajo_de_Programación_Capa_de_API.Models;

namespace Tarea___Trabajo_de_Programación_Capa_de_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuControllers : ControllerBase
    {
        public SalesContext _salescontext;
        public MenuControllers(SalesContext _Context)
        {
            _salescontext = _Context;
        }
        [HttpGet]
        [Route("Lista")]

        public IActionResult Lista()
        {
            List<Menu> lista = new List<Menu>();

            try
            {
                lista = _salescontext.Menus.ToList();

                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok", response = lista });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { mensaje = ex.Message, response = lista });

            }
        }
        [HttpGet]
        [Route("Obtener/{Id:int}")]

        public IActionResult Obtener(short Id)
        {
            Menu oMenu = _salescontext.Menus.Find(Id);
            if (oMenu == null)
            {
                return BadRequest("Detalle de venta no encontrado");
            }

            try
            {
                oMenu = _salescontext.Menus.Where(p => p.Id == Id).FirstOrDefault();

                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok", response = oMenu });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { mensaje = ex.Message, response = oMenu });

            }

        }
        [HttpPost]
        [Route("Guardar")]
        public IActionResult Guardar([FromBody] Menu objeto)
        {
            try
            {
                _salescontext.Menus.Add(objeto);
                _salescontext.SaveChanges();
                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok" });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { mensaje = ex.Message });
            }


        }
        [HttpPut]
        [Route("Editar")]
        public IActionResult Editar([FromBody] Menu objeto)
        {
            Menu oMenu = _salescontext.Menus.Find(objeto.Id);

            if (oMenu == null)
            {
                return BadRequest("Detalle de venta no encontrado");
            }
            try
            {
                oMenu.RolMenus = objeto.RolMenus;
                oMenu.Eliminado = objeto.Eliminado;
                oMenu.FechaElimino = objeto.FechaElimino;
                oMenu.FechaRegistro = objeto.FechaRegistro;
                oMenu.Controlador = objeto.Controlador;
                oMenu.Descripcion = objeto.Descripcion;
                oMenu.Controlador = objeto.Controlador;

                _salescontext.Menus.Update(oMenu);
                _salescontext.SaveChanges();
                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok" });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { mensaje = ex.Message });
            }
        }
        [HttpDelete]
        [Route("Eliminar/{Id:int}")]
        public IActionResult Eliminar(short Id)
        {
            Menu oMenu = _salescontext.Menus.Find(Id);
            if (oMenu == null)
            {
                return BadRequest("Detalle de venta no encontrado");
            }
            try
            {
                _salescontext.Menus.Remove(oMenu);
                _salescontext.SaveChanges();
                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok" });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { mensaje = ex.Message });
            }

        }
    }
}
