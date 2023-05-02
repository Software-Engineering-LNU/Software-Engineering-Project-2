using EmployeestWeb.BLL.Services;
using EmployeestWeb.DAL.Interfaces;
using EmployeestWeb.DAL.Models;
using Moq;

namespace EmployeestWeb.Tests
{
    public class UserServiceTests
    {
        private readonly Mock<IUserRepository> userRepositoryMock;
        private readonly UserService userService;

        private static readonly long testId = 1;
        private static readonly string testEmail = "test@gmail.com";
        private static readonly string testPassword = "password";
        public UserServiceTests()
        {
            userRepositoryMock = new Mock<IUserRepository>();
            userService = new UserService(userRepositoryMock.Object);
        }
        [Fact]
        public void GetUser_ForExistedUser_ReturnsCorrectUser()
        {
            userRepositoryMock.Setup(repository => repository.GetUser(testId)).Returns(new User { Id = testId, Email = testEmail, FullName = "Test Name", Password = testPassword, PhoneNumber = "380990009900", IsBusinessOwner = false });

            var result = userService.GetUser(testId);
            var expected = new User { Id = testId, Email = testEmail, FullName = "Test Name", Password = testPassword, PhoneNumber = "380990009900", IsBusinessOwner = false };

            Assert.Equal(expected, result);
        }

        [Fact]
        public void GetUser_ForNotExistedUser_ReturnsNull()
        {
            userRepositoryMock.Setup(repository => repository.GetUser(testId)).Throws(new InvalidOperationException());

            var result = userService.GetUser(testId);
            
            Assert.Null(result);
        }

        [Fact]
        public void AuthorizeUser_ForCorrectUserData_ReturnsCorrectUserId()
        {
            userRepositoryMock.Setup(repository => repository.GetUser(testEmail)).Returns(new User { Id = testId, Email = testEmail, FullName = "Test Name", Password = testPassword, PhoneNumber = "380990009900", IsBusinessOwner = false });

            var result = userService.AuthorizeUser(testEmail, testPassword);
            var expected = testId;

            Assert.Equal(expected, result);
        }
        [Fact]
        public void AuthorizeUser_ForInCorrectUserPassword_ReturnsNull()
        {
            userRepositoryMock.Setup(repository => repository.GetUser(testEmail)).Returns(new User { Id = testId, Email = testEmail, FullName = "Test Name", Password = testPassword, PhoneNumber = "380990009900", IsBusinessOwner = false });

            var result = userService.AuthorizeUser(testEmail, "incorrectPassword");

            Assert.Null(result);
        }
        [Fact]
        public void AuthorizeUser_ForInCorrectUserEmail_ReturnsNull()
        {
            userRepositoryMock.Setup(repository => repository.GetUser(testEmail)).Throws(new InvalidOperationException());

            var result = userService.AuthorizeUser(testEmail, testPassword);

            Assert.Null(result);
        }
        [Fact]
        public void RegisterUser_ForCorrectUser_ReturnsCorrectUserId()
        {
            User user = new User { Id = testId, Email = testEmail, FullName = "Test Name", Password = testPassword, PhoneNumber = "380990009900", IsBusinessOwner = false };
            userRepositoryMock.Setup(repository => repository.GetUser(user.Email)).Throws(new InvalidOperationException());

            var result = userService.RegisterUser(user);
            var expected = testId;

            Assert.Equal(expected, result);
        }
        [Fact]
        public void RegisterUser_ForExistedUser_ReturnsNull()
        {
            User user = new User { Id = testId, Email = testEmail, FullName = "Test Name", Password = testPassword, PhoneNumber = "380990009900", IsBusinessOwner = false };
            userRepositoryMock.Setup(repository => repository.GetUser(user.Email)).Returns(new User { Id = testId, Email = testEmail, FullName = "Test Name", Password = testPassword, PhoneNumber = "380990009900", IsBusinessOwner = false });

            var result = userService.RegisterUser(user);

            Assert.Null(result);
        }
    }
}
