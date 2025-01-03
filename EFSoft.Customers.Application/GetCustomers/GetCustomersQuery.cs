namespace EFSoft.Customers.Application.GetCustomers;

public sealed record GetCustomersQuery(IEnumerable<Guid> CustomerIds) : IQuery<GetCustomersQueryResult>
{
}
