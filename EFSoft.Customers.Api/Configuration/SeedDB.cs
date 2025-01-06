namespace EFSoft.Customers.Api.Configuration;

public static class SeedDB
{
    public static async void SeedCustomerDb(this WebApplication app)
    {
        using (var scope = app.Services.CreateScope())
        {
            using (var context = scope.ServiceProvider.GetRequiredService<CustomersDbContext>())
            {
                try
                {
                    context.Database.Migrate();
                    _ = context.Database.EnsureCreated();

                    if (context.Customers.Any())
                    {
                        return;
                    }

                    await context.Customers.AddRangeAsync(
                                new Customer
                                {
                                    CustomerId = new Guid(),
                                    FullName = "Loredana Simerea",
                                    DateOfBirth = new DateTime(1980, 11, 05)
                                },
                                new Customer
                                {
                                    CustomerId = new Guid(),
                                    FullName = "Emil Filip",
                                    DateOfBirth = new DateTime(1979, 03, 07)
                                });

                    var saved = await context.SaveChangesAsync();

                }
                catch (Exception ex)
                {
                    throw new Exception("An error occurred while migrating or initializing the database.", ex);
                }
            }
        }
    }
}
