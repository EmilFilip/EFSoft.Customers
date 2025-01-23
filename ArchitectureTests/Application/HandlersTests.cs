namespace ArchitectureTests.Application;

public class HandlersTests : ArchitectureBaseTest
{
    [Fact]
    public void CommandHandlers_Should_EndWithCommandHandler()
    {
        var result = Types.InAssembly(ApplicationAssembly)
            .That()
            .ImplementInterface(typeof(ICommandHandler<>))
            .And()
            .DoNotHaveNameEndingWith("CommandHandler")
            .GetTypes();

        _ = result.Should().BeNullOrEmpty();
    }

    [Fact]
    public void CommandHandlers_Should_ImplementICommandHandler()
    {
        var result = Types.InAssembly(ApplicationAssembly)
            .That()
            .HaveNameEndingWith("CommandHandler")
            .Should()
            .NotImplementInterface(typeof(ICommandHandler<>))
            .GetTypes();

        _ = result.Should().BeNullOrEmpty();
    }

    [Fact]
    public void QueryHandlers_Should_EndWithCommandHandler()
    {
        var result = Types.InAssembly(ApplicationAssembly)
            .That()
            .ImplementInterface(typeof(IQueryHandler<,>))
            .And()
            .DoNotHaveNameEndingWith("QueryHandler")
            .GetTypes();

        _ = result.Should().BeNullOrEmpty();
    }

    [Fact]
    public void QueryHandlers_Should_ImplementICommandHandler()
    {
        var result = Types.InAssembly(ApplicationAssembly)
            .That()
            .HaveNameEndingWith("QueryHandler")
            .Should()
            .NotImplementInterface(typeof(IQueryHandler<,>))
            .GetTypes();

        _ = result.Should().BeNullOrEmpty();
    }
}
