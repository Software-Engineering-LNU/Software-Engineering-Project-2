using EmployeestWeb.BLL.Services;
using EmployeestWeb.DAL.Interfaces;
using EmployeestWeb.DAL.Models;
using Moq;

namespace EmployeestWeb.Tests
{
    public class UserServiceTests
    {
        [Fact]
        public void GetUser_ForExistedUser_ReturnsCorrectUser()
        {
            var userRepositoryMock = new Mock<IUserRepository>();
            var userService = new UserService(userRepositoryMock.Object);

            long userId = 1;
            userRepositoryMock.Setup(repository => repository.GetUser(userId)).Returns(new User { Id = 1, Email = "belya@gmail.com", FullName = "Viktoriia Belia", Password = "password", PhoneNumber = "380963858681", IsBusinessOwner = false });

            var result = userService.GetUser(userId);
            var expected = new User { Id = 1, Email = "belya@gmail.com", FullName = "Viktoriia Belia", Password = "password", PhoneNumber = "380963858681", IsBusinessOwner = false };

            Assert.Equal(expected, result);
        }

        [Fact]
        public void GetUser_ForNotExistedUser_ReturnsNull()
        {
            var userRepositoryMock = new Mock<IUserRepository>();
            var userService = new UserService(userRepositoryMock.Object);

            long userId = 1;
            userRepositoryMock.Setup(repository => repository.GetUser(userId)).Throws(new InvalidOperationException());

            var result = userService.GetUser(1);
            
            Assert.Null(result);
        }

        [Fact]
        public void AuthorizeUser_ForCorrectUserData_ReturnsCorrectUserId()
        {
            var userRepositoryMock = new Mock<IUserRepository>();
            var userService = new UserService(userRepositoryMock.Object);

            string userEmail = "belya@gmail.com";
            string password = "password";
            userRepositoryMock.Setup(repository => repository.GetUser(userEmail)).Returns(new User { Id = 1, Email = "belya@gmail.com", FullName = "Viktoriia Belia", Password = "password", PhoneNumber = "380963858681", IsBusinessOwner = false });

            var result = userService.AuthorizeUser(userEmail, password);
            var expected = 1;

            Assert.Equal(expected, result);
        }
        [Fact]
        public void AuthorizeUser_ForInCorrectUserPassword_ReturnsNull()
        {
            var userRepositoryMock = new Mock<IUserRepository>();
            var userService = new UserService(userRepositoryMock.Object);

            string userEmail = "belya@gmail.com";
            string password = "notPassword";
            userRepositoryMock.Setup(repository => repository.GetUser(userEmail)).Returns(new User { Id = 1, Email = "belya@gmail.com", FullName = "Viktoriia Belia", Password = "password", PhoneNumber = "380963858681", IsBusinessOwner = false });

            var result = userService.AuthorizeUser(userEmail, password);

            Assert.Null(result);
        }
        [Fact]
        public void AuthorizeUser_ForInCorrectUserEmail_ReturnsNull()
        {
            var userRepositoryMock = new Mock<IUserRepository>();
            var userService = new UserService(userRepositoryMock.Object);

            string userEmail = "polivka@gmail.com";
            string password = "password";
            userRepositoryMock.Setup(repository => repository.GetUser(userEmail)).Throws(new InvalidOperationException());

            var result = userService.AuthorizeUser(userEmail, password);

            Assert.Null(result);
        }
        [Fact]
        public void RegisterUser_ForCorrectUser_ReturnsCorrectUserId()
        {
            var userRepositoryMock = new Mock<IUserRepository>();
            var userService = new UserService(userRepositoryMock.Object);

            User user = new User { Id = 1, Email = "belya@gmail.com", FullName = "Viktoriia Belia", Password = "password", PhoneNumber = "380963858681", IsBusinessOwner = false };
            userRepositoryMock.Setup(repository => repository.GetUser(user.Email)).Throws(new InvalidOperationException());

            var result = userService.RegisterUser(user);
            var expected = 1;

            Assert.Equal(expected, result);
        }
        [Fact]
        public void RegisterUser_ForExistedUser_ReturnsNull()
        {
            var userRepositoryMock = new Mock<IUserRepository>();
            var userService = new UserService(userRepositoryMock.Object);

            User user = new User { Id = 1, Email = "belya@gmail.com", FullName = "Viktoriia Belia", Password = "password", PhoneNumber = "380963858681", IsBusinessOwner = false };
            userRepositoryMock.Setup(repository => repository.GetUser(user.Email)).Returns(new User { Id = 1, Email = "belya@gmail.com", FullName = "Viktoriia Belia", Password = "password", PhoneNumber = "380963858681", IsBusinessOwner = false });

            var result = userService.RegisterUser(user);

            Assert.Null(result);
        }
    }
}
