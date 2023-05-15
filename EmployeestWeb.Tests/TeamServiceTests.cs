
using EmployeestWeb.BLL.Services;
using EmployeestWeb.DAL.Interfaces;
using EmployeestWeb.DAL.Models;
using Moq;

namespace EmployeestWeb.Tests
{
    public class TeamServiceTests
    {
        private readonly Mock<ITeamRepository> teamRepositoryMock;
        private readonly Mock<IWorkerRepository> workerRepositoryMock;
        private readonly TeamService teamService;

        private static readonly int testTeamId = 1;
        private static readonly int testUserId = 2;
        private static readonly string testEmail = "sergiy@gmail.com";

        public TeamServiceTests()
        {
            teamRepositoryMock = new Mock<ITeamRepository>();
            workerRepositoryMock = new Mock<IWorkerRepository>();
            teamService = new TeamService(teamRepositoryMock.Object, workerRepositoryMock.Object);
        }
        
        [Fact]
        public async System.Threading.Tasks.Task AddEmployee_UserExists_AddsEmployeeToTeam()
        {
            // Arrange
            var user = new User { Id = testUserId, Email = testEmail };
            workerRepositoryMock.Setup(x => x.GetEmployeeByEmail(testEmail)).ReturnsAsync((User)user);

            // Act
            await teamService.AddEmployee(testTeamId, testEmail);

            // Assert
            teamRepositoryMock.Verify(x => x.AddEmployee(It.Is<TeamMember>(tm => tm.TeamId == testTeamId && tm.UserId == testUserId)), Times.Once);
        }

        [Fact]
        public void AddEmployee_UserNotFound_ThrowsException()
        {
            // Arrange
            var user = new User { Id = testUserId, Email = testEmail };
            workerRepositoryMock.Setup(x => x.GetEmployeeByEmail(testEmail)).ReturnsAsync((User)null);

            // Act & Assert
            Assert.ThrowsAsync<Exception>(() => teamService.AddEmployee(testTeamId, testEmail));
        }

        [Fact]
        public async System.Threading.Tasks.Task RemoveEmployee_UserExists_RemovesEmployeeFromTeam()
        {
            // Arrange
            var user = new User { Id = testUserId, Email = testEmail };
            workerRepositoryMock.Setup(x => x.GetEmployeeByEmail(testEmail)).ReturnsAsync(user);

            // Act
            await teamService.RemoveEmployee(testTeamId, testEmail, testUserId);

            // Assert
            teamRepositoryMock.Verify(x => x.RemoveEmployee(It.Is<TeamMember>(tm => tm.TeamId == testTeamId && tm.UserId == testUserId)), Times.Once);
        }

        [Fact]
        public void RemoveEmployee_UserNotFound_ThrowsException()
        {
            // Arrange
            workerRepositoryMock.Setup(x => x.GetEmployeeByEmail(testEmail)).ReturnsAsync((User)null);

            // Act & Assert
            Assert.ThrowsAsync<Exception>(() => teamService.RemoveEmployee(testTeamId, testEmail, testUserId));
        }
    }
}
