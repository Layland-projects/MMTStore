using Store.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Services
{
    public interface IProductCategoriesService
    {
        Task<IEnumerable<ProductCategoryDTO_Flat>> GetProductCategories_Flat();
    }
}
