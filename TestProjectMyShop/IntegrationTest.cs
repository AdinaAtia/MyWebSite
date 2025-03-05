using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;
using Moq.EntityFrameworkCore;
using Repositories;
using Repository;

using Microsoft.EntityFrameworkCore;
namespace TestProjectMyShop
{
    public class IntegrationTest : IClassFixture<DatabaseFixture>
    {
        private readonly CatagoryContext Manger_DB_context;
        private readonly UserRepository _reposetory;
        public IntegrationTest(DatabaseFixture fixture)
        {
            Manger_DB_context = fixture.Context;
            var mockLogger = new Mock<ILogger<UserRepository>>();

            _reposetory = new UserRepository(Manger_DB_context, mockLogger.Object);
    }
        [Fact]
        public async Task Get_ShouldReturnUser_WhenUserExists()
        {
            // Arrange
            var user = new User { Email = "68nyuby@tdutf", Password = "iuhug@xtgbil" };
            Manger_DB_context.Users.Add(user);
            await Manger_DB_context.SaveChangesAsync();
            // Act
            var retrievedUser = await _reposetory.Login(user.Email, user.Password);
            // var retrievedUser = await _context.Users.FindAsync(user.Id);

            // Assert
            Assert.NotNull(retrievedUser);
            Assert.Equal(user.Email, retrievedUser.Email);
        }

        [Fact]
        public async Task LogIn_InvalidCredentials_ReturnsNull()
        {
            // Arrange
            //var userRepository = new UserRepository(_context);

            // Act
            var result = await _reposetory.Login("wrongPassword", "nonExistentUser");
            // Assert
            Assert.Null(result);
        }
        [Fact]
        public async Task LogIn_WrongPassword_ReturnsNull()
        {
            // Arrange
            var user = new User { Email = "68nyuby@tdutf", Password = "iuhug@xtgbil" };
            Manger_DB_context.Users.Add(user);
            await Manger_DB_context.SaveChangesAsync();


            // Act
            var result = await _reposetory.Login("wrongPassword", user.Email);

            // Assert
            Assert.Null(result);
        }
    }





}