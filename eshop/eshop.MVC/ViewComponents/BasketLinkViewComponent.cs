﻿using eshop.MVC.Extensions;
using eshop.MVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace eshop.MVC.ViewComponents
{
    public class BasketLinkViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            var collection = HttpContext.Session.GetJson<ShoppingCardCollection>("basket") ?? new ShoppingCardCollection();

            return View(collection.TotalCount);

        }
    }
}
