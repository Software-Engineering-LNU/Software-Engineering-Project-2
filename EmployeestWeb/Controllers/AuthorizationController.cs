namespace EmployeestWeb.Controllers
{
    using System.Diagnostics;
    using EmployeestWeb.BLL.Interfaces;
    using EmployeestWeb.DAL.Models;
    using EmployeestWeb.Models;
    using Microsoft.AspNetCore.Mvc;

    public class AuthorizationController : Controller
    {
        private readonly IUserService userService;

        public AuthorizationController(IUserService userService)
        {
            this.userService = userService;
        }

        public IActionResult SignIn()
        {
            return this.View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SignIn(string email, string password)
        {
            if (this.ModelState.IsValid)
            {
                User? user = this.userService.AuthorizeUser(email, password);
                if (user != null)
                {
                    if (user.IsBusinessOwner)
                    {
                        return this.RedirectToAction("Dashboard", "Owner", new { userId = user.Id });
                    }
                    else
                    {
                        return this.RedirectToAction("Dashboard", "Employee", new { userId = user.Id });
                    }
                }
                else
                {
                    this.ModelState.AddModelError("InvalidSignIn", "Invalid login or password!");
                }
            }

            return this.View();
        }
        public IActionResult SignUp()
        {
            return this.View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SignUp(User user, string password)
        {
            if (user.Password.Equals(password) && this.ModelState.IsValid)
            {
                User? registeredUser = this.userService.RegisterUser(user);
                if (registeredUser != null)
                {
                    return this.RedirectToAction("Dashboard", "Owner", new { userId = registeredUser.Id });
                }
                else
                {
                    this.ModelState.AddModelError("InvalidSignUp", "This user already exist!");
                }
            }

            return this.View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return this.View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? this.HttpContext.TraceIdentifier });
        }
    }
}
