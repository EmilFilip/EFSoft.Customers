namespace EFSoft.Customers.ArchitectureTests.Application;

public class QueriesTests : ArchitectureBaseTest
{
    [Fact]
    public void Queries_Should_EndWithQuery()
    {
        var result = Types.InAssembly(ApplicationAssembly)
            .That()
            .ImplementInterface(typeof(IQuery<>))
            .And()
            .DoNotHaveNameEndingWith("Query")
            .GetTypes();

        _ = result.Should().BeNullOrEmpty();
    }

    [Fact]
    public void Queries_Should_BeSealed()
    {
        var result = Types.InAssembly(ApplicationAssembly)
            .That()
            .HaveNameEndingWith("Query")
            .Should()
            .BeSealed()
            .GetResult();

        _ = result.IsSuccessful.Should().BeTrue();
    }

    [Fact]
    public void Queries_Should_ImplementIQuery()
    {
        var result = Types.InAssembly(ApplicationAssembly)
            .That()
            .HaveNameEndingWith("Query")
            .Should()
            .ImplementInterface(typeof(IQuery<>))
            .GetResult();

        _ = result.IsSuccessful.Should().BeTrue();
    }

    [Fact]
    public void Commands_Should_BeOfTypeRecord()
    {
        var types = Types.InAssembly(ApplicationAssembly)
            .That()
            .ImplementInterface(typeof(IQuery<>))
            .GetTypes();

        AssertAreOfTypeRecord(types);
    }
}
