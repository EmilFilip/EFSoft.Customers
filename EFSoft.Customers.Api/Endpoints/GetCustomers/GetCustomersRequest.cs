namespace EFSoft.Customers.Api.Endpoints.GetCustomers;

public sealed record GetCustomersRequest(IEnumerable<Guid> CustomerIds)
{
    //public static ValueTask<GetCustomersRequest> BindAsync(HttpContext context)
    //{
    //    string[] queries = context.Request.Query[nameof(CustomerIds)];

    //    var result = new GetCustomersRequest( queries.Select(Guid.Parse).ToList());

    //    return ValueTask.FromResult(result);
    //}
}
