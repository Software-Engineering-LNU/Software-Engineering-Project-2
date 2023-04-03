namespace EmployeestWeb.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    public class OwnerController : Controller
    {
        public IActionResult Workers()
        {
            // Add your code to display the Employee dashboard page
            return this.View();
        }
    }
}
