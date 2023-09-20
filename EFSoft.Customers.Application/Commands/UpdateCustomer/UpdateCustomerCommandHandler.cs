namespace EFSoft.Customers.Application.Commands.UpdateCustomer;

public class UpdateCustomerCommandHandler : ICommandHandler<UpdateCustomerCommand>
{
    private readonly ICustomersRepository _customerRepository;

    public UpdateCustomerCommandHandler(ICustomersRepository customerRepository)
    {
        _customerRepository = customerRepository ?? throw new ArgumentNullException(nameof(customerRepository));
    }

    public async Task Handle(
        UpdateCustomerCommand command,
        CancellationToken cancellationToken)
    {
        var customerModel = new CustomerModel(
            customerId: command.CustomerId,
            fullName: command.FullName,
            dateOfBirth: command.DateOfBirth);

        await _customerRepository.UpdateCustomerAsync(customerModel);
    }
}
