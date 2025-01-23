namespace EFSoft.Customers.ArchitectureTests;

public class ArchitectureBaseTest
{
    public static readonly Assembly ApplicationAssembly = typeof(CreateCustomerCommand).Assembly;
    public static readonly Assembly DomainAssembly = typeof(ICreateCustomerRepository).Assembly;
    public static readonly Assembly InfrastructureAssembly = typeof(CreateCustomerRepository).Assembly;
    public static readonly Assembly ApiAssembly = typeof(CreateCustomerRequest).Assembly;

    protected static void AssertAreImmutable(IEnumerable<Type> types)
    {
        var failingTypes = new List<Type>();

        foreach (var type in types)
        {
            if (type.GetFields().Any(x => !x.IsInitOnly) || type.GetProperties().Any(x => x.CanWrite))
            {
                failingTypes.Add(type);
                break;
            }
        }

        _ = failingTypes.Should().BeNullOrEmpty();
    }

    protected static void AssertAreOfTypeRecord(IEnumerable<Type> types)
    {
        var failingTypes = new List<Type>();

        foreach (var type in types)
        {
            var properties = type.GetTypeInfo().DeclaredProperties;
            if (!properties.Any(x => x.Name == "EqualityContract"))
            {
                failingTypes.Add(type);
            }
        }

        _ = failingTypes.Should().BeNullOrEmpty();
    }
}
