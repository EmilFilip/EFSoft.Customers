namespace EFSoft.Customers.Api.Endpoints;

public class EndpointsMapping : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("api/customer").WithTags("Customers");
        //.RequireAuthorization();

        group.MapGet("/{customerId:guid}", GetCustomerEndpoint.GetCustomer).WithDisplayName(nameof(GetCustomerEndpoint.GetCustomer));
        group.MapPost("/{customerIds}", GetCustomersEndpoint.GetCustomers).WithName(nameof(GetCustomersEndpoint.GetCustomers));
        group.MapPost("/", CreateCustomerEndpoint.CreateCustomer).WithDescription(nameof(CreateCustomerEndpoint.CreateCustomer));
        group.MapPut("/", UpdateCustomerEndpoint.UpdateCustomer);
        group.MapDelete("/{customerId:guid}", DeleteCustomerEndpoint.DeleteCustomer);
    }
}
