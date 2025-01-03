namespace EFSoft.Customers.Infrastructure.Repositories;

public class GetCustomerRepository(CustomersDbContext customerDbContext) : IGetCustomerRepository
{
    public async Task<CustomerModel?> GetCustomerAsync(
        Guid customerId,
        CancellationToken cancellationToken)
    {
        var entity = await customerDbContext.Customers
            .AsQueryable()
            .AsNoTracking()
            .FirstOrDefaultAsync(c => c.CustomerId == customerId && c.Deleted == false,
                                cancellationToken: cancellationToken);

        if (entity == null)
        {
            return null;
        }

        return MapToDomain(entity);
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
