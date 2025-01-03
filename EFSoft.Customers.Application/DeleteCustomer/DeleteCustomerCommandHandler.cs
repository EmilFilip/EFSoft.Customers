namespace EFSoft.Customers.Application.Commands.DeleteCustomer;

public class DeleteCustomerCommandHandler : ICommandHandler<DeleteCustomerCommand>
{
    private readonly IDeleteCustomerRepository _deleteCustomerRepository;

    public DeleteCustomerCommandHandler(IDeleteCustomerRepository deleteCustomerRepository)
    {
        _deleteCustomerRepository = deleteCustomerRepository;
    }

    public async Task Handle(
        DeleteCustomerCommand command,
        CancellationToken cancellationToken)
    {
        await _deleteCustomerRepository.DeleteCustomerAsync(command.CustomerId, cancellationToken);
    }
}
