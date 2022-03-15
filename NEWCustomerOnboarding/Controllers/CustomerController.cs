using CustomerOnboarding.Domain.Model;
using CustomerOnboarding.Helpers;
using CustomerOnboarding.Services.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NEWCustomerOnboarding.Controllers
{

    [Route("api/[controller")]
    [ApiController]

    public class CustomerController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly CustomerService _customerService;
        private readonly AppDbContext _context;
        private readonly Audit _audit;

        public CustomerController(IConfiguration configuration, CustomerService customerService, AppDbContext context, Audit audit)
        {
            _configuration = configuration;
            _customerService = customerService;
            _context = context;
            _audit = audit;
        }

        [HttpGet]
        [Route("list-all-Customers")]
        [Produces("application/json", "application/xml", Type = typeof(Response<List<Customer>>))]

        public async Task<IEnumerable<Customer>> GetAllCustomers()
        {
            try
            {


                var allCustomers = await _context.Customers.ToListAsync();
                return allCustomers;
            }
            catch (Exception ex)
            {
                _audit.LogFatal(ex);
                throw ex;
            }
        }
    }
}
