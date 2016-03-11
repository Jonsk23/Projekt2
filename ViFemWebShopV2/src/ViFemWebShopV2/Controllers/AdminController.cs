using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using ViFemWebShopV2.ViewModels;
using ViFemWebShopV2.Models;
using System.Diagnostics;
using Microsoft.AspNet.Http;
using Microsoft.AspNet.Mvc.Rendering;

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
            var model = new AddProductVM();
            model.Categories = new SelectListItem[]
            {
                new SelectListItem { Text ="Papper och block", Value="Papper Block" },
                new SelectListItem { Text ="Pennor och ritmaterial", Value="Pennor Ritmaterial" },
                new SelectListItem { Text ="Sorting och förvaring", Value="Sortering Förvaring" }
            };
            return View(model);
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
                string msg = "\n ***** \n " + ((ex.InnerException == null) ? ex.Message : ex.Message + ", INNER exception: " + ex.InnerException.Message) + "\n*******";
                ModelState.AddModelError(string.Empty, msg);
                Debug.WriteLine(msg);

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
                string msg = "\n ***** \n " + ((ex.InnerException == null) ? ex.Message : ex.Message + ", INNER exception: " + ex.InnerException.Message) + "\n*******";

                ModelState.AddModelError(string.Empty, msg);
                Debug.WriteLine(msg);
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
