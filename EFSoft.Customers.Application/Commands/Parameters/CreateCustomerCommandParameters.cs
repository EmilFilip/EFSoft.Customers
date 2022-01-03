namespace EFSoft.Customers.Application.Commands.Parameters;

public class CreateCustomerCommandParameters : ICommand
{
    public CreateCustomerCommandParameters(
         string fullName,
         DateTimeOffset dateOfBirth)
    {
        FullName = fullName;
        DateOfBirth = dateOfBirth;
    }

    public string FullName { get; }
    public DateTimeOffset DateOfBirth { get; }
}
