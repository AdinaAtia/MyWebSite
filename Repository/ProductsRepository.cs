
using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Repositories
{
    public class ProductsRepository: IProductsRepository
    {
        CatagoryContext Manger_DB_context;
        public ProductsRepository(CatagoryContext Manger_DB_context)
        {
            this.Manger_DB_context = Manger_DB_context;
        }
    public async Task<List<Product>> Get()
    {
            List<Product> products = await Manger_DB_context.Products.ToListAsync();
            return products;
        }
    
}
}
