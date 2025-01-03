namespace EFSoft.Customers.Domain.RepositoryContracts;

public interface IGetCustomersRepository
{
    Task<IEnumerable<CustomerModel>> GetCustomersAsync(
          IEnumerable<Guid> customerIds,
          CancellationToken cancellationToken = default);
}
