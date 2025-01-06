namespace EFSoft.Customers.Application.GetCustomers;

public sealed record GetCustomersQueryResult(IEnumerable<CustomerDomainModel> Customers);
