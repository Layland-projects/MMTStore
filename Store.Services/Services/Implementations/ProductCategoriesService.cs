using Store.Application.DTOs;
using Store.Infrastructure.Persistence.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Services.Implementations
{
    public class ProductCategoriesService : IProductCategoriesService
    {
        readonly IProductCategoryRepository productCatRepo;
        public ProductCategoriesService(IProductCategoryRepository productCatRepo)
        {
            this.productCatRepo = productCatRepo;
        }
        public async Task<IEnumerable<ProductCategoryDTO_Flat>> GetProductCategories_Flat()
        {
            return await productCatRepo.GetProductCategories<ProductCategoryDTO_Flat>();
        }
    }
}
