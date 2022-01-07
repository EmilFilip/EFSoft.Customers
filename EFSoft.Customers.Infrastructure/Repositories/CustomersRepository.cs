namespace EFSoft.Customers.Infrastructure.Repositories
{
    public class CustomersRepository : ICustomersRepository
    {
        private readonly CustomersDbContext _customersDbContext;

        public CustomersRepository(CustomersDbContext customerDbContext)
        {
            _customersDbContext = customerDbContext;
        }

        public async Task CreateCustomerAsync(
            CustomerModel customer,
            CancellationToken cancellationToken = default)
        {
            var entity = MapToEntity(customer);

            _customersDbContext.Customers.Add(entity);

            await _customersDbContext
                .SaveChangesAsync(cancellationToken);
        }

        public async Task DeleteCustomerAsync(
            Guid customerId,
            CancellationToken cancellationToken = default)
        {
            var entity = await _customersDbContext.Customers.FindAsync(
                keyValues: new object[] { customerId },
                cancellationToken: cancellationToken);

            if (entity != null)
            {
                entity.Deleted = true;
                entity.DeletedAt = DateTime.UtcNow;

                _customersDbContext.Update(entity);
                await _customersDbContext.SaveChangesAsync(cancellationToken);
            }
        }

        public async Task<CustomerModel?> GetCustomerAsync(
            Guid customerId,
            CancellationToken cancellationToken = default)
        {
            var entity = await _customersDbContext.Customers.FirstOrDefaultAsync(
                c => c.CustomerId == customerId && c.Deleted == false,
                cancellationToken: cancellationToken);

            if (entity == null)
            {
                return null;
            }

            return MapToDomain(entity);
        }

        public async Task<IEnumerable<CustomerModel>> GetCustomersAsync(
            IEnumerable<Guid> customerIds,
            CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateCustomerAsync(
            CustomerModel customer,
            CancellationToken cancellationToken = default)
        {
            var entity = await _customersDbContext.Customers.FindAsync(
                keyValues: new object[] { customer.CustomerId },
                cancellationToken: cancellationToken);

            if (entity != null)
            {
                entity.UpdatedAt = DateTime.UtcNow;
                entity.FullName = customer.FullName;
                entity.DateOfBirth = customer.DateOfBirth;

                _customersDbContext.Update(entity);
                await _customersDbContext.SaveChangesAsync(cancellationToken);
            }
        }

        private static CustomerModel MapToDomain(
            Customer entityCustomer)
        {
            return new CustomerModel(
                customerId: entityCustomer.CustomerId,
                fullName: entityCustomer.FullName,
                dateOfBirth: entityCustomer.DateOfBirth,
                hasOpenOrder: entityCustomer.HasOpenOrder);
        }

        private static Customer MapToEntity(
            CustomerModel domainCustomer)
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
}
