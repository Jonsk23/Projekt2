using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using ViFemWebShopV2.Models;
using ViFemWebShopV2.ViewModels;

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
