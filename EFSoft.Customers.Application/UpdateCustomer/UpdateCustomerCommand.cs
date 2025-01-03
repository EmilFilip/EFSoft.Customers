namespace EFSoft.Customers.Application.UpdateCustomer;

public sealed record UpdateCustomerCommand(
         Guid CustomerId,
         string FullName,
         DateTimeOffset DateOfBirth) : ICommand
{
}
