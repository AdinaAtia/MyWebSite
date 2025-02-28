using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class OrderRepositories: IOrderRepositories
    {

        CatagoryContext Manger_DB_context;
        public OrderRepositories(CatagoryContext Manger_DB_context)
        {
            this.Manger_DB_context = Manger_DB_context;
        }
        public async Task<Order> Post(Order neworder)
        {
            neworder.OrderDate = DateTime.Now;
            Manger_DB_context.Orders.AddAsync(neworder);
            await Manger_DB_context.SaveChangesAsync();
            Order order = await Manger_DB_context.Orders.Include(currentOrder => currentOrder.User).FirstOrDefaultAsync(currentOrder => currentOrder.OrderId == neworder.OrderId);
            return order;
        }
        public async Task<Order> GetById(int id)
        {
            Order order = await Manger_DB_context.Orders.FirstOrDefaultAsync(currentOrder => currentOrder.OrderId == id);
            return order;
        }

    }
}
