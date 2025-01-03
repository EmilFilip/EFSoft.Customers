namespace EFSoft.Customers.Api.Endpoints.DeleteCustomer;

public static class DeleteCustomerEndpoint
{
    public static async Task<IResult> DeleteCustomer(
        [FromRoute] Guid customerId,
        IMediator mediator,
        CancellationToken cancellationToken)
    {
        var deleteCustomerCommand = new DeleteCustomerCommand(customerId);

        await mediator.Send(
            deleteCustomerCommand,
            cancellationToken);

        return Results.Ok();
    }
}
