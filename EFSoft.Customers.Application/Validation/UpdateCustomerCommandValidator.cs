using EFSoft.Customers.Application.Commands.UpdateCustomer;

using FluentValidation;

namespace EFSoft.Customers.Application.Validation;

public class UpdateCustomerCommandValidator : AbstractValidator<UpdateCustomerCommand>
{
    public UpdateCustomerCommandValidator()
    {
        RuleFor(e => e.FullName)
            .NotNull().WithMessage("CustomerId cannot be null")
            .NotEmpty().WithMessage("CustomerId cannot be empty")
            .NotEqual("Emil Filip").WithMessage("Validation is working fine");

    }
}
