using Data.Contexts;
using Data.Entities;
using Data.Interfaces;

namespace Data.Repositories;

public class CustomerTypeRepository(DataContext context) : BaseRepository<CustomerTypeEntity>(context), ICustomerTypeRepository
{ }
