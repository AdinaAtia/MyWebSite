using Entities;
using Microsoft.AspNetCore.Mvc;
using Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MyShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        IOrderServices service;
        // GET: api/<OrderController>
        [HttpGet]
      

        // GET api/<OrderController>/5
       

        // POST api/<OrderController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Order order)
        {
            order = await service.Post(order);
            if (order != null)
            {
                return Ok(order);
            }
            return NoContent();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Order>> GetById(int id)
        {
            var order = await service.GetById(id);
            if (order != null)
            {
                return Ok(order);
            }
            return NoContent();
        }
        // PUT api/<OrderController>/5


        // DELETE api/<OrderController>/5

    }
}
