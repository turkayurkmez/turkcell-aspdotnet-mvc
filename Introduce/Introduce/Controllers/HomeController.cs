using Introduce.Models;
using Microsoft.AspNetCore.Mvc;

namespace Introduce.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.UserName = "Türkay";
            ViewBag.IsTurkey = true;


            return View();
        }
        [HttpGet]
        public IActionResult Response()
        {
            //HTML - CSS - JS
            //JSON
            //400 -> Durum kodları
            //Dosya
            //Başka URL yönlendirmeli.

            return View();

        }

        [HttpPost]
        public IActionResult Response(UserResponse userResponse)
        {

            if (ModelState.IsValid)
            {
                return View("Thanks", userResponse);
            }



            return View();

        }




    }
}
