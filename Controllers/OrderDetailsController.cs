using DepartmentalStore.Models;
using DepartmentalStore.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DepartmentalStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderDetailsController : ControllerBase
    {
        private readonly IDepartmentRepo repo;

        public OrderDetailsController(IDepartmentRepo _repo)
        {
            repo = _repo;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderDetail>>> GetAllOrderDetail()
        {
            try
            {
                return (await repo.GetAllOrderDetail()).ToList();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<OrderDetail>> GetOrderDetailById(int id)
        {
            try
            {
                var result = await repo.GetOrderDetailById(id);

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
        public async Task<ActionResult<OrderDetail>> AddOrderDetail(OrderDetail orderdetail)
        {
            try
            {
                if (orderdetail == null)
                    return BadRequest();

                var createdOrderDetail = await repo.AddOrderDetail(orderdetail);

                return CreatedAtAction(nameof(GetAllOrderDetail),
                    new { id = createdOrderDetail.OrderDetailID }, createdOrderDetail);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error creating new OrderDetail record");
            }
        }

        [HttpPut]
        public async Task<ActionResult<OrderDetail>> UpdateOrderDetail(int id, OrderDetail orderdetail)
        {
            try
            {
                if (id != orderdetail.OrderDetailID)
                    return BadRequest("OrderDetail ID mismatch");

                var update = await repo.UpdateOrderDetail(orderdetail);
                return Ok(update);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error updating data");
            }
        }

        [HttpDelete]
        public async Task<ActionResult<OrderDetail>> DeleteOrderDetail(int id)
        {
            try
            {
                var OrderDetailToDelete = await repo.GetOrderDetailById(id);

                if (OrderDetailToDelete == null)
                {
                    return NotFound($"OrderDetail with Id = {id} not found");
                }

                return await repo.DeleteOrderDetail(id);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error deleting data");
            }
        }
    }
}
