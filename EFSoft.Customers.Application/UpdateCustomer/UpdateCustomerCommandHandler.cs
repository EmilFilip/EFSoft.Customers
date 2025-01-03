namespace EFSoft.Customers.Application.UpdateCustomer;

public class UpdateCustomerCommandHandler : ICommandHandler<UpdateCustomerCommand>
{
    private readonly IUpdateCustomerRepository _updateCustomerRepository;

    public UpdateCustomerCommandHandler(IUpdateCustomerRepository updateCustomerRepository)
    {
        _updateCustomerRepository = updateCustomerRepository;
    }

    public async Task Handle(
        UpdateCustomerCommand command,
        CancellationToken cancellationToken)
    {
        var customerModel = new CustomerModel(
            customerId: command.CustomerId,
            fullName: command.FullName,
            dateOfBirth: command.DateOfBirth);

        await _updateCustomerRepository.UpdateCustomerAsync(customerModel, cancellationToken);
    }
}
