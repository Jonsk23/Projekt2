using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using ViFemWebShopV2.Models;
using ViFemWebShopV2.ViewModels;
using Newtonsoft.Json;
using Microsoft.AspNet.Http;

namespace ViFemWebShopV2.Controllers
{
    public class ShopController : Controller
    {
        EshopContext context;
        public ShopController(EshopContext context)
        {
            this.context = context;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Products()
        {
            //DataManager dataManager = new DataManager(context);
            DataManager dataManager = new DataManager(context);
            var viewModel = dataManager.ListProducts();
            return View(viewModel);
        }

        public IActionResult AddToCart(string name)
        {
            DataManager dm = new DataManager(context);
            dm.AddToCart(name, Request.Cookies["username"].ToString());
            Response.Cookies.Append("cart", $"{Request.Cookies["username"].ToString()}");
            return RedirectToAction(nameof(ShopController.Products));
        }
        public IActionResult Cart()
        {
            DataManager dm = new DataManager(context);

            return View(dm.GetCart(Request.Cookies["username"].ToString()));
        }
        public IActionResult ProductCategory(string category)
        {
            return View();
        }

        public IActionResult Checkout()
        {
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }

        public IActionResult RegisterAsCustomer()
        {
            return View();
        }

        public IActionResult Profiles()
        {
            DataManager dm = new DataManager(context);
            UserProfileVM vm = null;
            if (Request.Cookies["username"].Count() > 0)
                vm = dm.MyProfile(Request.Cookies["username"].ToString());
            return View(vm);
        }


        public IActionResult Tempproducts()
        {
            DataManager dataManager = new DataManager(context);
            var viewModel = dataManager.ListProducts();
            return View(viewModel);
        }
    }
}
