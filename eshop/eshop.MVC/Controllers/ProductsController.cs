using eshop.Services;
using eshop.Services.DataTransferObjects.Request;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace eshop.MVC.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ICategoryService categoryService;
        private readonly IProductService productService;

        public ProductsController(ICategoryService categoryService, IProductService productService)
        {
            this.categoryService = categoryService;
            this.productService = productService;
        }

        public async Task<IActionResult> Index()
        {
            var products = await productService.GetProductsAsync();
            return View(products);
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Categories = GetCategorySelectListItems();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateNewProductRequest request)
        {
            if (ModelState.IsValid)
            {
                await productService.CreateAsync(request);
                return Redirect(nameof(Index));
            }
            ViewBag.Categories = GetCategorySelectListItems();
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            ViewBag.Categories = GetCategorySelectListItems();
            var product = await productService.GetProductForAddToCardAsync(id);
            UpdateProductRequest updateProductRequest = new UpdateProductRequest
            {
                Description = product.Description,
                DiscountRate = product.DiscountRate,
                ImageUrl = product.ImageUrl,
                Id = product.Id,
                Name = product.Name,
                Price = product.Price

            };
            return View(updateProductRequest);
        }

        IEnumerable<SelectListItem> GetCategorySelectListItems()
        {
            return categoryService.GetCategories().Select(c => new SelectListItem { Text = c.Name, Value = c.Id.ToString() });

        }
    }
}
