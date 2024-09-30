using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tarea___Trabajo_de_Programación_Capa_de_API.Models;

public partial class Configuracion
{
    [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
    public short Id { get; set; }

    public string? Recurso { get; set; }

    public string? Propiedad { get; set; }

    public string? Valor { get; set; }
}
