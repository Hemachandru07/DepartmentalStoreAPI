using DepartmentalStore.Models;
using DepartmentalStore.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace DepartmentalStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly IDepartmentRepo repo;
       

        public CustomerController(IDepartmentRepo _repo)
        {
            repo = _repo;
           
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Customer>>> GetAllCustomer()
        {
            try
            {
                return (await repo.GetAllCustomer()).ToList();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Customer>> GetCustomerById(int id)
        {
            try
            {
                var result = await repo.GetCustomerById(id);

                if (result == null) return NotFound();

                return result;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }

        [HttpPost]
        public async Task<ActionResult<Customer>> AddCustomer(Customer customer)
        {
            try
            {
                if (customer == null)
                    return BadRequest();

                var createdCustomer = await repo.AddCustomer(customer);

                return CreatedAtAction(nameof(GetAllCustomer),
                    new { id = createdCustomer.CustomerId }, createdCustomer);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error creating new Customer record");
            }
        }

        [HttpPut]
        public async Task<ActionResult<Customer>> UpdateCustomer(int id, Customer customer)
        {
            try
            {
                if (id != customer.CustomerId)
                    return BadRequest("Customer ID mismatch");

                var update = await repo.UpdateCustomer(customer);
                return Ok(update);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error updating data");
            }
        }

        [HttpDelete]
        public async Task<ActionResult<Customer>> DeleteCustomer(int id)
        {
            try
            {
                var CustomerToDelete = await repo.GetCustomerById(id);

                if (CustomerToDelete == null)
                {
                    return NotFound($"Customer with Id = {id} not found");
                }

                return await repo.DeleteCustomer(id);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error deleting data");
            }
        }

        [Route("login")]
        [HttpPost]
        public async Task<ActionResult<Customer>> Login([FromBody] Customer customer)
        {
            var login = await repo.Login(customer);
            if (string.IsNullOrEmpty(login))
            {
                return Unauthorized();
            }

            return Ok(login);
        }

        
    }
}
