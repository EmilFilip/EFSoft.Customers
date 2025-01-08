namespace EFSoft.Customers.Domain.Models;

public sealed record PagedListParams(
    string? SearchTerm,
    string? SortColumn,
    string? SortOrder,
    int Page,
    int PageSize);
