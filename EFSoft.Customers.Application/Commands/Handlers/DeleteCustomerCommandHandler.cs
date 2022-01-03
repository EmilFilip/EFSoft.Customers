namespace EFSoft.Customers.Application.Commands.Handlers;

public class DeleteCustomerCommandHandler : ICommandHandler<DeleteCustomerCommandParameters>
{
    private readonly ICustomerRepository _customerRepository;

    public DeleteCustomerCommandHandler(ICustomerRepository customerRepository)
    {
        _customerRepository = customerRepository ?? throw new ArgumentNullException(nameof(customerRepository));
    }

    public async Task HandleAsync(DeleteCustomerCommandParameters command)
    {
        await _customerRepository.DeleteCustomerAsync(command.CustomerId);
    }
}
