namespace EFSoft.Customers.Application.Queries.GetCustomers;

public class GetCustomersQueryValidator : AbstractValidator<GetCustomersQuery>
{
    public GetCustomersQueryValidator()
    {
        RuleFor(e => e.CustomerIds)
            .Must(collection => collection == null || collection.All(item => !string.IsNullOrEmpty(item.ToString())))
            .WithMessage("Please specify at least one CustomerId");
    }
}
