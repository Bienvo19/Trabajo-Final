using SalesOnline.Domain.Core;
using System;
using System.Collections.Generic;

namespace Tarea___Trabajo_de_Programación_Capa_de_API.Models;

public partial class Menu : BaseEntity
{
  

    public string? Descripcion { get; set; }

    public int? IdMenuPadre { get; set; }

    public string? Icono { get; set; }

    public string? Controlador { get; set; }

    public string? PaginaAccion { get; set; }

    public bool? EsActivo { get; set; }

    public DateTime FechaRegistro { get; set; }

    public int IdUsuarioCreacion { get; set; }

    public DateTime? FechaMod { get; set; }

    public int? IdUsuarioMod { get; set; }

    public int? IdUsuarioElimino { get; set; }

    public DateTime? FechaElimino { get; set; }

    public bool Eliminado { get; set; }

    public virtual Menu? IdMenuPadreNavigation { get; set; }

    public virtual ICollection<Menu> InverseIdMenuPadreNavigation { get; set; } = new List<Menu>();

    public virtual ICollection<RolMenu> RolMenus { get; set; } = new List<RolMenu>();
}
