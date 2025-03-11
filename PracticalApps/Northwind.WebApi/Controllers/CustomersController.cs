using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Northwind.WebApi.Repositories;
using Packt.Shared;

namespace Northwind.WebApi.Controllers
{
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerRepository repo;

        //constructor injects repository registered in Startup
        public CustomersController(ICustomerRepository repo)
        {
            this.repo = repo;
        }

        //GET: api/customers
        //GET: api/customers/?country=[country]
        //this will always return a list of customers (but it might be empty)
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Customer>))]
        public async Task<IEnumerable<Customer>> GetCustomers(string? country)
        {
            if (string.IsNullOrWhiteSpace(country))
            {
                return await repo.RetrieveAllAsync();
            }
            else
            {
                return (await repo.RetrieveAllAsync()).Where(customer => customer.Country == country);
            }

        }

        //GET: api/customer/[id]
        [HttpGet("{id}", Name = nameof(GetCustomer))] //name route
        [ProducesResponseType(200, Type = typeof(Customer))]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetCustomer(string id)
        {
            Customer? c = await repo.RetrieveAsync(id);
            if (c == null)
            {
                return NotFound(); // 404 Resources not found                
            }
            return Ok(c); //200 OK with customer in body
        }

        // POST: api/customers
        //BODY: Customer (JSON, XML)
        [HttpPost]
        [ProducesResponseType(201, Type = typeof(Customer))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> Create([FromBody] Customer c)
        {
            if (c == null)
            {
                return BadRequest(); //400 bad request
            }
            Customer? addedCustomer = await repo.CreateAsync(c);
            
            if (addedCustomer == null)
            {
                return BadRequest("Repository failed to create customer");
            }else
            {
                return CreatedAtRoute( //201 Created
                    routeName: nameof(GetCustomer),
                    routeValues: new { id = addedCustomer.CustomerId.ToLower() },
                    value: addedCustomer);
            }
        }

    }
}