using DepartmentalStore.Models;
using DepartmentalStore.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DepartmentalStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroceriesController : ControllerBase
    {
        private readonly IDepartmentRepo repo;

        public GroceriesController(IDepartmentRepo _repo)
        {
            repo = _repo;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Groceries>>> GetAllGroceries()
        {
            try
            {
                return (await repo.GetAllGroceries()).ToList();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Groceries>> GetGroceriesById(int id)
        {
            try
            {
                var result = await repo.GetGroceriesById(id);

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
        public async Task<ActionResult<Groceries>> AddGroceries(Groceries groceries)
        {
            try
            {
                if (groceries == null)
                    return BadRequest();

                var createdGroceries = await repo.AddGroceries(groceries);

                return CreatedAtAction(nameof(GetAllGroceries),
                    new { id = createdGroceries.GroceryId }, createdGroceries);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error creating new employee record");
            }
        }

        [HttpPut]
        public async Task<ActionResult<Groceries>> UpdateGroceries(int id, Groceries groceries)
        {
            try
            {
                if (id != groceries.GroceryId)
                    return BadRequest("Employee ID mismatch");

                var update = await repo.UpdateGroceries(groceries);
                return Ok(update);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error updating data");
            }
        }

        [HttpDelete]
        public async Task<ActionResult<Groceries>> DeleteGroceries(int id)
        {
            try
            {
                var GroceryToDelete = await repo.GetGroceriesById(id);

                if (GroceryToDelete == null)
                {
                    return NotFound($"Grocery with Id = {id} not found");
                }

                return await repo.DeleteGroceries(id);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error deleting data");
            }
        }
    }
}
