namespace EFSoft.Customers.Api.Endpoints.UpdateCustomer;

public static class UpdateCustomerEndpoint
{
    public static async Task<IResult> UpdateCustomer(
        [FromBody] UpdateCustomerRequest updateCustomerRequest,
        IMediator mediator,
        CancellationToken cancellationToken)
    {
        var updateCustomerCommand = new UpdateCustomerCommand(
            CustomerId: updateCustomerRequest.CustomerId,
            FullName: updateCustomerRequest.FullName,
            DateOfBirth: updateCustomerRequest.DateOfBirth);

        await mediator.Send(
            updateCustomerCommand,
            cancellationToken);

        return Results.Ok();
    }
}
