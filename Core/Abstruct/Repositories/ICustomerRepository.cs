using Core.Abstruct.Base;
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.Abstruct.Repositories
{
    public interface ICustomerRepository : IRepository<Customer, int>
    {
        Task<Customer> GetCustomer(string customerEmail);
    }
}
