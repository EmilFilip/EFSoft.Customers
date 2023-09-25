namespace EFSoft.Customers.Application.Commands.DeleteCustomer;

public class DeleteCustomerCommandHandler : ICommandHandler<DeleteCustomerCommand>
{
    private readonly ICustomersRepository _customerRepository;

    public DeleteCustomerCommandHandler(ICustomersRepository customerRepository)
    {
        _customerRepository = customerRepository;
    }

    public async Task Handle(
        DeleteCustomerCommand command,
        CancellationToken cancellationToken)
    {
        await _customerRepository.DeleteCustomerAsync(command.CustomerId, cancellationToken);
    }
}
