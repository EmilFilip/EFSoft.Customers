namespace EFSoft.Customers.Application.Commands.CreateCustomer;

public class CreateCustomerCommandValidator : AbstractValidator<CreateCustomerCommand>
{
    public CreateCustomerCommandValidator()
    {
        RuleFor(e => e.FullName)
            .NotNull().WithMessage("FullName cannot be null")
            .NotEmpty().WithMessage("FullName cannot be empty");
    }
}
