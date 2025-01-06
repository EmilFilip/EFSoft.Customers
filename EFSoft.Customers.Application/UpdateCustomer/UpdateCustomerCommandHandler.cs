namespace EFSoft.Customers.Application.UpdateCustomer;

public class UpdateCustomerCommandHandler(IUpdateCustomerRepository updateCustomerRepository)
    : ICommandHandler<UpdateCustomerCommand>
{
    public async Task Handle(
        UpdateCustomerCommand command,
        CancellationToken cancellationToken)
    {
        var customerModel = new CustomerDomainModel(
            customerId: command.CustomerId,
            fullName: command.FullName,
            dateOfBirth: command.DateOfBirth);

        await updateCustomerRepository.UpdateCustomerAsync(customerModel, cancellationToken);
    }
}
