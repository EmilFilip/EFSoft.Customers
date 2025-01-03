namespace EFSoft.Customers.Application.Commands.DeleteCustomer;

public class DeleteCustomerRequestValidator : AbstractValidator<DeleteCustomerRequest>
{
    public DeleteCustomerRequestValidator()
    {
        RuleFor(e => e.CustomerId)
            .NotNull().WithMessage("CustomerId cannot be null")
            .NotEmpty().WithMessage("CustomerId cannot be empty");
    }
}
