namespace EFSoft.Customers.Application.GetCustomer;

public class GetCustomerQueryHandler : IQueryHandler<GetCustomerQuery, GetCustomerQueryResult?>
{
    private readonly IGetCustomerRepository _getCustomerRepository;

    public GetCustomerQueryHandler(IGetCustomerRepository getCustomerRepository)
    {
        _getCustomerRepository = getCustomerRepository;
    }

    public async Task<GetCustomerQueryResult?> Handle(
            GetCustomerQuery parameters,
            CancellationToken cancellationToken = default)
    {
        var customer = await _getCustomerRepository.GetCustomerAsync(
            customerId: parameters.CustomerId,
            cancellationToken: cancellationToken);


        if (customer is null)
        {
            return default;
        }


        return new GetCustomerQueryResult(
            fullName: customer.FullName,
            dateOfBirth: customer.DateOfBirth);
    }
}
