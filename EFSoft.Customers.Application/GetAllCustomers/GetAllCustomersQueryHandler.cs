namespace EFSoft.Customers.Application.GetAllCustomers;

public class GetAllCustomersQueryHandler(IGetAllCustomersRepository getAllCustomersRepository)
    : IQueryHandler<GetAllCustomersQuery, GetAllCustomersQueryResult>
{
    public async Task<GetAllCustomersQueryResult> Handle(
            GetAllCustomersQuery parameters,
            CancellationToken cancellationToken = default)
    {
        var pagedListParams = new PagedListParams(
            parameters.SearchTerm,
            parameters.SortColumn,
            parameters.SortOrder,
            parameters.Page,
            parameters.PageSize);

        var customers = await getAllCustomersRepository.GetAllCustomersAsync(
            pagedListParams: pagedListParams,
            cancellationToken: cancellationToken);

        return new GetAllCustomersQueryResult(customers);
    }
}
