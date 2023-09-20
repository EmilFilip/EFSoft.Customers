namespace EFSoft.Customers.Application.Queries.GetCustomer;

public sealed record GetCustomerQuery(Guid CustomerId) : IQuery<GetCustomerQueryResult>
{
}
