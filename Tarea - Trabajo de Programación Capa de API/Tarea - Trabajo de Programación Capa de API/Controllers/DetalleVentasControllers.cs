using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Tarea___Trabajo_de_Programación_Capa_de_API.Models;
using System.Collections;

namespace Tarea___Trabajo_de_Programación_Capa_de_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DetalleVentasControllers : ControllerBase
    {
        public SalesContext _salescontext;

        public DetalleVentasControllers(SalesContext _Context)
        {
            _salescontext = _Context;
        }
        [HttpGet]
        [Route("Lista")]

        public IActionResult Lista()
        {
            List<DetalleVentas> lista = new List<DetalleVentas>();

            try
            {
                lista = _salescontext.DetalleVenta.Include(c => c.oCategoria).ToList();

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
            DetalleVentas oDetalleVentas = _salescontext.DetalleVenta.Find(Id);
            if (oDetalleVentas == null)
            {
                return BadRequest("Detalle de venta no encontrado");
            }

            try
            {
                oDetalleVentas = _salescontext.DetalleVenta.Include(c => c.oCategoria).Where(p => p.Id == Id).FirstOrDefault();

                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok", response = oDetalleVentas });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { mensaje = ex.Message, response = oDetalleVentas });

            }

        }
        [HttpPost]
        [Route("Guardar")]
        public IActionResult Guardar([FromBody] DetalleVentas objeto)
        {
            try
            {
                _salescontext.DetalleVenta.Add(objeto);
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
        public IActionResult Editar([FromBody] DetalleVentas objeto)
        {
            DetalleVentas oDetalleVentas = _salescontext.DetalleVenta.Find(objeto.Id);

            if (oDetalleVentas == null)
            {
                return BadRequest("Detalle de venta no encontrado");
            }
            try
            {
                oDetalleVentas.DescripcionProducto = objeto.DescripcionProducto is null ? objeto.DescripcionProducto : objeto.DescripcionProducto;
                oDetalleVentas.MarcaProducto = objeto.MarcaProducto is null ? objeto.MarcaProducto : objeto.MarcaProducto;
                oDetalleVentas.CategoriaProducto = objeto.CategoriaProducto is null ? objeto.CategoriaProducto : objeto.CategoriaProducto;


              _salescontext.DetalleVenta.Update(oDetalleVentas);
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
            DetalleVentas oDetalleVentas = _salescontext.DetalleVenta.Find(Id);
            if (oDetalleVentas == null)
            {
                return BadRequest("Detalle de venta no encontrado");
            }
            try
            {
                _salescontext.DetalleVenta.Remove(oDetalleVentas);
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
