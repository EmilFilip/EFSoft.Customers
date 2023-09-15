using EFSoft.Customers.Application.Commands.CreateCustomer;

using FluentValidation;

namespace EFSoft.Customers.Application.Validation;

public class CreateCustomerCommandValidator : AbstractValidator<CreateCustomerCommand>
{
    public CreateCustomerCommandValidator()
    {
        RuleFor(e => e.FullName)
            .NotNull().WithMessage("CustomerId cannot be null")
            .NotEmpty().WithMessage("CustomerId cannot be empty")
            .NotEqual("Emil Filip").WithMessage("Validation is working fine");

    }
}
