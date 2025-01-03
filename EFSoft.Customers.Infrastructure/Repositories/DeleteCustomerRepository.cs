namespace EFSoft.Customers.Infrastructure.Repositories;

public class DeleteCustomerRepository : IDeleteCustomerRepository
{
    private readonly CustomersDbContext _customersDbContext;

    public DeleteCustomerRepository(CustomersDbContext customerDbContext)
    {
        _customersDbContext = customerDbContext;
    }

    public async Task DeleteCustomerAsync(
        Guid customerId,
        CancellationToken cancellationToken)
    {
        var entity = await _customersDbContext.Customers.FindAsync(
            keyValues: new object[] { customerId },
            cancellationToken: cancellationToken);

        if (entity != null)
        {
            entity.Deleted = true;
            entity.DeletedAt = DateTime.UtcNow;

            _customersDbContext.Update(entity);
            await _customersDbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
