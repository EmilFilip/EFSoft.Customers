namespace EFSoft.Customers.Application.RepositoryContracts;

public interface ICustomerRepository
{
    Task<CustomerModel> GetCustomerAsync(
              Guid customerId,
              CancellationToken cancellationToken = default(CancellationToken));

    Task<IEnumerable<CustomerModel>> GetCustomersAsync(
          IEnumerable<Guid> customerIds,
          CancellationToken cancellationToken = default(CancellationToken));

    Task CreateCustomerAsync(
        CustomerModel customer,
        CancellationToken cancellationToken = default(CancellationToken));

    Task UpdateCustomerAsync(
        CustomerModel customer,
        CancellationToken cancellationToken = default(CancellationToken));

    Task DeleteCustomerAsync(
        Guid customerId,
        CancellationToken cancellationToken = default(CancellationToken));
}
