namespace EFSoft.Customers.Api.Endpoints.GetCustomer;

public class GetCustomerRequestValidator : AbstractValidator<GetCustomerRequest>
{
    public GetCustomerRequestValidator()
    {
        RuleFor(e => e.CustomerId.ToString())
            .NotNull().WithMessage("CustomerId cannot be null")
            .NotEmpty().WithMessage("CustomerId cannot be empty");
    }
}
