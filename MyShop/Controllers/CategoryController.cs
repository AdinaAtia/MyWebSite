using Entities;
using Microsoft.AspNetCore.Mvc;
using Services;
using System.Collections.Generic;
using AutoMapper;
using System.Collections;
using DTO;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MyShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        ICategoryServices service;
        IMapper _mapper;
        public CategoryController(ICategoryServices service, IMapper _mapper)
        {
            this.service = service;
            this._mapper = _mapper;
        }
        // GET: api/<CategoryController>
        [HttpGet]
        public async Task<ActionResult<List<getCategoryDto>>> Get()
        {
            //List<Category>
             List<Category> category = await service.Get();
            if (category != null)
            {
                return Ok(_mapper.Map<List< Category>, List<getCategoryDto>>(category));
            }
            return NoContent();
        }

        // GET api/<CategoryController>/5
        //[HttpGet("{id}")]
        //public async Task<ActionResult<Category>> GetById(int id)
        //{
        //    var category = await service.GetById(id);
        //    if (category != null)
        //    {
        //        return Ok(category);
        //    }
        //    return NoContent();
        //}

        // POST api/<CategoryController>
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        //// PUT api/<CategoryController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/<CategoryController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}

    } }
