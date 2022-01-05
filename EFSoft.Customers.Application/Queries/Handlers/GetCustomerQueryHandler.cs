namespace EFSoft.Customers.Application.Queries.Handlers;

public class GetCustomerQueryHandler :
        IQueryHandler<GetCustomerQueryParameters, GetCustomerQueryResult>
{
    private readonly ICustomersRepository _customerRepository;

    public GetCustomerQueryHandler(ICustomersRepository customerRepository)
    {
        _customerRepository = customerRepository ?? throw new ArgumentNullException(nameof(customerRepository));
    }

    public async Task<GetCustomerQueryResult> HandleAsync(
            GetCustomerQueryParameters parameters,
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

