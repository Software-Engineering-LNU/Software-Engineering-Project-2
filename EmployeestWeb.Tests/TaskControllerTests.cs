using EmployeestWeb.BLL.Interfaces;
using EmployeestWeb.Controllers;
using EmployeestWeb.DAL.Models;
using EmployeestWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Moq;

using ModelTask = EmployeestWeb.DAL.Models.Task;

namespace EmployeestWeb.Tests
{
    public class TaskControllerTests
    {
        private TaskController _taskController;
        private readonly Mock<ITaskService> _taskServiceMock;

        public TaskControllerTests()
        {
            _taskServiceMock = new Mock<ITaskService>();
        }

        [Fact]
        public void AddTask_RedirectToActionResult()
        {
            var task = new ModelTask();
            var model = new AddTaskViewModel();
            task.Id = model.Id = 1111;
            task.Name = model.Name = "Test task";
            task.Description = model.Description = "Test description";
            task.UserId = model.UserId = 1;
            task.TeamId = model.TeamId = 1;
            task.Status = model.Status = "New";

            _taskServiceMock.Setup(serv => serv.CreateTask(task));
            _taskController = new TaskController(_taskServiceMock.Object);

            RedirectToActionResult result = (RedirectToActionResult)_taskController.Create(model);

            Assert.NotNull(result);
            Assert.IsAssignableFrom<IActionResult>(result);
            Assert.IsType<RedirectToActionResult>(result);
        }

        [Fact]
        public void DeleteTask_NotFoundResult()
        {
            var test = new ModelTask();
            test.Id = 1111;

            _taskServiceMock.Setup(serv => serv.DeleteTask(test.Id));
            _taskController = new TaskController(_taskServiceMock.Object);

            var result = (NotFoundResult)_taskController.Delete(test.Id);

            Assert.NotNull(result);
            Assert.IsAssignableFrom<IActionResult>(result);
            Assert.IsType<NotFoundResult>(result);
        }
    }
}
