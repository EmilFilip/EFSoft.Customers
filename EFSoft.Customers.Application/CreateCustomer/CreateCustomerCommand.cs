namespace EFSoft.Customers.Application.CreateCustomer;

public sealed record class CreateCustomerCommand(
    string FullName,
    DateTimeOffset DateOfBirth) : ICommand;
