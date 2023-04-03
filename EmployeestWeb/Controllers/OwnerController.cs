namespace EmployeestWeb.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    public class OwnerController : Controller
    {
        public IActionResult Dashboard()
        {
            // Add your code to display the Employee dashboard page
            return this.View();
        }
    }
}
