using EM_EntityFrameworkCore.Entities;
using EM_EntityFrameworkCore.Models;
using EM_EntityFrameworkCore.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EM_EntityFrameworkCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        [HttpPost]
        public IActionResult Create(CustomerSchema schema)
        {
            var customerentity = new CustomerEntity();
            var customer = new Customer();
            return Ok(customer);
        }
    }
}
