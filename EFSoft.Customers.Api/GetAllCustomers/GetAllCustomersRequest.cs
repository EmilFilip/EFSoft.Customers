namespace EFSoft.Customers.Api.GetAllCustomers;

public sealed record GetAllCustomersRequest(
    string? SearchTerm,
    string? SortColumn,
    string? SortOrder,
    int Page,
    int PageSize);
