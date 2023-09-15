using Infrastructure.CQRS.Queries;

namespace EFSoft.Customers.Application.Queries.GetCustomers;

public sealed record GetCustomersQuery(IEnumerable<Guid> CustomerIds) : IQuery<GetCustomersQueryResult>
{
}
