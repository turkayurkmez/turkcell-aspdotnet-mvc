using eshop.MVC.Extensions;
using eshop.MVC.Models;
using eshop.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace eshop.MVC.Controllers
{
    public class ShoppingController : Controller
    {

        private readonly IProductService productService;

        public ShoppingController(IProductService productService)
        {
            this.productService = productService;
        }

        public IActionResult Index()
        {
            var collection = getCollectionFromSession();
            return View(collection);
        }

        public IActionResult AddToCard(int id)
        {

            var product = productService.GetProductForAddToCard(id);
            if (product == null)
            {
                return Json(new { message = $"{id} id'li ürün db'de bulunamadı!" });

            }

            ShoppingCardCollection collection = getCollectionFromSession();
            collection.Add(new CardItem { Product = product, Quantity = 1 });
            saveCollectionToSession(collection);

            //1. Koleksiyona ekle
            //2. Koleksiyonu Session'a ekle

            return Json(new { message = $"{product.Name} isimli ürünü sepete eklediğiniz bilgisi sepete eklendi!" });
        }

        private void saveCollectionToSession(ShoppingCardCollection collection)
        {
            //var serialized = JsonConvert.SerializeObject(collection);
            //HttpContext.Session.SetString("basket", serialized);

            HttpContext.Session.SetJson("basket", collection);
        }

        private ShoppingCardCollection getCollectionFromSession()
        {
            /*
             * eğer session'da varsa var olan koleksiyonu döndür.
             * yoksa yeni koleksiyon oluştur ve session'a at.
             */

            //if (!HttpContext.Session.Keys.Contains("basket"))
            //{
            //    return new ShoppingCardCollection();

            //}
            //var serializedJson = HttpContext.Session.GetString("basket");
            //return JsonConvert.DeserializeObject<ShoppingCardCollection>(serializedJson);

            return HttpContext.Session.GetJson<ShoppingCardCollection>("basket") ?? new ShoppingCardCollection();

        }
    }
}
