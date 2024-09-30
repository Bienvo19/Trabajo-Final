using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesOnline.Application.Models.Category
{
    internal class CategoriaGetModels
    {
        public int Id { get; set; }

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
}
