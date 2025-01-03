namespace EFSoft.Customers.Application.CreateCustomer;

public class CreateCustomerRequestValidator : AbstractValidator<CreateCustomerRequest>
{
    public CreateCustomerRequestValidator()
    {
        RuleFor(e => e.FullName)
            .NotNull().WithMessage("FullName cannot be null")
            .NotEmpty().WithMessage("FullName cannot be empty");
    }
}
