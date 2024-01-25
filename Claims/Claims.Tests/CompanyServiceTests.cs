using AutoMapper;
using Claims.Application.Helpers;
using Claims.Application.Services;
using Claims.Data.Entities;
using Claims.Data.Repository;
using Claims.Models.ViewModels;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Claims.Tests
{
    public class CompanyServiceTests
    {
        [Fact]
        public async Task GetByIdAsyncReturns_Ok()
        {
            // Arrange
            var companyId = 1;
            var companyRepositoryMock = new Mock<ICompanyRepository>();
            companyRepositoryMock.Setup(repo => repo.GetCompany(companyId))
                .ReturnsAsync(new Company());
            var mapperMock = new Mock<IMapper>();
            mapperMock.Setup(mapper => mapper.Map<CompanyViewModel>(It.IsAny<Company>()))
                .Returns(new CompanyViewModel());
            var service = new CompanyService(companyRepositoryMock.Object, mapperMock.Object);

            // Act
            var result = await service.GetByIdAsync(companyId);

            // Assert
            Assert.NotNull(result);
        }

        [Fact]
        public async Task GetByIdAsyncReturns_NotFound()
        {
            // Arrange
            var companyId = 1;
            var companyRepositoryMock = new Mock<ICompanyRepository>();
            companyRepositoryMock.Setup(repo => repo.GetCompany(companyId))
                .ReturnsAsync((Company)null);
            var mapperMock = new Mock<IMapper>();
            var service = new CompanyService(companyRepositoryMock.Object, mapperMock.Object);

            // Act & Assert
            await Assert.ThrowsAsync<BusinessException>(() => service.GetByIdAsync(companyId));
        }
    }
}
