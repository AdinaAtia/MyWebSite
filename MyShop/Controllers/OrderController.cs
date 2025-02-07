using AutoMapper;
using DTO;
using Entities;
using Microsoft.AspNetCore.Mvc;
using Repositories;
using Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MyShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        IOrderServices service;
        IMapper _mapper;
        public OrderController(IOrderServices service, IMapper _mapper)
        {
            this.service = service;
            this._mapper = _mapper;
        }
        // GET: api/<OrderController>
        [HttpGet]
      
        // GET api/<OrderController>/5
       

        // POST api/<OrderController>
        [HttpPost]
        public async Task<ActionResult<OrderDTO>> Post([FromBody] OrderDTO order)
        {
             Order newOrder = await service.Post(_mapper.Map<OrderPostDTO, Order>(order));
            //Order neworder = _mapper.Map<OrderPostDTO, Order>(order);
            //neworder = await service.Post(neworder);
            if (newOrder != null)
            {
                return CreatedAtAction(nameof(GetById), new { id = newOrder.OrderId }, _mapper.Map<Order, OrderDTO>(newOrder));
             
             /*   return CreatedAtAction(_mapper.Map<Order, OrderDTO>(neworder))*/;
            }
            return NoContent();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<OrderDTO>> GetById(int id)
        {
            var order = await service.GetById(id);
            if (order != null)
            {
                return Ok(_mapper.Map <Order, OrderDTO>(order));
             
            }
            return NoContent();
        }

        // PUT api/<OrderController>/5


        // DELETE api/<OrderController>/5

    }
}
