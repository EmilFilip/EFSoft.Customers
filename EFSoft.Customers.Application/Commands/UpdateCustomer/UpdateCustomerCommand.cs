using Infrastructure.CQRS.Commands;

namespace EFSoft.Customers.Application.Commands.UpdateCustomer;

public sealed record UpdateCustomerCommand(
         Guid CustomerId,
         string FullName,
         DateTimeOffset DateOfBirth) : ICommand
{
}
