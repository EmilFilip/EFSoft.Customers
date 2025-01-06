namespace EFSoft.Customers.Application.GetCustomers;

public class GetCustomersQueryHandler(IGetCustomersRepository getCustomersRepository)
    : IQueryHandler<GetCustomersQuery, GetCustomersQueryResult>
{
    public async Task<GetCustomersQueryResult> Handle(
            GetCustomersQuery parameters,
            CancellationToken cancellationToken = default)
    {
        var customers = await getCustomersRepository.GetCustomersAsync(
            customerIds: parameters.CustomerIds,
            cancellationToken: cancellationToken);

        return new GetCustomersQueryResult(customers);
    }
}
