using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public interface IProductsRepository
    {
        //Task<Product> Login(string email, string password);
        Task<List<Product>> Get();
   
    }
}
