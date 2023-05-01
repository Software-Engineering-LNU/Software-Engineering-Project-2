namespace EmployeestWeb.Controllers
{
    using EmployeestWeb.BLL.Interfaces;
    using EmployeestWeb.Models;
    using Microsoft.AspNetCore.Mvc;

    public class TeamController : Controller
    {
        private readonly ITeamService teamService;

        public TeamController(ITeamService teamService)
        {
            this.teamService = teamService;
        }

        [HttpGet]
        public IActionResult AddEmployee()
        {
            var model = new AddEmployeeTeamViewModel
            {
                TeamId = 1,
            };

            return this.View(model);
        }

        [HttpPost]
        public IActionResult AddEmployee(AddEmployeeTeamViewModel model)
        {
            if (this.ModelState.IsValid)
            {
                try
                {
                    this.teamService.AddEmployee(model.TeamId, model.Email);
                }
                catch (Exception ex)
                {
                    return this.View(new ErrorViewModel { Message = ex.Message });
                }
            }

            return this.RedirectToAction("Home", "Home"); // TODO: Change route
        }
    }
}
