using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LocalizationTest.Models;
using Microsoft.Extensions.Localization;
using Microsoft.AspNetCore.Localization;

namespace LocalizationTest.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            ViewData["Welcome"] = _stringLocalizer["Kuy"].Value;
            ViewData["Welcome2"] = _stringLocalizer["Kuy"].Value;
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        private readonly IStringLocalizer<HomeController> _stringLocalizer;
        public HomeController(IStringLocalizer<HomeController> stringLocalizer)
        {
            _stringLocalizer = stringLocalizer;
        }

        public string Chen()
        {
            return _stringLocalizer.GetString("Hello");
        }

        public string Chen2()
        {
            var culture = Request.HttpContext.Features.Get<IRequestCultureFeature>().RequestCulture.Culture;
            return culture.ToString();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
