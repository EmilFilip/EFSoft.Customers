namespace EFSoft.Customers.Infrastructure.Repositories;

public class GetCustomersRepository : IGetCustomersRepository
{
    private readonly CustomersDbContext _customersDbContext;

    public GetCustomersRepository(CustomersDbContext customerDbContext)
    {
        _customersDbContext = customerDbContext;
    }

    public async Task<IEnumerable<CustomerModel>> GetCustomersAsync(
        IEnumerable<Guid> customerIds, 
        CancellationToken cancellationToken = default)
    {

        var entities = await _customersDbContext.Customers
            .AsQueryable()
            .Where(c => customerIds.Contains(c.CustomerId) && c.Deleted == false)
            .AsNoTracking()
            .ToListAsync(cancellationToken);

        return entities.Select(x => MapToDomain(x));
    }

    private static CustomerModel MapToDomain(
        Customer entityCustomer)
    {
        return new CustomerModel(
            customerId: entityCustomer.CustomerId,
            fullName: entityCustomer.FullName,
            dateOfBirth: entityCustomer.DateOfBirth,
            hasOpenOrder: entityCustomer.HasOpenOrder);
    }
}
