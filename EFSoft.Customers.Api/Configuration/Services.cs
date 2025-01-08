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
                    _ = options.UseSqlServer(configuration.GetConnectionString("CustomersConnectionString"), sqlServeroptions =>
                    {
                        _ = sqlServeroptions.EnableRetryOnFailure();
                    });
                })
             .AddScoped<ICreateCustomerRepository, CreateCustomerRepository>()
             .AddScoped<IDeleteCustomerRepository, DeleteCustomerRepository>()
             .AddScoped<IGetCustomerRepository, GetCustomerRepository>()
             .AddScoped<IGetCustomersRepository, GetCustomersRepository>()
             .AddScoped<IGetAllCustomersRepository, GetAllCustomersRepository>()
             .AddScoped<IUpdateCustomerRepository, UpdateCustomerRepository>();
    }
}
