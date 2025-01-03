namespace EFSoft.Customers.Api.Endpoints.CreateCustomer;

public sealed record class CreateCustomerRequest(
     string FullName,
     DateTimeOffset DateOfBirth)
{
}
