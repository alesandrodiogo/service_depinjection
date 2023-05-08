using Microsoft.AspNetCore.Mvc;
using service_depinjection.Models;
using System.Diagnostics;

namespace service_depinjection.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly IDateTime _dateTime;

        public HomeController(ILogger<HomeController> logger, IDateTime dateTime)
        {
            _logger = logger;
            _dateTime = dateTime;
        }

        public IActionResult Index()
        {
            var serverTime = DateTime.Now;
            if(serverTime.Hour < 12)
            {
                ViewData["Message"] = "It's morning here - Good Morning!";
            }

            else if(serverTime.Hour < 17 ) {
                ViewData["Message"] = "It's afternoon here - Good Afternoon!";
            }
            else
            {
                ViewData["Message"] = "It's evening here - Good Evening!";
            }
            return View();
        }

        public IActionResult Privacy()
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