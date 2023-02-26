using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Sample.Controllers;
using Sample.Models;
using Sample.Repositories.Interfaces;

namespace Sample.Tests.Controllers;

public class SampleControllerTest
{
    [Fact]
    public async Task SampleController_Divide_ZeroDividerShouldReturnBadRequest()
    {
        // Assume
        var sampleRepository = new Mock<ISampleRepository>();
        var sampleController = new SampleController(sampleRepository.Object);
        var model = new InputModel
        {
            Value1 = -1,
            Value2 = 0
        };


        // Act
        var result = await sampleController.Divide(model);


        // Assert
        result.Should().BeOfType<BadRequestObjectResult>();
        result.As<BadRequestObjectResult>().Value.As<SerializableError>().ContainsKey(nameof(InputModel.Value2));
    }

    [Fact]
    public async Task SampleController_Plus_NegativeValueShouldReturnBadRequest()
    {
        // Assume
        var sampleRepository = new Mock<ISampleRepository>();
        var sampleController = new SampleController(sampleRepository.Object);
        var model = new InputModel
        {
            Value1 = -1,
            Value2 = -2
        };


        // Act
        var result = await sampleController.Plus(model);


        // Assert
        result.Should().BeOfType<BadRequestObjectResult>();
        result.As<BadRequestObjectResult>().Value.As<SerializableError>().ContainsKey(nameof(InputModel.Value1));
        result.As<BadRequestObjectResult>().Value.As<SerializableError>().ContainsKey(nameof(InputModel.Value2));
    }
}