using Entities;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class OrderServices: IOrderServices
    {
        IOrderRepositories repository;
        IProductsRepository _productsRepository;
        public OrderServices(IOrderRepositories repository, IProductsRepository productsRepository)
        {
            this.repository = repository;
            _productsRepository = productsRepository;
        }

     
        public async Task<Order> Post(Order order)
        {

            return await repository.Post(order);
        }
        public async Task<Order> GetById(int id)
        {
            return await repository.GetById(id);
        }
        private async Task<bool> CheckSum(Order order)
        //int? minPrice, int? maxPrice, int?[] categoryIds, string? desc)
        {
            List<Product> products = await _productsRepository.Get(null, 0, 0, null);

            decimal amount = 0;
            foreach (var item in order.OrderItems)
            {
                //    var product = products.Find(p => p.ProductId == item.ProductId);
                //    amount += products.Find(product => product.ProductId == item.ProductId).Price;
                var product = products.Find(p => p.ProductsId == item.ProductId);
                if (product != null) // <--- שורה מתוקנת
                {
                    amount += product.Price;
                }
                //else
                //{
                //    throw new InvalidOperationException($"Product with ID {item.ProductId} not found in the product list"); // <--- שורה מתוקנת
                //}
            }

            return amount == order.OrderSum;


        }
    }
}
