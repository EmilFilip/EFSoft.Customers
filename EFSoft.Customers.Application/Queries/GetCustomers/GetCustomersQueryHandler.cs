namespace EFSoft.Customers.Application.Queries.GetCustomers;

public class GetCustomersQueryHandler : IQueryHandler<GetCustomersQuery, GetCustomersQueryResult>
{
    private readonly ICustomersRepository _customerRepository;

    public GetCustomersQueryHandler(ICustomersRepository customerRepository)
    {
        _customerRepository = customerRepository ?? throw new ArgumentNullException(nameof(customerRepository));
    }

    public async Task<GetCustomersQueryResult> Handle(
            GetCustomersQuery parameters,
            CancellationToken cancellationToken = default)
    {
        var customers = await _customerRepository.GetCustomersAsync(
            customerIds: parameters.CustomerIds,
            cancellationToken: cancellationToken);

        return new GetCustomersQueryResult(customers);
    }
}
