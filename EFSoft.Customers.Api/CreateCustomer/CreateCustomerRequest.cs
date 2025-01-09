namespace EFSoft.Customers.Api.CreateCustomer;

public sealed record CreateCustomerRequest(
     string FullName,
     DateTimeOffset DateOfBirth);
