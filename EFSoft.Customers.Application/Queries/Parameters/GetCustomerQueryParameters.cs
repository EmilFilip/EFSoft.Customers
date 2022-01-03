

namespace EFSoft.Customers.Application.Queries.Parameters;

public class GetCustomerQueryParameters : IQueryParameters
{
    public GetCustomerQueryParameters(Guid customerId)
    {
        CustomerId = customerId;
    }

    public Guid CustomerId { get; set; }
}
