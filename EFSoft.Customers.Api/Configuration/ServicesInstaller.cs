using EFSoft.Customers.Application.Queries.GetCustomer;

namespace EFSoft.Customers.Api.Configuration;

[ExcludeFromCodeCoverage]
public static class ServicesInstaller
{
    public static IServiceCollection RegisterLocalServices(
                    this IServiceCollection services,
                    IConfiguration configuration)
    {
        return services
             .AddMediatR(configure =>
             {
                 configure.RegisterServicesFromAssembly(typeof(GetCustomerQuery).Assembly);
             })
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
