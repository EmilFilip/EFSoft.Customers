namespace EFSoft.ArchitectureTests.Application;

public class ApplicationTests : ArchitectureBaseTest
{
    [Fact]
    public void Application_ShouldNotDependOnInfrastructure()
    {
        var result = Types.InAssembly(ApplicationAssembly)
            .That()
            .ResideInNamespace(ApplicationAssembly.GetName().Name)
            .ShouldNot()
            .HaveDependencyOn(InfrastructureAssembly.GetName().Name)
            .GetResult();

        Assert.True(result.IsSuccessful, "Application layer should not depend on Infrastructure layer.");
    }


    [Fact]
    public void Handlers_ShouldResideInCorrectNamespace()
    {
        var result = Types.InAssembly(ApplicationAssembly)
            .That()
            .ImplementInterface(typeof(ICommandHandler<>))
            .Or()
            .ImplementInterface(typeof(IQueryHandler<,>))
            .Should()
            .ResideInNamespace(ApplicationAssembly.GetName().Name)
            .GetResult();

        Assert.True(result.IsSuccessful, "Handlers should reside in the Application namespace.");
    }

    [Fact]
    public void Domain_ShouldNotDependOnOtherLayers()
    {
        var result = Types.InAssembly(ApplicationAssembly)
            .That()
            .ResideInNamespace(DomainAssembly.GetName().Name)
            .ShouldNot()
            .HaveDependencyOn(ApplicationAssembly.GetName().Name)
            .And()
            .HaveDependencyOn(InfrastructureAssembly.GetName().Name)
            .GetResult();

        Assert.True(result.IsSuccessful, "Domain layer should not depend on Application or Infrastructure layers.");
    }

    [Fact]
    public void Controllers_ShouldResideInApiNamespace()
    {
        var result = Types.InAssembly(ApplicationAssembly)
            .That()
            .HaveNameEndingWith("Controller")
            .Should()
            .ResideInNamespace(ApiAssembly.GetName().Name)
            .GetResult();

        Assert.True(result.IsSuccessful, "Controllers should reside in the API namespace.");
    }

    [Fact]
    public void CQRSHandlers_ShouldHaveCorrectNamingConvention()
    {
        var result = Types.InAssembly(ApplicationAssembly)
            .That()
            .ImplementInterface(typeof(ICommandHandler<>))
            .Or()
            .ImplementInterface(typeof(IQueryHandler<,>))
            .Should()
            .HaveNameEndingWith("Handler")
            .GetResult();

        Assert.True(result.IsSuccessful, "CQRS handlers should follow naming convention ending with 'Handler'.");
    }
}
