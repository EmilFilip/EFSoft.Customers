namespace EFSoft.Customers.Application.GetCustomers;

public class GetCustomersQueryHandler : IQueryHandler<GetCustomersQuery, GetCustomersQueryResult>
{
    private readonly IGetCustomersRepository _getCustomersRepository;

    public GetCustomersQueryHandler(IGetCustomersRepository getCustomersRepository)
    {
        _getCustomersRepository = getCustomersRepository;
    }

    public async Task<GetCustomersQueryResult> Handle(
            GetCustomersQuery parameters,
            CancellationToken cancellationToken = default)
    {
        var customers = await _getCustomersRepository.GetCustomersAsync(
            customerIds: parameters.CustomerIds,
            cancellationToken: cancellationToken);

        return new GetCustomersQueryResult(customers);
    }
}
