namespace EFSoft.Customers.Application.CreateCustomer;

public class CreateCustomerCommandHandler(ICreateCustomerRepository createCustomerRepository)
    : ICommandHandler<CreateCustomerCommand>
{
    public async Task Handle(
        CreateCustomerCommand command,
        CancellationToken cancellationToken)
    {
        var customer = CustomerDomainModel.CreateNew(
            fullName: command.FullName,
            dateOfBirth: command.DateOfBirth);

        await createCustomerRepository.CreateCustomerAsync(customer, cancellationToken);
    }
}
