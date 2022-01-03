namespace EFSoft.Customers.Infrastructure.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly CustomerDbContext _customerDbContext;

        public CustomerRepository(CustomerDbContext customerDbContext)
        {
            _customerDbContext = customerDbContext;
        }

        public async Task CreateCustomerAsync(
            CustomerModel customer,
            CancellationToken cancellationToken = default)
        {
            var entity = MapToEntity(customer);
            entity.UpdatedAt = DateTime.Now;

            _customerDbContext.Customers.Add(entity);

            await _customerDbContext
                .SaveChangesAsync(cancellationToken);
        }

        public async Task DeleteCustomerAsync(
            Guid customerId,
            CancellationToken cancellationToken = default)
        {
            var entity = await _customerDbContext.Customers.FindAsync(
            keyValues: new object[] { customerId },
            cancellationToken: cancellationToken);

            if (entity != null)
            {
                entity.Deleted = true;
                entity.DeletedAt = DateTime.Now;

                _customerDbContext.Update(entity);
                await _customerDbContext.SaveChangesAsync(cancellationToken);
            }
        }

        public async Task<CustomerModel?> GetCustomerAsync(
            Guid customerId,
            CancellationToken cancellationToken = default)
        {
            var entity = await _customerDbContext
                .Customers
                .FirstOrDefaultAsync(j => j.CustomerId == customerId && j.Deleted == false);

            if (entity == null)
            {
                return null;
            }

            return MapToDomain(entity);
        }

        public Task<IEnumerable<CustomerModel>> GetCustomersAsync(
            IEnumerable<Guid> customerIds,
            CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateCustomerAsync(
            CustomerModel customer,
            CancellationToken cancellationToken = default)
        {
            var entity = await _customerDbContext.Customers.FindAsync(
                        keyValues: new object[] { customer.CustomerId },
                        cancellationToken: cancellationToken);

            if (entity != null)
            {
                entity.UpdatedAt = DateTime.Now;
                entity.FullName = customer.FullName;
                entity.DateOfBirth = customer.DateOfBirth;

                _customerDbContext.Update(entity);
                await _customerDbContext.SaveChangesAsync(cancellationToken);
            }
        }

        private static CustomerModel MapToDomain(
            Customer entityCustomer)
        {
            return new CustomerModel(
                customerId: entityCustomer.CustomerId,
                fullName: entityCustomer.FullName,
                dateOfBirth: entityCustomer.DateOfBirth);
        }

        private static Customer MapToEntity(
            CustomerModel domainCustomer)
        {
            return new Customer
            {
                CustomerId = domainCustomer.CustomerId,
                FullName = domainCustomer.FullName,
                DateOfBirth = domainCustomer.DateOfBirth
            };
        }

    }
}
