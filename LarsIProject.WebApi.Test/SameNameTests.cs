using Azure;
using LarsIProject.WebApi.Controllers;
using LarsIProject.WebApi.Models;
using LarsIProject.WebApi.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;

namespace LarsIProject.WebApi.Test;

[TestClass]
public class SameNameTests
{
    [TestMethod]
    public async Task AddingEnvironment2DWithSameNameShouldReturnBadRequest()
    {
        string name = "Name";
        //Arrange
        var mockEnvironment2DRepository = new Mock<IEnvironment2DRepository>();
        var mockAuthenticationService = new Mock<IAuthenticationService>();
        var logger = new Mock<ILogger<Environment2DController>>();
        var environment2DController = new Environment2DController(mockAuthenticationService.Object, mockEnvironment2DRepository.Object, logger.Object);
        var environment2D1 = new Environment2D
        {
            Id = "1",
            Name = name,
            MaxHeight = 10,
            MaxLength = 10,
            UserId = "1"
        };
        var environment2D2 = new Environment2D
        {
            Id = "2",
            Name = name,
            MaxHeight = 10,
            MaxLength = 10,
            UserId = "1"
        };

        mockEnvironment2DRepository.Setup(x => x.ReadAsync(It.IsAny<string>())).ReturnsAsync(new List<Environment2D> { environment2D1 });

        //Act
        var response = await environment2DController.Add(environment2D2);

        //Assert
        Assert.IsInstanceOfType(response, out BadRequestObjectResult badRequestResult);
    }
}
