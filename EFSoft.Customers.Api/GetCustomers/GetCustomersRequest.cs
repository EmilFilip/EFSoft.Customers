namespace EFSoft.Customers.Api.GetCustomers;

public sealed record GetCustomersRequest(IEnumerable<Guid> CustomerIds);
