namespace EFSoft.Customers.Application.Commands.Parameters;

public class DeleteCustomerCommandParameters : ICommand
{
    public DeleteCustomerCommandParameters(
         Guid customerId)
    {
        CustomerId = customerId;
    }

    public Guid CustomerId { get; }
}

