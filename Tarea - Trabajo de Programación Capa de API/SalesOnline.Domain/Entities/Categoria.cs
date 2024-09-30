using SalesOnline.Domain.Core;
using System;
using System.Collections.Generic;

namespace Tarea___Trabajo_de_Programación_Capa_de_API.Models;

public partial class Categoria : BaseEntity
{
  

    public string? Descripcion { get; set; }

    public bool? EsActivo { get; set; }

    public DateTime FechaRegistro { get; set; }

    public int IdUsuarioCreacion { get; set; }

    public DateTime? FechaMod { get; set; }

    public int? IdUsuarioMod { get; set; }

    public int? IdUsuarioElimino { get; set; }

    public DateTime? FechaElimino { get; set; }

    public bool Eliminado { get; set; }

    public virtual ICollection<Producto> Productos { get; set; } = new List<Producto>();
}
