namespace EFSoft.Customers.Domain.Models;

public class CustomerModel
{
    public CustomerModel(
        Guid customerId,
        string fullName,
        DateTimeOffset dateOfBirth)
    {
        CustomerId = customerId;
        FullName = fullName;
        DateOfBirth = dateOfBirth;
    }

    public static CustomerModel CreateNew(
        string fullName,
        DateTimeOffset dateOfBirth)
    {
        return new CustomerModel(
            customerId: Guid.NewGuid(),
            fullName: fullName,
            dateOfBirth: dateOfBirth);
    }

    public void Update(
        string fullName,
        DateTimeOffset dateOfBirth)
    {
        FullName = fullName;
        DateOfBirth = dateOfBirth;
    }

    public Guid CustomerId { get; set; }

    public string FullName { get; set; }

    public DateTimeOffset DateOfBirth { get; set; }
}
