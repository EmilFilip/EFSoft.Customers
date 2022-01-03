namespace EFSoft.Customers.Application.Queries.Results;

    public class GetCustomerQueryResult : IQueryResult
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
