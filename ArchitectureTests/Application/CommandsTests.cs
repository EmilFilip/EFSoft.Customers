namespace EFSoft.ArchitectureTests.Application;

public class CommandsTests : ArchitectureBaseTest
{
    [Fact]
    public void Commands_Should_EndWithCommand()
    {
        var result = Types.InAssembly(ApplicationAssembly)
            .That()
            .ImplementInterface(typeof(ICommand))
            .And()
            .DoNotHaveNameEndingWith("Command")
            .GetTypes();

        _ = result.Should().BeNullOrEmpty();
    }

    [Fact]
    public void Commands_Should_BeSealed()
    {
        var result = Types.InAssembly(ApplicationAssembly)
            .That()
            .ImplementInterface(typeof(ICommand))
            .Should()
            .BeSealed()
            .GetResult();

        _ = result.IsSuccessful.Should().BeTrue();
    }

    [Fact]
    public void Commands_Should_ImplementICommand()
    {
        var result = Types.InAssembly(ApplicationAssembly)
            .That()
            .HaveNameEndingWith("Command")
            .Should()
            .ImplementInterface(typeof(ICommand))
            .GetResult();

        _ = result.IsSuccessful.Should().BeTrue();
    }

    [Fact]
    public void Commands_Should_BeOfTypeRecord()
    {
        var types = Types.InAssembly(ApplicationAssembly)
            .That()
            .ImplementInterface(typeof(ICommand))
            .GetTypes();

        AssertAreOfTypeRecord(types);
    }
}
