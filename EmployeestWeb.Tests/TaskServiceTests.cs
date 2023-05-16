using EmployeestWeb.BLL.Services;
using EmployeestWeb.DAL.Interfaces;
using EmployeestWeb.DAL.Models;
using Moq;
using Task = EmployeestWeb.DAL.Models.Task;

namespace EmployeestWeb.Tests
{
    public class TaskServiceTests
    {
        private readonly Mock<ITaskRepository> taskRepositoryMock;
        private readonly Mock<IUserRepository> userRepositoryMock;
        private readonly TaskService taskService;

        public TaskServiceTests()
        {
            taskRepositoryMock = new Mock<ITaskRepository>();
            userRepositoryMock = new Mock<IUserRepository>();
            taskService = new TaskService(taskRepositoryMock.Object, userRepositoryMock.Object);
        }
        [Fact]
        public void GetTaskById_ForExistedTask_ReturnsCorrectTask()
        {
            taskRepositoryMock.Setup(repository => repository.GetTaskById(1)).Returns(new Task
            {
                Id = 1,
                Name = "Test",
                Description = "Test",
                Status = "New",
                UserId = 1,
                TeamId = 1,
            });

            var result = taskService.GetTaskById(1);
            var expected = new Task
            {
                Id = 1,
                Name = "Test",
                Description = "Test",
                Status = "New",
                UserId = 1,
                TeamId = 1,
            };

            Assert.Equal(expected, result);
        }

        [Fact]
        public void GetTaskById_ForNotExistedTask_ReturnsNull()
        {
            taskRepositoryMock.Setup(repository => repository.GetTaskById(2)).Throws(new InvalidOperationException());

            Assert.Throws<InvalidOperationException>(() => taskService.GetTaskById(2));
        }
    }
}