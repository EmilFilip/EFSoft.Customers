namespace EFSoft.Customers.Domain.Models;

public class CustomerDomainModel
{
    public CustomerDomainModel(
        Guid customerId,
        string fullName,
        DateTimeOffset dateOfBirth,
        bool hasOpenOrder)
    {
        CustomerId = customerId;
        FullName = fullName;
        DateOfBirth = dateOfBirth;
        HasOpenOrder = hasOpenOrder;
    }
    public CustomerDomainModel(
        Guid customerId,
        string fullName,
        DateTimeOffset dateOfBirth)
    {
        CustomerId = customerId;
        FullName = fullName;
        DateOfBirth = dateOfBirth;
    }

    public static CustomerDomainModel CreateNew(
        string fullName,
        DateTimeOffset dateOfBirth)
    {
        return new CustomerDomainModel(
            customerId: Guid.NewGuid(),
            fullName: fullName,
            dateOfBirth: dateOfBirth,
            hasOpenOrder: false);
    }

    public void Update(
        string fullName,
        DateTimeOffset dateOfBirth)
    {
        FullName = fullName;
        DateOfBirth = dateOfBirth;
    }

    public void UpdateOpenOrder(
        bool hasOpenOrder)
    {
        HasOpenOrder = hasOpenOrder;
    }

    public Guid CustomerId { get; }

    public string FullName { get; set; }

    public DateTimeOffset DateOfBirth { get; set; }

    public bool HasOpenOrder { get; set; }
}
