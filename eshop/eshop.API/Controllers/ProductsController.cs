using eshop.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eshop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {

        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }


        //1. Tüm ürünleri getir:

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetProducts()
        {
            var products = await _productService.GetProductsAsync();
            return Ok(products);
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetProduct(int id)
        {
            var product = await _productService.GetProductForAddToCardAsync(id);
            if (product == null)
            {
                return NotFound(new { message = $"{id} id'li ürün db'de yok! " });
            }
            return Ok(product);
        }

        [HttpGet("[action]/{categoryId:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]

        public async Task<IActionResult> GetProductByCategory(int categoryId)
        {
            var products = await _productService.GetProductCardsByCategoryAsync(categoryId);
            return Ok(products);
        }

        [HttpGet("[action]/{name}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Search(string name)
        {
            var products = await _productService.Search(name);
            return Ok(products);
        }

        //RESTful 


    }
}
