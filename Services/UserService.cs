using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Entities;
using Repositories;
using Zxcvbn;
namespace Services
{
    public class UserService: IUserServices
    {
        IUserRepository repository;

        public UserService(IUserRepository repository)
        {
                this.repository = repository;
        }
        public async Task<User> Login(string email, string password)
        {
            return await repository.Login(email, password);
        }

        public async Task<User> Post(User user)
        {
            return await repository.Post(user);
        }
        public async Task<User> Put(int id,  User user)

        {
            return await repository.Put(id,user);

        }
        public int cheackPassword(string password)
        {
            var result = Zxcvbn.Core.EvaluatePassword(password);
            return result.Score;
        }

    }
}
