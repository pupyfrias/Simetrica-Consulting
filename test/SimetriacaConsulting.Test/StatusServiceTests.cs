using NUnit.Framework;
using Moq;
using System.Threading.Tasks;
using SimetricaConsulting.Application.Services;
using SimetricaConsulting.Domain.Contracts;
using SimetricaConsulting.Application.Contracts.Repositories.V1;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Caching.Memory;
using System.Xml;
using SimetricaConsulting.Application.Models.Dtos.V1.Status;
using SimetricaConsulting.Application.Models.Wrappers;
using SimetricaConsulting.Application.Exceptions;
using SimetricaConsulting.Domain.Entities.V1;
using Task = System.Threading.Tasks.Task;

namespace SimetricaConsulting.Tests
{
    [TestFixture]
    public class StatusServiceTests
    {
        private Mock<IAsyncRepository<Status>> _repositoryMock;
        private Mock<IMapper> _mapperMock;
        private Mock<IHttpContextAccessor> _httpContextAccessorMock;
        private Mock<IMemoryCache> _memoryCacheMock;
        private ServiceBase<Status> _service;

        [SetUp]
        public void Setup()
        {
            _repositoryMock = new Mock<IAsyncRepository<Status>>();
            _mapperMock = new Mock<IMapper>();
            _httpContextAccessorMock = new Mock<IHttpContextAccessor>();
            _memoryCacheMock = new Mock<IMemoryCache>();
            _service = new ServiceBase<Status>(_repositoryMock.Object, _mapperMock.Object, _httpContextAccessorMock.Object, _memoryCacheMock.Object);
        }

        [Test]
        public async System.Threading.Tasks.Task CreateAsync_CreatesEntitySuccessfully()
        {
            var source = new StatusCreateDto();
            var mappedEntity = new Status();
            var mappedResult = new StatusDetailDto();

            _mapperMock.Setup(m => m.Map<Status>(source)).Returns(mappedEntity);
            _repositoryMock.Setup(r => r.CreateAsync(mappedEntity)).Returns(System.Threading.Tasks.Task.FromResult(mappedEntity));
            _mapperMock.Setup(m => m.Map<StatusDetailDto>(mappedEntity)).Returns(mappedResult);

            var result = await _service.CreateAsync<StatusCreateDto, StatusDetailDto>(source);
            _repositoryMock.Verify(r => r.CreateAsync(mappedEntity), Times.Once);
            _mapperMock.Verify(m => m.Map<StatusDetailDto>(mappedEntity), Times.Once);

            Assert.IsNotNull(result);
            Assert.AreEqual(mappedResult, result);
        }


        [Test]
        public async Task DeleteLogicalAsync_UpdatesEntitySuccessfully()
        {
            var id = 1;
            var entity = new Status { Active = true };
            _repositoryMock.Setup(r => r.GetByIdAsync(id)).ReturnsAsync(entity);
            _repositoryMock.Setup(r => r.UpdateAsync(entity)).Returns(Task.CompletedTask);

            await _service.DeleteLogicalAsync(id);

            _repositoryMock.Verify(r => r.UpdateAsync(It.Is<Status>(e => e.Active == false)), Times.Once);
        }

        [Test]
        public async Task UpdateAsync_UpdatesEntitySuccessfully()
        {
            var id = 1;
            var source = new StatusUpdateDto { Id = id };
            var entity = new Status();
            _repositoryMock.Setup(r => r.GetByIdAsync(id)).ReturnsAsync(entity);
            _mapperMock.Setup(m => m.Map(source, entity));

            await _service.UpdateAsync(id, source);

            _repositoryMock.Verify(r => r.UpdateAsync(entity), Times.Once);
            _mapperMock.Verify(m => m.Map(source, entity), Times.Once);
        }

        [Test]
        public void GetByIdAsync_ThrowsNotFoundException_WhenEntityNotFound()
        {
            // Arrange
            var id = 1;
            var expectedMessage = "Status with id (1) was not found";
            _repositoryMock.Setup(r => r.GetByIdAsync<int>(id))
                           .ThrowsAsync(new NotFoundException(expectedMessage));

            // Act & Assert
            var ex = Assert.ThrowsAsync<NotFoundException>(() => _service.GetByIdProjectedAsync<int, StatusDetailDto>(id));
            Assert.That(ex.Message, Is.EqualTo(expectedMessage));  
        }


    }
}
