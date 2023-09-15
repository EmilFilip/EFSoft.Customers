using Infrastructure.CQRS.Commands;

namespace EFSoft.Customers.Application.Commands.DeleteCustomer;

public sealed record DeleteCustomerCommand(Guid CustomerId) : ICommand
{
}
