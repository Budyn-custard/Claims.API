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
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Claims.Tests
{
    public class ClaimsServiceTests
    {
        [Fact]
        public async Task GetReturns_Ok()
        {
            // Arrange
            var ucr = "123456";
            var claimRepositoryMock = new Mock<IClaimsRepository>();
            var mapperMock = new Mock<IMapper>();
            claimRepositoryMock.Setup(repo => repo.Get(ucr))
                .ReturnsAsync(new Claim());
            mapperMock.Setup(mapper => mapper.Map<ClaimViewModel>(It.IsAny<Claim>()))
                .Returns(new ClaimViewModel());
            var service = new ClaimsService(claimRepositoryMock.Object, mapperMock.Object, null);

            // Act
            var result = await service.Get(ucr);

            // Assert
            Assert.NotNull(result);
        }

        [Fact]
        public async Task GetReturns_NotFound()
        {
            // Arrange
            var ucr = "123456";
            var claimRepositoryMock = new Mock<IClaimsRepository>();
            claimRepositoryMock.Setup(repo => repo.Get(ucr))
                .ReturnsAsync((Claim)null);
            var mapperMock = new Mock<IMapper>();
            var service = new ClaimsService(claimRepositoryMock.Object, mapperMock.Object, null);

            // Act & Assert
            await Assert.ThrowsAsync<BusinessException>(() => service.Get(ucr));
        }

        [Fact]
        public async Task GetForCompanyReturns_Ok()
        {
            // Arrange
            var companyId = 1;
            var claimRepositoryMock = new Mock<IClaimsRepository>();
            claimRepositoryMock.Setup(repo => repo.GetForCompany(It.IsAny<Expression<Func<Claim, bool>>>()))
                .ReturnsAsync(new List<Claim>()); 
            var mapperMock = new Mock<IMapper>();
            mapperMock.Setup(mapper => mapper.Map<List<ClaimViewModel>>(It.IsAny<List<Claim>>()))
                .Returns(new List<ClaimViewModel>()); 
            var service = new ClaimsService(claimRepositoryMock.Object, mapperMock.Object, null);

            // Act
            var result = await service.GetForCompany(companyId);

            // Assert
            Assert.NotNull(result);
        }

        [Fact]
        public async Task UpdateReturns_NotFound()
        {
            var ucr = "123456";
            var model = new ClaimViewModelPut();
            var claimRepositoryMock = new Mock<IClaimsRepository>();
            claimRepositoryMock.Setup(repo => repo.Get(ucr))
                .ReturnsAsync((Claim)null);
            var mapperMock = new Mock<IMapper>();
            var claimTypeRepositoryMock = new Mock<IClaimTypeRepository>();
            var service = new ClaimsService(claimRepositoryMock.Object, mapperMock.Object, claimTypeRepositoryMock.Object);

            await Assert.ThrowsAsync<BusinessException>(() => service.Update(model, ucr));
        }

        [Fact]
        public async Task UpdateReturns_BadRequest()
        {
            var ucr = "123456";
            var model = new ClaimViewModelPut();
            var claimRepositoryMock = new Mock<IClaimsRepository>();
            claimRepositoryMock.Setup(repo => repo.Get(ucr))
                .ReturnsAsync(new Claim()); 
            var claimTypeRepositoryMock = new Mock<IClaimTypeRepository>();
            claimTypeRepositoryMock.Setup(repo => repo.Exists(It.IsAny<int>()))
                .ReturnsAsync(false); 
            var mapperMock = new Mock<IMapper>();
            var service = new ClaimsService(claimRepositoryMock.Object, mapperMock.Object, claimTypeRepositoryMock.Object);

            await Assert.ThrowsAsync<BusinessException>(() => service.Update(model, ucr));
        }

        [Fact]
        public async Task UpdateReturns_InternalServerError()
        {
            var ucr = "123456";
            var model = new ClaimViewModelPut();
            var claimRepositoryMock = new Mock<IClaimsRepository>();
            claimRepositoryMock.Setup(repo => repo.Get(ucr))
                .ReturnsAsync(new Claim()); 
            var claimTypeRepositoryMock = new Mock<IClaimTypeRepository>();
            claimTypeRepositoryMock.Setup(repo => repo.Exists(It.IsAny<int>()))
                .ReturnsAsync(true);
            var mapperMock = new Mock<IMapper>();
            claimRepositoryMock.Setup(repo => repo.Update(It.IsAny<Claim>()))
                .ReturnsAsync(0); 
            var service = new ClaimsService(claimRepositoryMock.Object, mapperMock.Object, claimTypeRepositoryMock.Object);

            await Assert.ThrowsAsync<BusinessException>(() => service.Update(model, ucr));
        }
    }
}
