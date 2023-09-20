namespace EFSoft.Customers.Application.Queries.GetCustomer;

public class GetCustomerQueryHandler : IQueryHandler<GetCustomerQuery, GetCustomerQueryResult>
{
    private readonly ICustomersRepository _customerRepository;

    public GetCustomerQueryHandler(ICustomersRepository customerRepository)
    {
        _customerRepository = customerRepository ?? throw new ArgumentNullException(nameof(customerRepository));
    }

    public async Task<GetCustomerQueryResult> Handle(
            GetCustomerQuery parameters,
            CancellationToken cancellationToken = default)
    {
        var customer = await _customerRepository.GetCustomerAsync(
            customerId: parameters.CustomerId,
            cancellationToken: cancellationToken);


        if (customer is null)
        {
            return null;
        }


        return new GetCustomerQueryResult(
            fullName: customer.FullName,
            dateOfBirth: customer.DateOfBirth);
    }
}
