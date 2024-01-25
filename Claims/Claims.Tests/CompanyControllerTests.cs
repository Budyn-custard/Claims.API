using Claims.API.Controllers;
using Claims.Application.Helpers;
using Claims.Application.Services;
using Claims.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Net;

namespace Claims.Tests
{
    public class CompanyControllerTests
    {
        [Fact]
        public async Task GetReturns_Ok()
        {
            // Arrange
            var companyId = 1;
            var companyServiceMock = new Mock<ICompanyService>();
            companyServiceMock.Setup(service => service.GetByIdAsync(companyId))
                .ReturnsAsync(new CompanyViewModel()); 
            var controller = new CompaniesController(companyServiceMock.Object, null);

            // Act
            var result = await controller.Get(companyId);

            // Assert
            Assert.IsType<OkObjectResult>(result);
            companyServiceMock.Verify(service => service.GetByIdAsync(companyId), Times.Once);
        }

        [Fact]
        public async Task GetReturns_NotFound()
        {
            // Arrange
            var companyId = 1;
            var companyServiceMock = new Mock<ICompanyService>();
            companyServiceMock.Setup(service => service.GetByIdAsync(companyId))
                .Throws(new BusinessException((int)HttpStatusCode.NotFound, "Not Found")); 
            var controller = new CompaniesController(companyServiceMock.Object, null);

            // Act & Assert
            var result = await Assert.ThrowsAsync<BusinessException>(() => controller.Get(companyId));
            Assert.Equal((int)HttpStatusCode.NotFound, result.StatusCode);
            companyServiceMock.Verify(service => service.GetByIdAsync(companyId), Times.Once);
        }

        [Fact]
        public async Task GetClaimsReturns_Ok()
        {
            // Arrange
            var companyId = 1;
            var claimsServiceMock = new Mock<IClaimsService>();
            claimsServiceMock.Setup(service => service.GetForCompany(companyId))
                .ReturnsAsync(new List<ClaimViewModel>());
            var controller = new CompaniesController(null, claimsServiceMock.Object);

            // Act
            var result = await controller.GetClaims(companyId);

            // Assert
            Assert.IsType<OkObjectResult>(result);
            claimsServiceMock.Verify(service => service.GetForCompany(companyId), Times.Once);
        }
    }
}