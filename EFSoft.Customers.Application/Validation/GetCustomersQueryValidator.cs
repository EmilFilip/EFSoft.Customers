using EFSoft.Customers.Application.Queries.GetCustomers;

using FluentValidation;

namespace EFSoft.Customers.Application.Validation;

public class GetCustomersQueryValidator : AbstractValidator<GetCustomersQuery>
{
    public GetCustomersQueryValidator()
    {
        RuleFor(e => e.CustomerIds)
            .Must(collection => collection == null || collection.All(item => item.Equals("AE62C366-F454-46C9-BCEC-04F7993B6123")))
            .WithMessage("Please fill all items");

    }
}
