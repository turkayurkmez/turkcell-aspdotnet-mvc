using eshop.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace eshop.API.Filters
{
    public class IsExistsFilter : IAsyncActionFilter
    {

        private readonly IProductService _productService;

        public IsExistsFilter(IProductService productService)
        {
            _productService = productService;
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            if (context.ActionArguments.ContainsKey("id"))
            {
                var id = (int)context.ActionArguments["id"];

                if (await _productService.ProductIsExists(id))
                {
                    await next();

                }
                else
                {
                    context.Result = new BadRequestObjectResult(new { message = $"{id} id'li ürün bulunamadı!" });
                }


            }
            else
            {
                context.Result = new BadRequestObjectResult(new { message = "fonksiyonda id parametresi olmalı" });
            }

        }
    }
}
