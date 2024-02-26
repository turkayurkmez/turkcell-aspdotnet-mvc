using eshop.Entities;
using eshop.MVC.Models;
using eshop.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace eshop.MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IProductService _productService;

        public HomeController(ILogger<HomeController> logger, IProductService productService)
        {
            _logger = logger;
            _productService = productService;
        }


        public IActionResult Index(int page = 1, int? category = null)
        {

            var products = category == null ? _productService.GetProducts() :
                                              _productService.GetProductCardsByCategory(category.Value);
            var info = new PagingInfo
            {
                TotalCount = products.Count(),
                PageSize = 3,
                ActivePage = page
            };

            /*
             * 1. sayfada koleksiyonda 0   atla 2 al
             * 2.                      2   atla 2 al
             * 3.  ....................4   atla 2 al
             * 
             */

            var first = (page - 1) * info.PageSize;
            var last = first + info.PageSize;

            //burada, Skip fonksiyonu var:
            var paginated = products.OrderBy(p => p.Id)
                                    .Skip(first)
                                    .Take(info.PageSize)
                                    .ToList();

            //burada ise Range tekniği var... 
            var paginated2 = products.OrderBy(p => p.Id)
                                     .Take(first..last)
                                     .ToList();


            ViewBag.Category = category;

            var viewModel = new IndexViewModel()
            {
                PagingInfo = info,
                ProductCardResponses = paginated2
            };



            return View(viewModel);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
