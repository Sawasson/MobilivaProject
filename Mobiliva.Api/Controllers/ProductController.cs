using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Mobiliva.Business.Contracts;
using Mobiliva.Common.Cache;
using Mobiliva.DataAccess.Data;
using Mobiliva.Models;

namespace Mobiliva.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {

        private readonly IProductRepository _productRepository;
        

        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpGet("getproducts")]
        public async Task<IActionResult> GetProducts(string? category=null)
        {
                var allProducts = _productRepository.GetAllProduct(category);
                var data = allProducts;
                return Ok(data);
        }

    }
}
