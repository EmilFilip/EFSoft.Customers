namespace EFSoft.Customers.Domain.RepositoryContracts;

public interface ICreateCustomerRepository
{
    Task CreateCustomerAsync(
        CustomerModel customer,
        CancellationToken cancellationToken = default);
}
