﻿using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using Services;
using Entities;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860
//שרה שלום וברכה לא סימנו הפונקצית עדכון עדיין בעדכון:) והפונקצית כניסה לא עובדת לנו משום מה ישבנו על זה הרבה זמן נשמח אם תצליחי לעזור תודה רבה!!!!! יום טוב!!!
namespace MyShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        IUserServices service;

        public UsersController(IUserServices service)
        {
            this.service = service;
        }
        // GET: api/<UsersController>
        [HttpGet]
        
        // GET api/<UsersController>/5
      

        // POST api/<UsersController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] User user)
        {
             user = await service.Post(user);
            if (user != null)
            {
                return Ok(user);
            }
            return NoContent();
        }

        //[HttpPost("login")]
        [HttpPost]
        [Route("Login")]

        public async Task< ActionResult> Login([FromQuery] string email, [FromQuery] string password)
        {
            User user=await service.Login(email, password);
            if (user!=null)
            {
                return Ok(user);
            }        
            return NoContent();
        }

        // PUT api/<UsersController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<User>> Put(int id, [FromBody] User user)
        {
             user = await service.Put(id, user);
            if (user != null)
            {
                return Ok(user);
            }
            return NoContent();

        }
        // DELETE api/<UsersController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
        [HttpPost("password")]
      
        public int cheackPassword([FromBody] string password)
        {
            int result = service.cheackPassword(password);
            return result;
        }

    }
}
