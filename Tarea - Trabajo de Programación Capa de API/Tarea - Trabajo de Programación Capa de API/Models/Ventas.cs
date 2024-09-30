using System;
using System.Collections.Generic;

namespace Tarea___Trabajo_de_Programación_Capa_de_API.Models;

public partial class Ventas
{
    public int Id { get; set; }

    public string? NumeroVenta { get; set; }

    public int? IdTipoDocumentoVenta { get; set; }

    public int? IdUsuario { get; set; }

    public string? CocumentoCliente { get; set; }

    public string? NombreCliente { get; set; }

    public decimal? SubTotal { get; set; }

    public decimal? ImpuestoTotal { get; set; }

    public decimal? Total { get; set; }

    public DateTime FechaRegistro { get; set; }

    public int IdUsuarioCreacion { get; set; }

    public virtual ICollection<DetalleVentas> DetalleVenta { get; set; } = new List<DetalleVentas>();

    public virtual TipoDocumentoVentum? IdTipoDocumentoVentaNavigation { get; set; }

    public virtual Usuario? IdUsuarioNavigation { get; set; }
}
