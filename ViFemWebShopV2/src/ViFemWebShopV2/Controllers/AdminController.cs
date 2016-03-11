using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using ViFemWebShopV2.ViewModels;
using ViFemWebShopV2.Models;
using System.Diagnostics;
using Microsoft.AspNet.Http;

namespace ViFemWebShopV2.Controllers
{
    public class AdminController : Controller
    {
        EshopContext context;
        public AdminController(EshopContext context)
        {
            this.context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AddProduct()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddProduct(AddProductVM viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }

            try
            {
            DataManager dataManager = new DataManager(context);
            dataManager.AddProduct(viewModel);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, "Vi har tyvärr inte plats i lagret för denna produkt. Gå till styrelsen och begär att bygga ut.");
                Debug.WriteLine(ex.Message + " Inner: " + ex.InnerException.Message);
                return View(viewModel);
            }
            return RedirectToAction(nameof(AdminController.Index));

        }

        public IActionResult AddUser()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddUser(AddUserVM viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }

            try
            {
                DataManager dataManager = new DataManager(context);
                dataManager.AddUser(viewModel);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                Debug.WriteLine(ex.Message + " Inner: " + ex.InnerException.Message);
                return View(viewModel);
            }
            return RedirectToAction(nameof(AdminController.Index));
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginVM viewModel)
        {
            if (!ModelState.IsValid)
                return View(viewModel);

            DataManager dm = new DataManager(context);
            var user = dm.Login(viewModel);
            if (user != null)
                Response.Cookies.Append("userid", user.ClientID.ToString());
            else
                return View(viewModel);
            //CookieOptions cookieOptions = new CookieOptions();
            //cookieOptions.Expires.
            //  return RedirectToAction(nameof(ShopController.Index));
            //var cookie = Request.Cookies["userid"].Count() > 0;
            return RedirectToAction("Index", "Shop");
        }

        public IActionResult Logout()
        {
            CookieOptions co = new CookieOptions();
            co.Expires = DateTime.Now.AddDays(-1);
            Response.Cookies.Append("userid", "", co);

            return RedirectToAction("Index", "Shop");
        }
    }
}
