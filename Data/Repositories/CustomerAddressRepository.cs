using Data.Contexts;
using Data.Entities;
using Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Data.Repositories;


public class CustomerAddressRepository(DataContext context) : BaseRepository<CustomerAddressEntity>(context), ICustomerAddressRepository
{
}
