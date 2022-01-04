namespace EFSoft.Customers.Application.Commands.Handlers;

public class UpdateCustomerCommandHandler : ICommandHandler<UpdateCustomerCommandParameters>
{
    private readonly ICustomersRepository _customerRepository;

    public UpdateCustomerCommandHandler(ICustomersRepository customerRepository)
    {
        _customerRepository = customerRepository ?? throw new ArgumentNullException(nameof(customerRepository));
    }

    public async Task HandleAsync(UpdateCustomerCommandParameters command)
    {
        var customerModel = new CustomerModel(
            customerId: command.CustomerId,
            fullName: command.FullName,
            dateOfBirth: command.DateOfBirth);

        await _customerRepository.UpdateCustomerAsync(customerModel);
    }
}
