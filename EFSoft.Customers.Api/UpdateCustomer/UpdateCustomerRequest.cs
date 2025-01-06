namespace EFSoft.Customers.Api.UpdateCustomer;

public sealed record UpdateCustomerRequest(
     Guid CustomerId,
     string FullName,
     DateTimeOffset DateOfBirth);