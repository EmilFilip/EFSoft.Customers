namespace EFSoft.Customers.Application.GetCustomer;

public sealed record GetCustomerQuery(Guid CustomerId)
    : IQuery<GetCustomerQueryResult?>;
