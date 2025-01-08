namespace EFSoft.Customers.Infrastructure.Repositories;

public class GetAllCustomersRepository(CustomersDbContext customerDbContext) : IGetAllCustomersRepository
{
    public async Task<PagedList<CustomerDomainModel>> GetAllCustomersAsync(
        PagedListParams pagedListParams,
        CancellationToken cancellationToken = default)
    {
        var customerQuery = customerDbContext.Customers.AsQueryable().AsNoTracking();

        if (!string.IsNullOrWhiteSpace(pagedListParams.SearchTerm))
        {
            customerQuery = customerQuery.Where(c =>
            c.FullName.Contains(pagedListParams.SearchTerm));
        }

        if (pagedListParams.SortOrder?.ToLower() == "desc")
        {
            customerQuery = customerQuery.OrderByDescending(GetSortProperty(pagedListParams.SortColumn!));
        }
        else
        {
            customerQuery = customerQuery.OrderBy(GetSortProperty(pagedListParams.SortColumn!));
        }

        var customerResponseQuery = customerQuery
            .Select(c => new CustomerDomainModel(
            c.CustomerId,
            c.FullName,
            c.DateOfBirth,
            c.HasOpenOrder));

        return new PagedList<CustomerDomainModel>(
            await customerResponseQuery.ToListAsync(cancellationToken),
            await customerResponseQuery.CountAsync(cancellationToken),
            pagedListParams.Page,
            pagedListParams.PageSize);
    }

    private static Expression<Func<Customer, object>> GetSortProperty(string sortColumn)
    {
        return sortColumn?.ToLower() switch
        {
            "FullName" => customer => customer.FullName,
            "DateOfBirth" => customer => customer.DateOfBirth,
            _ => customer => customer.UpdatedAt!
        };
    }
}
