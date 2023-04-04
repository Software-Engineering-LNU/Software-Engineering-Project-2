namespace EmployeestWeb.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    public class EmployeeController : Controller
    {
        public IActionResult Dashboard()
        {
            // Add your code to display the Employee dashboard page
            return this.View();
        }
    }
}
