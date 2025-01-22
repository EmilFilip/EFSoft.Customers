using AutoFixture;
using EFSoft.Customers.Application.DeleteCustomer;
using EFSoft.Customers.Domain.RepositoryContracts;
using FluentAssertions;
using Moq;

namespace EFSoft.Customers.Application.UnitTests;

public class DeleteCustomerCommandHandlerUnitTests
{
    private readonly IFixture _fixture;
    private readonly Mock<IDeleteCustomerRepository> _repositoryMock;
    private readonly DeleteCustomerCommandHandler _handler;

    public DeleteCustomerCommandHandlerUnitTests()
    {
        _fixture = new Fixture();
        _repositoryMock = new Mock<IDeleteCustomerRepository>();
        _handler = new DeleteCustomerCommandHandler(_repositoryMock.Object);
    }

    [Fact]
    public async Task Handle_ShouldCallDeleteCustomerAsync_WithCorrectCustomerId()
    {
        // Arrange
        var command = _fixture.Create<DeleteCustomerCommand>();

        // Act
        await _handler.Handle(command, CancellationToken.None);

        // Assert
        _repositoryMock.Verify(
            repo => repo.DeleteCustomerAsync(
                command.CustomerId,
                It.IsAny<CancellationToken>()),
            Times.Once);
    }

    [Fact]
    public async Task Handle_ShouldNotThrowException_WhenCalled()
    {
        // Arrange
        var command = _fixture.Create<DeleteCustomerCommand>();

        // Act
        var act = async () => await _handler.Handle(command, CancellationToken.None);

        // Assert
        _ = await act.Should().NotThrowAsync();
    }
}
