namespace EFSoft.Customers.Infrastructure.Repositories;

public class UpdateCustomerRepository(CustomersDbContext customersDbContext) : IUpdateCustomerRepository
{
    public async Task UpdateCustomerAsync(
        CustomerDomainModel customer,
        CancellationToken cancellationToken)
    {
        var entity = await customersDbContext.Customers.FindAsync(
            keyValues: [customer.CustomerId],
            cancellationToken: cancellationToken);

        if (entity != null)
        {
            entity.UpdatedAt = DateTime.UtcNow;
            entity.FullName = customer.FullName;
            entity.DateOfBirth = customer.DateOfBirth;

            _ = customersDbContext.Update(entity);
            _ = await customersDbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
