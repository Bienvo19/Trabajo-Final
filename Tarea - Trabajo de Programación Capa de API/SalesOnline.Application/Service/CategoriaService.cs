using SalesOnline.Application.Contract;
using SalesOnline.Application.Core;
using SalesOnline.Application.Models.Producto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tarea___Trabajo_de_Programación_Capa_de_API.Models;

namespace SalesOnline.Application.Service
{
    public class CategoriaService : ICategoriSevice
    {
        public ServiceResult<ProducGetModel> GetCatergoria(int Id)
        {
            List<Categoria> lista;

            return new ServiceResult<List<Categoria>>()
            {
                Success = true,
                Message = null,
                Data = list,
            }
            catch (Exception ex)
            {
                return ServiceResult<>

            }
        }

        public ServiceResult<List<ProducGetModel>> GetCatergories()
        {
            throw new NotImplementedException();
        }
    }
}
