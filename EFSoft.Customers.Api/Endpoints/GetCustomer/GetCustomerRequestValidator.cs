namespace EFSoft.Customers.Api.Endpoints.GetCustomer;

public class GetCustomerRequestValidator : AbstractValidator<GetCustomerRequest>
{
    public GetCustomerRequestValidator()
    {
        _ = RuleFor(e => e.CustomerId.ToString())
            .NotNull().WithMessage("CustomerId cannot be null")
            .NotEmpty().WithMessage("CustomerId cannot be empty");
    }
}
