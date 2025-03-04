using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;
using Moq.EntityFrameworkCore;
using Repositories;
using Repository;


namespace TestProjectMyShop
{
    public class IntegrationTest : IClassFixture<DatabaseFixture>
    {
        private readonly CatagoryContext Manger_DB_context;

        public IntegrationTest(DatabaseFixture fixture)
        {
            Manger_DB_context = fixture.Context;
        }
        [Fact]
        public async Task LogIn_ValidCredentials_ReturnsUser()
        {
            var user = new User { Email = "68nyuby@tdutf", Password = "iuhug@xtgbil" };
            Manger_DB_context.Users.Add(user);
            await Manger_DB_context.SaveChangesAsync();
            var userRepository = new UserRepository(Manger_DB_context, new LoggerFactory().CreateLogger<UserRepository>());


            // Act
            var retrievedUser = await userRepository.Login(user.Email, user.Password);

            // Assert
            Assert.NotNull(retrievedUser);
            Assert.Equal(user.Email, retrievedUser.Email);
        }
    }
}
