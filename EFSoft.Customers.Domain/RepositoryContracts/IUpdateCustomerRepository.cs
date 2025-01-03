namespace EFSoft.Customers.Domain.RepositoryContracts;
public interface IUpdateCustomerRepository
{
    Task UpdateCustomerAsync(
        CustomerModel customer,
        CancellationToken cancellationToken = default);
}
