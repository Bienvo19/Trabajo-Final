using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SalesOnline.Application.Core;
using SalesOnline.Application.Models.Category;
using SalesOnline.Application.Models.Producto;

namespace SalesOnline.Application.Contract
{
    public interface ICategoriSevice
    {
        ServiceResult<List<CategoriaGetModels>> GetCatergories();
        ServiceResult<CategoriaGetModels> GetCatergoria(int Id);
        ServiceResult<CategoriaGetModels> SaveProduct();

    }
}
