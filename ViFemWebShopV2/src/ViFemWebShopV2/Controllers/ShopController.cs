using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;

namespace ViFemWebShopV2.Controllers
{
    public class ShopController : Controller
    {

        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Products()
        {
            return View();
        }

        public IActionResult Kundvagn()
        {
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }
        //public IActionResult Category()
        //{

        //}

        //public IActionResult Category(string Category)
        //{

        //}
    }
}
