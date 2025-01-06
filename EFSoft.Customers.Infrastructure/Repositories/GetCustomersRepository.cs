namespace EFSoft.Customers.Infrastructure.Repositories;

public class GetCustomersRepository(CustomersDbContext customerDbContext) : IGetCustomersRepository
{
    public async Task<IEnumerable<CustomerDomainModel>> GetCustomersAsync(
        IEnumerable<Guid> customerIds,
        CancellationToken cancellationToken = default)
    {

        var entities = await customerDbContext.Customers
            .AsQueryable()
            .Where(c => customerIds.Contains(c.CustomerId) && c.Deleted == false)
            .AsNoTracking()
            .ToListAsync(cancellationToken);

        return entities.Select(x => MapToDomain(x));
    }

    private static CustomerDomainModel MapToDomain(
        Customer entityCustomer)
    {
        return new CustomerDomainModel(
            customerId: entityCustomer.CustomerId,
            fullName: entityCustomer.FullName,
            dateOfBirth: entityCustomer.DateOfBirth,
            hasOpenOrder: entityCustomer.HasOpenOrder);
    }
}
