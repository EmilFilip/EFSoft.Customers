namespace EFSoft.Customers.Application.Commands.DeleteCustomer;

public class DeleteCustomerCommandHandler : IRequestHandler<DeleteCustomerCommand>
{
    private readonly ICustomersRepository _customerRepository;

    public DeleteCustomerCommandHandler(ICustomersRepository customerRepository)
    {
        _customerRepository = customerRepository ?? throw new ArgumentNullException(nameof(customerRepository));
    }

    public async Task Handle(
        DeleteCustomerCommand command,
        CancellationToken cancellationToken)
    {
        await _customerRepository.DeleteCustomerAsync(command.CustomerId);
    }
}
