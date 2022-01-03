namespace EFSoft.Customers.Application.Queries.Parameters;

public class GetCustomersQueryParameters : IQueryParameters
{
    public GetCustomersQueryParameters(IEnumerable<Guid> customerIds)
    {
        CustomerIds = customerIds;
    }

    public IEnumerable<Guid> CustomerIds { get; set; }
}
