using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public record UserDTO(string Password, string Email, string? LastName, string? FirstName);
    public record ReturnPostUserDTO(string Email, string? LastName, string? FirstName, int UserId);

    //public record LoginUserDTO(string Password, string Email);
    public record ReturnLoginUserDTO(string Email, string? LastName, string? FirstName, int UserId);
}

//public record AddUserDTO(string Password, string Email, string? LastName, string? FirstName);
//public record ReturnPostUserDTO(string Email, string? LastName, string? FirstName, int UserId);

////public record LoginUserDTO(string Password, string Email);

//public record ReturnLoginUserDTO(string Email, string? LastName, string? FirstName);