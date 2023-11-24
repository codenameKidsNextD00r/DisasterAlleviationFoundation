using DisasterAlleviationFoundationWebApp.Controllers;
using DisasterAlleviationFoundationWebApp.Entity;
using DisasterAlleviationFoundationWebApp.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;

namespace DAF.nUnitTests
{
    public class MainControllerTests
    {
        public MainController _mainController;
        public Mock<UserServices> _mockUserServices;

        [SetUp]
        public void Setup()
        {
            _mockUserServices = new Mock<UserServices>();
            _mainController = new MainController
            {
                _mockUserServices = _mockUserServices.Object
                // Initialize other services as needed
            };
        }

        [Test]
        public void ProcessLogin_ValidUser_ReturnsIndexView()
        {
            // Arrange
            var user = new User { /* Set user properties */ };
            _mockUserServices.Setup(x => x.Login(It.IsAny<User>())).Returns(user);

            // Act
            var result = _mainController.ProcessLogin(user) as ViewResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("Index", result.ViewName);
            // You can add more assertions based on the expected behavior
        }

        [Test]
        public void ProcessLogin_InvalidUser_ReturnsView()
        {
            // Arrange
            var user = new User { /* Set user properties */ };
            _mockUserServices.Setup(x => x.Login(It.IsAny<User>())).Returns((User)null);

            // Act
            var result = _mainController.ProcessLogin(user) as ViewResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(string.Empty, result.ViewName); // Update with the correct view name
            // You can add more assertions based on the expected behavior
        }

        // Add more tests for other methods as needed
    }
}
