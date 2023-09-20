namespace EFSoft.Customers.Application.Commands.CreateCustomer;

public class CreateCustomerCommandHandler : ICommandHandler<CreateCustomerCommand>
{
    private readonly ICustomersRepository _customerRepository;

    public CreateCustomerCommandHandler(ICustomersRepository customerRepository)
    {
        _customerRepository = customerRepository ?? throw new ArgumentNullException(nameof(customerRepository));
    }

    public async Task Handle(
        CreateCustomerCommand command
        , CancellationToken cancellationToken)
    {
        var customer = CustomerModel.CreateNew(
            fullName: command.FullName,
            dateOfBirth: command.DateOfBirth);

        await _customerRepository.CreateCustomerAsync(customer);
    }
}
