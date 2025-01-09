namespace EFSoft.Customers.Application.CreateCustomer;

public sealed record CreateCustomerCommand(
    string FullName,
    DateTimeOffset DateOfBirth) : ICommand;
