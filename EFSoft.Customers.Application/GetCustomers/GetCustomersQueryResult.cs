namespace EFSoft.Customers.Application.GetCustomers;

public class GetCustomersQueryResult
{
    public GetCustomersQueryResult(IEnumerable<CustomerModel> customers)
    {
        Customers = customers;
    }

    public IEnumerable<CustomerModel> Customers { get; }
}
