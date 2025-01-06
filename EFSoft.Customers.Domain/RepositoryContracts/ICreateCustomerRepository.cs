namespace EFSoft.Customers.Domain.RepositoryContracts;

public interface ICreateCustomerRepository
{
    Task CreateCustomerAsync(
        CustomerDomainModel customer,
        CancellationToken cancellationToken = default);
}
