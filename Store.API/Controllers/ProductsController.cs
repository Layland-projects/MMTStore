using Microsoft.AspNetCore.Mvc;
using Store.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Store.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductsController : ControllerBase
    {
        [HttpGet]
        [Route("featured")]
        public async Task<IActionResult> GetFeaturedProducts([FromServices] IProductService prodService)
        {
            var prods = await prodService.GetFlatFeaturedProducts();
            if (prods == null)
                return NotFound();
            return Ok(prods);
        }

        [HttpGet]
        [Route("categoryId/{id:int}")]
        public async Task<IActionResult> GetProductById([FromServices] IProductService prodService, [FromRoute] int id)
        {
            var prods = await prodService.GetProductsByCategoryId(id);
            if (prods == null)
                return NotFound();
            return Ok(prods);
        }

        [HttpGet]
        [Route("categoryName/{name}")]
        public async Task<IActionResult> GetProductsByName([FromServices] IProductService prodService, [FromRoute] string name)
        {
            var prods = await prodService.GetProductsByCategoryName(name);
            if (prods == null)
                return NotFound();
            return Ok(prods);
        }
    }
}
