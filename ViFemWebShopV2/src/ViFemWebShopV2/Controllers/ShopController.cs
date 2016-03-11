using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using ViFemWebShopV2.Models;

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
            DataManager dataManager = new DataManager(context);
            var viewModel = dataManager.ListProducts();
            return View(viewModel);
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
            return View();
        }
        public IActionResult Tempproducts()
        {
            DataManager dataManager = new DataManager(context);
            var viewModel = dataManager.ListProducts();
            return View(viewModel);
        }
    }
}
