using AutoFixture;
using EFSoft.Customers.Application.CreateCustomer;
using EFSoft.Customers.Domain.Models;
using EFSoft.Customers.Domain.RepositoryContracts;
using FluentAssertions;
using Moq;

namespace EFSoft.Customers.Application.UnitTests;

public class CreateCustomerCommandHandlerUnitTests
{
    private readonly IFixture _fixture;
    private readonly Mock<ICreateCustomerRepository> _repositoryMock;
    private readonly CreateCustomerCommandHandler _handler;

    public CreateCustomerCommandHandlerUnitTests()
    {
        _fixture = new Fixture();
        _repositoryMock = new Mock<ICreateCustomerRepository>();
        _handler = new CreateCustomerCommandHandler(_repositoryMock.Object);
    }

    [Fact]
    public async Task Handle_ShouldCallCreateCustomerAsync_WithCorrectParameters()
    {
        // Arrange
        var command = _fixture.Create<CreateCustomerCommand>();

        // Act
        await _handler.Handle(command, CancellationToken.None);

        // Assert
        _repositoryMock.Verify(
            repo => repo.CreateCustomerAsync(
                It.Is<CustomerDomainModel>(c =>
                    c.FullName == command.FullName &&
                    c.DateOfBirth == command.DateOfBirth),
                It.IsAny<CancellationToken>()),
            Times.Once);
    }

    [Fact]
    public async Task Handle_ShouldNotThrowException_WhenCalled()
    {
        // Arrange
        var command = _fixture.Create<CreateCustomerCommand>();

        // Act
        var act = async () => await _handler.Handle(command, CancellationToken.None);

        // Assert
        _ = await act.Should().NotThrowAsync();
    }
}
