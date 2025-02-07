using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using Services;
using Entities;
using AutoMapper;
using DTO;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860
//שרה שלום וברכה לא סימנו הפונקצית עדכון עדיין בעדכון:) והפונקצית כניסה לא עובדת לנו משום מה ישבנו על זה הרבה זמן נשמח אם תצליחי לעזור תודה רבה!!!!! יום טוב!!!
namespace MyShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        IUserServices service;
        IMapper _mapper;
        public UsersController(IUserServices service, IMapper _mapper)
        {
            this.service = service;
            this._mapper = _mapper;

        }
        // GET: api/<UsersController>
        [HttpGet]

        // GET api/<UsersController>/5
        //UsertDto

        // POST api/<UsersController>
        [HttpPost]


        //public record AddUserDTO(string Password, string Email, string? LastName, string? FirstName);
        //public record ReturnPostUserDTO(string Email, string? LastName, string? FirstName);

        //public record LoginUserDTO(string Password, string Email);

        //public record ReturnLoginUserDTO


        public async Task<ActionResult<ReturnPostUserDTO>> Post([FromBody] UserDTO user)
        {
            //int res = service.cheackPassword(user.Password);
            //if (res < 3)
            //          {
            //               return (BadRequest(user));
            //            }
            User newUser = _mapper.Map<UserDTO, User>(user);
             newUser = await service.Post(newUser);
            if (newUser != null)
            {
                return Ok(_mapper.Map<User, ReturnPostUserDTO>(newUser));
            }
            return NoContent();
        }
        [HttpPost]
        [Route("Login")]
        //User user = await userServices.GetUserById(id);
        //UserDTO userDTO = mapper.Map<User, UserDTO>(user);
        //    return userDTO;
        public async Task< ActionResult<ReturnLoginUserDTO>> Login([FromQuery] string email, [FromQuery] string password)
        {
            User user=await service.Login(email, password);
            if (user!=null)
            {
                return Ok(_mapper.Map<User, ReturnLoginUserDTO>(user));
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
