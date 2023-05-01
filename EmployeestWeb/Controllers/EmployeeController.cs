namespace EmployeestWeb.Controllers
{
    using EmployeestWeb.BLL.Interfaces;
    using EmployeestWeb.Models;
    using Microsoft.AspNetCore.Mvc;
    using Serilog;

    public class EmployeeController : Controller
    {
        private readonly ITaskService taskService;
        private readonly IUserService userService;

        public EmployeeController(ITaskService taskService, IUserService userService)
        {
            this.taskService = taskService;
            this.userService = userService;
        }

        public IActionResult Dashboard(long userId)
        {
            // Add your code to display the Employee dashboard page
            var user = this.userService.GetUser(userId);
            return this.View(user);
        }
    }
}
