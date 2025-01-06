namespace EFSoft.Customers.Api.UpdateCustomer;

public class UpdateCustomerRequestValidator : AbstractValidator<UpdateCustomerRequest>
{
    public UpdateCustomerRequestValidator()
    {
        _ = RuleFor(e => e.CustomerId)
            .NotNull().WithMessage("CustomerId cannot be null")
            .NotEmpty().WithMessage("CustomerId cannot be empty");

        _ = RuleFor(e => e.FullName)
            .NotNull().WithMessage("FullName cannot be null")
            .NotEmpty().WithMessage("FullName cannot be empty");

        _ = RuleFor(e => e.DateOfBirth)
            .Must(date => date != default(DateTime)).WithMessage("Please specify DateOfBirth")
            .LessThan(p => DateTime.Now).WithMessage("DateOfBirth must be in the past");
    }
}
