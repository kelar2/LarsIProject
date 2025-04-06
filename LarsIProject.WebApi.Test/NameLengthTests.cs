using Azure;
using LarsIProject.WebApi.Controllers;
using LarsIProject.WebApi.Models;
using LarsIProject.WebApi.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;

namespace LarsIProject.WebApi.Test;

[TestClass]
public class NameLengthTests
{

    [TestMethod]
    public async Task AddingEnvironment2DWithAnEmptyNameShouldReturnBadRequest()
    {
        string name = "";
        //Arrange
        var mockEnvironment2DRepository = new Mock<IEnvironment2DRepository>();
        var mockAuthenticationService = new Mock<IAuthenticationService>();
        var logger = new Mock<ILogger<Environment2DController>>();
        var environment2DController = new Environment2DController(mockAuthenticationService.Object, mockEnvironment2DRepository.Object, logger.Object);
        var Environment2D = new Environment2D
        {
            Id = "1",
            Name = name,
            MaxHeight = 10,
            MaxLength = 10,
            UserId = "1"
        };

        //Act
        var response = await environment2DController.Add(Environment2D);

        //Assert
        Assert.IsInstanceOfType(response, out BadRequestObjectResult badRequestResult);
    }

    [TestMethod]
    public async Task AddingEnvironment2DWithTooLongNameShouldReturnBadRequest()
    {
        string name = "NameLongerThan25characters";
        //Arrange
        var mockEnvironment2DRepository = new Mock<IEnvironment2DRepository>();
        var mockAuthenticationService = new Mock<IAuthenticationService>();
        var logger = new Mock<ILogger<Environment2DController>>();
        var environment2DController = new Environment2DController(mockAuthenticationService.Object, mockEnvironment2DRepository.Object, logger.Object);
        var Environment2D = new Environment2D
        {
            Id = "1",
            Name = name,
            MaxHeight = 10,
            MaxLength = 10,
            UserId = "1"
        };

        //Act
        var response = await environment2DController.Add(Environment2D);

        //Assert
        Assert.IsInstanceOfType(response, out BadRequestObjectResult badRequestResult);
    }

    [TestMethod]
    public async Task AddingEnvironment2DWithPerfectNameShouldReturnCreatedRequest()
    {
        string name = "PerfectName";
        //Arrange
        var mockEnvironment2DRepository = new Mock<IEnvironment2DRepository>();
        var mockAuthenticationService = new Mock<IAuthenticationService>();
        var logger = new Mock<ILogger<Environment2DController>>();
        var environment2DController = new Environment2DController(mockAuthenticationService.Object, mockEnvironment2DRepository.Object, logger.Object);
        var Environment2D = new Environment2D
        {
            Id = "1",
            Name = name,
            MaxHeight = 10,
            MaxLength = 10,
            UserId = "1"
        };

        //Act
        var response = await environment2DController.Add(Environment2D);

        //Assert
        Assert.IsInstanceOfType(response, out CreatedResult createdObjectResult);
    }

}

