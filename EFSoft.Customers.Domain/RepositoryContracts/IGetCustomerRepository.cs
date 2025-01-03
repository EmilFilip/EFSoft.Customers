namespace EFSoft.Customers.Domain.RepositoryContracts;

public interface IGetCustomerRepository
{
    Task<CustomerModel?> GetCustomerAsync(
              Guid customerId,
              CancellationToken cancellationToken = default);
}
