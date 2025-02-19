using Data.Contexts;
using Data.Entities;
using Data.Interfaces;

namespace Data.Repositories;

public class CustomerContactRepoitory(DataContext context) : BaseRepository<CustomerContactEntity>(context), ICustomerContactRepoitory
{ }
