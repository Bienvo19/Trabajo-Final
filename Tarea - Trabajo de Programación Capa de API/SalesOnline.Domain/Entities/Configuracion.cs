using SalesOnline.Domain.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tarea___Trabajo_de_Programación_Capa_de_API.Models;

public partial class Configuracion : BaseEntity
{
    [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]


    public string? Recurso { get; set; }

    public string? Propiedad { get; set; }

    public string? Valor { get; set; }
}
