namespace EFSoft.Customers.Api.Endpoints;

public static class CustomerEndpoints
{
    public static void MapCustomerEndpoints(this IEndpointRouteBuilder endpoint)
    {
        var group = endpoint.MapGroup("api/customer");

        group.MapGet("{customerId:guid}", Get);
        group.MapGet("{customerIds}", GetCustomers);
        group.MapPost("", Post);
        group.MapPut("", Put);
        group.MapDelete("{customerId:guid}", Delete);
    }

    public static async Task<Results<Ok<GetCustomerQueryResult>, NotFound>> Get(
        Guid customerId,
        IMediator mediator,
        CancellationToken cancellationToken)
    {
        var results = await mediator.Send(
            new GetCustomerQuery(customerId),
            cancellationToken);

        if (results == null)
        {
            return TypedResults.NotFound();
        }

        return TypedResults.Ok(results);
    }

    public static async Task<Results<Ok<IEnumerable<CustomerModel>>, NotFound>> GetCustomers(
        Guid[] customerIds,
        IMediator mediator,
        CancellationToken cancellationToken)
    {
        var results = await mediator.Send(
            new GetCustomersQuery(customerIds),
            cancellationToken);

        if (results == null)
        {
            return TypedResults.NotFound();
        }

        return TypedResults.Ok(results.Customers);
    }

    public static async Task<IResult> Post(
        [FromBody] CreateCustomerCommand parameters,
        IMediator mediator,
        CancellationToken cancellationToken)
    {
        await mediator.Send(
            parameters,
            cancellationToken);

        return Results.Ok();
    }

    public static async Task<IResult> Put(
        [FromBody] UpdateCustomerCommand parameters,
        IMediator mediator,
        CancellationToken cancellationToken)
    {
        await mediator.Send(
            parameters,
            cancellationToken);

        return Results.Ok();
    }

    public static async Task<IResult> Delete(
        Guid customerId,
        IMediator mediator,
        CancellationToken cancellationToken)
    {
        await mediator.Send(
            new DeleteCustomerCommand(customerId),
            cancellationToken);

        return Results.Ok();
    }
}
