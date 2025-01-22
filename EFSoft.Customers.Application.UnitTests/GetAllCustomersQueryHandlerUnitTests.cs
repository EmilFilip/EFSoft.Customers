using AutoFixture;
using EFSoft.Customers.Application.GetAllCustomers;
using EFSoft.Customers.Domain.Models;
using EFSoft.Customers.Domain.RepositoryContracts;
using FluentAssertions;
using Moq;

namespace EFSoft.Customers.Application.UnitTests;

public class GetAllCustomersQueryHandlerUnitTests
{
    private readonly IFixture _fixture;
    private readonly Mock<IGetAllCustomersRepository> _repositoryMock;
    private readonly GetAllCustomersQueryHandler _handler;

    public GetAllCustomersQueryHandlerUnitTests()
    {
        _fixture = new Fixture();
        _repositoryMock = new Mock<IGetAllCustomersRepository>();
        _handler = new GetAllCustomersQueryHandler(_repositoryMock.Object);
    }

    [Fact]
    public async Task Handle_ShouldCallGetAllCustomersAsync_WithCorrectParameters()
    {
        // Arrange
        var query = _fixture.Create<GetAllCustomersQuery>();
        var pagedListCustomers = _fixture.Create<PagedList<CustomerDomainModel>>();

        _ = _repositoryMock
                .Setup(repo => repo.GetAllCustomersAsync(It.IsAny<PagedListParams>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(pagedListCustomers);

        // Act
        var result = await _handler.Handle(query, CancellationToken.None);

        // Assert
        _repositoryMock.Verify(
            repo => repo.GetAllCustomersAsync(
                It.Is<PagedListParams>(p =>
                    p.SearchTerm == query.SearchTerm &&
                    p.SortColumn == query.SortColumn &&
                    p.SortOrder == query.SortOrder &&
                    p.Page == query.Page &&
                    p.PageSize == query.PageSize),
                It.IsAny<CancellationToken>()),
            Times.Once);

        _ = result.Should().NotBeNull();

        _ = result.PagedList.Items.Should().BeEquivalentTo(pagedListCustomers.Items);
    }

    [Fact]
    public async Task Handle_ShouldNotThrowException_WhenCalled()
    {
        // Arrange
        var query = _fixture.Create<GetAllCustomersQuery>();

        // Act
        var act = async () => await _handler.Handle(query, CancellationToken.None);

        // Assert
        _ = await act.Should().NotThrowAsync();
    }
}
