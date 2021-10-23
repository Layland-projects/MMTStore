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
    public class ProductCategoriesController : ControllerBase
    {
        [Route("")]
        [HttpGet]
        public async Task<IActionResult> GetAll([FromServices] IProductCategoriesService prodCatService)
        {
            var results = await prodCatService.GetProductCategories_Flat();
            if (results == null || !results.Any())
                return NotFound();
            return Ok(results);
        }
    }
}
