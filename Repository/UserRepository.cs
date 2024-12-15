using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Entities;
using Microsoft.EntityFrameworkCore;
//using MyShop.Models;


namespace Repositories
{
    public class UserRepository : IUserRepository
    {
        
        CatagoryContext Manger_DB_context;
        public UserRepository(CatagoryContext Manger_DB_context)
        {
            this.Manger_DB_context = Manger_DB_context;
        }
        //const string filePath = "M:\\New folder\\MyShop\\MyShop\\user.txt";        
        public async Task<User> Login(string email, string password)
        {

            User userFind = await Manger_DB_context.Users.FirstOrDefaultAsync(user => user.Email == email && user.Password == password);
            //if(userFind.Email== email && userFind.Password == password)
            // {
            return userFind;
            //}
            //return null;


        }
        public async Task<User> Post(User user)
        {
            await Manger_DB_context.Users.AddAsync(user);
            await Manger_DB_context.SaveChangesAsync();
            return user;
        }

        public async Task<User> Put(int id, User user)

        {
            user.UserId = id;
            Manger_DB_context.Users.Update(user);
            await Manger_DB_context.SaveChangesAsync();
            return user;


        }
    }
}