namespace EFSoft.Customers.Application.CreateCustomer;

public class CreateCustomerCommandHandler : ICommandHandler<CreateCustomerCommand>
{
    private readonly ICreateCustomerRepository _createCustomerRepository;

    public CreateCustomerCommandHandler(ICreateCustomerRepository createCustomerRepository)
    {
        _createCustomerRepository = createCustomerRepository;
    }

    public async Task Handle(
        CreateCustomerCommand command,
        CancellationToken cancellationToken)
    {
        var customer = CustomerModel.CreateNew(
            fullName: command.FullName,
            dateOfBirth: command.DateOfBirth);

        await _createCustomerRepository.CreateCustomerAsync(customer, cancellationToken);
    }
}
