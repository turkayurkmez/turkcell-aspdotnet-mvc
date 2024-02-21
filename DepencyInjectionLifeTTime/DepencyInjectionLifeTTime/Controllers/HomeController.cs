using DepencyInjectionLifeTTime.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace DepencyInjectionLifeTTime.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ISingleton singleton;
        private readonly ITransient transient;
        private readonly IScoped scoped;
        private readonly GuidService guidService;

        public HomeController(ILogger<HomeController> logger,
             ISingleton singleton,
             ITransient transient,
             IScoped scoped,

             GuidService guidService
             )
        {
            _logger = logger;
            this.singleton = singleton;
            this.transient = transient;
            this.scoped = scoped;
            this.guidService = guidService;
        }

        public IActionResult Index()
        {
            ViewBag.Singleton = singleton.Guid.ToString();
            ViewBag.Transient = transient.Guid.ToString();
            ViewBag.Scoped = scoped.Guid.ToString();


            ViewBag.ServiceSingleton = guidService.Singleton.Guid.ToString();
            ViewBag.ServiceTransient = guidService.Transient.Guid.ToString();
            ViewBag.ServiceScoped = guidService.Scoped.Guid.ToString();



            return View();
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
