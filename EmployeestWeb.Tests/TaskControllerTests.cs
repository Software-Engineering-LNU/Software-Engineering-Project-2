using EmployeestWeb.BLL.Interfaces;
using EmployeestWeb.Controllers;
using EmployeestWeb.DAL.Models;
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
            var test = new ModelTask();
            test.Id = 1111;
            test.Name = "Test task";
            test.UserId = 1;
            test.TeamId = 1;
            test.TeamId = 1;

            _taskServiceMock.Setup(serv => serv.CreateTask(test));
            _taskController = new TaskController(_taskServiceMock.Object);

            RedirectToActionResult result = (RedirectToActionResult)_taskController.Create(test);

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

    /*
     [Fact]
    public async Task Index_ReturnsAViewResult_WithoutRedirect()
    {
        var user = new ClaimsPrincipal();
        _homeController = new HomeController(_loggerMock.Object, _userServiceMock.Object);
        _homeController.ControllerContext = new ControllerContext()
        {
            HttpContext = new DefaultHttpContext() { User = user }
        };

        ViewResult result = (ViewResult)_homeController.Index();

        Assert.NotNull(result);
        Assert.IsAssignableFrom<IActionResult>(result);
        Assert.IsType<ViewResult>(result);
        Assert.True(string.IsNullOrEmpty(result.ViewName));
    }
     */
}
