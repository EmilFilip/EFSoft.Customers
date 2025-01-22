using AutoFixture;
using EFSoft.Customers.Application.UpdateCustomer;
using EFSoft.Customers.Domain.Models;
using EFSoft.Customers.Domain.RepositoryContracts;
using FluentAssertions;
using Moq;

namespace EFSoft.Customers.Application.UnitTests;

public class UpdateCustomerCommandHandlerUnitTests
{
    private readonly IFixture _fixture;
    private readonly Mock<IUpdateCustomerRepository> _repositoryMock;
    private readonly UpdateCustomerCommandHandler _handler;

    public UpdateCustomerCommandHandlerUnitTests()
    {
        _fixture = new Fixture();
        _repositoryMock = new Mock<IUpdateCustomerRepository>();
        _handler = new UpdateCustomerCommandHandler(_repositoryMock.Object);
    }

    [Fact]
    public async Task Handle_ShouldCallUpdateCustomerAsync_WithCorrectParameters()
    {
        // Arrange
        var command = _fixture.Create<UpdateCustomerCommand>();

        // Act
        await _handler.Handle(command, CancellationToken.None);

        // Assert
        _repositoryMock.Verify(
            repo => repo.UpdateCustomerAsync(
                It.Is<CustomerDomainModel>(c =>
                    c.CustomerId == command.CustomerId &&
                    c.FullName == command.FullName &&
                    c.DateOfBirth == command.DateOfBirth),
                It.IsAny<CancellationToken>()),
            Times.Once);
    }

    [Fact]
    public async Task Handle_ShouldNotThrowException_WhenCalled()
    {
        // Arrange
        var command = _fixture.Create<UpdateCustomerCommand>();

        // Act
        var act = async () => await _handler.Handle(command, CancellationToken.None);

        // Assert
        _ = await act.Should().NotThrowAsync();
    }
}
