namespace EFSoft.Customers.Application.GetCustomer;

public sealed record GetCustomerQueryResult(
    Guid CustomerId,
    string FullName,
    DateTimeOffset DateOfBirth,
    bool HasOpenedOrder);
