namespace EFSoft.Customers.Application.GetCustomer;

public sealed record GetCustomerQueryResult(
        string FullName,
        DateTimeOffset DateOfBirth);
