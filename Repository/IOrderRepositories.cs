using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public  interface IOrderRepositories
    {
        Task<Order> Post(Order order);
        Task<Order> GetById(int id);
    }
}
