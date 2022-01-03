namespace EFSoft.Customers.Application.Commands.Handlers;

public class CreateCustomerCommandHandler : ICommandHandler<CreateCustomerCommandParameters>
{
    private readonly ICustomerRepository _customerRepository;

    public CreateCustomerCommandHandler(ICustomerRepository customerRepository)
    {
        _customerRepository = customerRepository ?? throw new ArgumentNullException(nameof(customerRepository));
    }

    public async Task HandleAsync(
        CreateCustomerCommandParameters command)
    {
        var customer = CustomerModel.CreateNew(command.FullName, command.DateOfBirth);

        await _customerRepository.CreateCustomerAsync(customer);
    }
}
