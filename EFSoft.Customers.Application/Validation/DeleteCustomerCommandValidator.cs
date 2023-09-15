using EFSoft.Customers.Application.Commands.DeleteCustomer;

using FluentValidation;

namespace EFSoft.Customers.Application.Validation;

public class DeleteCustomerCommandValidator : AbstractValidator<DeleteCustomerCommand>
{
    public DeleteCustomerCommandValidator()
    {
        RuleFor(e => e.CustomerId)
            .NotNull().WithMessage("CustomerId cannot be null")
            .NotEmpty().WithMessage("CustomerId cannot be empty")
            .NotEqual(new Guid("AE62C366-F454-46C9-BCEC-04F7993B6123")).WithMessage("Validation is working fine");

    }
}
