namespace EFSoft.Customers.Api.GetCustomers;

public class GetCustomersRequestValidator : AbstractValidator<GetCustomersRequest>
{
    public GetCustomersRequestValidator()
    {
        _ = RuleFor(e => e.CustomerIds)
            .Must(collection => collection?.Count() == 0)
            .WithMessage("CustomerIds cannot be null")
            .Must(collection => collection == null)
            .WithMessage("Please specify at least one CustomerId");
    }
}
