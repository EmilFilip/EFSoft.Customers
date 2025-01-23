namespace EFSoft.Customers.ArchitectureTests.Application;

public class ResultsTests : ArchitectureBaseTest
{
    [Fact]
    public void Results_Should_BeSealed()
    {

        var result = Types.InAssembly(ApplicationAssembly)
            .That()
            .HaveNameEndingWith("Result")
            .Should()
            .BeSealed()
            .GetResult();

        _ = result.IsSuccessful.Should().BeTrue();
    }

    [Fact]
    public void Results_Should_NotImplementAnything()
    {
        var result = Types.InAssembly(ApplicationAssembly)
            .That()
            .HaveNameEndingWith("Result")
            .Should()
            .NotBeInterfaces()
            .GetResult();

        _ = result.IsSuccessful.Should().BeTrue();
    }

    [Fact]
    public void Results_Should_BeOfTypeRecord()
    {
        var types = Types.InAssembly(ApplicationAssembly)
            .That()
            .HaveNameEndingWith("Result")
            .GetTypes();

        AssertAreOfTypeRecord(types);
    }
}
