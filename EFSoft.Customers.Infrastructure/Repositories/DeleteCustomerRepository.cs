namespace EFSoft.Customers.Infrastructure.Repositories;

public class DeleteCustomerRepository(CustomersDbContext customersDbContext) : IDeleteCustomerRepository
{
    public async Task DeleteCustomerAsync(
        Guid customerId,
        CancellationToken cancellationToken)
    {
        var entity = await customersDbContext.Customers.FindAsync(
            keyValues: [customerId],
            cancellationToken: cancellationToken);

        if (entity != null)
        {
            entity.Deleted = true;
            entity.DeletedAt = DateTime.UtcNow;

            _ = customersDbContext.Update(entity);
            _ = await customersDbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
