using System;
using System.Collections.Generic;

namespace Tarea___Trabajo_de_Programación_Capa_de_API.Models;

public partial class NumeroCorrelativo
{
    public int Id { get; set; }

    public int? UltimoNumero { get; set; }

    public int? CantidadDigitos { get; set; }

    public string? Gestion { get; set; }

    public DateTime? FechaActualizacion { get; set; }
}
