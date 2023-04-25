namespace EmployeestWeb.Controllers
{
    using EmployeestWeb.BLL.Interfaces;
    using EmployeestWeb.DAL.Models;
    using EmployeestWeb.Models;
    using Microsoft.AspNetCore.Mvc;

    public class EmployeeController : Controller
    {
        private readonly IEmployeeService employeeService;
        private readonly ITaskService taskService;
        private readonly IUserService userService;
        private EmployeeViewModel employeeViewModel;

        public EmployeeController(IEmployeeService employeeService, ITaskService taskService, IUserService userService)
        {
            this.employeeService = employeeService;
            this.taskService = taskService;
            this.userService = userService;
            this.employeeViewModel = new EmployeeViewModel();
        }

        [HttpGet]
        public IActionResult Dashboard(long userId)
        {
            this.employeeViewModel.UserId = userId;
            string? userName = this.employeeService.GetUserName(userId);
            if (userName != null)
            {
                this.employeeViewModel.FullName = userName;
                this.employeeViewModel.Projects = this.employeeService.GetProjects(userId);
                this.employeeViewModel.Tasks = this.employeeService.GetTasks(userId);
                this.employeeViewModel.Teams = this.employeeService.GetTeams(userId);
                return this.View(this.employeeViewModel);
            }

            return this.View();
        }
    }
}
