namespace EmployeestWeb.Controllers
{
    using AutoMapper;
    using EmployeestWeb.BLL.Models;
    using EmployeestWeb.BLL.Services.Interfaces;
    using EmployeestWeb.DAL.Models;
    using EmployeestWeb.Models;
    using Microsoft.AspNetCore.Mvc;

    public class WorkerController : Controller
    {
        private readonly IWorkerService workerService;
        private readonly IMapper mapper;

        public WorkerController(IMapper mapper, IWorkerService workerService)
        {
            this.mapper = mapper;
            this.workerService = workerService;
        }

        [HttpGet]
        public IActionResult AddEmployee()
        {
            return this.PartialView();
        }

        [HttpPost]
        public IActionResult AddEmployee(AddEmployeeModel model)
        {
            if (this.ModelState.IsValid)
            {
                this.workerService.AddEmployee(this.mapper.Map<User>(model));
            }

            return this.View(model); // TODO: Change route
        }

        [HttpGet]
        public IActionResult FireEmployee()
        {
            return this.PartialView();
        }

        [HttpPost]
        public async Task<IActionResult> FireEmployee(string propertyName, string propertyValue)
        {
            if (this.ModelState.IsValid)
            {
                Models.FireEmployeeModel model = new Models.FireEmployeeModel();

                var propInfo = typeof(Models.FireEmployeeModel).GetProperty(propertyName);
                if (propInfo != null)
                {
                    propInfo.SetValue(model, propertyValue);
                }

                await this.workerService.FireEmployeeByFireEmployeeModel(this.mapper.Map<BLL.Models.FireEmployeeModel>(model));
            }

            return this.RedirectToAction("Index", "Home"); // TODO: Change route
        }
    }
}
