namespace EFSoft.Customers.Api.CreateCustomer;

public static class CreateCustomerEndpoint
{
    public static async Task<IResult> CreateCustomer(
        [FromBody] CreateCustomerRequest createCustomerRequest,
        IMediator mediator,
        CancellationToken cancellationToken)
    {
        var createCustomerCommand = new CreateCustomerCommand(
            FullName: createCustomerRequest.FullName,
            DateOfBirth: createCustomerRequest.DateOfBirth);

        await mediator.Send(
            createCustomerCommand,
            cancellationToken);

        return Results.Ok();
    }
}
