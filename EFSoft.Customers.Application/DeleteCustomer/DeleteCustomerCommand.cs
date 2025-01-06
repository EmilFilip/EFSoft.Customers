namespace EFSoft.Customers.Application.DeleteCustomer;

public sealed record DeleteCustomerCommand(Guid CustomerId) : ICommand;
