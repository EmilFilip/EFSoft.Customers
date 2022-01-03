namespace EFSoft.Customers.Api.Configuration;

[ExcludeFromCodeCoverage]
public static class ServicesInstaller
{
    public static IServiceCollection RegisterLocalServices(
                    this IServiceCollection services,
                    IConfiguration configuration)
    {
        return services
             .AddCqrs(configurator =>
                    configurator.AddHandlers(typeof(GetCustomerQueryParameters).Assembly))
             .AddDbContext<CustomerDbContext>(
                options =>
                {
                    options.UseSqlServer(configuration.GetConnectionString("CustomerDbConnection"));
                })
             .AddScoped<ICustomerRepository, CustomerRepository>();
    }
}
