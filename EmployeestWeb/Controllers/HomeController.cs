namespace EmployeestWeb.Controllers
{
    using System.Diagnostics;
    using EmployeestWeb.DAL.Models;
    using EmployeestWeb.Models;
    using Microsoft.AspNetCore.Mvc;
    using Serilog;

    public class HomeController : Controller
    {
        public IActionResult Home()
        {
            Log.Information("HomeController Home");
            return this.View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            Log.Information("HomeController Error");
            return this.View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? this.HttpContext.TraceIdentifier });
        }
    }
}