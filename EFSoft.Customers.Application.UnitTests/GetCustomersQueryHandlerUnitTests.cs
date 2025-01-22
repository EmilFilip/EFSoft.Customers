using AutoFixture;
using EFSoft.Customers.Application.GetCustomers;
using EFSoft.Customers.Domain.Models;
using EFSoft.Customers.Domain.RepositoryContracts;
using FluentAssertions;
using Moq;

namespace EFSoft.Customers.Application.UnitTests;

public class GetCustomersQueryHandlerUnitTests
{
    private readonly IFixture _fixture;
    private readonly Mock<IGetCustomersRepository> _repositoryMock;
    private readonly GetCustomersQueryHandler _handler;

    public GetCustomersQueryHandlerUnitTests()
    {
        _fixture = new Fixture();
        _repositoryMock = new Mock<IGetCustomersRepository>();
        _handler = new GetCustomersQueryHandler(_repositoryMock.Object);
    }

    [Fact]
    public async Task Handle_ShouldCallGetCustomersAsync_WithCorrectCustomerIds()
    {
        // Arrange
        var query = _fixture.Create<GetCustomersQuery>();
        var customers = _fixture.Create<List<CustomerDomainModel>>();

        _ = _repositoryMock
                .Setup(repo => repo.GetCustomersAsync(query.CustomerIds, It.IsAny<CancellationToken>()))
                .ReturnsAsync(customers);

        // Act
        var result = await _handler.Handle(query, CancellationToken.None);

        // Assert
        _repositoryMock.Verify(
            repo => repo.GetCustomersAsync(query.CustomerIds, It.IsAny<CancellationToken>()),
            Times.Once);

        _ = result.Customers.Should().BeEquivalentTo(customers);
    }

    [Fact]
    public async Task Handle_ShouldReturnEmptyResult_WhenNoCustomersFound()
    {
        // Arrange
        var query = _fixture.Create<GetCustomersQuery>();

        _ = _repositoryMock
                .Setup(repo => repo.GetCustomersAsync(query.CustomerIds, It.IsAny<CancellationToken>()))
                .ReturnsAsync(new List<CustomerDomainModel>());

        // Act
        var result = await _handler.Handle(query, CancellationToken.None);

        // Assert
        _ = result.Customers.Should().BeEmpty();
    }

    [Fact]
    public async Task Handle_ShouldNotThrowException_WhenCalled()
    {
        // Arrange
        var query = _fixture.Create<GetCustomersQuery>();

        // Act
        var act = async () => await _handler.Handle(query, CancellationToken.None);

        // Assert
        _ = await act.Should().NotThrowAsync();
    }
}
