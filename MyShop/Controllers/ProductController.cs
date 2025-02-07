using AutoMapper;
using DTO;
using Entities;
using Microsoft.AspNetCore.Mvc;
using Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MyShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        IProductsServices service;
        IMapper _mapper;
        public ProductController(IProductsServices service, IMapper _mapper)
        {
            this.service = service;
            this._mapper = _mapper;
        }
        // GET: api/<Product>
        [HttpGet]
        public async Task<ActionResult<List<ProductDto>>> Get([FromQuery]string? desc, [FromQuery] int? minPrice, [FromQuery] int? maxPrice, [FromQuery] int?[] categoryId)
        {
             List<Product> product = await service.Get(  desc,   minPrice,   maxPrice, categoryId);
            if (product != null)
            {
                return Ok(_mapper.Map<List<Product>, List<ProductDto>>(product));
            }
            return NoContent();
        }
            // GET api/<Product>/5
        
        // POST api/<Product>

        // PUT api/<Product>/5
       
        // DELETE api/<Product>/5
       
    }
}
