using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Tarea___Trabajo_de_Programación_Capa_de_API.Models;
using System.Collections;
using Microsoft.Identity.Client;

namespace Tarea___Trabajo_de_Programación_Capa_de_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaControllers : ControllerBase
    {
        public SalesContext _salescontext;
        public CategoriaControllers(SalesContext _Context)
        {
            _salescontext = _Context;
        }
        [HttpGet]
        [Route("Lista")]

        public IActionResult Lista()
        {
            List<Categoria> lista = new List<Categoria>();

            try
            {
                lista = _salescontext.Categoria.ToList();

                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok", response = lista });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { mensaje = ex.Message, response = lista });

            }
        }
        [HttpGet]
        [Route("Obtener/{Id:int}")]

        public IActionResult Obtener(int Id)
        {
            Categoria oCategoria = _salescontext.Categoria.Find(Id);
            if (oCategoria == null)
            {
                return BadRequest("Detalle de venta no encontrado");
            }

            try
            {
                oCategoria = _salescontext.Categoria.Where(p => p.Id == Id).FirstOrDefault();

                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok", response = oCategoria});
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { mensaje = ex.Message, response = oCategoria});

            }

        }
        [HttpPost]
        [Route("Guardar")]
        public IActionResult Guardar([FromBody] Categoria objeto)
        {
            try
            {
                _salescontext.Categoria.Add(objeto);
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
        public IActionResult Editar([FromBody] Categoria objeto)
        {
            Categoria oCategoria = _salescontext.Categoria.Find(objeto.Id);

            if (oCategoria == null)
            {
                return BadRequest("Detalle de venta no encontrado");
            }
            try
            {
                oCategoria.Productos = objeto.Productos;
                oCategoria.Eliminado = objeto.Eliminado;
                oCategoria.FechaElimino = objeto.FechaElimino;
                oCategoria.FechaMod = objeto.FechaMod;
                oCategoria.IdUsuarioMod = objeto.IdUsuarioMod;


                _salescontext.Categoria.Update(oCategoria);
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
        public IActionResult Eliminar(int Id)
        {
            Categoria oCategoria = _salescontext.Categoria.Find(Id);
            if (oCategoria == null)
            {
                return BadRequest("Detalle de venta no encontrado");
            }
            try
            {
                _salescontext.Categoria.Remove(oCategoria);
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
