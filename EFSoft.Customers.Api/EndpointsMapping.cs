namespace EFSoft.Customers.Api;

public class EndpointsMapping : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("api/customer").WithTags("Customers");

        _ = group.MapGet("/{customerId:guid}", GetCustomerEndpoint.GetCustomer);

        _ = group.MapPost("/get-customers", GetCustomersEndpoint.GetCustomers);

        _ = group.MapPost("/get-all-customers", GetAllCustomersEndpoint.GetAllCustomers);

        _ = group.MapPost("/", CreateCustomerEndpoint.CreateCustomer);

        _ = group.MapPut("/", UpdateCustomerEndpoint.UpdateCustomer);

        _ = group.MapDelete("/{customerId:guid}", DeleteCustomerEndpoint.DeleteCustomer);
    }
}
