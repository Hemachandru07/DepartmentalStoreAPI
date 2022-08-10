using DepartmentalStore.Models;
using DepartmentalStore.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DepartmentalStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BeveragesController : ControllerBase
    {
        private readonly IDepartmentRepo repo;

        public BeveragesController(IDepartmentRepo _repo)
        {
            repo = _repo;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Beverages>>> GetAllBeverages()
        {
            try
            {
                return (await repo.GetAllBeverages()).ToList();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Beverages>> GetBeveragesById(int id)
        {
            try
            {
                var result = await repo.GetBeveragesById(id);

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
        public async Task<ActionResult<Beverages>> AddBeverages(Beverages beverages)
        {
            try
            {
                if (beverages == null)
                    return BadRequest();

                var createdBeverages = await repo.AddBeverages(beverages);

                return CreatedAtAction(nameof(GetAllBeverages),
                    new { id = createdBeverages.BeverageId }, createdBeverages);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error creating new Beverage record");
            }
        }

        [HttpPut]
        public async Task<ActionResult<Beverages>> UpdateBeverages(int id, Beverages beverages)
        {
            try
            {
                if (id != beverages.BeverageId)
                    return BadRequest("Beverage ID mismatch");

                var update = await repo.UpdateBeverages(beverages);
                return Ok(update);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error updating data");
            }
        }

        [HttpDelete]
        public async Task<ActionResult<Beverages>> DeleteBeverages(int id)
        {
            try
            {
                var BeverageToDelete = await repo.GetBeveragesById(id);

                if (BeverageToDelete == null)
                {
                    return NotFound($"Beverage with Id = {id} not found");
                }

                return await repo.DeleteBeverages(id);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error deleting data");
            }
        }
    }
}
