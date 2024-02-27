using eshop.API.Filters;
using eshop.Services;
using eshop.Services.DataTransferObjects.Request;
using eshop.Services.DataTransferObjects.Response;
using Microsoft.AspNetCore.Authorization;
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
        //Representational State Transfer 
        [Authorize(Roles = "Admin,Editor")]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Create(CreateNewProductRequest createNewProductRequest)
        {
            if (ModelState.IsValid)
            {
                var lastProductId = await _productService.CreateAsync(createNewProductRequest);
                return CreatedAtAction(nameof(GetProduct), routeValues: new { id = lastProductId }, value: null);

            }

            return BadRequest(ModelState);
        }
        [Authorize(Roles = "Admin,Editor")]
        [IsExists]
        [HttpPut("{id}")] //idempotent
        public async Task<IActionResult> Update(int id, UpdateProductRequest updateProductRequest)
        {

            if (ModelState.IsValid)
            {
                await _productService.UpdateAsync(updateProductRequest);
                return Ok(updateProductRequest);
            }
            return BadRequest(ModelState);

        }
        [Authorize(Roles = "Admin,Editor")]
        [IsExists]
        [HttpDelete]//idempotent
        public async Task<IActionResult> Delete(int id)
        {

            await _productService.DeleteAsync(id);
            return Ok(new { message = "Ürün silindi" });

        }

        //[ArgumentNullFilter()]
        //[HttpGet("[action]")]
        //public async Task<IActionResult> Test()
        //{
        //    throw new ArgumentNullException("hatalı talep!");

        //}


    }
}
