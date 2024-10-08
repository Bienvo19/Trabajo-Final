﻿using System;
using System.Collections.Generic;

namespace Tarea___Trabajo_de_Programación_Capa_de_API.Models;

public partial class RolMenu
{
    public int Id { get; set; }

    public int? IdRol { get; set; }

    public int? IdMenu { get; set; }

    public bool? EsActivo { get; set; }

    public DateTime FechaRegistro { get; set; }

    public int IdUsuarioCreacion { get; set; }

    public DateTime? FechaMod { get; set; }

    public int? IdUsuarioMod { get; set; }

    public int? IdUsuarioElimino { get; set; }

    public DateTime? FechaElimino { get; set; }

    public bool Eliminado { get; set; }

    public virtual Menu? IdMenuNavigation { get; set; }

    public virtual Rol? IdRolNavigation { get; set; }
}
