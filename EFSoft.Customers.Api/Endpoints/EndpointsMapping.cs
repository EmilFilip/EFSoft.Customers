namespace EFSoft.Customers.Api.Endpoints;

public class EndpointsMapping : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("api/customer").WithTags("Customers");
        //.RequireAuthorization();

        _ = group.MapGet("/{customerId:guid}", GetCustomerEndpoint.GetCustomer).WithDisplayName(nameof(GetCustomerEndpoint.GetCustomer));
        _ = group.MapPost("/{customerIds}", GetCustomersEndpoint.GetCustomers).WithName(nameof(GetCustomersEndpoint.GetCustomers));
        _ = group.MapPost("/", CreateCustomerEndpoint.CreateCustomer).WithDescription(nameof(CreateCustomerEndpoint.CreateCustomer));
        _ = group.MapPut("/", UpdateCustomerEndpoint.UpdateCustomer);
        _ = group.MapDelete("/{customerId:guid}", DeleteCustomerEndpoint.DeleteCustomer);
    }
}
