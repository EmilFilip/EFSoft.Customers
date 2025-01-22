using AutoFixture;
using EFSoft.Customers.Application.GetCustomer;
using EFSoft.Customers.Domain.Models;
using EFSoft.Customers.Domain.RepositoryContracts;
using FluentAssertions;
using Moq;

namespace EFSoft.Customers.Application.UnitTests;

public class GetCustomerQueryHandlerUnitTests
{
    private readonly IFixture _fixture;
    private readonly Mock<IGetCustomerRepository> _repositoryMock;
    private readonly GetCustomerQueryHandler _handler;

    public GetCustomerQueryHandlerUnitTests()
    {
        _fixture = new Fixture();
        _repositoryMock = new Mock<IGetCustomerRepository>();
        _handler = new GetCustomerQueryHandler(_repositoryMock.Object);
    }

    [Fact]
    public async Task Handle_ShouldCallGetCustomerAsync_WithCorrectCustomerId()
    {
        // Arrange
        var query = _fixture.Create<GetCustomerQuery>();
        var customer = _fixture.Create<CustomerDomainModel>();

        _ = _repositoryMock
                .Setup(repo => repo.GetCustomerAsync(query.CustomerId, It.IsAny<CancellationToken>()))
                .ReturnsAsync(customer);

        // Act
        var result = await _handler.Handle(query, CancellationToken.None);

        // Assert
        _repositoryMock.Verify(
            repo => repo.GetCustomerAsync(query.CustomerId, It.IsAny<CancellationToken>()),
            Times.Once);

        _ = result.Should().NotBeNull();
        _ = result!.CustomerId.Should().Be(customer.CustomerId);
        _ = result.FullName.Should().Be(customer.FullName);
        _ = result.DateOfBirth.Should().Be(customer.DateOfBirth);
        _ = result.HasOpenedOrder.Should().Be(customer.HasOpenOrder);
    }

    [Fact]
    public async Task Handle_ShouldReturnNull_WhenCustomerDoesNotExist()
    {
        // Arrange
        var query = _fixture.Create<GetCustomerQuery>();
        CustomerDomainModel? customer = null;

        _ = _repositoryMock
                .Setup(repo => repo.GetCustomerAsync(query.CustomerId, It.IsAny<CancellationToken>()))
                .ReturnsAsync(customer);

        // Act
        var result = await _handler.Handle(query, CancellationToken.None);

        // Assert
        _ = result.Should().BeNull();
    }

    [Fact]
    public async Task Handle_ShouldNotThrowException_WhenCalled()
    {
        // Arrange
        var query = _fixture.Create<GetCustomerQuery>();

        // Act
        var act = async () => await _handler.Handle(query, CancellationToken.None);

        // Assert
        _ = await act.Should().NotThrowAsync();
    }
}
