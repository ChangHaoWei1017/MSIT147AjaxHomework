using Microsoft.AspNetCore.Mvc;
using MSIT14720230714.Models;
using System.Diagnostics;

namespace MSIT14720230714.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        public IActionResult Homework1()
        {
            return View();
        }
        public IActionResult Homework2()
        {
            return View();
        }
        public IActionResult Homework4()
        {
            return View();
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult First()
        {
            return View();
        }
        public IActionResult AjaxEvent()
        {
            return View();
        }
        public IActionResult Address()
        {
            return View();
        }
        public IActionResult Register()
        {
            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult Fetch()
        {
            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}