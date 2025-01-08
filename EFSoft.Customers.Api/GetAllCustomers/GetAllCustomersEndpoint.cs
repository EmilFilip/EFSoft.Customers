using Microsoft.IdentityModel.Tokens;

namespace EFSoft.Customers.Api.GetAllCustomers;

public static class GetAllCustomersEndpoint
{
    public static async Task<Results<Ok<GetAllCustomersQueryResult>, NotFound>> GetAllCustomers(
        [FromBody] GetAllCustomersRequest getCustomersRequest,
        IMediator mediator,
        CancellationToken cancellationToken)
    {
        var getCustomersQuery = new GetAllCustomersQuery(
            getCustomersRequest.SearchTerm,
            getCustomersRequest.SortColumn,
            getCustomersRequest.SortOrder,
            getCustomersRequest.Page,
            getCustomersRequest.PageSize);

        var results = await mediator.Send(
            getCustomersQuery,
            cancellationToken);

        if (results.PagedList.Items.IsNullOrEmpty())
        {
            return TypedResults.NotFound();
        }

        return TypedResults.Ok(results);
    }
}
