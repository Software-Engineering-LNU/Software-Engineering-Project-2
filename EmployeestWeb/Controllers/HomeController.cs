namespace EmployeestWeb.Controllers
{
    using System.Diagnostics;
    using EmployeestWeb.Models;
    using Microsoft.AspNetCore.Mvc;

    public class HomeController : Controller
    {
        private readonly ILogger logger;

        public HomeController(ILogger<HomeController> logger)
        {
            this.logger = logger;
        }

        public IActionResult Index()
        {
            return this.View();
        }

        public IActionResult Privacy()
        {
            return this.View();
        }

        public ILogger GetLogger()
        {
            return logger;
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return this.View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? this.HttpContext.TraceIdentifier });
        }
    }
}