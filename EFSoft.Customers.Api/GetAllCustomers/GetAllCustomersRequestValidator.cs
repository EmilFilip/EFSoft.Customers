namespace EFSoft.Customers.Api.GetAllCustomers;

public class GetAllCustomersRequestValidator : AbstractValidator<GetAllCustomersRequest>
{
    public GetAllCustomersRequestValidator()
    {
        _ = RuleFor(e => e.Page)
            .Must(p => p > 0)
            .WithMessage("Please specify the page number");

        _ = RuleFor(e => e.PageSize)
            .Must(p => p > 0)
            .WithMessage("Please specify the page size");
    }
}
