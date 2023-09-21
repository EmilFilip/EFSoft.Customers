namespace EFSoft.Customers.Api.Endpoints;

public static class CustomerEndpoints
{
    public static void MapCustomerEndpoints(this IEndpointRouteBuilder endpoint)
    {
        var group = endpoint.MapGroup("api/customers");

        group.MapGet("{customerId:guid}", Get);
        group.MapPost("", Post);
        group.MapPut("", Put);
        group.MapDelete("{customerId:guid}", Delete);
    }

    public static async Task<Results<Ok<GetCustomerQueryResult>, NotFound>> Get(
        Guid customerId,
        IMediator mediator)
    {
        var results = await mediator.Send(new GetCustomerQuery(customerId));

        if (results == null)
        {
            return TypedResults.NotFound();
        }

        return TypedResults.Ok(results);
    }

    public static async Task<IResult> Post(
        [FromBody] CreateCustomerCommand parameters,
        IMediator mediator)
    {
        await mediator.Send(parameters);

        return Results.Ok();
    }

    public static async Task<IResult> Put(
        [FromBody] UpdateCustomerCommand parameters,
        IMediator mediator)
    {
        await mediator.Send(parameters);

        return Results.Ok();
    }

    public static async Task<IResult> Delete(
        Guid customerId,
        IMediator mediator)
    {
        await mediator.Send(new DeleteCustomerCommand(customerId));

        return Results.Ok();
    }
}
