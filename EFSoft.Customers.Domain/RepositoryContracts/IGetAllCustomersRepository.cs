namespace EFSoft.Customers.Domain.RepositoryContracts;

public interface IGetAllCustomersRepository
{
    Task<PagedList<CustomerDomainModel>> GetAllCustomersAsync(
          PagedListParams pagedListParams,
          CancellationToken cancellationToken = default);
}
