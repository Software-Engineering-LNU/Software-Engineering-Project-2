namespace EmployeestWeb.Controllers
{
    using EmployeestWeb.BLL.Interfaces;
    using EmployeestWeb.BLL.Services;
    using EmployeestWeb.DAL.Models;
    using EmployeestWeb.Models;
    using Microsoft.AspNetCore.Mvc;

    public class EmployeeController : Controller
    {
        private readonly IEmployeeService employeeService;
        private EmployeeViewModel employeeViewModel;

        public EmployeeController(IEmployeeService employeeService)
        {
            this.employeeService = employeeService;
            this.employeeViewModel = new EmployeeViewModel();
        }

        public IActionResult Dashboard(long userId)
        {
            // Add your code to display the Employee dashboard page
            this.employeeViewModel.UserId = userId;
            this.employeeViewModel.FullName = this.employeeService.GetUserName(userId);
            this.employeeViewModel.Projects = this.employeeService.GetProjects(userId);
            this.employeeViewModel.Tasks = this.employeeService.GetTasks(userId);
            this.employeeViewModel.Teams = this.employeeService.GetTeams(userId);
            return this.View(this.employeeViewModel);
        }
    }
}
