using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using ViFemWebShopV2.ViewModels;
using ViFemWebShopV2.Models;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace ViFemWebShopV2.Controllers
{
    public class AdminController : Controller
    {
        UserAccountContext userAccountContext;
        ProductContext productContext;

        public AdminController(UserAccountContext context)
        {
            userAccountContext = context;
        }
        public AdminController(ProductContext context)
        {
            productContext = context;
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
            DataManager dataManager = new DataManager(productContext);
            dataManager.AddProduct(viewModel);
            }
            catch (Exception)
            {
                ModelState.AddModelError(string.Empty, "Vi har tyvärr inte plats i lagret för denna produkt. Gå till styrelsen och begär att bygga ut.");
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
                DataManager dataManager = new DataManager(userAccountContext);
                dataManager.AddUser(viewModel);
            }
            catch (Exception)
            {
                ModelState.AddModelError(string.Empty, "You don't want your business.");
                return View(viewModel);
            }
            return RedirectToAction(nameof(AdminController.Index));
            
        }
    }
}
