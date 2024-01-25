using Claims.API.Controllers;
using Claims.Application.Helpers;
using Claims.Application.Services;
using Claims.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Claims.Tests
{
    public class ClaimsControllerTests
    {
        [Fact]
        public async Task GetReturns_Ok()
        {
         // Arrange
            var ucr = "123456";
        var claimServiceMock = new Mock<IClaimsService>();
        claimServiceMock.Setup(service => service.Get(ucr))
            .ReturnsAsync(new ClaimViewModel()); 
        var controller = new ClaimsController(claimServiceMock.Object);

        // Act
        var result = await controller.Get(ucr);

        // Assert
        Assert.IsType<OkObjectResult>(result);
        claimServiceMock.Verify(service => service.Get(ucr), Times.Once);
    }

    [Fact]
    public async Task PutReturns_Ok()
    {
        // Arrange
        var ucr = "123456";
        var model = new ClaimViewModelPut();
        var claimServiceMock = new Mock<IClaimsService>();
        claimServiceMock.Setup(service => service.Update(model, ucr))
            .ReturnsAsync(new ClaimViewModel()); 
        var controller = new ClaimsController(claimServiceMock.Object);

        // Act
        var result = await controller.Put(model, ucr);

        // Assert
        Assert.IsType<OkObjectResult>(result);
        claimServiceMock.Verify(service => service.Update(model, ucr), Times.Once);
    }

    [Fact]
    public async Task PutReturns_BadRequest()
    {
        // Arrange
        var ucr = "123456";
        var model = new ClaimViewModelPut();
        var claimServiceMock = new Mock<IClaimsService>();
        claimServiceMock.Setup(service => service.Update(model, ucr))
            .Throws(new BusinessException((int)System.Net.HttpStatusCode.BadRequest, "Bad Request")); 
        var controller = new ClaimsController(claimServiceMock.Object);

        // Act & Assert
        var result = await Assert.ThrowsAsync<BusinessException>(() => controller.Put(model, ucr));
        Assert.IsType<BusinessException>(result);
        Assert.Equal((int)System.Net.HttpStatusCode.BadRequest, result.StatusCode);
        claimServiceMock.Verify(service => service.Update(model, ucr), Times.Once);
    }
}
}
