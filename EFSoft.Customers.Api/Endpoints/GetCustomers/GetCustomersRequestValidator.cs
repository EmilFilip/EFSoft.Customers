namespace EFSoft.Customers.Application.GetCustomers;

public class GetCustomersRequestValidator : AbstractValidator<GetCustomersRequest>
{
    public GetCustomersRequestValidator()
    {
        RuleFor(e => e.CustomerIds)
            .Must(collection => collection == null || collection.All(item => !string.IsNullOrEmpty(item.ToString())))
            .WithMessage("Please specify at least one CustomerId");
    }
}
