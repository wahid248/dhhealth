using Core.Abstruct.Repositories;
using Core.Entities;
using Data.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    class CustomerRepository : Repository<Customer, int>, ICustomerRepository
    {
        public CustomerRepository(DataContext dbContext) : base(dbContext) { }

        public async Task<Customer> GetCustomer(string customerEmail)
        {
            return await _dbSet.Where(s => s.Email == customerEmail)
                .Select(s => new Customer()
                {
                    Id = s.Id,
                    Email = s.Email
                }).FirstOrDefaultAsync();
        }
    }
}
