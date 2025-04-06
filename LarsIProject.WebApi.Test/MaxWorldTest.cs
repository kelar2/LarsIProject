using Azure;
using LarsIProject.WebApi.Controllers;
using LarsIProject.WebApi.Models;
using LarsIProject.WebApi.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;

namespace LarsIProject.WebApi.Test;

[TestClass]
public class MaxWorldTest
{
    [TestMethod]
    public async Task AddingMoreThan5Environment2DShouldReturnBadRequest()
    {
        //Arrange
        var mockEnvironment2DRepository = new Mock<IEnvironment2DRepository>();
        var mockAuthenticationService = new Mock<IAuthenticationService>();
        var logger = new Mock<ILogger<Environment2DController>>();
        var environment2DController = new Environment2DController(mockAuthenticationService.Object, mockEnvironment2DRepository.Object, logger.Object);
        var environment2D1 = new Environment2D
        {
            Id = "1",
            Name = "worldName1",
            MaxHeight = 10,
            MaxLength = 10,
            UserId = "1"
        };
        var environment2D2 = new Environment2D
        {
            Id = "2",
            Name = "worldName2",
            MaxHeight = 10,
            MaxLength = 10,
            UserId = "1"
        };
        var environment2D3 = new Environment2D
        {
            Id = "3",
            Name = "worldName3",
            MaxHeight = 10,
            MaxLength = 10,
            UserId = "1"
        };
        var environment2D4 = new Environment2D
        {
            Id = "4",
            Name = "worldName4",
            MaxHeight = 10,
            MaxLength = 10,
            UserId = "1"
        };
        var environment2D5 = new Environment2D
        {
            Id = "5",
            Name = "worldName5",
            MaxHeight = 10,
            MaxLength = 10,
            UserId = "1"
        };
        var environment2D6 = new Environment2D
        {
            Id = "6",
            Name = "worldName6",
            MaxHeight = 10,
            MaxLength = 10,
            UserId = "1"
        };

        mockEnvironment2DRepository.Setup(x => x.ReadAsync(It.IsAny<string>())).ReturnsAsync(new List<Environment2D> { environment2D1, environment2D2, environment2D3, environment2D4, environment2D5 });

        //Act
        var response = await environment2DController.Add(environment2D6);

        //Assert
        Assert.IsInstanceOfType(response, out BadRequestObjectResult badRequestResult);
    }
}
