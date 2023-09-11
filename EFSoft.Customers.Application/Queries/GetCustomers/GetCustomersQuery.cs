namespace EFSoft.Customers.Application.Queries.GetCustomers;

public sealed record GetCustomersQuery(IEnumerable<Guid> CustomerIds) : IRequest<GetCustomersQueryResult>
{
}
