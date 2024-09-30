using SalesOnline.Application.Core;
using SalesOnline.Application.Models.Category;
using SalesOnline.Application.Models.Producto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesOnline.Application.Contract
{
    internal interface ProducService
    {
        ServiceResult<List<ProducGetModel>> GetProducts();
        ServiceResult<ProducGetModel> GetProduct(int Id);
        ServiceResult<ProducGetModel> SaveProduct();
        
    }
}
