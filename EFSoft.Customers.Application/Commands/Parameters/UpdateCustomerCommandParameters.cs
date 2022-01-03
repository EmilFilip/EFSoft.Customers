namespace EFSoft.Customers.Application.Commands.Parameters;

public class UpdateCustomerCommandParameters : ICommand
{
    public UpdateCustomerCommandParameters(
         Guid customerId,
         string fullName,
         DateTimeOffset dateOfBirth)
    {
        CustomerId = customerId;
        FullName = fullName;
        DateOfBirth = dateOfBirth;
    }

    public Guid CustomerId { get; }

    public string FullName { get; }

    public DateTimeOffset DateOfBirth { get; }
}
