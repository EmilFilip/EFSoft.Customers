namespace EFSoft.Customers.Domain.RepositoryContracts;
public interface IUpdateCustomerRepository
{
    Task UpdateCustomerAsync(
        CustomerDomainModel customer,
        CancellationToken cancellationToken = default);
}
