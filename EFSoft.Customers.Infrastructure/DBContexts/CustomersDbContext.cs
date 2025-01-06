namespace EFSoft.Customers.Infrastructure.DBContexts;

public class CustomersDbContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<Customer> Customers { get; set; }
}
