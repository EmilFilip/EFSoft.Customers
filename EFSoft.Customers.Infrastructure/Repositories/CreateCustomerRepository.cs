namespace EFSoft.Customers.Infrastructure.Repositories;

public class CreateCustomerRepository : ICreateCustomerRepository
{
    private readonly CustomersDbContext _customersDbContext;

    public CreateCustomerRepository(CustomersDbContext customerDbContext)
    {
        _customersDbContext = customerDbContext;
    }

    public async Task CreateCustomerAsync(
        CustomerModel customer,
        CancellationToken cancellationToken)
    {
        var entity = MapToEntity(customer);

        _customersDbContext.Customers.Add(entity);

        await _customersDbContext
            .SaveChangesAsync(cancellationToken);
    }

    private static Customer MapToEntity(
        CustomerModel domainCustomer)
    {
        return new Customer
        {
            CustomerId = domainCustomer.CustomerId,
            FullName = domainCustomer.FullName,
            DateOfBirth = domainCustomer.DateOfBirth,
            HasOpenOrder = domainCustomer.HasOpenOrder,
            UpdatedAt = DateTime.UtcNow
        };
    }
}
