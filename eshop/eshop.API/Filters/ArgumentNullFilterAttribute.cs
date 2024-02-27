using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace eshop.API.Filters
{
    public class ArgumentNullFilterAttribute : ExceptionFilterAttribute
    {
        //1. Exception Filter: Action içinde bir hata meydana geldiği zaman....
        //2. ResultFilter....
        //3. ActionFilter


        public override void OnException(ExceptionContext context)
        {
            if (context.Exception is ArgumentNullException)
            {

                context.Result = new BadRequestObjectResult(new { error = "parametre null olamaz!" });


            }
            base.OnException(context);
        }
    }
}
