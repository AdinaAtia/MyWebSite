using Entities;
using Microsoft.AspNetCore.Mvc;
using Services;
using System.Collections.Generic;
using AutoMapper;
using System.Collections;
using DTO;
using Microsoft.Extensions.Caching.Memory;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MyShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        ICategoryServices service;
        IMapper _mapper;
        IMemoryCache _memoryCache;
        public CategoryController(ICategoryServices service, IMapper _mapper, IMemoryCache memoryCache)
        {
            this.service = service;
            this._mapper = _mapper;
            this._memoryCache = memoryCache;
        }
        // GET: api/<CategoryController>
        [HttpGet]
        public async Task<ActionResult<List<getCategoryDto>>> Get()
        {
            //List<Category>
            if (!_memoryCache.TryGetValue("categories", out List<Category> category))
            {
                category = await service.Get();
                _memoryCache.Set("categories", category, TimeSpan.FromMinutes(30));
            }
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
