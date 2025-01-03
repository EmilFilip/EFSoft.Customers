namespace EFSoft.Customers.Domain.RepositoryContracts;

public interface IDeleteCustomerRepository
{
    Task DeleteCustomerAsync(
        Guid customerId,
        CancellationToken cancellationToken = default);
}
