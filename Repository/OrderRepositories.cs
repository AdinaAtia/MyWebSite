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
        public async Task<Order> Post(Order order)
        {
            await Manger_DB_context.Orders.AddAsync(order);
            await Manger_DB_context.SaveChangesAsync();
            return order;
        }
        public async Task<Order> GetById(int id)
        {
            return await Manger_DB_context.Orders.FirstOrDefaultAsync(currentOrder => currentOrder.OrderId == id);
            //Order order = await Manger_DB_context.Orders.FirstOrDefaultAsync(currentOrder => currentOrder.OrderId == id);
            //return order;
        }

    }
}
