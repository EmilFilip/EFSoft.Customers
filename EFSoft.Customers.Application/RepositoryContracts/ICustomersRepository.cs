namespace EFSoft.Customers.Application.RepositoryContracts;

public interface ICustomersRepository
{
    Task<CustomerModel> GetCustomerAsync(
              Guid customerId,
              CancellationToken cancellationToken = default);

    Task<IEnumerable<CustomerModel>> GetCustomersAsync(
          IEnumerable<Guid> customerIds,
          CancellationToken cancellationToken = default);

    Task CreateCustomerAsync(
        CustomerModel customer,
        CancellationToken cancellationToken = default);

    Task UpdateCustomerAsync(
        CustomerModel customer,
        CancellationToken cancellationToken = default);

    Task DeleteCustomerAsync(
        Guid customerId,
        CancellationToken cancellationToken = default);
}
