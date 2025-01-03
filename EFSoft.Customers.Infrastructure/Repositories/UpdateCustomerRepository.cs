namespace EFSoft.Customers.Infrastructure.Repositories;

public class UpdateCustomerRepository : IUpdateCustomerRepository
{
    private readonly CustomersDbContext _customersDbContext;

    public UpdateCustomerRepository(CustomersDbContext customerDbContext)
    {
        _customersDbContext = customerDbContext;
    }

    public async Task UpdateCustomerAsync(
        CustomerModel customer,
        CancellationToken cancellationToken)
    {
        var entity = await _customersDbContext.Customers.FindAsync(
            keyValues: new object[] { customer.CustomerId },
            cancellationToken: cancellationToken);

        if (entity != null)
        {
            entity.UpdatedAt = DateTime.UtcNow;
            entity.FullName = customer.FullName;
            entity.DateOfBirth = customer.DateOfBirth;

            _customersDbContext.Update(entity);
            await _customersDbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
