using DepartmentalStore.Models;
using DepartmentalStore.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DepartmentalStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FruitsController : ControllerBase
    {
        private readonly IDepartmentRepo repo;

        public FruitsController(IDepartmentRepo _repo)
        {
            repo = _repo;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Fruits>>> GetAllFruits()
        {
            try
            {
                return (await repo.GetAllFruits()).ToList();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Fruits>> GetFruitsById(int id)
        {
            try
            {
                var result = await repo.GetFruitsById(id);

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
        public async Task<ActionResult<Fruits>> AddFruits(Fruits fruits)
        {
            try
            {
                if (fruits == null)
                    return BadRequest();

                var createdFruits = await repo.AddFruits(fruits);

                return CreatedAtAction(nameof(GetAllFruits),
                    new { id = createdFruits.FruitId }, createdFruits);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error creating new employee record");
            }
        }

        [HttpPut]
        public async Task<ActionResult<Fruits>> UpdateFruits(int id, Fruits fruits)
        {
            try
            {
                if (id != fruits.FruitId)
                    return BadRequest("Employee ID mismatch");

               var update = await repo.UpdateFruits(fruits);
               return Ok(update);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error updating data");
            }
        }

        [HttpDelete]
        public async Task<ActionResult<Fruits>> DeleteFruits(int id)
        {
            try
            {
                var fruitToDelete = await repo.GetFruitsById(id);

                if (fruitToDelete == null)
                {
                    return NotFound($"Fruit with Id = {id} not found");
                }

                return await repo.DeleteFruits(id);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error deleting data");
            }
        }
    }
}
