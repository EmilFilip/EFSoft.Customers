namespace EFSoft.Customers.ArchitectureTests.Layers;

public class LayersTests : ArchitectureBaseTest
{
    [Fact]
    public void DomainLayer_DoesNotHaveDependency_ToApplicationLayer()
    {
        var result = Types.InAssembly(DomainAssembly)
            .Should()
            .NotHaveDependencyOn(ApplicationAssembly.GetName().Name)
            .GetResult();

        _ = result.FailingTypes.Should().BeNullOrEmpty();
    }

    [Fact]
    public void DomainLayer_DoesNotHaveDependency_ToInfrastructureLayer()
    {
        var result = Types.InAssembly(DomainAssembly)
            .Should()
            .NotHaveDependencyOn(InfrastructureAssembly.GetName().Name)
            .GetResult();

        _ = result.FailingTypes.Should().BeNullOrEmpty();
    }

    [Fact]
    public void DomainLayer_DoesNotHaveDependency_ToApiLayer()
    {
        var result = Types.InAssembly(DomainAssembly)
            .Should()
            .NotHaveDependencyOn(ApiAssembly.GetName().Name)
            .GetResult();

        _ = result.FailingTypes.Should().BeNullOrEmpty();
    }

    [Fact]
    public void ApplicationLayer_DoesNotHaveDependency_ToInfrastructureLayer()
    {
        var result = Types.InAssembly(ApplicationAssembly)
            .Should()
            .NotHaveDependencyOn(InfrastructureAssembly.GetName().Name)
            .GetResult();

        _ = result.FailingTypes.Should().BeNullOrEmpty();
    }

    [Fact]
    public void ApplicationLayer_DoesNotHaveDependency_ToApiLayer()
    {
        var result = Types.InAssembly(ApplicationAssembly)
            .Should()
            .NotHaveDependencyOn(ApiAssembly.GetName().Name)
            .GetResult();

        _ = result.FailingTypes.Should().BeNullOrEmpty();
    }

    [Fact]
    public void InfrastructureLayer_ShouldHaveDependency_ToApplicationLayer()
    {
        var result = Types.InAssembly(InfrastructureAssembly)
            .Should()
            .HaveDependencyOn(ApplicationAssembly.GetName().Name)
            .GetResult();

        _ = result.FailingTypes.Should().NotBeNullOrEmpty();
    }

    [Fact]
    public void ApplicationLayer_ShouldHaveDependency_ToDomainLayer()
    {
        var result = Types.InAssembly(ApplicationAssembly)
            .Should()
            .HaveDependencyOn(DomainAssembly.GetName().Name)
            .GetResult();

        _ = result.FailingTypes.Should().NotBeNullOrEmpty();
    }
}
