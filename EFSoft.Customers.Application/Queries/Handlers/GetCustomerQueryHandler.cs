namespace EFSoft.Customers.Application.Queries.Handlers;

public class GetCustomerQueryHandler :
        IQueryHandler<GetCustomerQueryParameters, GetCustomerQueryResult>
{
    private readonly ICustomerRepository _customerRepository;

    public GetCustomerQueryHandler(ICustomerRepository customerRepository)
    {
        _customerRepository = customerRepository ?? throw new ArgumentNullException(nameof(customerRepository));
    }

    public async Task<GetCustomerQueryResult> HandleAsync(
            GetCustomerQueryParameters parameters,
            CancellationToken cancellationToken = default)
    {
        var customer = await _customerRepository.GetCustomerAsync(
            parameters.CustomerId,
            cancellationToken);


        if (customer is null)
        {
            return null;
        }


        return new GetCustomerQueryResult(
            fullName: customer.FullName,
            dateOfBirth: customer.DateOfBirth);
    }
}

