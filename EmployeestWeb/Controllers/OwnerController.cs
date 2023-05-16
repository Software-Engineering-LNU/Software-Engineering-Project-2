namespace EmployeestWeb.Controllers
{
    using EmployeestWeb.BLL.Interfaces;
    using EmployeestWeb.DAL.Models;
    using EmployeestWeb.Models;
    using Microsoft.AspNetCore.Mvc;
    using Serilog;

    public class OwnerController : Controller
    {
        private readonly IOwnerService ownerService;
        private OwnerViewModel ownerViewModel;

        public OwnerController(IOwnerService ownerService)
        {
            this.ownerService = ownerService;
            this.ownerViewModel = new OwnerViewModel();
        }

        [HttpGet]
        public IActionResult Dashboard(long userId)
        {
            Log.Information("OwnerController Dashboard {@userId}", userId);
            this.ownerViewModel.UserId = userId;
            string? userName = this.ownerService.GetUserName(userId);
            if (userName != null)
            {
                Log.Error("OwnerController InvalidUserName {@userId}", userId);
                this.ownerViewModel.FullName = userName;
                this.ownerViewModel.Projects = this.ownerService.GetProjects(userId);
                return this.View(this.ownerViewModel);
            }

            return this.View();
        }

        public IActionResult Workers()
        {
            Log.Information("OwnerController Workers");

            // Add your code to display the Employee workers page
            return this.View();
        }
    }
}
