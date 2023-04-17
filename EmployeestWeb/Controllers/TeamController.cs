namespace EmployeestWeb.Controllers
{
    using EmployeestWeb.BLL.Services.Interfaces;
    using EmployeestWeb.Models;
    using Microsoft.AspNetCore.Mvc;

    public class TeamController : Controller
    {
        private readonly ITeamService teamService;

        private int teamId = 1;  // TODO: Change this

        public TeamController(ITeamService teamService)
        {
            this.teamService = teamService;
        }

        [HttpGet]
        public IActionResult AddEmployee()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult AddEmployee(AddEmployeeTeamModel model)
        {
            if (this.ModelState.IsValid)
            {
                this.teamService.AddEmployee(this.teamId, model.Email);
            }

            return this.View(); // TODO: Change route
        }
    }
}
