namespace EFSoft.Customers.Application.GetAllCustomers;

public sealed record GetAllCustomersQueryResult(PagedList<CustomerDomainModel> PagedList);
