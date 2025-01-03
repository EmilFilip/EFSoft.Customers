namespace EFSoft.Customers.Application.GetCustomer;

public class GetCustomerQueryResult
{
    public GetCustomerQueryResult(
        string fullName,
        DateTimeOffset dateOfBirth)
    {
        FullName = fullName;
        DateOfBirth = dateOfBirth;
    }

    public string FullName { get; }
    public DateTimeOffset DateOfBirth { get; }
}
