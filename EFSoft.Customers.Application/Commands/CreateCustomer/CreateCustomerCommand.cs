namespace EFSoft.Customers.Application.Commands.CreateCustomer;

public sealed record class CreateCustomerCommand(
         string FullName,
         DateTimeOffset DateOfBirth) : IRequest
{
}
