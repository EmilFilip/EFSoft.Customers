namespace EFSoft.Customers.Application.Queries.Handlers;

public class GetCustomersQueryHandler :
        IQueryHandler<GetCustomersQueryParameters, GetCustomersQueryResult>
{
    private readonly ICustomerRepository _customerRepository;

    public GetCustomersQueryHandler(ICustomerRepository customerRepository)
    {
        _customerRepository = customerRepository ?? throw new ArgumentNullException(nameof(customerRepository));
    }

    public async Task<GetCustomersQueryResult> HandleAsync(
            GetCustomersQueryParameters parameters,
            CancellationToken cancellationToken = default)
    {
        var customers = await _customerRepository.GetCustomersAsync(
            parameters.CustomerIds,
            cancellationToken);

        return new GetCustomersQueryResult(customers: customers);
    }
}
