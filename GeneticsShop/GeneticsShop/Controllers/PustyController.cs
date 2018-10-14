using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace GeneticsShop.Controllers
{
    public class PustyController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Extra()
        {
            return View();
        }

        public IActionResult Power(int? id)
        {
            ViewBag.ID = id;
            return View("Extra");
        }
    }
}