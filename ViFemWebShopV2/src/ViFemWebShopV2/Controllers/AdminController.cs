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
        EshopContext productContext;
        public AdminController(EshopContext context)
        {
            productContext = context;
        }
        // GET: /<controller>/
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
                return View(viewModel);
            DataManager dataManager = new DataManager(productContext);
            dataManager.AddProduct(viewModel);
            return RedirectToAction(nameof(AdminController.Index));
            
        }
    }
}
