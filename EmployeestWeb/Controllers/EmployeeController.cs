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
