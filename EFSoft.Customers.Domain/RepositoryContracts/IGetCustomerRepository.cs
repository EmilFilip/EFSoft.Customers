namespace EFSoft.Customers.Domain.RepositoryContracts;

public interface IGetCustomerRepository
{
    Task<CustomerDomainModel?> GetCustomerAsync(
              Guid customerId,
              CancellationToken cancellationToken = default);
}
