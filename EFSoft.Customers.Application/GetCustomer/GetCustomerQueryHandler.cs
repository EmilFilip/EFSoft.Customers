namespace EFSoft.Customers.Application.GetCustomer;

public class GetCustomerQueryHandler(IGetCustomerRepository getCustomerRepository)
    : IQueryHandler<GetCustomerQuery, GetCustomerQueryResult?>
{
    public async Task<GetCustomerQueryResult?> Handle(
            GetCustomerQuery parameters,
            CancellationToken cancellationToken = default)
    {
        var customer = await getCustomerRepository.GetCustomerAsync(
            customerId: parameters.CustomerId,
            cancellationToken: cancellationToken);

        if (customer is null)
        {
            return default;
        }

        return new GetCustomerQueryResult(
            FullName: customer.FullName,
            DateOfBirth: customer.DateOfBirth);
    }
}
