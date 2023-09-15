using EFSoft.Customers.Application.Queries.GetCustomer;
using EFSoft.Customers.Application.Validation;

using FluentValidation;

namespace EFSoft.Customers.Api.Configuration;

[ExcludeFromCodeCoverage]
public static class ServicesInstaller
{
    public static IServiceCollection RegisterLocalServices(
                    this IServiceCollection services,
                    IConfiguration configuration)
    {
        var assembly = typeof(GetCustomerQuery).Assembly;

        return services
            .AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>))
             .AddMediatR(configure =>
             {
                 configure.RegisterServicesFromAssembly(assembly);
             })
             .AddValidatorsFromAssembly(assembly)
             .AddDbContext<CustomersDbContext>(
                options =>
                {
                    options.UseSqlServer(configuration.GetConnectionString("CustomersConnectionString"), sqlServeroptions =>
                    {
                        sqlServeroptions.EnableRetryOnFailure();
                    });
                })
             .AddScoped<ICustomersRepository, CustomersRepository>();
    }
}
