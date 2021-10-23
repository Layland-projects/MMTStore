using Store.Application.DTOs.Create;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Services
{
    public interface IFeaturedProductService
    {
        Task<int> CreateNewFeaturedProduct(FeaturedProductDTO_Create obj);
    }
}
