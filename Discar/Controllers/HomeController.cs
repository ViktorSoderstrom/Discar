using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Discar.Models;

namespace Discar.Controllers
{
    public class HomeController : Controller
    {
        public DiscContext Context { get; set; }
        public HomeController(DiscContext context)
        {
            this.Context = context;
        }
        public IActionResult Index()
        {
            var brands = Context.Brands.AsEnumerable();

            return View(brands);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";
            ViewData["Title"] = "LOL";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }

        public IActionResult Lol()
        {
            ViewData["Lol"] = "Detta är ganska roligt!";
            return View();
        }

    }
}
