namespace EFSoft.Customers.Api.Endpoints.UpdateCustomer;

public sealed record UpdateCustomerRequest(
     Guid CustomerId,
     string FullName,
     DateTimeOffset DateOfBirth)
{
}
