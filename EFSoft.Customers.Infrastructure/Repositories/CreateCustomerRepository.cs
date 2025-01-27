﻿namespace EFSoft.Customers.Infrastructure.Repositories;

public class CreateCustomerRepository(CustomersDbContext customerDbContext) : ICreateCustomerRepository
{
    public async Task CreateCustomerAsync(
        CustomerDomainModel customer,
        CancellationToken cancellationToken)
    {
        var entity = MapToEntity(customer);

        _ = customerDbContext.Customers.Add(entity);

        _ = await customerDbContext
            .SaveChangesAsync(cancellationToken);
    }

    private static Customer MapToEntity(
        CustomerDomainModel domainCustomer)
    {
        return new Customer
        {
            CustomerId = domainCustomer.CustomerId,
            FullName = domainCustomer.FullName,
            DateOfBirth = domainCustomer.DateOfBirth,
            HasOpenOrder = domainCustomer.HasOpenOrder,
            UpdatedAt = DateTime.UtcNow
        };
    }
}
