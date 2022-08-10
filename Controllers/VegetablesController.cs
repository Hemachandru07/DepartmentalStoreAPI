using DepartmentalStore.Models;
using DepartmentalStore.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DepartmentalStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VegetablesController : ControllerBase
    {
        private readonly IDepartmentRepo repo;

        public VegetablesController(IDepartmentRepo _repo)
        {
            repo = _repo;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Vegetables>>> GetAllVegetables()
        {
            try
            {
                return (await repo.GetAllVegetables()).ToList();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Vegetables>> GetVegetablesById(int id)
        {
            try
            {
                var result = await repo.GetVegetablesById(id);

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
        public async Task<ActionResult<Vegetables>> AddVegetables(Vegetables vegetables)
        {
            try
            {
                if (vegetables == null)
                    return BadRequest();

                var createdVegetables = await repo.AddVegetables(vegetables);

                return CreatedAtAction(nameof(GetAllVegetables),
                    new { id = createdVegetables.VegetableId }, createdVegetables);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error creating new Vegetable record");
            }
        }

        [HttpPut]
        public async Task<ActionResult<Vegetables>> UpdateVegetables(int id, Vegetables vegetables)
        {
            try
            {
                if (id != vegetables.VegetableId)
                    return BadRequest("Vegetable ID mismatch");

                var update = await repo.UpdateVegetables(vegetables);
                return Ok(update);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error updating data");
            }
        }

        [HttpDelete]
        public async Task<ActionResult<Vegetables>> DeleteVegetables(int id)
        {
            try
            {
                var VegetableToDelete = await repo.GetVegetablesById(id);

                if (VegetableToDelete == null)
                {
                    return NotFound($"Vegetable with Id = {id} not found");
                }

                return await repo.DeleteVegetables(id);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error deleting data");
            }
        }
    }
}
