using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Packt.Shared;

namespace Packt.Shared
{
    public interface INorthwindService
    {
        Task<List<Customer>> GetCustomersAsync();
        Task<List<Customer>> GetCustomersAsync(string country);
        Task<Customer?> GetCustomerAsync(string id);
        Task<Customer> CreateCustomerAsync(Customer customer);
        Task<Customer> UpdateCustomerAsync(Customer customer);
        Task DeleteCustomerAsync(string id);
    }

}