﻿namespace EmployeestWeb.Controllers
{
    using System.Diagnostics;
    using EmployeestWeb.Models;
    using Microsoft.AspNetCore.Mvc;

    public class AuthorizationController : Controller
    {
        private readonly ILogger logger;

        public AuthorizationController(ILogger<HomeController> logger)
        {
            this.logger = logger;
        }

        public IActionResult SignIn()
        {
            return this.View();
        }

        public IActionResult SignUp()
        {
            return this.View();
        }

        public ILogger GetLogger()
        {
            return this.logger;
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return this.View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? this.HttpContext.TraceIdentifier });
        }
    }
}