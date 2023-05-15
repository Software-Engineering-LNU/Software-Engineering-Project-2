namespace EmployeestWeb.Controllers
{
    using EmployeestWeb.BLL.Interfaces;
    using EmployeestWeb.Models;
    using Microsoft.AspNetCore.Mvc;
    using Serilog;

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
        public async Task<ActionResult> AddEmployee(AddEmployeeTeamViewModel model)
        {
            if (this.ModelState.IsValid)
            {
                try
                {
                    await this.teamService.AddEmployee(model.TeamId, model.Email);
                }
                catch (Exception ex)
                {
                    Log.Error(ex.Message);
                    this.ModelState.AddModelError(string.Empty, "Error in AddEmployee " + ex.Message);
                    return this.View(model);
                }

                return this.RedirectToAction("Home", "Home");
            }

            return this.View(model);
        }

        [HttpGet]
        public IActionResult RemoveEmployee(int userId)
        {
            var model = new RemoveEmployeeTeamViewModel
            {
                TeamId = 1,
                UserId = userId,
            };

            return this.View(model);
        }

        [HttpPost]
        public async Task<ActionResult> RemoveEmployee(RemoveEmployeeTeamViewModel model)
        {
            if (this.ModelState.IsValid)
            {
                try
                {
                    await this.teamService.RemoveEmployee(model.TeamId, model.Email, model.UserId);
                }
                catch (Exception ex)
                {
                    Log.Error(ex.Message);
                    this.ModelState.AddModelError(string.Empty, "Error in RemoveEmployee " + ex.Message);
                    return this.View(model);
                }

                return this.RedirectToAction("Home", "Home"); // TODO: Change route
            }

            return this.View(model);
        }
    }
}
