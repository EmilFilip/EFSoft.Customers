namespace EFSoft.Customers.Application.Queries.Results;

public class GetCustomersQueryResult : IQueryResult
{
    public GetCustomersQueryResult(IEnumerable<CustomerModel> customers)
    {
        Customers = customers;
    }

    public IEnumerable<CustomerModel> Customers { get; }
}
