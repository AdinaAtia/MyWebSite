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
        public ProductController(IProductsServices service)
        {
            this.service = service;
        }
        // GET: api/<Product>
        [HttpGet]
        public async Task<ActionResult<List<Product>>> Get()
        {
             List<Product> product = await service.Get();
            if (product != null)
            {
                return Ok(product);
            }
            return NoContent();
        }
            // GET api/<Product>/5
        
        // POST api/<Product>
       

        // PUT api/<Product>/5
       
        // DELETE api/<Product>/5
       
    }
}
