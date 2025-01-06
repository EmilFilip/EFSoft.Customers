namespace EFSoft.Customers.Api.CreateCustomer;

public sealed record class CreateCustomerRequest(
     string FullName,
     DateTimeOffset DateOfBirth);
