
//using Repositories;
//using System;
//using System.Collections.Generic;
//using Microsoft.EntityFrameworkCore;
//using Entities;
//using Moq;
//using Moq.EntityFrameworkCore;
//using Xunit;
//using Microsoft.Extensions.Logging;
//using Services;


//namespace TestProjectMyShop
//{
//    public class UserReposetoryTests 
//    {
      

        


//        [Fact]
//        public async Task LogIn()
//        {
//            // Arrange
//            var user = new User { Email = "68nyuby@tdutf", Password = "iuhug@xtgbil"};
//            var mocContext = new Mock<CatagoryContext>();
//            var users = new List<User>() { user };
//            mocContext.Setup(x => x.Users).ReturnsDbSet(users);
//            var userRepository = new UserRepository(mocContext.Object, new LoggerFactory().CreateLogger<UserRepository>());
//            var result = await userRepository.Login(user.Email, user.Password);
//            Assert.Equal(user, result);
//        }
//        [Fact]
//        public async Task LogIn_Invalid_ReturnsNull()
//        {
//            var mocContext = new Mock<CatagoryContext>();
//            var users = new List<User>();
//            mocContext.Setup(x => x.Users).ReturnsDbSet(users);

//            // Arrange
//            var userRepository = new UserRepository(mocContext.Object, new LoggerFactory().CreateLogger<UserRepository>());

//            // Act
//            var result = await userRepository.Login("wrongPassword", "nonExistentUser");

//            // Assert
//            Assert.Null(result);
//        }
//        [Fact]
//        public async Task LogIn_WrongPassword_ReturnsNull()
//        {
//            // Arrange
//            var user = new User { Email = "68nyuby@tdutf", Password = "iuhug@xtgbil" };
//            var mocContext = new Mock<CatagoryContext>();
//            var users = new List<User> { user };
//            mocContext.Setup(x => x.Users).ReturnsDbSet(users);
//            var userRepository = new UserRepository(mocContext.Object, new LoggerFactory().CreateLogger<UserRepository>());

//            // Act
//            var result = await userRepository.Login("wrongPassword", user.Password);

//            // Assert
//            Assert.Null(result);
//        }
//        [Fact]
//        public async Task CreateOrder_checkOrderSum_ReturnsOrder()
//        {
//            // Arrange
//            var orderItems = new List<OrderItem>() { new() { ProductId = 1 } };
//            var order = new Order { OrderSum = 6, OrderItems = orderItems };

//            var mockOrderRepository = new Mock<IOrderRepositories>();
//            var mockProductRepository = new Mock<IProductsRepository>();

//            var products = new List<Product> { new Product { ProductId = 1, Price = 6 } };
//            mockProductRepository.Setup(x => x.Get(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>(), It.IsAny<int?>(), It.IsAny<int?>(), It.IsAny<int?[]>()))
//                                 .ReturnsAsync(products);

//            mockOrderRepository.Setup(x => x.createOrder(It.IsAny<Order>()))
//                               .ReturnsAsync(order);

//            var orderService = new OrderServices(mockOrderRepository.Object, mockProductRepository.Object, null);

//            // Act
//            var result = await orderService.createOrder(order);

//            // Assert
//            Assert.NotNull(result);
//            Assert.Equal(order, result);
//        }
//    }
//} 