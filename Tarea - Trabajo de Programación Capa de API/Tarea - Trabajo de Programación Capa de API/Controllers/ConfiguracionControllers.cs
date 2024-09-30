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
    public class ConfiguracionControllers : ControllerBase
    {
        public SalesContext _salescontext;
        public ConfiguracionControllers(SalesContext _Context)
        {
            _salescontext = _Context;
        }
        [HttpGet]
        [Route("Lista")]

        public IActionResult Lista()
        {
            List<Configuracion> lista = new List<Configuracion>();

            try
            {
                lista = _salescontext.Configuracions.ToList();

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
            Configuracion oConfiguracion = _salescontext.Configuracions.Find(Id);
            if (oConfiguracion == null)
            {
                return BadRequest("Detalle de venta no encontrado");
            }

            try
            {
                oConfiguracion = _salescontext.Configuracions.Where(p => p.Id == Id).FirstOrDefault();

                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok", response = oConfiguracion });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { mensaje = ex.Message, response = oConfiguracion});

            }

        }
        [HttpPost]
        [Route("Guardar")]
        public IActionResult Guardar([FromBody] Configuracion objeto)
        {
            try
            {
                _salescontext.Configuracions.Add(objeto);
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
        public IActionResult Editar([FromBody] Configuracion objeto)
        {
            Configuracion oConfiguracion = _salescontext.Configuracions.Find(objeto.Id);

            if (oConfiguracion == null)
            {
                return BadRequest("Detalle de venta no encontrado");
            }
            try
            {
                oConfiguracion.Valor = objeto.Valor;
                oConfiguracion.Recurso = objeto.Recurso;
                oConfiguracion.Propiedad = objeto.Propiedad;

                _salescontext.Configuracions.Update(oConfiguracion);
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
            Configuracion oConfiguracion = _salescontext.Configuracions.Find(Id);
            if (oConfiguracion == null)
            {
                return BadRequest("Detalle de venta no encontrado");
            }
            try
            {
                _salescontext.Configuracions.Remove(oConfiguracion);
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
