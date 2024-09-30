using SalesOnline.Domain.Core;
using System;
using System.Collections.Generic;

namespace Tarea___Trabajo_de_Programación_Capa_de_API.Models;

public partial class DetalleVentas : BaseEntity
{
 

    public int? IdVenta { get; set; }

    public int? IdProducto { get; set; }

    public string? MarcaProducto { get; set; }

    public string? DescripcionProducto { get; set; }

    public string? CategoriaProducto { get; set; }

    public int? Cantidad { get; set; }

    public decimal? Precio { get; set; }

    public decimal? Total { get; set; }

    public virtual Ventas? oCategoria { get; set; }
}
