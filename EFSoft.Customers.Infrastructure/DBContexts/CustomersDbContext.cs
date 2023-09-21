namespace EFSoft.Customers.Infrastructure.DBContexts;

public class CustomersDbContext : DbContext
{
    public CustomersDbContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Customer> Customers { get; set; }
}
