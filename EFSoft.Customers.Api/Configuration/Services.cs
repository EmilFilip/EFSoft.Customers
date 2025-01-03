using EFSoft.Customers.Application.GetCustomer;
using EFSoft.Customers.Infrastructure.Repositories;

namespace EFSoft.Customers.Api.Configuration;

[ExcludeFromCodeCoverage]
public static class Services
{
    public static IServiceCollection RegisterLocalServices(
                    this IServiceCollection services,
                    IConfiguration configuration)
    {
        return services
             .RegisterCqrs(typeof(GetCustomerQuery).Assembly)
             .AddDbContext<CustomersDbContext>(
                options =>
                {
                    options.UseSqlServer(configuration.GetConnectionString("CustomersConnectionString"), sqlServeroptions =>
                    {
                        sqlServeroptions.EnableRetryOnFailure();
                    });
                })
             .AddScoped<ICreateCustomerRepository, CreateCustomerRepository>()
             .AddScoped<IDeleteCustomerRepository, DeleteCustomerRepository>()
             .AddScoped<IGetCustomerRepository, GetCustomerRepository>()
             .AddScoped<IGetCustomersRepository, GetCustomersRepository>()
             .AddScoped<IUpdateCustomerRepository, UpdateCustomerRepository>();
    }
}
