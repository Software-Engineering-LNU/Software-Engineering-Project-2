namespace EmployeestWeb.Controllers
{
    using EmployeestWeb.BLL.Interfaces;
    using EmployeestWeb.Models;
    using Microsoft.AspNetCore.Mvc;

    public class OwnerController : Controller
    {
        private readonly IOwnerService ownerService;
        private OwnerViewModel ownerViewModel;

        public OwnerController(IOwnerService ownerService)
        {
            this.ownerService = ownerService;
            this.ownerViewModel = new OwnerViewModel();
        }

        public IActionResult Dashboard(long userId)
        {
            this.ownerViewModel.UserId = userId;
            string? userName = this.ownerService.GetUserName(userId);
            if (userName != null)
            {
                this.ownerViewModel.FullName = userName;
                this.ownerViewModel.Projects = this.ownerService.GetProjects(userId);
                return this.View(this.ownerViewModel);
            }

            return this.View();
        }

        public IActionResult Workers()
        {
            // Add your code to display the Employee workers page
            return this.View();
        }
    }
}
